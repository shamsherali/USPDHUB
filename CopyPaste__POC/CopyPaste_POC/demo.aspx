<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="CopyPaste_POC.demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script>

        /*  Button On Click Functions Using JQuery */
        $(document).ready(function () {

            var db = openDatabase("Demo_Ext", "1.0", "Demo_Ext", 200000);  // Open SQLite Database

            var dataset;
            var DataType;

            initDatabase();

            function initDatabase()  // Function Call When Page is ready.
            {

                db.transaction(function (tx) {

                    tx.executeSql('CREATE TABLE IF NOT EXISTS UserList (firstname unique, lastname, companyname)');

                    //showRecords();

                }); //tx


                db.transaction(function (tx) {

                    tx.executeSql('INSERT INTO UserList (firstname,lastname,companyname) VALUES("Balaji","Mada","LT")');

                    showRecords();

                }); //tx

                //showRecords();

            }


            function showRecords() // Function For Retrive data from Database Display records as list
            {

                db.transaction(function (tx) {


                    try {
                        tx.executeSql("SELECT * FROM UserList", [], function (tx, result) {

                            dataset = result.rows;


                            for (var i = 0, item = null; i < dataset.length; i++) {

                                item = dataset.item(i);

                                var linkeditdelete = '<li>' + item['username'] + ' , ' + item['useremail'] + '    ' + '<a href="#" onclick="loadRecord(' + i + ');">edit</a>' + '    ' +

                                            '<a href="#" onclick="deleteRecord(' + item['id'] + ');">delete</a></li>';

                                $("#results").text(linkeditdelete);

                            }

                        }); //tx
                    }

                    catch (e) {
                        console.log(e);
                    }


                }); //db.



            } // END
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="results">
    </div>
    </form>
</body>
</html>
