namespace PocoGenerator
{
    partial class PocoGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocoGenerator));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.scBody = new System.Windows.Forms.SplitContainer();
            this.tvDatabase = new System.Windows.Forms.TreeView();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.pnlMenuBar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).BeginInit();
            this.scBody.Panel1.SuspendLayout();
            this.scBody.Panel2.SuspendLayout();
            this.scBody.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.scBody);
            this.pnlBody.Location = new System.Drawing.Point(0, 35);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1282, 818);
            this.pnlBody.TabIndex = 3;
            // 
            // scBody
            // 
            this.scBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scBody.Location = new System.Drawing.Point(0, 0);
            this.scBody.Name = "scBody";
            // 
            // scBody.Panel1
            // 
            this.scBody.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.scBody.Panel1.Controls.Add(this.tvDatabase);
            this.scBody.Panel1MinSize = 300;
            // 
            // scBody.Panel2
            // 
            this.scBody.Panel2.Controls.Add(this.rtxtOutput);
            this.scBody.Panel2.Controls.Add(this.pnlSettings);
            this.scBody.Size = new System.Drawing.Size(1282, 818);
            this.scBody.SplitterDistance = 320;
            this.scBody.SplitterWidth = 1;
            this.scBody.TabIndex = 0;
            // 
            // tvDatabase
            // 
            this.tvDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.tvDatabase.CheckBoxes = true;
            this.tvDatabase.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvDatabase.Location = new System.Drawing.Point(0, 0);
            this.tvDatabase.Name = "tvDatabase";
            this.tvDatabase.ShowLines = false;
            this.tvDatabase.Size = new System.Drawing.Size(424, 818);
            this.tvDatabase.TabIndex = 0;
            this.tvDatabase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabase_AfterCheck);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.txtNamespace);
            this.pnlSettings.Controls.Add(this.lblNamespace);
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(949, 160);
            this.pnlSettings.TabIndex = 0;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(92, 8);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(369, 22);
            this.txtNamespace.TabIndex = 1;
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(3, 11);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(83, 17);
            this.lblNamespace.TabIndex = 0;
            this.lblNamespace.Text = "Namespace";
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pnlMenuBar.Controls.Add(this.btnSettings);
            this.pnlMenuBar.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(1282, 34);
            this.pnlMenuBar.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(1247, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 23);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.Location = new System.Drawing.Point(0, 160);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(960, 658);
            this.rtxtOutput.TabIndex = 1;
            this.rtxtOutput.Text = "";
            // 
            // PocoGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.pnlBody);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PocoGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poco Generator";
            this.pnlBody.ResumeLayout(false);
            this.scBody.Panel1.ResumeLayout(false);
            this.scBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).EndInit();
            this.scBody.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlMenuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.SplitContainer scBody;
        private System.Windows.Forms.TreeView tvDatabase;
        private System.Windows.Forms.Panel pnlMenuBar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.RichTextBox rtxtOutput;
    }
}

