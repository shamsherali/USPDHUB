namespace SendSMSNotifications
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendSMSserviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SendSMSserviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SendSMSserviceProcessInstaller
            // 
            this.SendSMSserviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SendSMSserviceProcessInstaller.Password = null;
            this.SendSMSserviceProcessInstaller.Username = null;
            // 
            // SendSMSserviceInstaller
            // 
            this.SendSMSserviceInstaller.ServiceName = "USPDhubSendSMS";
            this.SendSMSserviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SendSMSserviceProcessInstaller,
            this.SendSMSserviceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SendSMSserviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SendSMSserviceInstaller;
    }
}