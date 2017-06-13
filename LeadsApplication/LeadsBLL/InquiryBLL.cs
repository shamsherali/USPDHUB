using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeadsDAL;
using System.Data;
using LeadsModels;

namespace LeadsBLL
{
    public class InquiryBLL
    {

        public int SaveResellerInquiry(Inquiry objInquiry)
        {
            return InquiryDAL.SaveResellerInquiry(objInquiry);
        }
        public DataTable GetResellerInfo(string retrieveName)
        {
            return InquiryDAL.GetResellerInfo(retrieveName);
        }
    }
}
