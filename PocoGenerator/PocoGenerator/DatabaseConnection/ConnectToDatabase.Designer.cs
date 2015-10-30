namespace PocoGenerator.DatabaseConnection
{
    partial class ConnectToDatabase
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
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblAuthenticationType = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblSelectDatabase = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbAuthenticationType = new System.Windows.Forms.ComboBox();
            this.cmbSelectDatabase = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(12, 9);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(91, 17);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name";
            this.lblServerName.Click += new System.EventHandler(this.lblServerName_Click);
            // 
            // lblAuthenticationType
            // 
            this.lblAuthenticationType.AutoSize = true;
            this.lblAuthenticationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthenticationType.Location = new System.Drawing.Point(12, 38);
            this.lblAuthenticationType.Name = "lblAuthenticationType";
            this.lblAuthenticationType.Size = new System.Drawing.Size(134, 17);
            this.lblAuthenticationType.TabIndex = 1;
            this.lblAuthenticationType.Text = "Authentication Type";
            this.lblAuthenticationType.Click += new System.EventHandler(this.lblAuthenticationType_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 68);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(79, 17);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            this.lblUserName.Click += new System.EventHandler(this.lblUserName_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(12, 97);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // lblSelectDatabase
            // 
            this.lblSelectDatabase.AutoSize = true;
            this.lblSelectDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDatabase.Location = new System.Drawing.Point(12, 127);
            this.lblSelectDatabase.Name = "lblSelectDatabase";
            this.lblSelectDatabase.Size = new System.Drawing.Size(112, 17);
            this.lblSelectDatabase.TabIndex = 4;
            this.lblSelectDatabase.Text = "Select Database";
            this.lblSelectDatabase.Click += new System.EventHandler(this.lblSelectDatabase_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(166, 9);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(279, 22);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Text = "(localdb)\\MSSQLLocalDB";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(166, 69);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(279, 22);
            this.txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(166, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(279, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // cmbAuthenticationType
            // 
            this.cmbAuthenticationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthenticationType.FormattingEnabled = true;
            this.cmbAuthenticationType.Location = new System.Drawing.Point(166, 38);
            this.cmbAuthenticationType.Name = "cmbAuthenticationType";
            this.cmbAuthenticationType.Size = new System.Drawing.Size(222, 24);
            this.cmbAuthenticationType.TabIndex = 2;
            this.cmbAuthenticationType.SelectedIndexChanged += new System.EventHandler(this.cmbAuthenticationType_SelectedIndexChanged);
            // 
            // cmbSelectDatabase
            // 
            this.cmbSelectDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectDatabase.FormattingEnabled = true;
            this.cmbSelectDatabase.Location = new System.Drawing.Point(166, 127);
            this.cmbSelectDatabase.Name = "cmbSelectDatabase";
            this.cmbSelectDatabase.Size = new System.Drawing.Size(279, 24);
            this.cmbSelectDatabase.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(289, 178);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 28);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(12, 178);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(125, 28);
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(451, 127);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ConnectToDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 213);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbSelectDatabase);
            this.Controls.Add(this.cmbAuthenticationType);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblSelectDatabase);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblAuthenticationType);
            this.Controls.Add(this.lblServerName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To Database...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectToDatabase_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblAuthenticationType;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblSelectDatabase;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbAuthenticationType;
        private System.Windows.Forms.ComboBox cmbSelectDatabase;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnRefresh;
    }
}