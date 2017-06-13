<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_Sitemaplinks" Codebehind="Sitemaplinks.ascx.cs" %>
  <%--<table width="100%" border="0" cellpadding="0" cellspacing="0" class="breadcrumb">
    <tr>
      <td>
        <%
        string tmpvarpath = Request.Url.ToString();
        if (tmpvarpath.Contains("/Business/"))
        { %>
         Dashboard 
       <%}
         else if (tmpvarpath.Contains("/Appointments/"))
         {%>
            Dashboard    
           <% }
              else if (tmpvarpath.Contains("/Consumer/"))
              { %> 
             
             Dashboard
       <%}
         else if (tmpvarpath.Contains("/WowzzyAds/"))
         {%>
              
             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Business/MyAccount/Default.aspx">Dashboard</asp:HyperLink> > 
       <%}
         else if (tmpvarpath.Contains("/Coupons/"))
         {%>
             Dashboard
            
      <%  if (Session["userid"] != null && Session["RoleID"] != null) // Check for session
             {
                 if (Session["RoleID"].ToString() == "2" )  // check for business 
                 { 
                 %>
                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Business/MyAccount/Default.aspx">Dashboard</asp:HyperLink> >
                 <% }
                    else if (Session["RoleID"].ToString() == "1")  // check for Consumer 
                    { 
                 %>  
                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Consumer/MyAccount/Default.aspx">Dashboard</asp:HyperLink> >
                   
                 <% } 
            }%>
            
        <%}
          else if (tmpvarpath.Contains("/News/"))
          {%>
              News
        <%}
          else if (tmpvarpath.Contains("/Admin/"))
          {%>
              Administration
        <%}
          else if (tmpvarpath.Contains("/Forums/"))
          {%>
              Forums
              <%}
                else if (tmpvarpath.Contains("/DefaultHTML.aspx"))
                { %>    
             
             <asp:HyperLink ID="HyperLink12" runat="server">Business Category</asp:HyperLink>
                
        <%}
          else if (tmpvarpath.Contains("/BusinessSubCategoryItems.aspx"))
          { %>   
             <asp:HyperLink ID="HyperLink13" runat="Server" NavigateUrl="~/DefaultHTML.aspx">Business Category</asp:HyperLink> > Sub Categories
              
          <%}
            else if (tmpvarpath.Contains("/BusinessSubCategories.aspx"))
            { %>
          
             <asp:HyperLink ID="HyperLink15" runat="Server" NavigateUrl="~/DefaultHTML.aspx">Business Category</asp:HyperLink>
             <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/BusinessSubCategoryItems.aspx"> > Sub Categories</asp:HyperLink> > Business Profiles
              
        <%}
          else
          {%>
            
        <%} %>    
     
       </td>
    </tr>
  </table>--%>
