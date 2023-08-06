namespace player
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.imageIcons = new System.Windows.Forms.ImageList(this.components);
            this.listFiles = new System.Windows.Forms.ListView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolOffset = new System.Windows.Forms.ToolStripTextBox();
            this.toolRionix = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.SystemColors.Window;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.treeFolders);
            this.splitter.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 0, 4);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.listFiles);
            this.splitter.Panel2.Padding = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.splitter.Size = new System.Drawing.Size(632, 423);
            this.splitter.SplitterDistance = 175;
            this.splitter.TabIndex = 2;
            // 
            // treeFolders
            // 
            this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolders.ImageIndex = 0;
            this.treeFolders.ImageList = this.imageIcons;
            this.treeFolders.Location = new System.Drawing.Point(4, 4);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.Size = new System.Drawing.Size(171, 415);
            this.treeFolders.StateImageList = this.imageIcons;
            this.treeFolders.TabIndex = 0;
            this.treeFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolders_BeforeExpand);
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            // 
            // imageIcons
            // 
            this.imageIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listFiles
            // 
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.FullRowSelect = true;
            this.listFiles.GridLines = true;
            this.listFiles.HideSelection = false;
            this.listFiles.LargeImageList = this.imageIcons;
            this.listFiles.Location = new System.Drawing.Point(0, 4);
            this.listFiles.MultiSelect = false;
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(449, 415);
            this.listFiles.SmallImageList = this.imageIcons;
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            this.listFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFiles_KeyDown);
            this.listFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseClick);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMessages,
            this.toolStripStatusLabel1,
            this.toolOffset,
            this.toolRionix});
            this.statusStrip.Location = new System.Drawing.Point(0, 423);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 23);
            this.statusStrip.TabIndex = 4;
            // 
            // toolMessages
            // 
            this.toolMessages.Name = "toolMessages";
            this.toolMessages.Size = new System.Drawing.Size(403, 18);
            this.toolMessages.Spring = true;
            this.toolMessages.Text = "Ready";
            this.toolMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 18);
            this.toolStripStatusLabel1.Text = "Song #";
            // 
            // toolOffset
            // 
            this.toolOffset.MaxLength = 16;
            this.toolOffset.Name = "toolOffset";
            this.toolOffset.Size = new System.Drawing.Size(30, 23);
            this.toolOffset.Text = "0";
            this.toolOffset.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolOffset.TextChanged += new System.EventHandler(this.toolOffset_TextChanged);
            // 
            // toolRionix
            // 
            this.toolRionix.IsLink = true;
            this.toolRionix.Name = "toolRionix";
            this.toolRionix.Size = new System.Drawing.Size(107, 18);
            this.toolRionix.Text = "© 2007-2023 rionix";
            this.toolRionix.Click += new System.EventHandler(this.toolRionix_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "BASS Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ImageList imageIcons;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolMessages;
        private System.Windows.Forms.ToolStripStatusLabel toolRionix;
        private System.Windows.Forms.ToolStripTextBox toolOffset;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

