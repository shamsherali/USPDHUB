using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USPDHUB.Controls
{
    public partial class TimeControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string SelectedTime
        {
            get
            {
                return ddlTime.SelectedValue;
            }
            set
            {
                ddlTime.SelectedValue = value;
            }
        }

        public bool Enabled
        {
            set
            {
                ddlTime.Enabled = value;
                //if (value)
                //    ddlTime.BackColor = System.Drawing.Color.Transparent;
                //else
                //    ddlTime.BackColor = System.Drawing.Color.LightGray;

            }
        }
    }
}