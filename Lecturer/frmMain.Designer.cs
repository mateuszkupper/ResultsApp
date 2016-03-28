namespace Lecturer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Results", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Results", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Lecturers");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Students");
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidebarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.btnStripSave = new System.Windows.Forms.ToolStripButton();
            this.btnStripBack = new System.Windows.Forms.ToolStripButton();
            this.btnStripRedo = new System.Windows.Forms.ToolStripButton();
            this.btnStripCopy = new System.Windows.Forms.ToolStripButton();
            this.btnStripPaste = new System.Windows.Forms.ToolStripButton();
            this.btnStripCut = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeLecturer = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeAdmin = new System.Windows.Forms.TreeView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.statusStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.userToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(984, 28);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCurrentToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveCurrentToolStripMenuItem
            // 
            this.saveCurrentToolStripMenuItem.Name = "saveCurrentToolStripMenuItem";
            this.saveCurrentToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.saveCurrentToolStripMenuItem.Text = "Save Current";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolbarsToolStripMenuItem
            // 
            this.toolbarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.sidebarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.toolbarsToolStripMenuItem.Name = "toolbarsToolStripMenuItem";
            this.toolbarsToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.toolbarsToolStripMenuItem.Text = "Toolbars";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // sidebarToolStripMenuItem
            // 
            this.sidebarToolStripMenuItem.Name = "sidebarToolStripMenuItem";
            this.sidebarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.sidebarToolStripMenuItem.Text = "Sidebar";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.statusBarToolStripMenuItem.Text = "Status bar";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.logInToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.userToolStripMenuItem.Text = "User";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.logInToolStripMenuItem.Text = "Log in";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusMain
            // 
            this.statusMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusMain.Location = new System.Drawing.Point(0, 556);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(984, 22);
            this.statusMain.TabIndex = 1;
            this.statusMain.Text = "statusStrip1";
            // 
            // toolMain
            // 
            this.toolMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStripSave,
            this.btnStripBack,
            this.btnStripRedo,
            this.btnStripCopy,
            this.btnStripPaste,
            this.btnStripCut});
            this.toolMain.Location = new System.Drawing.Point(0, 28);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(984, 27);
            this.toolMain.TabIndex = 2;
            this.toolMain.Text = "toolStrip1";
            // 
            // btnStripSave
            // 
            this.btnStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripSave.Image = ((System.Drawing.Image)(resources.GetObject("btnStripSave.Image")));
            this.btnStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripSave.Name = "btnStripSave";
            this.btnStripSave.Size = new System.Drawing.Size(24, 24);
            this.btnStripSave.Text = "toolStripButton1";
            this.btnStripSave.Click += new System.EventHandler(this.btnStripSave_Click);
            // 
            // btnStripBack
            // 
            this.btnStripBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripBack.Image = ((System.Drawing.Image)(resources.GetObject("btnStripBack.Image")));
            this.btnStripBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripBack.Name = "btnStripBack";
            this.btnStripBack.Size = new System.Drawing.Size(24, 24);
            this.btnStripBack.Text = "toolStripButton2";
            // 
            // btnStripRedo
            // 
            this.btnStripRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnStripRedo.Image")));
            this.btnStripRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripRedo.Name = "btnStripRedo";
            this.btnStripRedo.Size = new System.Drawing.Size(24, 24);
            this.btnStripRedo.Text = "toolStripButton3";
            // 
            // btnStripCopy
            // 
            this.btnStripCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnStripCopy.Image")));
            this.btnStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripCopy.Name = "btnStripCopy";
            this.btnStripCopy.Size = new System.Drawing.Size(24, 24);
            this.btnStripCopy.Text = "toolStripButton4";
            // 
            // btnStripPaste
            // 
            this.btnStripPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnStripPaste.Image")));
            this.btnStripPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripPaste.Name = "btnStripPaste";
            this.btnStripPaste.Size = new System.Drawing.Size(24, 24);
            this.btnStripPaste.Text = "toolStripButton5";
            // 
            // btnStripCut
            // 
            this.btnStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStripCut.Image = ((System.Drawing.Image)(resources.GetObject("btnStripCut.Image")));
            this.btnStripCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStripCut.Name = "btnStripCut";
            this.btnStripCut.Size = new System.Drawing.Size(24, 24);
            this.btnStripCut.Text = "toolStripButton6";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.dgvMain);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip3);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(984, 501);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip2);
            this.splitContainer2.Panel1.Controls.Add(this.treeLecturer);
            this.splitContainer2.Panel1.Enabled = false;
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.treeView1);
            this.splitContainer2.Panel2.Controls.Add(this.treeAdmin);
            this.splitContainer2.Panel2.Enabled = false;
            this.splitContainer2.Size = new System.Drawing.Size(235, 501);
            this.splitContainer2.SplitterDistance = 215;
            this.splitContainer2.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSlateGray;
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(233, 28);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 23);
            this.toolStripStatusLabel1.Text = "Lecturer";
            // 
            // treeLecturer
            // 
            this.treeLecturer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeLecturer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeLecturer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeLecturer.Location = new System.Drawing.Point(11, 31);
            this.treeLecturer.Name = "treeLecturer";
            treeNode1.Name = "tnoModulesResults";
            treeNode1.Text = "Modules";
            treeNode2.Name = "tnoResults";
            treeNode2.Text = "Results";
            treeNode3.Name = "tnoModules";
            treeNode3.Text = "Modules";
            this.treeLecturer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.treeLecturer.Size = new System.Drawing.Size(189, 165);
            this.treeLecturer.TabIndex = 0;
            this.treeLecturer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(233, 28);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(114, 23);
            this.toolStripStatusLabel2.Text = "Administrator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, -263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lecturer";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Menu;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(16, -243);
            this.treeView1.Name = "treeView1";
            treeNode4.Name = "tnoModulesResults";
            treeNode4.Text = "Modules";
            treeNode5.Name = "tnoResults";
            treeNode5.Text = "Results";
            treeNode6.Name = "tnoModules";
            treeNode6.Text = "Modules";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(189, 165);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // treeAdmin
            // 
            this.treeAdmin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeAdmin.Location = new System.Drawing.Point(11, 31);
            this.treeAdmin.Name = "treeAdmin";
            treeNode7.Name = "tnoModules";
            treeNode7.Text = "Modules";
            treeNode8.Name = "tnoLecturers";
            treeNode8.Text = "Lecturers";
            treeNode9.Name = "tnoStudents";
            treeNode9.Text = "Students";
            this.treeAdmin.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeAdmin.Size = new System.Drawing.Size(189, 165);
            this.treeAdmin.TabIndex = 1;
            this.treeAdmin.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAdmin_AfterSelect);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(28, 96);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.Size = new System.Drawing.Size(651, 319);
            this.dgvMain.TabIndex = 2;
            // 
            // statusStrip3
            // 
            this.statusStrip3.BackColor = System.Drawing.Color.LightSlateGray;
            this.statusStrip3.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3});
            this.statusStrip3.Location = new System.Drawing.Point(0, 0);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(743, 28);
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(46, 23);
            this.toolStripStatusLabel3.Text = "Data";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.Text = "Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolbarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sidebarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeLecturer;
        private System.Windows.Forms.ToolStripButton btnStripSave;
        private System.Windows.Forms.ToolStripButton btnStripBack;
        private System.Windows.Forms.ToolStripButton btnStripRedo;
        private System.Windows.Forms.ToolStripButton btnStripCopy;
        private System.Windows.Forms.ToolStripButton btnStripPaste;
        private System.Windows.Forms.ToolStripButton btnStripCut;
        private System.Windows.Forms.TreeView treeAdmin;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
    }
}

