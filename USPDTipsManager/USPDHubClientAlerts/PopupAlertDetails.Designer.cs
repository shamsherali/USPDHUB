namespace USPDHubClientAlerts
{
    partial class PopupAlertDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupAlertDetails));
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.GBMessage = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.panelUsername = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblContactEmail = new System.Windows.Forms.Label();
            this.panelPhoneNumber = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.panelMessage = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.TextBox();
            this.panelLocation = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.TextBox();
            this.panelImage = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.GBMessage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panelUsername.SuspendLayout();
            this.panelEmail.SuspendLayout();
            this.panelPhoneNumber.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.panelLocation.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(374, 12);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(155, 3, 3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 28);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // GBMessage
            // 
            this.GBMessage.AutoSize = true;
            this.GBMessage.Controls.Add(this.flowLayoutPanel1);
            this.GBMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GBMessage.Location = new System.Drawing.Point(15, 46);
            this.GBMessage.Name = "GBMessage";
            this.GBMessage.Size = new System.Drawing.Size(439, 576);
            this.GBMessage.TabIndex = 5;
            this.GBMessage.TabStop = false;
            this.GBMessage.Text = "groupBox1";
            this.GBMessage.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.panelUsername);
            this.flowLayoutPanel1.Controls.Add(this.panelEmail);
            this.flowLayoutPanel1.Controls.Add(this.panelPhoneNumber);
            this.flowLayoutPanel1.Controls.Add(this.panelMessage);
            this.flowLayoutPanel1.Controls.Add(this.panelLocation);
            this.flowLayoutPanel1.Controls.Add(this.panelImage);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(416, 527);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblSubject);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(410, 30);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.ForeColor = System.Drawing.Color.Green;
            this.lblSubject.Location = new System.Drawing.Point(5, 2);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(80, 20);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Subject: ";
            // 
            // panelUsername
            // 
            this.panelUsername.Controls.Add(this.label4);
            this.panelUsername.Controls.Add(this.lblUserName);
            this.panelUsername.Location = new System.Drawing.Point(3, 39);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Padding = new System.Windows.Forms.Padding(2);
            this.panelUsername.Size = new System.Drawing.Size(410, 25);
            this.panelUsername.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "User Name:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(131, 2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 19);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username";
            // 
            // panelEmail
            // 
            this.panelEmail.Controls.Add(this.label5);
            this.panelEmail.Controls.Add(this.lblContactEmail);
            this.panelEmail.Location = new System.Drawing.Point(3, 70);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(410, 25);
            this.panelEmail.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Contact Email:";
            // 
            // lblContactEmail
            // 
            this.lblContactEmail.AutoSize = true;
            this.lblContactEmail.Location = new System.Drawing.Point(129, 0);
            this.lblContactEmail.Name = "lblContactEmail";
            this.lblContactEmail.Size = new System.Drawing.Size(93, 19);
            this.lblContactEmail.TabIndex = 4;
            this.lblContactEmail.Text = "Contact Email";
            // 
            // panelPhoneNumber
            // 
            this.panelPhoneNumber.Controls.Add(this.label6);
            this.panelPhoneNumber.Controls.Add(this.lblPhoneNumber);
            this.panelPhoneNumber.Location = new System.Drawing.Point(3, 101);
            this.panelPhoneNumber.Name = "panelPhoneNumber";
            this.panelPhoneNumber.Size = new System.Drawing.Size(410, 25);
            this.panelPhoneNumber.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phone Number:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(129, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(102, 19);
            this.lblPhoneNumber.TabIndex = 6;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // panelMessage
            // 
            this.panelMessage.Controls.Add(this.label7);
            this.panelMessage.Controls.Add(this.lblMessage);
            this.panelMessage.Location = new System.Drawing.Point(3, 132);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(410, 75);
            this.panelMessage.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Message:";
            // 
            // lblMessage
            // 
            this.lblMessage.AcceptsReturn = true;
            this.lblMessage.AcceptsTab = true;
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMessage.Location = new System.Drawing.Point(129, 3);
            this.lblMessage.Multiline = true;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.ReadOnly = true;
            this.lblMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblMessage.Size = new System.Drawing.Size(277, 58);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.TabStop = false;
            // 
            // panelLocation
            // 
            this.panelLocation.Controls.Add(this.label9);
            this.panelLocation.Controls.Add(this.lblLocation);
            this.panelLocation.Location = new System.Drawing.Point(0, 213);
            this.panelLocation.Name = "panelLocation";
            this.panelLocation.Size = new System.Drawing.Size(413, 66);
            this.panelLocation.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Location:";
            // 
            // lblLocation
            // 
            this.lblLocation.AcceptsReturn = true;
            this.lblLocation.AcceptsTab = true;
            this.lblLocation.BackColor = System.Drawing.SystemColors.Control;
            this.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblLocation.Location = new System.Drawing.Point(129, 3);
            this.lblLocation.Multiline = true;
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.ReadOnly = true;
            this.lblLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblLocation.Size = new System.Drawing.Size(277, 58);
            this.lblLocation.TabIndex = 13;
            this.lblLocation.TabStop = false;
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBox1);
            this.panelImage.Location = new System.Drawing.Point(0, 285);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(413, 250);
            this.panelImage.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(395, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel4.Controls.Add(this.btnClose);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 541);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(413, 35);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Location = new System.Drawing.Point(155, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(155, 3, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PopupAlertDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(474, 618);
            this.Controls.Add(this.GBMessage);
            this.Controls.Add(this.btnPrint);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "PopupAlertDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            this.Load += new System.EventHandler(this.PopupAlertDetails_Load);
            this.GBMessage.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panelUsername.ResumeLayout(false);
            this.panelUsername.PerformLayout();
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.panelPhoneNumber.ResumeLayout(false);
            this.panelPhoneNumber.PerformLayout();
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.panelLocation.ResumeLayout(false);
            this.panelLocation.PerformLayout();
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.GroupBox GBMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.FlowLayoutPanel panelUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.FlowLayoutPanel panelEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblContactEmail;
        private System.Windows.Forms.FlowLayoutPanel panelPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.FlowLayoutPanel panelMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel panelLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lblLocation;
        private System.Windows.Forms.FlowLayoutPanel panelImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox lblMessage;

    }
}