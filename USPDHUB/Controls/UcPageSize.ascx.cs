using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USPDHUB.Controls
{
    public partial class UcPageSize : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string SelectedPage
        {
            get 
            {
                return ddlPageSize.SelectedValue; 
            }
            set 
            {
                ddlPageSize.SelectedValue = value;
            }
        }
        

    }
}