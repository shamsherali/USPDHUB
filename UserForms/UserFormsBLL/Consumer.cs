using System;
using System.Data;

namespace UserFormsBLL
{
    public class Consumer
    {
        /// <summary>
        /// for retrieving active associates
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <returns>datatable</returns>
        public DataTable GetActiveAssociates(int pUserID)
        {
            return UserFormsDAL.Consumer.GetActiveAssociates(pUserID);
        }
    }
}
