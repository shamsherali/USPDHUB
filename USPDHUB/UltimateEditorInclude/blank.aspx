<%@ Page Language="C#" ValidateRequest="false" %>
<html>
    <head id="Head1" runat="server">
        <title></title>
        <base id="Base1" runat="server" />
        
        <script runat="server">
            protected void Page_Load(object sender, EventArgs e)
            {
                Base1.Attributes.Add("href", Request.QueryString["p"]);
            }
        </script>
    </head>
    <body>
    </body>
</html>
