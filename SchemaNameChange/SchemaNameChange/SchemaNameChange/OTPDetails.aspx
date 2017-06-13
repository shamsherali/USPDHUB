<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OTPDetails.aspx.cs" Inherits="SchemaNameChange.OTPDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <style>
        .btn
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 7px 15px 7px 15px;
            text-decoration: none;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        
        body
        {
            font-family: Segoe UI;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <h3>OTP Details</h3>
     
    </div>
    <table  width="700" style="padding: 17px;" border="1px solid black">
       
             <tr>
                <td align="center" >
                    <asp:GridView ID="grdOPTDetails" runat="server" AutoGenerateColumns="False" 
                         Font-Size = "11pt" ShowHeaderWhenEmpty="True" 
                        HeaderStyle-ForeColor="Black" CellPadding="4" 
                        GridLines="None" Width="623px" ForeColor="#333333"  >
                             <EditRowStyle BackColor="#2461BF" />
                             <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                             <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="OTPID">
                          
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblOTPID" Text='<%#Eval("OTPID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OTP">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblOTP" Text='<%#Eval("OTP")%>' Font-Bold="true"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="BDID">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBDID" Text='<%#Eval("BDID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Mobile Number">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblMblNum" Text='<%#Eval("MobileNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Email ID">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblMailId" Text='<%#Eval("EmailID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblName" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Module Type" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblName" Text='<%#Eval("ModuleType")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                          <EmptyDataTemplate>
                            No Data Found
                        </EmptyDataTemplate>
                             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#EFF3FB" />
                             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#F5F7FB" />
                             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                             <SortedDescendingCellStyle BackColor="#E9EBEF" />
                             <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
               
                <td  align="center" valign="top">
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                        onclick="btnRefresh_Click" Width="75px" style="font-family: Arial; background-color:#99ccff; font-size: 16px;text-decoration: none;"/>
                </td>
            </tr>
       
    </table>
   
    </form>
</body>
</html>
