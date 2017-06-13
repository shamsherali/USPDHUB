namespace USPDHubClientAlerts
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.gbsetting = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.txtTipsCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtMessagesCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMins = new System.Windows.Forms.Label();
            this.gbsetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule an automatic notification check every:";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(15, 21);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(58, 23);
            this.lblErrorMessage.TabIndex = 2;
            this.lblErrorMessage.Text = "Message";
            this.lblErrorMessage.UseCompatibleTextRendering = true;
            // 
            // gbsetting
            // 
            this.gbsetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbsetting.Controls.Add(this.lblMins);
            this.gbsetting.Controls.Add(this.btnCancel);
            this.gbsetting.Controls.Add(this.cmbTime);
            this.gbsetting.Controls.Add(this.txtTipsCount);
            this.gbsetting.Controls.Add(this.label5);
            this.gbsetting.Controls.Add(this.btnUpdate);
            this.gbsetting.Controls.Add(this.txtMessagesCount);
            this.gbsetting.Controls.Add(this.label2);
            this.gbsetting.Controls.Add(this.lblErrorMessage);
            this.gbsetting.Controls.Add(this.label1);
            this.gbsetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbsetting.Location = new System.Drawing.Point(17, 37);
            this.gbsetting.Name = "gbsetting";
            this.gbsetting.Size = new System.Drawing.Size(621, 212);
            this.gbsetting.TabIndex = 0;
            this.gbsetting.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "45",
            "60"});
            this.cmbTime.Location = new System.Drawing.Point(327, 47);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(100, 25);
            this.cmbTime.TabIndex = 9;
            // 
            // txtTipsCount
            // 
            this.txtTipsCount.Location = new System.Drawing.Point(327, 110);
            this.txtTipsCount.MaxLength = 3;
            this.txtTipsCount.Name = "txtTipsCount";
            this.txtTipsCount.Size = new System.Drawing.Size(100, 25);
            this.txtTipsCount.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Number of tips to display:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(326, 174);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtMessagesCount
            // 
            this.txtMessagesCount.Location = new System.Drawing.Point(327, 79);
            this.txtMessagesCount.MaxLength = 3;
            this.txtMessagesCount.Name = "txtMessagesCount";
            this.txtMessagesCount.Size = new System.Drawing.Size(100, 25);
            this.txtMessagesCount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of messages to display:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(13, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.gbsetting);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 284);
            this.panel1.TabIndex = 2;
            // 
            // lblMins
            // 
            this.lblMins.AutoSize = true;
            this.lblMins.Location = new System.Drawing.Point(434, 52);
            this.lblMins.Name = "lblMins";
            this.lblMins.Size = new System.Drawing.Size(58, 19);
            this.lblMins.TabIndex = 11;
            this.lblMins.Text = "minutes";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 307);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbsetting.ResumeLayout(false);
            this.gbsetting.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox gbsetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessagesCount;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMins;

    }
}