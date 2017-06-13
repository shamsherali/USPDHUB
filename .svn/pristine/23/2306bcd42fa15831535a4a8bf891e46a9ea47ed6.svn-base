using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Drawing;

namespace USPDHUB.Admin
{
    public partial class ManageRecurringTranscationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BindGrid();
        }

        protected void grdTranscationDetails_rowDatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string responseMessage = e.Row.Cells[5].Text;

                if (e.Row.Cells[5].Text.Contains("successful"))
                {
                    //e.Row.Font.Bold = false;
                    e.Row.Cells[5].ForeColor = Color.Green;

                }
            }
        }

        protected void grdTranscationDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTranscationDetails.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        public void BindGrid()
        {
            AdminBLL objAdmin = new AdminBLL();

            DataTable dtTransactionDetails = new DataTable();
            dtTransactionDetails = objAdmin.GetRecurringTransactionDetails();
            grdTranscationDetails.DataSource = dtTransactionDetails;
            grdTranscationDetails.DataBind();
        }
    }
}