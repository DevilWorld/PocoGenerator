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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.chkRelations = new System.Windows.Forms.CheckBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.pnlMenuBar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).BeginInit();
            this.scBody.Panel1.SuspendLayout();
            this.scBody.Panel2.SuspendLayout();
            this.scBody.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.scBody.Panel1MinSize = 250;
            // 
            // scBody.Panel2
            // 
            this.scBody.Panel2.Controls.Add(this.panel1);
            this.scBody.Panel2.Controls.Add(this.pnlSettings);
            this.scBody.Panel2MinSize = 500;
            this.scBody.Size = new System.Drawing.Size(1282, 818);
            this.scBody.SplitterDistance = 315;
            this.scBody.SplitterWidth = 1;
            this.scBody.TabIndex = 0;
            this.scBody.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scBody_SplitterMoved);
            // 
            // tvDatabase
            // 
            this.tvDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.tvDatabase.CheckBoxes = true;
            this.tvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDatabase.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDatabase.Location = new System.Drawing.Point(0, 0);
            this.tvDatabase.Name = "tvDatabase";
            this.tvDatabase.ShowLines = false;
            this.tvDatabase.Size = new System.Drawing.Size(315, 818);
            this.tvDatabase.TabIndex = 0;
            this.tvDatabase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabase_AfterCheck);
            this.tvDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabase_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtxtOutput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 658);
            this.panel1.TabIndex = 2;
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtOutput.Location = new System.Drawing.Point(0, 0);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(966, 658);
            this.rtxtOutput.TabIndex = 2;
            this.rtxtOutput.Text = "";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSettings.Controls.Add(this.chkRelations);
            this.pnlSettings.Controls.Add(this.txtNamespace);
            this.pnlSettings.Controls.Add(this.lblNamespace);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(966, 160);
            this.pnlSettings.TabIndex = 0;
            // 
            // chkRelations
            // 
            this.chkRelations.AutoSize = true;
            this.chkRelations.Location = new System.Drawing.Point(6, 47);
            this.chkRelations.Name = "chkRelations";
            this.chkRelations.Size = new System.Drawing.Size(159, 21);
            this.chkRelations.TabIndex = 2;
            this.chkRelations.Text = "Include EF Relations";
            this.chkRelations.UseVisualStyleBackColor = true;
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
            // PocoGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PocoGenerator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poco Generator";
            this.pnlBody.ResumeLayout(false);
            this.scBody.Panel1.ResumeLayout(false);
            this.scBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).EndInit();
            this.scBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxtOutput;
        private System.Windows.Forms.CheckBox chkRelations;
    }
}

