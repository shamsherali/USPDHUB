using System;
using System.IO;
using System.Text;
using System.Collections;

namespace USPDHUBBLL
{
    public class CSVReader
    {
        private Stream objStream;
        private StreamReader objReader;
        public CSVReader(Stream filestream) : this(filestream, null) { }
        public CSVReader(Stream filestream, Encoding enc)
        {
            this.objStream = filestream;
            //check the Pass Stream whether it is readable or not 
            if (!filestream.CanRead)
            {
                return;
            }
            objReader = (enc != null) ? new StreamReader(filestream, enc) : new StreamReader(filestream);
        }
        public string[] GetCsvLine()
        {
            string data = objReader.ReadLine();
            if (data == null) return null;
            if (data.Length == 0) return new string[0];
            //System.Collection.Generic 
            ArrayList result = new ArrayList();
            //parsing CSV Data 
            ParseCsvData(result, data);
            return (string[])result.ToArray(typeof(string));
        }
        private void ParseCsvData(ArrayList result, string data)
        {
            int position = -1;
            while (position < data.Length)
                result.Add(ParseCsvField(ref data, ref position));
        }
        private string ParseCsvField(ref string data, ref int startSeperatorPos)
        {
            if (startSeperatorPos == data.Length - 1)
            {
                startSeperatorPos++;
                return "";
            }
            int fromPos = startSeperatorPos + 1;
            if (data[fromPos] == '"')
            {
                int nextSingleQuote = GetSingleQuote(data, fromPos + 1);
                int lines = 1;
                while (nextSingleQuote == -1)
                {
                    data = data + "\n" + objReader.ReadLine();
                    nextSingleQuote = GetSingleQuote(data, fromPos + 1);
                    lines++;
                    if (lines > 20)
                        throw new Exception("lines overflow: " + data);
                }
                startSeperatorPos = nextSingleQuote + 1;
                string tempString = data.Substring(fromPos + 1, nextSingleQuote - fromPos - 1);
                tempString = tempString.Replace("'", "''");
                return tempString.Replace("\"\"", "\"");
            }
            int nextComma = data.IndexOf(',', fromPos);
            if (nextComma == -1)
            {
                startSeperatorPos = data.Length;
                return data.Substring(fromPos);
            }
            else
            {
                startSeperatorPos = nextComma;
                return data.Substring(fromPos, nextComma - fromPos);
            }
        }
        private int GetSingleQuote(string data, int sFrom)
        {
            int i = sFrom - 1;
            while (++i < data.Length)
                if (data[i] == '"')
                {
                    if (i < data.Length - 1 && data[i + 1] == '"')
                    {
                        i++;
                        continue;
                    }
                    else return i;
                }
            return -1;
        }
    }
}
