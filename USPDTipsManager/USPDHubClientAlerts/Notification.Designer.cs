namespace USPDHubClientAlerts
{
    partial class Notification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.imgNotify = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.imgClose = new System.Windows.Forms.PictureBox();
            this.lblMore = new System.Windows.Forms.Label();
            this.lblNoMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgNotify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "USPD Message Center";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // imgNotify
            // 
            this.imgNotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgNotify.Image = ((System.Drawing.Image)(resources.GetObject("imgNotify.Image")));
            this.imgNotify.Location = new System.Drawing.Point(11, 12);
            this.imgNotify.Name = "imgNotify";
            this.imgNotify.Size = new System.Drawing.Size(50, 50);
            this.imgNotify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgNotify.TabIndex = 6;
            this.imgNotify.TabStop = false;
            this.imgNotify.Click += new System.EventHandler(this.imgNotify_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(79, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(40, 15);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "label1";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubject.Location = new System.Drawing.Point(80, 30);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(38, 15);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "label1";
            // 
            // imgClose
            // 
            this.imgClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgClose.Image = ((System.Drawing.Image)(resources.GetObject("imgClose.Image")));
            this.imgClose.Location = new System.Drawing.Point(279, 3);
            this.imgClose.Name = "imgClose";
            this.imgClose.Size = new System.Drawing.Size(16, 16);
            this.imgClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgClose.TabIndex = 10;
            this.imgClose.TabStop = false;
            this.imgClose.Click += new System.EventHandler(this.imgClose_Click);
            // 
            // lblMore
            // 
            this.lblMore.AutoSize = true;
            this.lblMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMore.Location = new System.Drawing.Point(76, 73);
            this.lblMore.Name = "lblMore";
            this.lblMore.Size = new System.Drawing.Size(38, 15);
            this.lblMore.TabIndex = 11;
            this.lblMore.Text = "label1";
            this.lblMore.Visible = false;
            // 
            // lblNoMessages
            // 
            this.lblNoMessages.AutoSize = true;
            this.lblNoMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoMessages.Location = new System.Drawing.Point(95, 30);
            this.lblNoMessages.Name = "lblNoMessages";
            this.lblNoMessages.Size = new System.Drawing.Size(52, 17);
            this.lblNoMessages.TabIndex = 12;
            this.lblNoMessages.Text = "label1";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(298, 98);
            this.ControlBox = false;
            this.Controls.Add(this.lblNoMessages);
            this.Controls.Add(this.lblMore);
            this.Controls.Add(this.imgClose);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.imgNotify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Notification";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.imgNotify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox imgNotify;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.PictureBox imgClose;
        private System.Windows.Forms.Label lblMore;
        private System.Windows.Forms.Label lblNoMessages;

    }
}