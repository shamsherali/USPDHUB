using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.XPath;

namespace USPDHUBBLL
{
    public interface ISpatialCoordinate
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }

    /// <summary>
    /// Coordiate structure. Holds Latitude and Longitude.
    /// </summary>
    public struct Coordinate : ISpatialCoordinate
    {
        private decimal _latitude;
        private decimal _longitude;

        public Coordinate(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        #region ISpatialCoordinate Members

        public decimal Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                this._latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                this._longitude = value;
            }
        }

        #endregion
    }
    public class Geocode
    {
        private const string _googleUri = "http://maps.google.com/maps/geo?q=";
        private const string _googleKey = "ABQIAAAA74uqNA7QanBdIdoyQkT7UxScF-BH9Y-SIKcAjU8YFS_uTREdFBRC5chWNwUTskUXuJo7420Q6VJZsg"; // Get your key from:  http://www.google.com/apis/maps/signup.html
        private const string _outputType = "csv"; // Available options: csv, xml, kml, json

        private static Uri GetGeocodeUri(string address)
        {
            address = HttpUtility.UrlEncode(address);
            return new Uri(String.Format("{0}{1}&output={2}&key={3}", _googleUri, address, _outputType, _googleKey));
        }

        /// <summary>
        /// Gets a Coordinate from a address.
        /// </summary>
        /// <param name="address">An address.
        ///     <remarks>
        ///         <example>1600 Amphitheatre Parkway Mountain View, CA  94043</example>
        ///     </remarks>
        /// </param>
        /// <returns>A spatial coordinate that contains the latitude and longitude of the address.</returns>
        public static Coordinate GetCoordinates(string address)
        {
            /*
            try
            {
                WebClient client = new WebClient();
                Uri uri = GetGeocodeUri(address);
                 
                string[] geocodeInfo = client.DownloadString(uri).Split(',');

                return new Coordinate(Convert.ToDecimal(geocodeInfo[2]), Convert.ToDecimal(geocodeInfo[3]));
            }
            catch (Exception)
            {
                ;
                return new Coordinate { Latitude = 0, Longitude = 0 };
            }

            */


            string latitude = "0";
            string longtude = "0";

            string url = "http://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address=" + address;

            WebResponse response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    XPathDocument document = new XPathDocument(response.GetResponseStream());
                    XPathNavigator navigator = document.CreateNavigator();

                    // get response status
                    XPathNodeIterator statusIterator = navigator.Select("/GeocodeResponse/status");
                    while (statusIterator.MoveNext())
                    {
                        if (statusIterator.Current.Value != "OK")
                        {
                            //Console.WriteLine("Error: response status = '" + statusIterator.Current.Value + "'");
                            return new Coordinate();
                        }
                    }

                    // get results
                    XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");

                    while (resultIterator.MoveNext())
                    {
                        //Console.WriteLine("Result: "); 

                        XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                        while (geometryIterator.MoveNext())
                        {
                            XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                            while (locationIterator.MoveNext())
                            {
                                Console.WriteLine("     location: ");
                                XPathNodeIterator latIterator = locationIterator.Current.Select("lat");
                                while (latIterator.MoveNext())
                                {
                                    latitude = latIterator.Current.Value;
                                    //Console.WriteLine("         lat: " + latIterator.Current.Value);
                                }

                                XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");
                                while (lngIterator.MoveNext())
                                {
                                    longtude = lngIterator.Current.Value;
                                    //Console.WriteLine("         lng: " + lngIterator.Current.Value);
                                }
                            }
                        }
                    }
                }
                return new Coordinate { Latitude = Convert.ToDecimal(latitude), Longitude = Convert.ToDecimal(longtude) };
            }
            catch (Exception /*ex*/)
            {
                return new Coordinate();
            }
            finally
            {
                Console.WriteLine("Clean up");
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }

        }

    }
}

