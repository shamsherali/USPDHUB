using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.IO;
public partial class Controls_popupcontorl : System.Web.UI.UserControl
{
    public int ProfileID = 0;
    public int PrID = 0;
    public int UserID = 0;
    public string startdate = string.Empty;
    public string enddate = string.Empty;
    public int Sch_Profile_ID = 0;
    public int ScheduleID = 0;
    public int fromsearchflag = 0;
    public static string SelectedEndTime = string.Empty;
    public static bool FreeClick = true;
    public static DataTable dt = new DataTable();
    public string PProfileID = string.Empty;
    public string PTemplateID = string.Empty;
    DataTable dtuser = new DataTable();
    string useremail = string.Empty;
    public string sname = string.Empty;
    public string Sendername = string.Empty;
    public string Guid;
    public static string starttime = string.Empty;
    public static int FlagAffiliate = 0;
    public int RoleID = 0;
    string Message = string.Empty;
    public int C_UserID = 0;
    public string RootPath = ConfigurationManager.AppSettings["RootPath"];
    CommonBLL objCommon = new CommonBLL();
    # region Page Load
    UtilitiesBLL utlObj = new UtilitiesBLL();
    public string businesstype = string.Empty;
    BusinessBLL BusObj = new BusinessBLL();
    public int AffiliateID = 0;
    public int CheckSendMessage = 0;
    string logourl = string.Empty;
    public string DomainName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["VerticalDomain"] == null || Session["RootPath"] == null)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            DomainName = objCommon.CreateDomainUrl(url);
        }
        DomainName = Convert.ToString(Session["VerticalDomain"]);
        // Adding content extra to the URL for changing Captcha in IE9 (for Add a Testimonial & Add Contacts).
        imgreviewrcaptcha.ImageUrl = "~/GenerateCaptcha.aspx?dt=" + DateTime.Now.ToString();
        img1.ImageUrl = "~/GenerateCaptcha.aspx?dt=" + DateTime.Now.ToString();
        if (Session["BusinessType"] != null)
            businesstype = Session["BusinessType"].ToString();
        else
            businesstype = "Business";
        if (Session["hdnValue"] != null)
        {
            if (Session["hdnValue"].ToString() != "")
            {
                hdncntrl.Value = Session["hdnValue"].ToString();
            }
        }


        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
            C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
        else
            C_UserID = UserID;


        if (hdncntrl.Value == "1")
        {
            if (Session["ProfileID"] != null)
                ProfileID = Convert.ToInt32(Session["ProfileID"]);
            if (Request.QueryString["PID"] != null)
            {
                AffiliateID = Convert.ToInt32(Request.QueryString["PID"]);
            }
            int affflag = 0;
            affflag = BusObj.VerifyAffiliateDetailsByProfileID(ProfileID, AffiliateID);
            if (Session["Affiliate"] == null)
            {
                if (affflag == 1)
                    Session["Affiliate"] = "Yes";
            }

            Session["pop"] = "1";
        }
        else
        {
            Session["pop"] = null;
        }
        if (Session["addreviewfromezsmart"] != null)
        {
            hdnezsmartreview.Value = Session["addreviewfromezsmart"].ToString();
            Session["addreviewfromezsmart"] = null;
        }
        //Issue no 102 for spelling corrections  entire Page
        PnlAddFav.Visible = false;
        PnlAddReviews.Visible = false;
        PnlSchAppointment.Visible = false;
        PnlSendMessages.Visible = false;
        PnlJoinMyNetwork.Visible = false;
        PnlLoginControl.Visible = false;
        PnlError.Visible = false;
        PnlSuccess.Visible = false;
        Pnlsavesearchresults.Visible = false;
        lblsavesearch.Text = "";
        Message = "<font face=arial color=red size=2>This time slot is not available. Please select a different time.</font>";
        ifrappointments.Attributes["onload"] = "autoIframe()";

        # region Query Strings
        //Page Load Query Strings

        if (Request.QueryString["PID"] != null)
        {
            PProfileID = Request.QueryString["PID"].ToString();
        }
        if (PID.Value != null)
        {
            if (PID.Value.Length > 0)
            {
                PProfileID = PID.Value.ToString();
                PrID = int.Parse(PID.Value.ToString());
            }
        }

        if (Request.QueryString["TID"] != null)
            PTemplateID = Request.QueryString["TID"].ToString();
        if (Session["userid"] != null)
            UserID = Convert.ToInt32(Session["userid"]);
        if (Request.QueryString["SchID"] != null)
            ScheduleID = Convert.ToInt32(Request.QueryString["SchID"]);
        if (Session["RoleID"] != null)
        {
            if (Session["RoleID"].ToString() != "")
                RoleID = Convert.ToInt32(Session["RoleID"].ToString());
        }

        string test = hdncntrl.Value;
        # endregion

        # region Business User
        if (Session["ProfileID"] != null)
        {
            if (Session["ProfileID"].ToString() != "")
            {
                if (Session["RoleID"] != null)
                {
                    if (Session["RoleID"].ToString() != "")
                    {
                        if (Session["RoleID"].ToString() != "1")
                        {

                            if (test != string.Empty)
                            {
                                if (test != "")
                                {
                                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                                    // Check for Same ProfileID
                                    # region Check For ProfileID

                                    # region Differnet ProfileID
                                    if (Session["ProfileID"].ToString() != PProfileID)
                                    {
                                        // if ProfileID is not Same
                                        # region Post Back

                                        // Post Back Events of Panels


                                        if (test != string.Empty)
                                        {
                                            if (test != "")
                                            {
                                                # region Add Fav
                                                // Page Post Back of Add Fav
                                                if (test == "3")
                                                {
                                                    string businessname = string.Empty;
                                                    if (PProfileID != "")
                                                    {
                                                        BusinessBLL BusObj = new BusinessBLL();
                                                        businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                        lblprofilename.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                                        txtfavoritename.Text = businessname;
                                                    }
                                                }
                                                # endregion

                                                # region Business Reviews

                                                // Page Post Back of Business Reviews
                                                else if (test == "4")
                                                {
                                                    if (PProfileID != "")
                                                    {
                                                        BusinessBLL BusObj = new BusinessBLL();
                                                        lbladdreviewprofilename.Text = "Add a testimonial for <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                                    }
                                                }
                                                // Page Post Back of Join My Network

                                                # endregion

                                                # region Join My Network
                                                else if (test == "5")
                                                {
                                                    lblmsg.Text = "";
                                                    string businessname = string.Empty;
                                                    BusinessBLL BusObj = new BusinessBLL();
                                                    FlagAffiliate = BusObj.VerifyAffiliateDetailsByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()), Convert.ToInt32(PProfileID));
                                                    businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                    lblprofilename1.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                                    dtuser = BusObj.GetuserdetailsByProfileID(Convert.ToInt32(PProfileID));
                                                    if (dtuser.Rows.Count > 0)
                                                    {
                                                        txtaffiliate.Text = dtuser.Rows[0]["Firstname"].ToString();
                                                        txtemail.Text = dtuser.Rows[0]["Username"].ToString();
                                                    }

                                                    UserID = Convert.ToInt32(Session["UserID"]);
                                                    //Get the name of this user.
                                                    Consumer conObj = new Consumer();
                                                    DataTable dtobj = new DataTable();
                                                    dtobj = conObj.GetUserDetailsByID(UserID);
                                                    if (dtobj.Rows.Count == 1)
                                                    {
                                                        useremail = dtobj.Rows[0]["Username"].ToString();
                                                        if ((dtobj.Rows[0]["Lastname"].ToString().Length > 1) && (dtobj.Rows[0]["Firstname"].ToString().Length > 1))
                                                            Sendername = dtobj.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Firstname"].ToString().Substring(1, dtobj.Rows[0]["Firstname"].ToString().Length - 1) + " " + dtobj.Rows[0]["Lastname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Lastname"].ToString().Substring(1, dtobj.Rows[0]["Lastname"].ToString().Length - 1);
                                                        else if ((dtobj.Rows[0]["Firstname"].ToString().Length > 1))
                                                            Sendername = dtobj.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Firstname"].ToString().Substring(1, dtobj.Rows[0]["Firstname"].ToString().Length - 1);
                                                        else
                                                            Sendername = "";
                                                    }
                                                    sname = Sendername.ToUpper() + " has sent you an Affiliate Invitation";
                                                    //txtsubject.Text = sname;
                                                }
                                                # endregion

                                                # region Schedule Appointment

                                                else if (test == "1")
                                                {
                                                    lblheader.Text = "Schedule an Appointment";
                                                    string businessname = string.Empty;
                                                    BusinessBLL BusObj = new BusinessBLL();
                                                    if (PProfileID != null)
                                                        businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                    if (businessname.Length > 0)
                                                    {
                                                        lblBusiness.Text = " with <font size=2 color=maroon><b>" + businessname + "</b></font>";

                                                    }

                                                }

                                                # endregion

                                                # region Send Messages

                                                else if (test == "2")
                                                {
                                                    if (PProfileID != "")
                                                    {
                                                        BusinessBLL BusObj = new BusinessBLL();
                                                        lblsendmessprofilename.Text = "Send message to <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                                    }
                                                }

                                                # endregion
                                            }
                                        }
                                        # endregion

                                        # region LoadMethods

                                        if (Session["ProfileID"] != null)
                                        {
                                            if (Session["ProfileID"].ToString() != "")
                                            {

                                                // For Add Fav
                                                // Nothing

                                                // For Reviews
                                                if (test == "4")
                                                {
                                                    string theFunction = @"<script language=javascript>
          function textCounter(field, countfield, maxlimit) 
          {
                if (field.value.length > maxlimit)
                    field.value = field.value.substring(0, maxlimit);
                else
                    countfield.value = maxlimit - field.value.length;
                }
            </script>";
                                                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", theFunction);
                                                    string theFunction1 = "javascript:textCounter(" + txtcomments.ClientID + "," + txtCount.ClientID + "," + txtcomments.MaxLength.ToString() + ");";

                                                    txtcomments.Attributes.Add("onKeyDown", theFunction1);
                                                    txtcomments.Attributes.Add("onKeyUp", theFunction1);
                                                    txtCount.Text = Convert.ToString(txtcomments.MaxLength - txtcomments.Text.Length);
                                                }

                                                // For Join My Network

                                                // Nothing

                                                // For Schdule Appointment                      


                                                // For Send Messages

                                                // Nothing
                                            }
                                        }

                                        # endregion

                                        # region POP Session

                                        if (test != string.Empty)
                                        {
                                            if (test != "")
                                            {
                                                if (test == "1")
                                                {
                                                    PnlSchAppointment.Visible = true;
                                                    string url = string.Empty;
                                                    string UrlPath = string.Empty;
                                                    if (Request.Url.ToString().Contains("https") == true)
                                                    {
                                                        UrlPath = ConfigurationManager.AppSettings.Get("RootPath");
                                                    }
                                                    else
                                                    {
                                                        UrlPath = ConfigurationManager.AppSettings.Get("OuterRootURL");
                                                    }
                                                    url = UrlPath + "/Appointments/AppointmentIframe.aspx?PID=" + PProfileID.ToString();
                                                    ifrappointments.Attributes["src"] = url;
                                                    ifrappointments.Attributes["onload"] = "autoIframe()";

                                                }
                                                else if (test == "2")
                                                {
                                                    PnlSendMessages.Visible = true;

                                                }
                                                else if (test == "3")
                                                {
                                                    PnlAddFav.Visible = true;
                                                    hdnsuccess.Value = "2";

                                                }
                                                else if (test == "4")
                                                {
                                                    PnlAddReviews.Visible = true;

                                                }
                                                else if (test == "5")
                                                {
                                                    if (FlagAffiliate > 0)
                                                    {

                                                        PnlError.Visible = true;
                                                        hdnsuccess.Value = "3";
                                                        //lblSameProfileerror.Text = "This member is already listed in your network. Please click here to continue.";
                                                        lblSameProfileerror.Text = "This member is already listed in your network.";
                                                    }
                                                    else
                                                    {
                                                        PnlJoinMyNetwork.Visible = true;
                                                        hdnsuccess.Value = "2";
                                                    }

                                                }
                                                else if (test == "7")
                                                {
                                                    Pnlsavesearchresults.Visible = true;
                                                }
                                                Session["POP"] = string.Empty;

                                            }
                                            Session["SPOP"] = "TR";
                                        }
                                        # endregion
                                    }
                                    # endregion

                                    else
                                    {
                                        // if ProfileID is Same

                                        # region ProfileID IS SAME

                                        if (test != string.Empty)
                                        {
                                            if (test != "")
                                            {
                                                if (test == "1")
                                                {
                                                    //plapp.Visible = false;

                                                    lblheader.Text = "Schedule an Appointment";
                                                    string businessname = string.Empty;
                                                    BusinessBLL BusObj = new BusinessBLL();
                                                    if (PProfileID != "")
                                                    {

                                                        businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                    }
                                                    if (businessname.Length > 0)
                                                    {
                                                        lblBusiness.Text = " with <font size=2 color=maroon><b>" + businessname + "</b></font>";

                                                    }

                                                    Schedules ObjSch = new Schedules();
                                                    DataTable DtAppts = new DataTable();
                                                    PnlSchAppointment.Visible = true;
                                                    string url = string.Empty;
                                                    string UrlPath = string.Empty;
                                                    if (Request.Url.ToString().Contains("https") == true)
                                                    {
                                                        UrlPath = ConfigurationManager.AppSettings.Get("RootPath");
                                                    }
                                                    else
                                                    {
                                                        UrlPath = ConfigurationManager.AppSettings.Get("OuterRootURL");
                                                    }
                                                    url = UrlPath + "/Appointments/AppointmentIframe.aspx?PID=" + PProfileID.ToString();
                                                    ifrappointments.Attributes["src"] = url;
                                                    ifrappointments.Attributes["onload"] = "autoIframe()";


                                                }
                                                else if (test == "2")
                                                {
                                                    //lblSameProfileerror.Text = "You cannot send a message to yourself. Please click here to continue.";
                                                    lblSameProfileerror.Text = "You cannot send a message to yourself.";
                                                    PnlError.Visible = true;
                                                    hdnsuccess.Value = "1";

                                                }
                                                else if (test == "3")
                                                {
                                                    //lblSameProfileerror.Text = "You cannot add your own site to your list of favorites. Please click here to continue.";
                                                    lblSameProfileerror.Text = "You cannot add your own site to your list of favorites.";
                                                    PnlError.Visible = true;
                                                    hdnsuccess.Value = "1";
                                                }
                                                else if (test == "4")
                                                {
                                                    //lblSameProfileerror.Text = "You cannot add a review to your own " + businesstype + ". Please click here to continue.";
                                                    lblSameProfileerror.Text = "You cannot add a testimonial for your own " + businesstype + ".";
                                                    PnlError.Visible = true;
                                                    hdnsuccess.Value = "1";

                                                }
                                                else if (test == "5")
                                                {
                                                    //lblSameProfileerror.Text = "You cannot send an invitation to yourself. Please click here to continue.";
                                                    lblSameProfileerror.Text = "You cannot send an invitation to yourself.";
                                                    PnlError.Visible = true;
                                                    hdnsuccess.Value = "1";

                                                }
                                                else if (test == "7")
                                                {
                                                    Pnlsavesearchresults.Visible = true;
                                                }

                                            }

                                        }
                                        # endregion

                                    }
                                    # endregion
                                }
                            }
                        }
                    }
                }

            }
        }
        else if (test == "2")
        {
            PnlSendMessages.Visible = true;
            if (PProfileID != "")
            {
                lblsendmessprofilename.Text = "Send message to <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
            }
        }
        //Start Issue 770
        else if (test == "4")
        {
            PnlAddReviews.Visible = true;
            if (PProfileID != "")
            {
                lbladdreviewprofilename.Text = "Add a testimonial for <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
            }

        }
        //End Issue 770
        else if (test == "1")
        {
            lblheader.Text = "Schedule an Appointment";
            string businessname = string.Empty;
            BusinessBLL BusObj = new BusinessBLL();
            if (PProfileID != "")
            {
                businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
            }
            if (businessname.Length > 0)
            {
                lblBusiness.Text = " with <font size=2 color=maroon><b>" + businessname + "</b></font>";

            }
            PnlSchAppointment.Visible = true;
            string url = string.Empty;
            string UrlPath = string.Empty;
            if (Request.Url.ToString().Contains("https") == true)
            {
                UrlPath = ConfigurationManager.AppSettings.Get("RootPath");
            }
            else
            {
                UrlPath = ConfigurationManager.AppSettings.Get("OuterRootURL");
            }
            url = UrlPath + "/Appointments/AppointmentIframe.aspx?PID=" + PProfileID.ToString();
            ifrappointments.Attributes["src"] = url;
            ifrappointments.Attributes["onload"] = "autoIframe()";
        }
        else
        {
            if (Session["userid"] == null)
            {
                if (test == "3") //Favorites
                {
                    pnlfavlogin.Visible = true;
                    pnlafflogin.Visible = false;
                    pnlapplogin.Visible = false;
                }
                else if (test == "5")
                {
                    pnlafflogin.Visible = true;
                    pnlapplogin.Visible = false;
                    pnlfavlogin.Visible = false;
                }
                else
                {
                    pnlafflogin.Visible = false;
                    pnlapplogin.Visible = false;
                    pnlfavlogin.Visible = false;
                }
                PnlLoginControl.Visible = true;
            }
        }

        # endregion

        # region Consumer
        // If Login User Is Consumer
        if (Session["UserId"] != null)
        {
            if (Session["UserID"].ToString() != "")
            {
                if (Session["RoleID"] != null)
                {
                    if (Session["RoleID"].ToString() != "")
                    {
                        if (Session["RoleID"].ToString() != "2")
                        {
                            //string test = hdncntrl.Value;
                            if (test != string.Empty)
                            {
                                if (test != "")
                                {

                                    # region Post Back

                                    // Post Back Events of Panels


                                    if (test != string.Empty)
                                    {
                                        if (test != "")
                                        {
                                            # region Add Fav
                                            // Page Post Back of Add Fav
                                            if (test == "3")
                                            {
                                                string businessname = string.Empty;
                                                BusinessBLL BusObj = new BusinessBLL();
                                                businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                lblprofilename.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                                txtfavoritename.Text = businessname;
                                            }
                                            # endregion

                                            # region Business Reviews

                                            // Page Post Back of Business Reviews
                                            else if (test == "4")
                                            {

                                                BusinessBLL BusObj = new BusinessBLL();
                                                lbladdreviewprofilename.Text = "Add a testimonial for <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                            }
                                            // Page Post Back of Join My Network

                                            # endregion

                                            # region Join My Network
                                            //else if (test == "5")
                                            //{
                                            //    lblmsg.Text = "";
                                            //    string businessname = string.Empty;
                                            //    Business BusObj = new Business();
                                            //    FlagAffiliate = BusObj.VerifyAffiliateDetailsByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()), Convert.ToInt32(PProfileID));
                                            //    businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                            //    lblprofilename.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                            //    dtuser = BusObj.GetuserdetailsByProfileID(Convert.ToInt32(PProfileID));
                                            //    if (dtuser.Rows.Count > 0)
                                            //    {
                                            //        txtaffiliate.Text = dtuser.Rows[0]["Firstname"].ToString();
                                            //        txtemail.Text = dtuser.Rows[0]["Username"].ToString();
                                            //    }

                                            //    UserID = Convert.ToInt32(Session["UserID"]);
                                            //    //Get the name of this user.
                                            //    Consumer conObj = new Consumer();
                                            //    DataTable dtobj = new DataTable();
                                            //    dtobj = conObj.GetUserDetailsByID(UserID);
                                            //    if (dtobj.Rows.Count == 1)
                                            //    {
                                            //        useremail = dtobj.Rows[0]["Username"].ToString();
                                            //        if ((dtobj.Rows[0]["Lastname"].ToString().Length > 1) && (dtobj.Rows[0]["Firstname"].ToString().Length > 1))
                                            //            Sendername = dtobj.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Firstname"].ToString().Substring(1, dtobj.Rows[0]["Firstname"].ToString().Length - 1) + " " + dtobj.Rows[0]["Lastname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Lastname"].ToString().Substring(1, dtobj.Rows[0]["Lastname"].ToString().Length - 1);
                                            //        else if ((dtobj.Rows[0]["Firstname"].ToString().Length > 1))
                                            //            Sendername = dtobj.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj.Rows[0]["Firstname"].ToString().Substring(1, dtobj.Rows[0]["Firstname"].ToString().Length - 1);
                                            //        else
                                            //            Sendername = "";
                                            //    }
                                            //    sname = Sendername.ToUpper() + " has sent you an Affiliate Invitation";
                                            //    txtsubject.Text = sname;
                                            //}
                                            # endregion

                                            # region Schedule Appointment

                                            else if (test == "1")
                                            {
                                                //lblunavailable.Visible = false;
                                                //urlreferer = Request.UrlReferrer.ToString();
                                                //calSchDate.SelectedDate = DateTime.Today;
                                                //daytimeslot.StartDate = calSchDate.SelectedDate;
                                                //plapp.Visible = false;

                                                lblheader.Text = "<font color=#003366 size=3><b>Schedule an Appointment&nbsp; </b></font>";
                                                string businessname = string.Empty;
                                                BusinessBLL BusObj = new BusinessBLL();
                                                businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                if (businessname.Length > 0)
                                                {
                                                    lblBusiness.Text = "<font color=#003366 size=3><b> with </b></font><font size=2 color=maroon><b>" + businessname + "</b></font>";

                                                }



                                            }

                                            # endregion

                                            # region Send Messages

                                            else if (test == "2")
                                            {
                                                if (PProfileID != "")
                                                {
                                                    BusinessBLL BusObj = new BusinessBLL();
                                                    lblsendmessprofilename.Text = "Send message to <font color=maroon size=2 face=arial>" + BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                                }
                                            }

                                            # endregion
                                        }
                                    }
                                    # endregion

                                    # region LoadMethods

                                    // For Add Fav
                                    // Nothing

                                    // For Reviews
                                    if (test == "4")
                                    {
                                        string theFunction = @"<script language=javascript>
          function textCounter(field, countfield, maxlimit) 
          {
                if (field.value.length > maxlimit)
                    field.value = field.value.substring(0, maxlimit);
                else
                    countfield.value = maxlimit - field.value.length;
                }
            </script>";
                                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", theFunction);
                                        string theFunction1 = "javascript:textCounter(" + txtcomments.ClientID + "," + txtCount.ClientID + "," + txtcomments.MaxLength.ToString() + ");";

                                        txtcomments.Attributes.Add("onKeyDown", theFunction1);
                                        txtcomments.Attributes.Add("onKeyUp", theFunction1);
                                        txtCount.Text = Convert.ToString(txtcomments.MaxLength - txtcomments.Text.Length);
                                    }

                                    // For Join My Network

                                    // Nothing

                                    // For Schdule Appointment

                                    if (test == "1")
                                    {
                                        Schedules ObjSch = new Schedules();
                                        DataTable DtAppts = new DataTable();
                                        //calSchDate.VisibleDate = DateTime.Today;
                                        //calSchDate.SelectedDate = DateTime.Today;
                                        //if (calSchDate.SelectedDate >= DateTime.Today)
                                        //{
                                        //    if (calSchDate.SelectedDate == DateTime.Today)
                                        //    {
                                        //        startdate = DateTime.Now.Date.ToShortDateString();
                                        //    }
                                        //    else
                                        //    {
                                        //        startdate = calSchDate.SelectedDate.ToShortDateString();
                                        //    }
                                        //    enddate = Convert.ToDateTime(startdate).AddDays(Convert.ToDouble(1)).ToString();


                                        //    DisplayProfileAppointments(Convert.ToInt32(PProfileID), startdate, enddate);
                                        //}
                                    }

                                    // For Send Messages

                                    // Nothing


                                    # endregion

                                    # region POP Session

                                    if (test != string.Empty)
                                    {
                                        if (test != "")
                                        {
                                            if (test == "1")
                                            {
                                                PnlSchAppointment.Visible = true;
                                                string url = string.Empty;
                                                string UrlPath = string.Empty;
                                                if (Request.Url.ToString().Contains("https") == true)
                                                {
                                                    UrlPath = ConfigurationManager.AppSettings.Get("RootPath");
                                                }
                                                else
                                                {
                                                    UrlPath = ConfigurationManager.AppSettings.Get("OuterRootURL");
                                                }
                                                url = UrlPath + "/Appointments/AppointmentIframe.aspx?PID=" + PProfileID.ToString();
                                                ifrappointments.Attributes["src"] = url;
                                                ifrappointments.Attributes["onload"] = "autoIframe()";
                                                //PnlError.Visible = true;
                                                //lblSameProfileerror.Text = "";

                                            }
                                            else if (test == "2")
                                            {
                                                PnlSendMessages.Visible = true;

                                            }
                                            else if (test == "3")
                                            {
                                                PnlAddFav.Visible = true;

                                            }
                                            else if (test == "4")
                                            {
                                                PnlAddReviews.Visible = true;

                                            }
                                            else if (test == "5")
                                            {
                                                hdnsuccess.Value = "1";
                                                PnlError.Visible = true;
                                                //lblSameProfileerror.Text = "Being a consumer you cannot send an affiliate invitation. Please click here to continue.";
                                                lblSameProfileerror.Text = "Being a consumer you cannot send an affiliate invitation.";
                                                //if (FlagAffiliate > 0)
                                                //{
                                                //    PnlError.Visible = true;
                                                //    lblSameProfileerror.Text = "This business profile is already add as an affiliate to your business profile, please <a href='" + Request.UrlReferrer.ToString() + "' style='color:Green;'> click here </a> to continue.";
                                                //}
                                                //else
                                                //{
                                                //    PnlJoinMyNetwork.Visible = true;
                                                //}

                                            }


                                        }

                                    }
                                    # endregion
                                }
                            }
                        }
                    }
                }

            }
        }
        # endregion



        string theFunction3 = @"<script language=javascript>
          function textCounter(field, countfield, maxlimit) 
          {
                if (field.value.length > maxlimit)
                    field.value = field.value.substring(0, maxlimit);
                else
                    countfield.value = maxlimit - field.value.length;
                }
            </script>";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", theFunction3);
        string theFunction4 = "javascript:textCounter(" + txtcomments.ClientID + "," + txtCount.ClientID + "," + txtcomments.MaxLength.ToString() + ");";

        txtcomments.Attributes.Add("onKeyDown", theFunction4);
        txtcomments.Attributes.Add("onKeyUp", theFunction4);
        txtCount.Text = Convert.ToString(txtcomments.MaxLength - txtcomments.Text.Length);
        if (Session["Aptcompleted"] != null)
        {
            PnlSchAppointment.Visible = false;
            if (Session["Affiliate"] != null)
            {
                if (Session["Affiliate"].ToString() == "Yes")
                {
                    //lbpnlsucess.Text = "Your appointment request has been submitted and your affiliate has been notified. Please click here to continue.";
                    lbpnlsucess.Text = "Your appointment request has been submitted for approval.";
                }
            }
            else
            {
                //lbpnlsucess.Text = "Your appointment request has been submitted and the business owner has been notified. Please click here to continue.";
                lbpnlsucess.Text = "Your appointment request has been submitted for approval.";
            }
            PnlSuccess.Visible = true;
            Session["Aptcompleted"] = null;
            Session["Affiliate"] = null;
        }

    }

    # endregion

    # region Add Fav Button

    protected void Save_Favorite(object sender, EventArgs e)
    {
        if (Request.QueryString["PID"] != null)
            PProfileID = Request.QueryString["PID"].ToString();
        if (Request.QueryString["TID"] != null)
            PTemplateID = Request.QueryString["TID"].ToString();
        if (Session["userid"] != null)
            UserID = Convert.ToInt32(Session["userid"]);
        if (Session["RoleID"].ToString() == "2")
        {
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
        }

        string urlinfo = string.Empty;
        string favoritename = txtfavoritename.Text.Trim();
        Consumer conobj = new Consumer();
        int Addflag = 0;
        //For Adding favorite Ttype = 1 and Favorite ID = 0
        Addflag = conobj.ManageFavoriteDetails(favoritename, Convert.ToInt32(PProfileID), UserID, 1, 0);        
        ClearControlPopUp();
        PnlAddFav.Visible = false;
        hdnsuccess.Value = "1";
        //lbpnlsucess.Text = "This listing has been added to your favorites list for quick reference.<br/> Please click here to continue.";
        lbpnlsucess.Text = "This listing has been added to your favorites list for quick reference.";
        PnlSuccess.Visible = true;
        //Session["Suc"] = "1";

    }


    # endregion

    # region Business Reviews Button


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PID"] != null)
            PProfileID = Request.QueryString["PID"].ToString();
        if (Request.QueryString["TID"] != null)
            PTemplateID = Request.QueryString["TID"].ToString();
        if (Session["userid"] != null)
            UserID = Convert.ToInt32(Session["userid"]);
        if (Session["RoleID"] != null)
        {
            if (Session["RoleID"].ToString() == "2")
            {
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            }
        }
        // Issue 768
        string Captcha = string.Empty;
        if (Session["ImageString"] != null)
        {
            if (Session["ImageString"].ToString() != "")
            {
                Captcha = Session["ImageString"].ToString();
            }
        }
        try
        {
            if (txtreviewerphone.Text.Trim() != "" || txtrevieweremail.Text != "")
            {
                if (txtreviewercaptcha.Text.Trim() != "")
                {
                    string Captchtxt = txtreviewercaptcha.Text.Trim();
                    if (Captcha == Captchtxt)
                    {
                        BusinessBLL BusObj = new BusinessBLL();
                        if (validateform())
                        {
                            int intreview1 = Convert.ToInt32(Review1.SelectedValue);
                            int intreview2 = Convert.ToInt32(Review2.SelectedValue);
                            int intreview3 = Convert.ToInt32(Review3.SelectedValue);
                            string txtcomments1 = Convert.ToString(txtcomments.Text.Replace("\n", "<BR>"));
                            decimal overall = intreview1 + intreview2 + intreview3;

                            int avgval = Convert.ToInt32(Math.Round(overall / 3, 0));

                            Consumer conobj = new Consumer();
                            string name = string.Empty;
                            name = txtname.Text;

                            int addflag = conobj.ManageBusinessReviewDetails(UserID, name, Convert.ToInt32(PProfileID), intreview1, intreview2, intreview3, txtcomments1, avgval, UserID, 1, 0, txtreviewerphone.Text, txtrevieweremail.Text);

                            string urlinfo = string.Empty;

                            ClearControlPopUp();
                            PnlAddReviews.Visible = false;
                            lbpnlsucess.Text = "Thank you for submitting your testimonial.";
                            PnlSuccess.Visible = true;
                            hdnsuccess.Value = "1";
                        }
                    }
                    else
                    {

                        lblshowreviewerror.Text = "<font face=arial color=red size=2>Enter Correct Security Code</font>";
                    }
                }
            }
            else
            {
                lblshowreviewerror.Text = "Please enter either phone or email address.";
            }
        }
        catch (Exception ex)
        {
            lblshowreviewerror.Text = ex.Message;
        }
        Random ran = new Random();
        img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
        // End issue 768
    }
    protected void txtcomments_TextChanged(object sender, EventArgs e)
    {

    }

    private bool validateform()
    {
        if (Review1.SelectedValue.Length == 0)
        {
            lblmsg.Text = "<font face=arial color=red size=2> Please choose Professionalism Rating..!</font>";
            return false;
        }
        if (Review2.SelectedValue.Length == 0)
        {
            lblmsg.Text = "<font face=arial color=red size=2> Please choose Communication Rating..!</font>";
            return false;
        }
        if (Review3.SelectedValue.Length == 0)
        {
            lblmsg.Text = "<font face=arial color=red size=2> Please choose Customer Service Rating..!</font>";
            return false;
        }
        if (txtcomments.Text.Trim().Length == 0)
        {
            lblmsg.Text = "<font face=arial color=red size=2> Please enter Testimonial comments..!</font>";
            return false;
        }

        return true;

    }

    # endregion

    # region Join My Network Button

    protected void btninvite_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PID"] != null)
            PProfileID = Request.QueryString["PID"].ToString();
        if (Request.QueryString["TID"] != null)
            PTemplateID = Request.QueryString["TID"].ToString();
        if (Session["userid"] != null)
            UserID = Convert.ToInt32(Session["userid"]);
        string businessname = string.Empty;
        string emailid = string.Empty;
        businessname = txtaffiliate.Text;
        emailid = txtemail.Text;
        if (emailid.Length > 0 && businessname.Length > 0)
        {
            lblerr.Visible = false;
            sendemail(businessname, emailid);
            string urlinfo = string.Empty;
            ClearControlPopUp();
            PnlJoinMyNetwork.Visible = false;
            lbpnlsucess.Text = "Your invitation has been sent successfully.";
            PnlSuccess.Visible = true;
            hdnsuccess.Value = "1";

        }
        else
        {
            lblerr.Visible = true;
            lblerr.Text = "Business owner name and Email id should not be empty";
        }


    }

    # endregion

    # region Send Email For Join My Network
    protected void sendemail(string businessownername, string email)
    {
        BusinessBLL BusObj = new BusinessBLL();
        Consumer ConObj = new Consumer();
        DataTable CondtObj = new DataTable();
        DataTable dtobjmsg = new DataTable();

        string message = string.Empty;
        string bodymsg = string.Empty;
        string subject = sname;
        string senderBusinessname = string.Empty;
        int addflag = 0;
        string mailedflag = string.Empty;
        senderBusinessname = BusObj.GetBusinessNameByProfileID(ProfileID).ToString();
        if (senderBusinessname.Length > 0)
        {
            senderBusinessname = senderBusinessname.ToString();
        }
        else
        {
            senderBusinessname = "";
        }
        DataTable dtprofile = new DataTable();
        dtprofile = BusObj.GetProfileDetailsByProfileID(ProfileID);
        if (dtprofile.Rows.Count > 0)
        {
            if (dtprofile.Rows[0]["Profile_logo_path"].ToString() != "")
            {
                logourl = dtprofile.Rows[0]["Profile_logo_path"].ToString();
                if (logourl.Trim().Length > 3)
                {
                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;
                    string url = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\" + thumbimg1;
                    FileInfo obj = new FileInfo(url);

                    if (obj.Exists)
                    {
                        logourl = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Upload/Logos/" + ProfileID + "/" + thumbimg1;
                    }
                    else
                    {
                        logourl = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Upload/Logos/" + ProfileID + "/" + logourl;
                    }
                }
                else // No image
                {
                    logourl = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/images/blank.gif";
                }
            }
            else // no image... hide the logo 
            {
                logourl = System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/images/blank.gif";
            }
        }
        if (email.Trim().Length > 0 && businessownername.Trim().Length > 0)
        {
            CondtObj = ConObj.ValidateConsumer(email.Trim(), string.Empty);
            if (CondtObj.Rows.Count > 0) // attach the member invitation.
            {
                if (Convert.ToInt32(CondtObj.Rows[0]["Role_ID"]) == 2)
                {
                    dtobjmsg = utlObj.GetConfigDetailsbyName("AInviteMsg");
                    if (dtobjmsg.Rows.Count > 0)
                        message = dtobjmsg.Rows[0]["Config_value"].ToString();
                    message = message.Replace("#Sender#", Sendername.ToUpper());
                    bodymsg = "<html><head>";
                    bodymsg = bodymsg + "<link href=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/css/wowzzy_general.css rel='stylesheet' type='text/css' />";
                    bodymsg = bodymsg + "</head><body><table width='100%' border='0' align='center' style='padding:10px;'><tr><td>";
                    bodymsg = bodymsg + "<img src='" + logourl + "' /><br><br></td></tr>";

                    bodymsg = bodymsg + "<tr><td>Hi " + businessownername + "," + "<BR><BR>" + message;
                }
                else  // If member is consumer , then need to send the non member message.
                {
                    dtobjmsg = utlObj.GetConfigDetailsbyName("ANONInviteMsg");
                    if (dtobjmsg.Rows.Count > 0)
                    {
                        message = dtobjmsg.Rows[0]["Config_value"].ToString();
                        message = message.Replace("#Sender#", Sendername.ToUpper());
                    }
                    bodymsg = "<html><head>";
                    bodymsg = bodymsg + "<link href=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/css/wowzzy_general.css rel='stylesheet' type='text/css' />";
                    bodymsg = bodymsg + "</head><body><table width='100%' border='0' align='center' style='padding:10px;'><tr><td>";
                    bodymsg = bodymsg + "<img src='" + logourl + "' /><br><br></td></tr>";
                    bodymsg = bodymsg + "<br><br><tr><td><table width='470px' border='0'><tr><td>";
                    bodymsg = bodymsg + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'>";
                    bodymsg = bodymsg + "<br><strong   style='color:#B3B3B3;'>This is Automated Email from USPDhub.com. Please do not reply to it..</strong><br>";
                    bodymsg = bodymsg + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'><br><br></td></tr></table></td></tr><tr><td>";

                    bodymsg = bodymsg + "Dear " + businessownername + "," + "<BR><BR>" + message;
                }
            }
            else // Nonmember
            {
                dtobjmsg = utlObj.GetConfigDetailsbyName("ANONInviteMsg");
                if (dtobjmsg.Rows.Count > 0)
                {
                    message = dtobjmsg.Rows[0]["Config_value"].ToString();
                    message = message.Replace("#Sender#", Sendername.ToUpper());
                }
                bodymsg = "<html><head>";
                bodymsg = bodymsg + "<link href=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/css/wowzzy_general.css rel='stylesheet' type='text/css' />";
                bodymsg = bodymsg + "</head><body><table width='100%' border='0' align='center' style='padding:10px;'><tr><td>";
                bodymsg = bodymsg + "<img src='" + logourl + "' /><br><br></td></tr>";
                bodymsg = bodymsg + "<br><br><tr><td><table width='470px' border='0'><tr><td>";
                bodymsg = bodymsg + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'>";
                bodymsg = bodymsg + "<br><strong   style='color:#B3B3B3;'>This is Automated Email from USPDhub.com. Please do not reply to it..</strong><br>";
                bodymsg = bodymsg + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'><br><br></td></tr></table></td></tr><tr><td>";

                bodymsg = bodymsg + "Hi " + businessownername + "," + "<BR><BR>" + message;
            }
            Guid = Convert.ToString(System.Guid.NewGuid().ToString());


            bodymsg = bodymsg + "<br/><br/>";
            bodymsg = bodymsg + "Thank you,<br/><br/>";
            bodymsg = bodymsg + Sendername;
            bodymsg = bodymsg + "<br/><br/>If you would like more information about me or would like to accept this affiliate invitation, please <a href='" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Business/AffiliateInvPreRegister.aspx?InviteID=" + EncryptDecrypt.DESEncrypt(Session["ProfileID"].ToString()) + "&EmailID=" + email + "&Affguid=" + Guid + "' target=_new>  <font size='2'><strong>click here</strong></font></a>.";
            bodymsg = bodymsg + " If this link does not work, simply copy and paste the following address into your browser:<br/><br/>" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/Business/AffiliateInvPreRegister.aspx?InviteID=" + EncryptDecrypt.DESEncrypt(Session["ProfileID"].ToString()) + "&EmailID=" + email + "&Affguid=" + Guid;


            bodymsg = bodymsg + "<br><br><br><br><br></td></tr> <tr><td><table><tr style='color:#B3B3B3;' cellpadding='5px'><td><strong style='color: #0071B3'>Disclaimer Notice:</strong><br><br>This email and its attachments may be confidential and are intended solely for the use of the individual to whom it is addressed. Any views or opinions expressed are solely those of the author and do not necessarily represent those of USPDhub.com.<br><br>If you are not the intended recipient of this email and its attachments, you must take no action based upon them, nor must you copy or show them to anyone.<br><br>Please contact <u style='color: #0071B3'>info@uspdhub.com</u>  if you believe you have received this email in error and you would like to be taken off our email list.</td>";
            bodymsg = bodymsg + "<td align='right' valign='bottom'>&nbsp;<a href='" + RootPath + "' target='_blank'><img src='" + RootPath + "/images/emailby.gif' alt='Email by inReachHub' border='0' longdesc='http://www.inreachhub.com' /></a></td></tr></table> </td></tr></table></body></html>";


            addflag = 0;

            addflag = BusObj.AddAffiliateInvitation(Convert.ToInt32(Session["ProfileID"].ToString()), email, businessownername, subject, bodymsg, 0, UserID, Guid);
            mailedflag = utlObj.SendWowzzyEmail("donotreply@uspdhub.com", email, subject, bodymsg, string.Empty,"", Session["VerticalDomain"].ToString());
            if (mailedflag == "SUCCESS")
            {
                lblmsg.Text = "your invitations had sent successfully";

            }
            else
            {
                lblmsg.Text = "We apologize that this invitation Sending is Failed";
            }
        }

    }

    # endregion

    # region Send Messages Button

    protected void Button3_Click(object sender, EventArgs e)
    {
        string Captcha = string.Empty;
        if (Request.QueryString["PID"] != null)
            PProfileID = Request.QueryString["PID"].ToString();
        if (Request.QueryString["TID"] != null)
            PTemplateID = Request.QueryString["TID"].ToString();
        if (Session["userid"] != null)
            UserID = Convert.ToInt32(Session["userid"]);

        string urlinfo = string.Empty;

        if (Session["ImageString"] != null)
        {
            if (Session["ImageString"].ToString() != "")
            {
                Captcha = Session["ImageString"].ToString();
            }
        }
        try
        {

            if (txtcaptcha.Text.Trim() != "")
            {
                string Captchtxt = txtcaptcha.Text.Trim();
                if (Captcha == Captchtxt)
                {
                    string subject = txtsendmessubject.Text.Trim();
                    string message = txtmessage.Text.Trim();

                    message = message + "<br/><br/>";
                    int value = 0;
                    if (Txtsendername.Text.Trim() != "")
                    {
                        message = message + "Sender name: " + Txtsendername.Text.Trim();
                        value = 1;
                    }
                    if (txtsenderphone.Text.Trim() != "")
                    {
                        if (value == 0)
                        {
                            message = message + "Sender phone number: " + txtsenderphone.Text.Trim();
                        }
                        else
                        {
                            message = message + "<br/> Sender phone number: " + txtsenderphone.Text.Trim();
                        }
                        value = 1;
                    }
                    if (txtsenderemail.Text.Trim() != "")
                    {
                        if (value == 0)
                        {
                            message = message + "Sender email address: " + txtsenderemail.Text.Trim();
                        }
                        else
                        {
                            message = message + "<br/>Sender email address: " + txtsenderemail.Text.Trim();
                        }
                        value = 1;
                    }


                    Consumer conobj = new Consumer();
                    int Addflag = 0;
                    //For Adding message Ttype = 1 and MSG ID = 0
                    if (Session["RoleID"] != null)
                    {
                        if (Session["RoleID"].ToString() == "2")
                        {
                            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                        }
                    }
                    Addflag = conobj.ManageMessage(Convert.ToInt32(PProfileID), 2, UserID, subject, message, 0, true, 0, UserID, 1,C_UserID);

                    ClearControlPopUp();
                    PnlSendMessages.Visible = false;
                    lbpnlsucess1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    lbpnlsucess2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    //lbpnlsucess.Text = "Your message has been sent successfully. Please click here to continue";
                    lbpnlsucess.Text = "Your message has been sent successfully.";
                    hdnsuccess.Value = "1";
                    PnlSuccess.Visible = true;
                    // *** Notify User for new Message *** //
                    DataTable dtUser = BusObj.GetuserdetailsByProfileID(Convert.ToInt32(PProfileID));
                    if (dtUser.Rows.Count > 0)
                    {
                        SendMessageNotification(dtUser.Rows[0]["Username"].ToString(), dtUser.Rows[0]["Firstname"].ToString());
                    }
                    // *** End Notify User for new Message *** //
                }
                else
                {
                    lblShowError.Text = "<font face=arial color=red size=2>Enter Correct Security Code</font>";
                }
            }
        }
        catch (Exception ex)
        {
            lblShowError.Text = ex.Message;
        }
        Random ran = new Random();
        img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
    }

    # endregion

    # region Login Buttion Click

    protected void Login_Click(object sender, EventArgs e)
    {

        string username = string.Empty;
        string passcode = string.Empty;
        int tmpusrID = 0;
        username = email.Text;
        passcode = EncryptDecrypt.DESEncrypt(password.Text);
        int RoleID = 0;
        DataTable dtobj = new DataTable();
        USPDHUBBLL.Consumer userobj = new USPDHUBBLL.Consumer();
        dtobj = userobj.GetUserDetails(username, Session["VerticalDomain"].ToString());

        if (dtobj != null)
        {
            if (dtobj.Rows.Count == 1)
            {
                if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                {

                    if (passcode.CompareTo(dtobj.Rows[0]["Password"].ToString()) == 0)
                    {
                        //Assign to Session variables 
                        Session["userid"] = dtobj.Rows[0]["User_ID"].ToString();
                        UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                        tmpusrID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                        Session["username"] = dtobj.Rows[0]["Username"].ToString();
                        Session["firstname"] = dtobj.Rows[0]["firstname"].ToString();
                        Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                        RoleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);
                        BusinessBLL busObj = new BusinessBLL();
                        int profid = busObj.GetProfileIDByUserID(UserID);
                        Session["profileid"] = profid;
                        dtobj = userobj.GetForumUserDetails(username);
                        // user tracking                        
                        string test = hdncntrl.Value;
                        if (test != string.Empty)
                        {
                            if (test != "")
                            {
                                if (test == "1")
                                {
                                    lblheader.Text = "Schedule an Appointment";
                                    string businessname = string.Empty;
                                    businessname = busObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                    if (businessname.Length > 0)
                                    {
                                        lblBusiness.Text = " with <font size=2 color=maroon><b>" + businessname + "</b></font>";

                                    }


                                    Schedules ObjSch = new Schedules();
                                    DataTable DtAppts = new DataTable();

                                    PnlLoginControl.Visible = false;
                                    PnlSchAppointment.Visible = true;
                                    string url = string.Empty;
                                    string UrlPath = string.Empty;
                                    if (Request.Url.ToString().Contains("https") == true)
                                    {
                                        UrlPath = ConfigurationManager.AppSettings.Get("RootPath");
                                    }
                                    else
                                    {
                                        UrlPath = ConfigurationManager.AppSettings.Get("OuterRootURL");
                                    }
                                    url = UrlPath + "/Appointments/AppointmentIframe.aspx?PID=" + PProfileID.ToString();
                                    ifrappointments.Attributes["src"] = url;
                                    ifrappointments.Attributes["onload"] = "autoIframe()";

                                }
                                else if (test == "2")
                                {
                                    if (PProfileID != profid.ToString())
                                    {
                                        
                                        lblsendmessprofilename.Text = "Send message to <font color=maroon size=2 face=arial>" + busObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                        PnlLoginControl.Visible = false;
                                        PnlSendMessages.Visible = true;
                                        hdnsuccess.Value = "1";
                                    }
                                    else
                                    {
                                        // lblSameProfileerror.Text = "You cannot send a message to yourself. Please click here to continue.";
                                        lblSameProfileerror.Text = "You cannot send a message to yourself.";
                                        PnlLoginControl.Visible = false;
                                        PnlError.Visible = true;
                                        hdnsuccess.Value = "1";
                                    }

                                }
                                else if (test == "3")
                                {
                                    if (PProfileID != profid.ToString())
                                    {
                                        string businessname = string.Empty;
                                        businessname = busObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                        lblprofilename.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                        txtfavoritename.Text = businessname;
                                        PnlLoginControl.Visible = false;
                                        PnlAddFav.Visible = true;
                                        hdnsuccess.Value = "2";
                                    }
                                    else
                                    {
                                        PnlLoginControl.Visible = false;
                                        //lblSameProfileerror.Text = "You cannot add your own business to the list of favorites. Please click here to continue.";
                                        lblSameProfileerror.Text = "You cannot add your own business to the list of favorites.";
                                        PnlError.Visible = true; hdnsuccess.Value = "1";
                                    }
                                }
                                else if (test == "4")
                                {
                                    if (PProfileID != profid.ToString())
                                    {
                                        lbladdreviewprofilename.Text = "Add a testimonial for <font color=maroon size=2 face=arial>" + busObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID)) + "<font>";
                                        string theFunction = @"<script language=javascript>
                                                                  function textCounter(field, countfield, maxlimit) 
                                                                  {
                                                                        if (field.value.length > maxlimit)
                                                                            field.value = field.value.substring(0, maxlimit);
                                                                        else
                                                                            countfield.value = maxlimit - field.value.length;
                                                                        }
                                                                    </script>";
                                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", theFunction);
                                        string theFunction1 = "javascript:textCounter(" + txtcomments.ClientID + "," + txtCount.ClientID + "," + txtcomments.MaxLength.ToString() + ");";

                                        txtcomments.Attributes.Add("onKeyDown", theFunction1);
                                        txtcomments.Attributes.Add("onKeyUp", theFunction1);
                                        txtCount.Text = Convert.ToString(txtcomments.MaxLength - txtcomments.Text.Length);
                                        PnlLoginControl.Visible = false;
                                        PnlAddReviews.Visible = true;
                                    }
                                    else
                                    {
                                        PnlLoginControl.Visible = false;
                                        //lblSameProfileerror.Text = "You cannot add a review to your own business. Please click here to continue.";
                                        lblSameProfileerror.Text = "You cannot add a testimonial for your own business.";
                                        PnlError.Visible = true; hdnsuccess.Value = "1";
                                    }

                                }
                                else if (test == "5")
                                {
                                    if (RoleID.ToString() != "1")
                                    {
                                        if (PProfileID != profid.ToString())
                                        {
                                            FlagAffiliate = busObj.VerifyAffiliateDetailsByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()), Convert.ToInt32(PProfileID));
                                            if (FlagAffiliate > 0)
                                            {
                                                PnlLoginControl.Visible = false;
                                                PnlError.Visible = true; hdnsuccess.Value = "1";
                                                //lblSameProfileerror.Text = "This member is already listed in your network. Please click here to continue.";
                                                lblSameProfileerror.Text = "This member is already listed in your network.";
                                            }
                                            else
                                            {
                                                lblmsg.Text = "";
                                                string businessname = string.Empty;
                                                businessname = BusObj.GetBusinessNameByProfileID(Convert.ToInt32(PProfileID));
                                                lblprofilename1.Text = "<font color=maroon size=2 face=arial>" + businessname + "</font>";
                                                dtuser = BusObj.GetuserdetailsByProfileID(Convert.ToInt32(PProfileID));
                                                if (dtuser.Rows.Count > 0)
                                                {
                                                    txtaffiliate.Text = dtuser.Rows[0]["Firstname"].ToString();
                                                    txtemail.Text = dtuser.Rows[0]["Username"].ToString();
                                                }

                                                UserID = Convert.ToInt32(Session["UserID"]);
                                                //Get the name of this user.
                                                Consumer conObj = new Consumer();
                                                DataTable dtobj1 = new DataTable();
                                                dtobj1 = conObj.GetUserDetailsByID(UserID);
                                                if (dtobj1.Rows.Count == 1)
                                                {
                                                    useremail = dtobj1.Rows[0]["Username"].ToString();
                                                    if ((dtobj1.Rows[0]["Lastname"].ToString().Length > 1) && (dtobj1.Rows[0]["Firstname"].ToString().Length > 1))
                                                        Sendername = dtobj1.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj1.Rows[0]["Firstname"].ToString().Substring(1, dtobj1.Rows[0]["Firstname"].ToString().Length - 1) + " " + dtobj1.Rows[0]["Lastname"].ToString().Substring(0, 1).ToUpper() + dtobj1.Rows[0]["Lastname"].ToString().Substring(1, dtobj1.Rows[0]["Lastname"].ToString().Length - 1);
                                                    else if ((dtobj1.Rows[0]["Firstname"].ToString().Length > 1))
                                                        Sendername = dtobj1.Rows[0]["Firstname"].ToString().Substring(0, 1).ToUpper() + dtobj1.Rows[0]["Firstname"].ToString().Substring(1, dtobj1.Rows[0]["Firstname"].ToString().Length - 1);
                                                    else
                                                        Sendername = "";
                                                }
                                                sname = Sendername.ToUpper() + " has sent you an Affiliate Invitation";
                                                //txtsubject.Text = "";
                                                PnlLoginControl.Visible = false;
                                                PnlJoinMyNetwork.Visible = true;
                                                hdnsuccess.Value = "2";
                                            }
                                        }
                                        else
                                        {
                                            //lblSameProfileerror.Text = "You cannot send an invitation to yourself. Please click here to continue.";
                                            lblSameProfileerror.Text = "You cannot send an invitation to yourself.";
                                            PnlLoginControl.Visible = false;
                                            PnlError.Visible = true; hdnsuccess.Value = "1";
                                        }
                                    }
                                    else
                                    {
                                        PnlLoginControl.Visible = false;
                                        PnlError.Visible = true; hdnsuccess.Value = "1";
                                        //lblSameProfileerror.Text = "Being a consumer you cannot send affiliate invitations. Please click here to continue.";
                                        lblSameProfileerror.Text = "Being a consumer you cannot send affiliate invitations.";
                                    }

                                }
                                else if (test == "7")
                                {
                                    PnlLoginControl.Visible = false;
                                    Pnlsavesearchresults.Visible = true;
                                }


                            }
                        }



                    }
                    else
                    {
                        lblmsg.Text = "<font face=arial color=red size=2>Invalid password. Please try again..!</font>";

                    }
                }
                else
                {
                    string activationCode = string.Empty;
                    BusinessBLL objBus = new BusinessBLL();
                    activationCode = objBus.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                    if (activationCode != "")
                    {
                        lblmsg.Text = "<font face=arial color=red size=2> Your account is not yet activated. Please check your email (<b style='color:Green'> " + dtobj.Rows[0]["username"].ToString() + "</b> ) to activate your USPDhub Account.";
                    }
                    else
                    {
                        lblmsg.Text = "<font face=arial color=red size=2> Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + username + "'>click here</a> to start new Registration...!";
                    }
                }
            }
            else
            {
                lblmsg.Text = "<font face=arial color=red size=2>Invalid Login Name & Password <BR>Please try again </font>";
            }
        }
        else
        {
            lblmsg.Text = "<font face=arial color=red size=2>Invalid Login Name & Password</font>";
        }

    }
    protected void lblDifferentUser_Click(object sender, EventArgs e)
    {

        HttpCookie obj = new HttpCookie("wowzzyUserId");
        obj = Request.Cookies["wowzzyUserID"];
        if (obj != null)
        {
            if (obj.Value != string.Empty)
            {
                obj.Value = string.Empty;
                obj.Expires = DateTime.Now;
                Response.Cookies.Add(obj);
                email.Text = "";
            }
        }
        else
        {
            email.Text = "";
            password.Text = "";
            lblmsg.Text = "";
        }
        HttpContext.Current.Response.Cookies.Set(obj);
        string urlinfo = Page.ResolveClientUrl("~");
        Response.Redirect(urlinfo + "login.aspx");
        HttpCookieCollection objcoll = new HttpCookieCollection();
        objcoll.Clear();

    }


    # endregion


    protected void imclose_Click(object sender, ImageClickEventArgs e)
    {
        lbpnlsucess2.Text = "";
        lbpnlsucess1.Text = "";
        Session["hdnValue"] = null;
        Random ran = new Random();
        hdnclose1.Value = "1";
        //hdnclose.Value = "1";
        img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
        ClearControlPopUp();


    }


    # region Clear Controls

    private void ClearControlPopUp()
    {
        email.Text = "";
        password.Text = "";
        txtname.Text = "";
        txtcomments.Text = "";
        txtsendmessubject.Text = "";
        txtmessage.Text = "";
        Review1.SelectedIndex = -1;
        Review2.SelectedIndex = -1;
        Review3.SelectedIndex = -1;
        txtsenderemail.Text = "";
        Txtsendername.Text = "";
        txtsenderphone.Text = "";
        txtcaptcha.Text = "";
        lblShowError.Text = "";


    }

    # endregion


    # region Save Search Results
    protected void btnsavesearch_Click(object sender, EventArgs e)
    {

        string favoritename = txtsearchname.Text.Trim();
        string Criteria = string.Empty;
        if (Session["whtwhe"] != null)
        {
            Criteria = Session["whtwhe"].ToString();
            Session["whtwhe"] = null;
        }

        Consumer conobj = new Consumer();
        int Addflag = 0;
        DataTable dtvalidate = new DataTable();
        dtvalidate = conobj.ValidateSavedSearch(favoritename, UserID);
        if (dtvalidate.Rows.Count > 0)
        {
            Pnlsavesearchresults.Visible = true;
            lblsavesearch.Text = "You already have a search result saved with this name. Please choose a different name.";
        }
        else
        {
            Addflag = conobj.ManageSavedSearchDetails(favoritename, Criteria, UserID, 1, 0);
            Pnlsavesearchresults.Visible = false;
            PnlSuccess.Visible = true;
            lblsavesearch.Text = "";
            //lbpnlsucess.Text = "Your search results has been saved successfully. Click here to continue.";
            lbpnlsucess.Text = "Your search results has been saved successfully.";
        }



    }

    # endregion
    private void SendMessageNotification(string Email1, string ReceiverName)
    {
        string RootPath = ConfigurationManager.AppSettings.Get("SRootPath");
        string strfilepath = Server.MapPath("~") + "\\EmailContent" + Session["VerticalDomain"].ToString() + "\\";
        StreamReader re = File.OpenText(strfilepath + "NotifyMessages.txt");
        string msgbody = string.Empty;
        msgbody = "<html><head>";
        msgbody = msgbody + "<link href=" + RootPath + "/css/wowzzy_general.css rel='stylesheet' type='text/css' />";
        msgbody = msgbody + "</head><body><table width='100%' border='0' align='center' style='padding:10px;'><tr><td>";
        msgbody = msgbody + "<img src=" + RootPath + "/images/wowlogo.gif /><br><br></td></tr>";
        msgbody = msgbody + "<br><br><tr><td><table width='470px' border='0'><tr><td nowrap>";
        msgbody = msgbody + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'>";
        msgbody = msgbody + "<br><strong   style='color:#B3B3B3;'>This is an Automated Email from USPDhub.com. Please do not reply to it.</strong><br>";
        msgbody = msgbody + "<HR size='1' style='color: #fff; background-color: #fff; border: 1px dotted #025586; border-style: none none dotted;'><br><br></td></tr></table></td></tr><tr><td>";
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            msgbody = msgbody + input + "<BR>";
        }

        msgbody = msgbody + "<br><br></td></tr>";
        msgbody = msgbody + "<tr style='color:#B3B3B3;'><td><strong style='color: #0071B3'>Disclaimer Notice:</strong><br><br>This email and its attachments may be confidential and are intended solely for the use of the individual to whom it is addressed. Any views or opinions expressed are solely those of the author and do not necessarily represent those of USPDhub.com.<br><br>If you are not the intended recipient of this email and its attachments, you must take no action based upon them, nor must you copy or show them to anyone.<br><br>Please contact <u style='color: #0071B3'>info@uspdhub.com</u>  if you believe you have received this email in error and you would like to be taken off our email list.</td></tr><br><br>";
        msgbody = msgbody + "</html></body></td><tr></table></body></html>";
        msgbody = msgbody.Replace("#ReceiverName#", ReceiverName);
        msgbody = msgbody.Replace("#Memberlogin#", "<a href='" + RootPath + "/Login.aspx' target=_new>" + ConfigurationManager.AppSettings.Get("AppointmentloginText") + "</a>");
        re.Close();
        re.Dispose();
        string ccemail = string.Empty;
        string returnval = string.Empty;
        USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
        returnval = utlobj.SendWowzzyEmail(ConfigurationManager.AppSettings.Get("Emailinfo1"), Email1, "You have new messages waiting", msgbody, ccemail,"", Session["VerticalDomain"].ToString());

    }
}
