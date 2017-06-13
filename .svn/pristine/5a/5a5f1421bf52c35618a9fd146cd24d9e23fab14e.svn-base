<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PushNotify.aspx.cs" Inherits="IOSPush.PushNotify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function insert(item, user, request) {
            var payload = {
                "data": {
                    "message": item.message

                },
            };
            request.execute({
                success: function () {
                    setTimeout(function () {
                        push.gcm.createNativeRegistration('APA91bH2qvUjPWVPWKFaMD2zpVyBWsfnAiVQQDQ0W5zI1ct4UGnWz27ztSn5haEzcoK4utKYPJIu7eeFSLsBru-Zdr4dKbn52fCBnDzXE-h3r0S8DOJZ3H6fkO-lIp93EreTdFZ4xhPY', "PID:10151", {

                            success: function (resp) {
                                setTimeout(function () {
                                    var legacyGcm = require('dpush');
                                    //API Key,RegID
                                    legacyGcm.send("AIzaSyB-idC6BK6ieTa_dfeyXymiTyoWSdVWDXA", "APA91bH2qvUjPWVPWKFaMD2zpVyBWsfnAiVQQDQ0W5zI1ct4UGnWz27ztSn5haEzcoK4utKYPJIu7eeFSLsBru-Zdr4dKbn52fCBnDzXE-h3r0S8DOJZ3H6fkO-lIp93EreTdFZ4xhPY", item, function (error, response) {
                                        if (!error) {
                                            console.log("Sent push:", payload);
                                            request.respond();
                                        } else {

                                            console.error(error, item.message)
                                        };
                                    });
                                }, 2500);


                            },
                            error: function (err) {
                                console.error(err, item.message)
                            }

                        });

                    }, 2500);


                }

            });

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            User Id 
            <asp:TextBox runat="server" ID="txtUserID"></asp:TextBox>

            <br />


            Profile ID 
            <asp:TextBox runat="server" ID="txtProfileID"></asp:TextBox>
            <br />

            Message  
            <asp:TextBox runat="server" ID="txtText"></asp:TextBox>
            <br />

            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" />
            <br />
            <asp:Label runat="server" ID="lblmsg"></asp:Label>
        </div>
    </form>
</body>
</html>


