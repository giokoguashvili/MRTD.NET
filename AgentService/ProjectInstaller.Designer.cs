namespace AgentService
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
            this.agentServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.agentServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // agentServiceProcessInstaller
            // 
            this.agentServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.agentServiceProcessInstaller.Password = null;
            this.agentServiceProcessInstaller.Username = null;
            // 
            // agentServiceInstaller
            // 
            this.agentServiceInstaller.ServiceName = "AgentService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.agentServiceProcessInstaller,
            this.agentServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller agentServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller agentServiceInstaller;
    }
}