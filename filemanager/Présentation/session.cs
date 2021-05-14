using filemanager.DAO;
using filemanager.Métier;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WPF.JoshSmith.ServiceProviders.UI;

namespace filemanager.Présentation
{

    class session : MetroForm
    {      
        List<Dossier> beforlist = new List<Dossier>();
        List<TreeNode> parentsnode = new List<TreeNode>();
        private Utulisateur newuser;
        private Dossier dossier = new Dossier();
        private fichier fichier = new fichier();
        private Dossier parent;
        List<string> str = new List<string>();
        string chemin = "";
        string labeloldname, nodeoldname;

        string thenewpath = "C:/";
        private bool g = false;
        private System.ComponentModel.IContainer components;
        private ListView listView2;
        private ImageList imageList2;
        int i = 0, stop = 0, copie = 0, c = 0, nd = 0, ff = 0, cut = 0;
        int d = 0, retour = 0, drop = 0, MF = 0, lastindex = 0;
        ListViewItem hoveritem;
        ListViewItem labelitem;
        ListViewItem itemdrop;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem copieToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem propertyToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        TreeNode previousnode;
        TreeNode selectedn;
        TreeNode testnode;

        mydb db = new mydb();
        private ImageList imageList1;
        private ToolStripMenuItem newDirectoryToolStripMenuItem1;
        private ToolStripMenuItem newFileToolStripMenuItem1;
        Form1 form;
        private ToolStripMenuItem cutToolStripMenuItem;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip2;
        ToolStripMenuItem toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9;
        private ImageList imageList3;
        private ToolStripMenuItem renameToolStripMenuItem;
        private Panel panel2;
        private PictureBox pictureBox7;
        private PictureBox pictureBox2;
        private Label Open;
        private Label label10;
        private Label label5;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox textBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton8;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdown2;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdown1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox maskedTextBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Label label12;
        private Label label11;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton4;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton7;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton6;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton5;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem affichageToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem bigIconsToolStripMenuItem;
        private ToolStripMenuItem triToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem newDirectoryToolStripMenuItem;
        private ToolStripMenuItem newFileToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem1;
        private TreeView treeView1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem smallIconsToolStripMenuItem;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button button1;
        private ToolStripMenuItem listToolStripMenuItem1;
        ListViewItem listV;
        public session(Utulisateur user, Form1 form)
        {

            //var skinmanager = MaterialSkinManager.Instance;
            //skinmanager.AddFormToManage(this);
            //skinmanager.Theme = MaterialSkinManager.Themes.LIGHT;
            this.form = form;
            InitializeComponent();
            listView2.LargeImageList = imageList2;
            newuser = user;
            db.Chargerlesfichierofuser(newuser);
            maskedTextBox1.Text = thenewpath;
            db.Chargerlesdossier(newuser);
            db.chargerlesfichier(newuser);
            db.Chargerlesdossierdsd(newuser);
            stop = newuser.Getlistdossier().Length;

            while (i < stop)
            {

                ListViewItem listitem = new ListViewItem(newuser.Getlistdossier()[i].GetNom().Trim(), 0);
                listitem.ImageIndex = 0;
                listitem.SubItems.Add("Folder of files");
                listitem.SubItems.Add("");
                listitem.SubItems.Add(newuser.Getlistdossier()[i].GetDatecreation().ToString());
                listitem.SubItems.Add("");
                listView2.Items.Add(listitem);
                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[i].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[i].GetNom().Trim();
                treeView1.Nodes.Add(mainNode);
                bunifuDropdown1.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                bunifuDropdown2.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                i++;
            }
            i = 0;
            stop = newuser.Getlistfiles().Length;
            while (i < stop)
            {
                ListViewItem listitem = new ListViewItem(newuser.Getlistfiles()[i].GetNom().Trim(), 1);
                listitem.ImageIndex = 1;
                listitem.SubItems.Add(" File");

                listitem.SubItems.Add("txt");
                listitem.SubItems.Add(newuser.Getlistfiles()[i].GetDatecreation().ToString());
                listitem.SubItems.Add("");

                listView2.Items.Add(listitem);

                i++;
            }
            i = 0;
            List<Dossier> dos = new List<Dossier>();
            bunifuDropdown1.Enabled = true;
            //user.getth(459,user,user.Getlistdirlist(),dos);
            //pictureBox7.Enabled = true;
            bunifuButton1.Enabled = false;
            bunifuButton2.Enabled = false;
            bunifuButton3.Enabled = false;
            bunifuButton4.Enabled = false;
            bunifuButton5.Enabled = false;
            bunifuButton6.Enabled = false;
            bunifuButton7.Enabled = false;


            //bunifuButton1.IdleBorderColor = Color.Turquoise;
            //bunifuButton1.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton2.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton3.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton4.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton5.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton6.IdleBorderColor = Color.WhiteSmoke;
            //bunifuButton7.IdleBorderColor = Color.WhiteSmoke;

        }
        private void listthetree()
        {
            treeView1.Nodes.Clear();
            stop = newuser.Getlistdossier().Length;
            i = 0;
            while (i < stop)

            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[i].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[i].GetNom().Trim();
                treeView1.Nodes.Add(mainNode);
                i++;
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(session));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDirectoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.textBox1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.bunifuButton8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuDropdown2 = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuDropdown1 = new Bunifu.Framework.UI.BunifuDropdown();
            this.Open = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.triToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.copieToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.newDirectoryToolStripMenuItem1,
            this.newFileToolStripMenuItem1,
            this.propertyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 224);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // copieToolStripMenuItem
            // 
            this.copieToolStripMenuItem.Name = "copieToolStripMenuItem";
            this.copieToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.copieToolStripMenuItem.Text = "Copie";
            this.copieToolStripMenuItem.Click += new System.EventHandler(this.copieToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // newDirectoryToolStripMenuItem1
            // 
            this.newDirectoryToolStripMenuItem1.Name = "newDirectoryToolStripMenuItem1";
            this.newDirectoryToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.newDirectoryToolStripMenuItem1.Text = "new directory";
            this.newDirectoryToolStripMenuItem1.Click += new System.EventHandler(this.newDirectoryToolStripMenuItem1_Click);
            // 
            // newFileToolStripMenuItem1
            // 
            this.newFileToolStripMenuItem1.Name = "newFileToolStripMenuItem1";
            this.newFileToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.newFileToolStripMenuItem1.Text = "new file";
            this.newFileToolStripMenuItem1.Click += new System.EventHandler(this.newFileToolStripMenuItem1_Click);
            // 
            // propertyToolStripMenuItem
            // 
            this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
            this.propertyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.propertyToolStripMenuItem.Text = "Properties";
            this.propertyToolStripMenuItem.Click += new System.EventHandler(this.propertyToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "folder.png");
            this.imageList2.Images.SetKeyName(1, "file.png");
            this.imageList2.Images.SetKeyName(2, "opacity.png");
            this.imageList2.Images.SetKeyName(3, "imgonline-com-ua-ReplaceColor-9MvJDcb2V6c1B.png");
            this.imageList2.Images.SetKeyName(4, "imgonline-com-ua-ReplaceColor-fqClJaPtMH.png");
            this.imageList2.Images.SetKeyName(5, "output-onlinepngtools (1).png");
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.BackColor = System.Drawing.Color.White;
            this.listView2.BackgroundImageTiled = true;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listView2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.HideSelection = false;
            this.listView2.LabelEdit = true;
            this.listView2.LabelWrap = false;
            this.listView2.LargeImageList = this.imageList2;
            this.listView2.Location = new System.Drawing.Point(294, 203);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(989, 453);
            this.listView2.SmallImageList = this.imageList3;
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView2_AfterLabelEdit);
            this.listView2.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView2_BeforeLabelEdit);
            this.listView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView2_ItemDrag);
            this.listView2.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView2_ItemMouseHover);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView2_DragDrop);
            this.listView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView2_DragEnter);
            this.listView2.DragOver += new System.Windows.Forms.DragEventHandler(this.listView2_DragOver);
            this.listView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_doubleclick);
            this.listView2.MouseLeave += new System.EventHandler(this.listView2_MouseLeave);
            this.listView2.MouseHover += new System.EventHandler(this.listView2_MouseHover);
            this.listView2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseUp);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 210;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            this.columnHeader5.Width = 202;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Format";
            this.columnHeader6.Width = 232;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date Creation";
            this.columnHeader7.Width = 258;
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "folder.png");
            this.imageList3.Images.SetKeyName(1, "file.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Flat Folder icon (1).png");
            this.imageList1.Images.SetKeyName(1, "flat-files-icon-3.jpg");
            this.imageList1.Images.SetKeyName(2, "dopen (2).png");
            this.imageList1.Images.SetKeyName(3, "imgonline-com-ua-ReplaceColor-LcjU8c9vnIMf (1).png");
            this.imageList1.Images.SetKeyName(4, "imgonline-com-ua-ReplaceColor-hWdAqf7vvcUwc1J.png");
            this.imageList1.Images.SetKeyName(5, "imgonline-com-ua-ReplaceColor-XlXtzxnDRI.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-6, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 53);
            this.panel1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(826, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 26);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AcceptsReturn = false;
            this.maskedTextBox1.AcceptsTab = false;
            this.maskedTextBox1.AnimationSpeed = 200;
            this.maskedTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.maskedTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.maskedTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.maskedTextBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maskedTextBox1.BackgroundImage")));
            this.maskedTextBox1.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.maskedTextBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.maskedTextBox1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.maskedTextBox1.BorderColorIdle = System.Drawing.Color.Silver;
            this.maskedTextBox1.BorderRadius = 1;
            this.maskedTextBox1.BorderThickness = 1;
            this.maskedTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.maskedTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox1.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.maskedTextBox1.DefaultText = "";
            this.maskedTextBox1.FillColor = System.Drawing.Color.White;
            this.maskedTextBox1.HideSelection = true;
            this.maskedTextBox1.IconLeft = null;
            this.maskedTextBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox1.IconPadding = 10;
            this.maskedTextBox1.IconRight = null;
            this.maskedTextBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.maskedTextBox1.Lines = new string[0];
            this.maskedTextBox1.Location = new System.Drawing.Point(123, 12);
            this.maskedTextBox1.MaxLength = 32767;
            this.maskedTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.maskedTextBox1.Modified = false;
            this.maskedTextBox1.Multiline = false;
            this.maskedTextBox1.Name = "maskedTextBox1";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.maskedTextBox1.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.maskedTextBox1.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.maskedTextBox1.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.maskedTextBox1.OnIdleState = stateProperties4;
            this.maskedTextBox1.PasswordChar = '\0';
            this.maskedTextBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.maskedTextBox1.PlaceholderText = "";
            this.maskedTextBox1.ReadOnly = false;
            this.maskedTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maskedTextBox1.SelectedText = "";
            this.maskedTextBox1.SelectionLength = 0;
            this.maskedTextBox1.SelectionStart = 0;
            this.maskedTextBox1.ShortcutsEnabled = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(706, 28);
            this.maskedTextBox1.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.maskedTextBox1.TabIndex = 7;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskedTextBox1.TextMarginBottom = 0;
            this.maskedTextBox1.TextMarginLeft = 5;
            this.maskedTextBox1.TextMarginTop = 0;
            this.maskedTextBox1.TextPlaceholder = "";
            this.maskedTextBox1.UseSystemPasswordChar = false;
            this.maskedTextBox1.WordWrap = true;
            this.maskedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = false;
            this.textBox1.AcceptsTab = false;
            this.textBox1.AnimationSpeed = 200;
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBox1.BackgroundImage")));
            this.textBox1.BorderColorActive = System.Drawing.Color.Gray;
            this.textBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.textBox1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textBox1.BorderColorIdle = System.Drawing.Color.Silver;
            this.textBox1.BorderRadius = 1;
            this.textBox1.BorderThickness = 1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.textBox1.DefaultText = "";
            this.textBox1.FillColor = System.Drawing.Color.White;
            this.textBox1.HideSelection = true;
            this.textBox1.IconLeft = null;
            this.textBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.IconPadding = 10;
            this.textBox1.IconRight = ((System.Drawing.Image)(resources.GetObject("textBox1.IconRight")));
            this.textBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(939, 12);
            this.textBox1.MaxLength = 32767;
            this.textBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.textBox1.Modified = false;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            stateProperties5.BorderColor = System.Drawing.Color.Gray;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBox1.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnIdleState = stateProperties8;
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBox1.PlaceholderText = "Search in :";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(242, 28);
            this.textBox1.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.textBox1.TabIndex = 6;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TextMarginBottom = 0;
            this.textBox1.TextMarginLeft = 5;
            this.textBox1.TextMarginTop = 0;
            this.textBox1.TextPlaceholder = "Search in :";
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.WordWrap = true;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(78, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 25);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::filemanager.Properties.Resources.Captureundo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(11, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 25);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::filemanager.Properties.Resources._444_4446156_windows_explorer_clipart_clear_windows_10_explorer_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem9});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(147, 180);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "Open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem2.Text = "Copie";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem3.Text = "Cut";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem4.Text = "Paste";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem5.Text = "Delete";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem8.Text = "Refresh";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem7.Text = "new directory";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem9.Text = "Property";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.bunifuButton1);
            this.panel2.Controls.Add(this.bunifuButton4);
            this.panel2.Controls.Add(this.bunifuButton3);
            this.panel2.Controls.Add(this.bunifuButton7);
            this.panel2.Controls.Add(this.bunifuButton6);
            this.panel2.Controls.Add(this.bunifuButton5);
            this.panel2.Controls.Add(this.bunifuButton2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.bunifuButton8);
            this.panel2.Controls.Add(this.bunifuDropdown2);
            this.panel2.Controls.Add(this.bunifuDropdown1);
            this.panel2.Controls.Add(this.Open);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox7);
            this.panel2.Location = new System.Drawing.Point(2, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 126);
            this.panel2.TabIndex = 7;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 75;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton1.ButtonText = "";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges1;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton1.IdleBorderRadius = 3;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.IdleIconLeftImage")));
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(3, 8);
            this.bunifuButton1.Name = "bunifuButton1";
            this.bunifuButton1.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.onHoverState.BorderRadius = 3;
            this.bunifuButton1.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.onHoverState.BorderThickness = 1;
            this.bunifuButton1.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.onHoverState.IconLeftImage = null;
            this.bunifuButton1.onHoverState.IconRightImage = null;
            this.bunifuButton1.OnIdleState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton1.OnIdleState.BorderRadius = 3;
            this.bunifuButton1.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton1.OnIdleState.BorderThickness = 1;
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.OnIdleState.IconLeftImage")));
            this.bunifuButton1.OnIdleState.IconRightImage = null;
            this.bunifuButton1.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.BorderRadius = 3;
            this.bunifuButton1.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnPressedState.BorderThickness = 1;
            this.bunifuButton1.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.OnPressedState.IconLeftImage = null;
            this.bunifuButton1.OnPressedState.IconRightImage = null;
            this.bunifuButton1.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton1.TabIndex = 67;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click_1);
            // 
            // bunifuButton4
            // 
            this.bunifuButton4.AllowToggling = false;
            this.bunifuButton4.AnimationSpeed = 75;
            this.bunifuButton4.AutoGenerateColors = false;
            this.bunifuButton4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton4.BackColor1 = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton4.BackgroundImage")));
            this.bunifuButton4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton4.ButtonText = "";
            this.bunifuButton4.ButtonTextMarginLeft = 0;
            this.bunifuButton4.ColorContrastOnClick = 45;
            this.bunifuButton4.ColorContrastOnHover = 45;
            this.bunifuButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton4.CustomizableEdges = borderEdges2;
            this.bunifuButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton4.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton4.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton4.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton4.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton4.ForeColor = System.Drawing.Color.White;
            this.bunifuButton4.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton4.IconMarginLeft = 11;
            this.bunifuButton4.IconPadding = 10;
            this.bunifuButton4.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton4.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton4.IdleBorderRadius = 3;
            this.bunifuButton4.IdleBorderThickness = 1;
            this.bunifuButton4.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton4.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton4.IdleIconLeftImage")));
            this.bunifuButton4.IdleIconRightImage = null;
            this.bunifuButton4.IndicateFocus = false;
            this.bunifuButton4.Location = new System.Drawing.Point(169, 65);
            this.bunifuButton4.Name = "bunifuButton4";
            this.bunifuButton4.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton4.onHoverState.BorderRadius = 3;
            this.bunifuButton4.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton4.onHoverState.BorderThickness = 1;
            this.bunifuButton4.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton4.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton4.onHoverState.IconLeftImage = null;
            this.bunifuButton4.onHoverState.IconRightImage = null;
            this.bunifuButton4.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton4.OnIdleState.BorderRadius = 3;
            this.bunifuButton4.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton4.OnIdleState.BorderThickness = 1;
            this.bunifuButton4.OnIdleState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton4.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton4.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton4.OnIdleState.IconLeftImage")));
            this.bunifuButton4.OnIdleState.IconRightImage = null;
            this.bunifuButton4.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton4.OnPressedState.BorderRadius = 3;
            this.bunifuButton4.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton4.OnPressedState.BorderThickness = 1;
            this.bunifuButton4.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton4.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton4.OnPressedState.IconLeftImage = null;
            this.bunifuButton4.OnPressedState.IconRightImage = null;
            this.bunifuButton4.Size = new System.Drawing.Size(54, 44);
            this.bunifuButton4.TabIndex = 66;
            this.bunifuButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton4.TextMarginLeft = 0;
            this.bunifuButton4.UseDefaultRadiusAndThickness = true;
            this.bunifuButton4.Click += new System.EventHandler(this.bunifuButton4_Click_1);
            // 
            // bunifuButton3
            // 
            this.bunifuButton3.AllowToggling = false;
            this.bunifuButton3.AnimationSpeed = 75;
            this.bunifuButton3.AutoGenerateColors = false;
            this.bunifuButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.BackColor1 = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton3.BackgroundImage")));
            this.bunifuButton3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton3.ButtonText = "";
            this.bunifuButton3.ButtonTextMarginLeft = 0;
            this.bunifuButton3.ColorContrastOnClick = 45;
            this.bunifuButton3.ColorContrastOnHover = 45;
            this.bunifuButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.bunifuButton3.CustomizableEdges = borderEdges3;
            this.bunifuButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton3.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton3.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton3.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton3.ForeColor = System.Drawing.Color.White;
            this.bunifuButton3.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton3.IconMarginLeft = 11;
            this.bunifuButton3.IconPadding = 10;
            this.bunifuButton3.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton3.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.IdleBorderRadius = 3;
            this.bunifuButton3.IdleBorderThickness = 1;
            this.bunifuButton3.IdleFillColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton3.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton3.IdleIconLeftImage")));
            this.bunifuButton3.IdleIconRightImage = null;
            this.bunifuButton3.IndicateFocus = false;
            this.bunifuButton3.Location = new System.Drawing.Point(169, 15);
            this.bunifuButton3.Name = "bunifuButton3";
            this.bunifuButton3.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.onHoverState.BorderRadius = 3;
            this.bunifuButton3.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.onHoverState.BorderThickness = 1;
            this.bunifuButton3.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton3.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton3.onHoverState.IconLeftImage = null;
            this.bunifuButton3.onHoverState.IconRightImage = null;
            this.bunifuButton3.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton3.OnIdleState.BorderRadius = 3;
            this.bunifuButton3.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton3.OnIdleState.BorderThickness = 1;
            this.bunifuButton3.OnIdleState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton3.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton3.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton3.OnIdleState.IconLeftImage")));
            this.bunifuButton3.OnIdleState.IconRightImage = null;
            this.bunifuButton3.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton3.OnPressedState.BorderRadius = 3;
            this.bunifuButton3.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton3.OnPressedState.BorderThickness = 1;
            this.bunifuButton3.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton3.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton3.OnPressedState.IconLeftImage = null;
            this.bunifuButton3.OnPressedState.IconRightImage = null;
            this.bunifuButton3.Size = new System.Drawing.Size(54, 44);
            this.bunifuButton3.TabIndex = 65;
            this.bunifuButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton3.TextMarginLeft = 0;
            this.bunifuButton3.UseDefaultRadiusAndThickness = true;
            this.bunifuButton3.Click += new System.EventHandler(this.bunifuButton3_Click_1);
            // 
            // bunifuButton7
            // 
            this.bunifuButton7.AllowToggling = false;
            this.bunifuButton7.AnimationSpeed = 75;
            this.bunifuButton7.AutoGenerateColors = false;
            this.bunifuButton7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton7.BackgroundImage")));
            this.bunifuButton7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton7.ButtonText = "";
            this.bunifuButton7.ButtonTextMarginLeft = 0;
            this.bunifuButton7.ColorContrastOnClick = 45;
            this.bunifuButton7.ColorContrastOnHover = 45;
            this.bunifuButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.bunifuButton7.CustomizableEdges = borderEdges4;
            this.bunifuButton7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton7.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton7.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton7.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton7.ForeColor = System.Drawing.Color.White;
            this.bunifuButton7.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton7.IconMarginLeft = 11;
            this.bunifuButton7.IconPadding = 10;
            this.bunifuButton7.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton7.IdleBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.IdleBorderRadius = 3;
            this.bunifuButton7.IdleBorderThickness = 1;
            this.bunifuButton7.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton7.IdleIconLeftImage")));
            this.bunifuButton7.IdleIconRightImage = null;
            this.bunifuButton7.IndicateFocus = false;
            this.bunifuButton7.Location = new System.Drawing.Point(947, 11);
            this.bunifuButton7.Name = "bunifuButton7";
            this.bunifuButton7.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.onHoverState.BorderRadius = 3;
            this.bunifuButton7.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton7.onHoverState.BorderThickness = 1;
            this.bunifuButton7.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton7.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton7.onHoverState.IconLeftImage = null;
            this.bunifuButton7.onHoverState.IconRightImage = null;
            this.bunifuButton7.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.OnIdleState.BorderRadius = 3;
            this.bunifuButton7.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton7.OnIdleState.BorderThickness = 1;
            this.bunifuButton7.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton7.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton7.OnIdleState.IconLeftImage")));
            this.bunifuButton7.OnIdleState.IconRightImage = null;
            this.bunifuButton7.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton7.OnPressedState.BorderRadius = 3;
            this.bunifuButton7.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton7.OnPressedState.BorderThickness = 1;
            this.bunifuButton7.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton7.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton7.OnPressedState.IconLeftImage = null;
            this.bunifuButton7.OnPressedState.IconRightImage = null;
            this.bunifuButton7.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton7.TabIndex = 64;
            this.bunifuButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton7.TextMarginLeft = 0;
            this.bunifuButton7.UseDefaultRadiusAndThickness = true;
            this.bunifuButton7.Click += new System.EventHandler(this.bunifuButton7_Click_1);
            // 
            // bunifuButton6
            // 
            this.bunifuButton6.AllowToggling = false;
            this.bunifuButton6.AnimationSpeed = 75;
            this.bunifuButton6.AutoGenerateColors = false;
            this.bunifuButton6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton6.BackgroundImage")));
            this.bunifuButton6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton6.ButtonText = "";
            this.bunifuButton6.ButtonTextMarginLeft = 0;
            this.bunifuButton6.ColorContrastOnClick = 45;
            this.bunifuButton6.ColorContrastOnHover = 45;
            this.bunifuButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.bunifuButton6.CustomizableEdges = borderEdges5;
            this.bunifuButton6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton6.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton6.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton6.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton6.ForeColor = System.Drawing.Color.White;
            this.bunifuButton6.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton6.IconMarginLeft = 11;
            this.bunifuButton6.IconPadding = 10;
            this.bunifuButton6.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton6.IdleBorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton6.IdleBorderRadius = 3;
            this.bunifuButton6.IdleBorderThickness = 1;
            this.bunifuButton6.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton6.IdleIconLeftImage")));
            this.bunifuButton6.IdleIconRightImage = null;
            this.bunifuButton6.IndicateFocus = false;
            this.bunifuButton6.Location = new System.Drawing.Point(694, 9);
            this.bunifuButton6.Name = "bunifuButton6";
            this.bunifuButton6.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.onHoverState.BorderRadius = 3;
            this.bunifuButton6.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton6.onHoverState.BorderThickness = 1;
            this.bunifuButton6.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton6.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton6.onHoverState.IconLeftImage = null;
            this.bunifuButton6.onHoverState.IconRightImage = null;
            this.bunifuButton6.OnIdleState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton6.OnIdleState.BorderRadius = 3;
            this.bunifuButton6.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton6.OnIdleState.BorderThickness = 1;
            this.bunifuButton6.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton6.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton6.OnIdleState.IconLeftImage")));
            this.bunifuButton6.OnIdleState.IconRightImage = null;
            this.bunifuButton6.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton6.OnPressedState.BorderRadius = 3;
            this.bunifuButton6.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton6.OnPressedState.BorderThickness = 1;
            this.bunifuButton6.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton6.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton6.OnPressedState.IconLeftImage = null;
            this.bunifuButton6.OnPressedState.IconRightImage = null;
            this.bunifuButton6.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton6.TabIndex = 63;
            this.bunifuButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton6.TextMarginLeft = 0;
            this.bunifuButton6.UseDefaultRadiusAndThickness = true;
            this.bunifuButton6.Click += new System.EventHandler(this.bunifuButton6_Click_1);
            // 
            // bunifuButton5
            // 
            this.bunifuButton5.AllowToggling = false;
            this.bunifuButton5.AnimationSpeed = 75;
            this.bunifuButton5.AutoGenerateColors = false;
            this.bunifuButton5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton5.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton5.BackgroundImage")));
            this.bunifuButton5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton5.ButtonText = "";
            this.bunifuButton5.ButtonTextMarginLeft = 0;
            this.bunifuButton5.ColorContrastOnClick = 45;
            this.bunifuButton5.ColorContrastOnHover = 45;
            this.bunifuButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.bunifuButton5.CustomizableEdges = borderEdges6;
            this.bunifuButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton5.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton5.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton5.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton5.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton5.ForeColor = System.Drawing.Color.White;
            this.bunifuButton5.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton5.IconMarginLeft = 11;
            this.bunifuButton5.IconPadding = 10;
            this.bunifuButton5.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton5.IdleBorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton5.IdleBorderRadius = 3;
            this.bunifuButton5.IdleBorderThickness = 1;
            this.bunifuButton5.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton5.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton5.IdleIconLeftImage")));
            this.bunifuButton5.IdleIconRightImage = null;
            this.bunifuButton5.IndicateFocus = false;
            this.bunifuButton5.Location = new System.Drawing.Point(551, 8);
            this.bunifuButton5.Name = "bunifuButton5";
            this.bunifuButton5.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton5.onHoverState.BorderRadius = 3;
            this.bunifuButton5.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton5.onHoverState.BorderThickness = 1;
            this.bunifuButton5.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton5.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton5.onHoverState.IconLeftImage = null;
            this.bunifuButton5.onHoverState.IconRightImage = null;
            this.bunifuButton5.OnIdleState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton5.OnIdleState.BorderRadius = 3;
            this.bunifuButton5.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton5.OnIdleState.BorderThickness = 1;
            this.bunifuButton5.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton5.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton5.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton5.OnIdleState.IconLeftImage")));
            this.bunifuButton5.OnIdleState.IconRightImage = null;
            this.bunifuButton5.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton5.OnPressedState.BorderRadius = 3;
            this.bunifuButton5.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton5.OnPressedState.BorderThickness = 1;
            this.bunifuButton5.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton5.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton5.OnPressedState.IconLeftImage = null;
            this.bunifuButton5.OnPressedState.IconRightImage = null;
            this.bunifuButton5.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton5.TabIndex = 62;
            this.bunifuButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton5.TextMarginLeft = 0;
            this.bunifuButton5.UseDefaultRadiusAndThickness = true;
            this.bunifuButton5.Click += new System.EventHandler(this.bunifuButton5_Click_1);
            // 
            // bunifuButton2
            // 
            this.bunifuButton2.AllowToggling = false;
            this.bunifuButton2.AnimationSpeed = 75;
            this.bunifuButton2.AutoGenerateColors = false;
            this.bunifuButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.BackgroundImage")));
            this.bunifuButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton2.ButtonText = "";
            this.bunifuButton2.ButtonTextMarginLeft = 0;
            this.bunifuButton2.ColorContrastOnClick = 45;
            this.bunifuButton2.ColorContrastOnHover = 45;
            this.bunifuButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.bunifuButton2.CustomizableEdges = borderEdges7;
            this.bunifuButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton2.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton2.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton2.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IconMarginLeft = 11;
            this.bunifuButton2.IconPadding = 10;
            this.bunifuButton2.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton2.IdleBorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton2.IdleBorderRadius = 3;
            this.bunifuButton2.IdleBorderThickness = 1;
            this.bunifuButton2.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.IdleIconLeftImage")));
            this.bunifuButton2.IdleIconRightImage = null;
            this.bunifuButton2.IndicateFocus = false;
            this.bunifuButton2.Location = new System.Drawing.Point(95, 11);
            this.bunifuButton2.Name = "bunifuButton2";
            this.bunifuButton2.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.onHoverState.BorderRadius = 3;
            this.bunifuButton2.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.onHoverState.BorderThickness = 1;
            this.bunifuButton2.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton2.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.onHoverState.IconLeftImage = null;
            this.bunifuButton2.onHoverState.IconRightImage = null;
            this.bunifuButton2.OnIdleState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton2.OnIdleState.BorderRadius = 3;
            this.bunifuButton2.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Dot;
            this.bunifuButton2.OnIdleState.BorderThickness = 1;
            this.bunifuButton2.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.OnIdleState.IconLeftImage")));
            this.bunifuButton2.OnIdleState.IconRightImage = null;
            this.bunifuButton2.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton2.OnPressedState.BorderRadius = 3;
            this.bunifuButton2.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.OnPressedState.BorderThickness = 1;
            this.bunifuButton2.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton2.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.OnPressedState.IconLeftImage = null;
            this.bunifuButton2.OnPressedState.IconRightImage = null;
            this.bunifuButton2.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton2.TabIndex = 61;
            this.bunifuButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton2.TextMarginLeft = 0;
            this.bunifuButton2.UseDefaultRadiusAndThickness = true;
            this.bunifuButton2.Click += new System.EventHandler(this.bunifuButton2_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(955, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 59;
            this.label12.Text = "Properties";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(837, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 16);
            this.label11.TabIndex = 58;
            this.label11.Text = "New";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(709, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 57;
            this.label9.Text = "Rename";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(568, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 56;
            this.label8.Text = "Delete";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(448, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 55;
            this.label7.Text = "Copie to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 54;
            this.label6.Text = "Move to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Cut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Paste";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Copie";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(914, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 99);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(269, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 127);
            this.pictureBox4.TabIndex = 47;
            this.pictureBox4.TabStop = false;
            // 
            // bunifuButton8
            // 
            this.bunifuButton8.AllowToggling = false;
            this.bunifuButton8.AnimationSpeed = 75;
            this.bunifuButton8.AutoGenerateColors = false;
            this.bunifuButton8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton8.BackColor1 = System.Drawing.Color.Transparent;
            this.bunifuButton8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton8.BackgroundImage")));
            this.bunifuButton8.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton8.ButtonText = "";
            this.bunifuButton8.ButtonTextMarginLeft = 0;
            this.bunifuButton8.ColorContrastOnClick = 45;
            this.bunifuButton8.ColorContrastOnHover = 45;
            this.bunifuButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges8.BottomLeft = true;
            borderEdges8.BottomRight = true;
            borderEdges8.TopLeft = true;
            borderEdges8.TopRight = true;
            this.bunifuButton8.CustomizableEdges = borderEdges8;
            this.bunifuButton8.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton8.DisabledBorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton8.DisabledFillColor = System.Drawing.Color.Gainsboro;
            this.bunifuButton8.DisabledForecolor = System.Drawing.Color.Transparent;
            this.bunifuButton8.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.bunifuButton8.ForeColor = System.Drawing.Color.White;
            this.bunifuButton8.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton8.IconMarginLeft = 11;
            this.bunifuButton8.IconPadding = 10;
            this.bunifuButton8.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton8.IdleBorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton8.IdleBorderRadius = 3;
            this.bunifuButton8.IdleBorderThickness = 1;
            this.bunifuButton8.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuButton8.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton8.IdleIconLeftImage")));
            this.bunifuButton8.IdleIconRightImage = null;
            this.bunifuButton8.IndicateFocus = false;
            this.bunifuButton8.Location = new System.Drawing.Point(818, 9);
            this.bunifuButton8.Name = "bunifuButton8";
            this.bunifuButton8.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuButton8.onHoverState.BorderRadius = 3;
            this.bunifuButton8.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton8.onHoverState.BorderThickness = 1;
            this.bunifuButton8.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton8.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton8.onHoverState.IconLeftImage = null;
            this.bunifuButton8.onHoverState.IconRightImage = null;
            this.bunifuButton8.OnIdleState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuButton8.OnIdleState.BorderRadius = 3;
            this.bunifuButton8.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton8.OnIdleState.BorderThickness = 1;
            this.bunifuButton8.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.bunifuButton8.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton8.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton8.OnIdleState.IconLeftImage")));
            this.bunifuButton8.OnIdleState.IconRightImage = null;
            this.bunifuButton8.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton8.OnPressedState.BorderRadius = 3;
            this.bunifuButton8.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton8.OnPressedState.BorderThickness = 1;
            this.bunifuButton8.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton8.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton8.OnPressedState.IconLeftImage = null;
            this.bunifuButton8.OnPressedState.IconRightImage = null;
            this.bunifuButton8.Size = new System.Drawing.Size(73, 72);
            this.bunifuButton8.TabIndex = 46;
            this.bunifuButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton8.TextMarginLeft = 0;
            this.bunifuButton8.UseDefaultRadiusAndThickness = true;
            this.bunifuButton8.Click += new System.EventHandler(this.bunifuButton8_Click);
            // 
            // bunifuDropdown2
            // 
            this.bunifuDropdown2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuDropdown2.BackgroundImage")));
            this.bunifuDropdown2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDropdown2.BorderRadius = 3;
            this.bunifuDropdown2.Enabled = false;
            this.bunifuDropdown2.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown2.Items = new string[0];
            this.bunifuDropdown2.Location = new System.Drawing.Point(434, 9);
            this.bunifuDropdown2.Name = "bunifuDropdown2";
            this.bunifuDropdown2.NomalColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown2.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuDropdown2.selectedIndex = -1;
            this.bunifuDropdown2.Size = new System.Drawing.Size(73, 72);
            this.bunifuDropdown2.TabIndex = 42;
            this.bunifuDropdown2.onItemSelected += new System.EventHandler(this.bunifuDropdown2_onItemSelected);
            this.bunifuDropdown2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bunifuDropdown2_MouseClick);
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuDropdown1.BackgroundImage")));
            this.bunifuDropdown1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDropdown1.BorderRadius = 3;
            this.bunifuDropdown1.Enabled = false;
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.Items = new string[0];
            this.bunifuDropdown1.Location = new System.Drawing.Point(321, 11);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.NomalColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuDropdown1.selectedIndex = -1;
            this.bunifuDropdown1.Size = new System.Drawing.Size(73, 72);
            this.bunifuDropdown1.TabIndex = 41;
            this.bunifuDropdown1.onItemSelected += new System.EventHandler(this.bunifuDropdown1_onItemSelected);
            // 
            // Open
            // 
            this.Open.AutoSize = true;
            this.Open.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open.Location = new System.Drawing.Point(899, 102);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(45, 19);
            this.Open.TabIndex = 36;
            this.Open.Text = "Open";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(457, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 19);
            this.label10.TabIndex = 34;
            this.label10.Text = "Organisation";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Clipboard";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(778, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 127);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(525, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 99);
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affichageToolStripMenuItem,
            this.triToolStripMenuItem,
            this.pasteToolStripMenuItem1,
            this.newToolStripMenuItem,
            this.refreshToolStripMenuItem1});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(154, 114);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.bigIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem1});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.affichageToolStripMenuItem.Text = "Display";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem.Text = "Details";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // bigIconsToolStripMenuItem
            // 
            this.bigIconsToolStripMenuItem.Name = "bigIconsToolStripMenuItem";
            this.bigIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.bigIconsToolStripMenuItem.Text = "Big icons";
            this.bigIconsToolStripMenuItem.Click += new System.EventHandler(this.bigIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.smallIconsToolStripMenuItem.Text = "Small icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem1
            // 
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem1.Text = "List";
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.listToolStripMenuItem1_Click);
            // 
            // triToolStripMenuItem
            // 
            this.triToolStripMenuItem.Name = "triToolStripMenuItem";
            this.triToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.triToolStripMenuItem.Text = "Order by name";
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDirectoryToolStripMenuItem,
            this.newFileToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // newDirectoryToolStripMenuItem
            // 
            this.newDirectoryToolStripMenuItem.Name = "newDirectoryToolStripMenuItem";
            this.newDirectoryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newDirectoryToolStripMenuItem.Text = "New directory";
            this.newDirectoryToolStripMenuItem.Click += new System.EventHandler(this.newDirectoryToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newFileToolStripMenuItem.Text = "New file";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.LabelEdit = true;
            this.treeView1.LineColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(5, 203);
            this.treeView1.Margin = new System.Windows.Forms.Padding(10);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = "/";
            this.treeView1.Size = new System.Drawing.Size(263, 453);
            this.treeView1.TabIndex = 8;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView1_NodeMouseHover);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.LocationChanged += new System.EventHandler(this.treeView1_LocationChanged);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            this.treeView1.MouseCaptureChanged += new System.EventHandler(this.treeView1_MouseCaptureChanged);
            this.treeView1.MouseLeave += new System.EventHandler(this.treeView1_MouseLeave);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // session
            // 
            this.ClientSize = new System.Drawing.Size(1286, 663);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "session";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.session_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void listView2_doubleclick(object sender, MouseEventArgs e)
        {
            beforlist.Clear();
            listView2.Columns.Clear();
            MF = 0;
            //ListViewHitTestInfo info = listView2.HitTest(e.X,e.Y) ;
            ListViewItem item = listView2.SelectedItems[0];

            this.button1.Enabled = true;
            //ListViewItem item = listView2.SelectedItems[0];
            listView2.Clear();
            string nom = item.Text;

            Dossier temp = new Dossier();
            fichier tempf = new fichier();
            string[] colString = new string[] { "Name", "Type", "Format", "Date creation" };
            //  int colIndex = 0;
            ColumnHeader[] columns = { columnHeader4, columnHeader5, columnHeader6, columnHeader7 };
            listView2.Columns.AddRange(columns);
            if (item.ImageIndex == 1 || item.ImageIndex == 5)
            {
                if (parent == null)
                {

                    tempf = newuser.Open_file(nom, newuser.Getlistfiles());



                }
                else
                {

                    tempf = newuser.Open_file(nom, parent.Getlistfichier());

                }
                db.chargerblob(tempf);

                Texteditor txt = new Texteditor(tempf);
                // txt.Visible = true;
                refresh();
                stop = newuser.Getlistdossier().Length;
                int j = 0;
                treeView1.Nodes.Clear();
                while (j < stop)
                {

                    TreeNode mainNode = new TreeNode();
                    mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                    mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                    treeView1.Nodes.Add(mainNode);
                    j++;
                }
                txt.Visible = true;
            }
            if (item.ImageIndex == 0 || item.ImageIndex == 4)
            {
                if (retour == 0)
                {
                    if (parent == null)
                    {

                        temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                        parent = temp;
                        temp.Getlistofdir().Clear();
                        temp.Getlistoffiles().Clear();
                        GC.Collect();
                        db.chargerdossierdsd(newuser, temp);
                        db.Chargerlesfichierdsd(newuser, temp);
                        // parent.Getlistofdir().Clear();
                        // db.chargerdossierdsd(newuser, parent);
                        chemin = "";

                    }
                    else
                    {

                        temp = newuser.Open_folder(nom, parent.Getlistdir());
                        // db.chargerdossierdsd(newuser, temp);
                        // db.Chargerlesfichierdsd(newuser, temp);
                        parent = temp;
                        parent.Getlistofdir().Clear();
                        parent.Getlistoffiles().Clear();
                        GC.Collect();
                        db.chargerdossierdsd(newuser, parent);
                        db.Chargerlesfichierdsd(newuser, parent);
                    }
                }
                else
                {
                    if (parent == null)
                    {
                        temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                        parent = temp;
                        temp.Getlistofdir().Clear();
                        temp.Getlistoffiles().Clear();
                        //   db.chargerdossierdsd(newuser, temp);
                        db.Chargerlesfichierdsd(newuser, temp);
                        //    parent.Getlistofdir().Clear();
                        db.chargerdossierdsd(newuser, parent);
                        chemin = "";
                    }
                    else
                    {
                        temp = newuser.Open_folder(nom, parent.Getlistdir());
                        // db.chargerdossierdsd(newuser, temp);
                        //   db.Chargerlesfichierdsd(newuser, temp);
                        parent = temp;
                        parent.Getlistoffiles().Clear();
                        parent.Getlistofdir().Clear();
                        db.chargerdossierdsd(newuser, parent);
                        db.Chargerlesfichierdsd(newuser, parent);

                    }

                }
                d = 1;
                //maskedTextBox1.Text = chemin;

                int i = 0;
                int stop = temp.Getlistdir().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                    listitem.ImageIndex = 0;
                    listitem.SubItems.Add("Folder of files");
                    listitem.SubItems.Add("");
                    listitem.SubItems.Add(temp.Getlistdir()[i].GetDatecreation().ToString());
                    listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                stop = temp.Getlistfichier().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                    listitem.ImageIndex = 1;
                    listitem.SubItems.Add("File");
                    listitem.SubItems.Add("txt");
                    listitem.SubItems.Add(temp.Getlistfichier()[i].GetDatecreation().ToString());
                    //listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                chemin = chemin.Trim() + temp.GetNom().Trim() + "/";
                maskedTextBox1.Text = thenewpath + chemin;

            }

        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView2.Columns.Clear();
            string[] colString = new string[] { "Name", "Type", "Format", "Date creation" };
            //  int colIndex = 0;
            ColumnHeader[] columns = { columnHeader4, columnHeader5, columnHeader6, columnHeader7 };
            listView2.Columns.AddRange(columns);
            beforlist.Clear();
            if (listView2.SelectedItems == null)
            {
                return;
            }
            MF = 0;
            this.button1.Enabled = true;
            ListViewItem item = listView2.SelectedItems[0];
            listView2.Clear();
            string nom = item.Text;
            Dossier temp = new Dossier();
            fichier tempf = new fichier();
            if (item.ImageIndex == 1)
            {
                if (parent == null)
                {

                    tempf = newuser.Open_file(nom, newuser.Getlistfiles());



                }
                else
                {

                    tempf = newuser.Open_file(nom, parent.Getlistfichier());

                }

                db.chargerblob(tempf);

                Texteditor txt = new Texteditor(tempf);
                txt.Visible = true;
                refresh();
            }
            if (item.ImageIndex == 0)
            {
                if (retour == 0)
                {
                    if (parent == null)
                    {

                        temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                        parent = temp;
                        chemin = "";

                    }
                    else
                    {

                        temp = newuser.Open_folder(nom, parent.Getlistdir());
                        db.chargerdossierdsd(newuser, temp);
                        db.Chargerlesfichierdsd(newuser, temp);
                        parent = temp;
                    }
                }
                else
                {
                    if (parent == null)
                    {
                        temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                        //  chemin =  temp.GetNom().TrimEnd();
                        chemin = "";
                        parent = temp;
                    }
                    else
                    {
                        temp = newuser.Open_folder(nom, parent.Getlistdir());
                        parent = temp;

                    }

                }
                d = 1;
                //maskedTextBox1.Text = chemin;

                int i = 0;
                int stop = temp.Getlistdir().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                    listitem.ImageIndex = 0;
                    listitem.SubItems.Add("Folder of Files");
                    listitem.SubItems.Add("");
                    listitem.SubItems.Add(temp.Getlistfichier()[i].GetDatecreation().ToString());
                    //listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                stop = temp.Getlistfichier().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                    listitem.ImageIndex = 1;
                    listitem.SubItems.Add("File");
                    listitem.SubItems.Add("txt");
                    listitem.SubItems.Add(temp.Getlistfichier()[i].GetDatecreation().ToString());
                    //listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                chemin = chemin.Trim() + temp.GetNom().Trim() + "/";
                maskedTextBox1.Text = thenewpath + chemin;

            }

        }
        private void refresh()
        {
            GC.Collect();
            //listView2.Columns.Clear();
            string[] colString = new string[] { "Name", "Type", "Format", "Date creation" };
            //  int colIndex = 0;
            ColumnHeader[] columns = { columnHeader4, columnHeader5, columnHeader6, columnHeader7 };
            // listView2.Columns.AddRange(columns);
            treeView1.Nodes.Clear();
            listView2.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            if (parent == null)
            {
                listView2.Columns.Clear();
                // colString = new string[] { "Name", "Type", "Format", "Date creation" };
                //  int colIndex = 0;

                listView2.Columns.AddRange(columns);
                stop = newuser.Getlistdossier().Length;
                i = 0;
                while (i < stop)
                {
                    bunifuDropdown1.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                    bunifuDropdown2.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                    i++;
                }
                i = 0;

                while (i < stop)

                {

                    ListViewItem listitem = new ListViewItem(newuser.Getlistdossier()[i].GetNom().Trim(), 0);
                    listitem.ImageIndex = 0;
                    listitem.SubItems.Add("Folder of files");
                    listitem.SubItems.Add("");
                    listitem.SubItems.Add(newuser.Getlistdossier()[i].GetDatecreation().ToString());
                    listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);


                    i++;

                }
                i = 0;
                while (i < stop)
                {
                    TreeNode mainNode = new TreeNode();
                    mainNode.Text = newuser.Getlistdossier()[i].GetNom().Trim();
                    mainNode.Name = newuser.Getlistdossier()[i].GetNom().Trim();
                    treeView1.Nodes.Add(mainNode);
                    i++;
                }
                i = 0;
                stop = newuser.Getlistfiles().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(newuser.Getlistfiles()[i].GetNom().Trim(), 1);
                    listitem.ImageIndex = 1;
                    listitem.SubItems.Add(" File");

                    listitem.SubItems.Add("txt");
                    listitem.SubItems.Add(newuser.Getlistfiles()[i].GetDatecreation().ToString());
                    listitem.SubItems.Add("");

                    listView2.Items.Add(listitem);
                    i++;
                }

            }
            else
            {
                listView2.Columns.Clear();
                // colString = new string[] { "Name", "Type", "Format", "Date creation" };
                //  int colIndex = 0;

                listView2.Columns.AddRange(columns);
                //listthetree();
                Dossier temp = new Dossier();


                if (parent == null)
                {
                    temp = newuser.Open_folder(parent.GetNom().Trim(), newuser.Getlistdossier());
                }

                else
                {

                    if (parent.GetEmplacement() == null)
                    {
                        temp = newuser.Open_folder(parent.GetNom().Trim(), newuser.Getlistdossier());
                    }
                    else
                    {
                        temp = newuser.Open_folder(parent.GetNom().Trim(), parent.GetEmplacement().Getlistdir());
                    }
                }
                int stop = temp.Getlistdir().Length;
                i = 0;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                    listitem.ImageIndex = 0;
                    listitem.SubItems.Add("Folder of files");
                    listitem.SubItems.Add("");
                    listitem.SubItems.Add(temp.Getlistdir()[i].GetDatecreation().ToString());
                    listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                stop = temp.Getlistfichier().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                    listitem.ImageIndex = 1;
                    listitem.SubItems.Add(" File");
                    listitem.SubItems.Add("txt");
                    listitem.SubItems.Add(temp.Getlistfichier()[i].GetDatecreation().ToString());
                    //listitem.SubItems.Add(temp.Getlistfichier()[i].GetBlob().Length.ToString());
                    listitem.SubItems.Add("");
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                stop = newuser.Getlistdossier().Length;
                while (i < stop)
                {
                    TreeNode mainNode = new TreeNode();
                    mainNode.Text = newuser.Getlistdossier()[i].GetNom().Trim();
                    mainNode.Name = newuser.Getlistdossier()[i].GetNom().Trim();
                    treeView1.Nodes.Add(mainNode);
                    i++;
                }

                i = 0;
                while (i < stop)
                {
                    bunifuDropdown1.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                    bunifuDropdown2.AddItem(newuser.Getlistdossier()[i].GetNom().Trim());
                    i++;
                }

            }
            refreshpanel();
            //pictureBox7.Enabled = false;





        }
        public void refreshpanel()
        {
            bunifuButton1.Enabled = false;
            bunifuDropdown1.Enabled = false;
            bunifuDropdown2.Enabled = false;
            bunifuButton3.Enabled = false;
            bunifuButton4.Enabled = false;
            bunifuButton5.Enabled = false;
            bunifuButton6.Enabled = false;
            bunifuButton7.Enabled = false;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshpanel();

            foreach (ListViewItem item in listView2.SelectedItems)
            {
                //ListViewItem item = listView2.SelectedItems[0];

                string nom = item.Text;
                if (item.ImageIndex == 1 || item.ImageIndex == 5)
                {
                    fichier temp = new fichier();
                    //DialogResult dialogResult = MessageBox.Show("are u Sure?", "delete ", MessageBoxButtons.YesNo);
                    refresh();
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //do something
                    if (parent == null)
                    {
                        temp = newuser.Open_file(nom, newuser.Getlistfiles());

                        temp.Supprimer_fichier(temp, false);
                    }
                    else
                    {
                        temp = newuser.Open_file(nom, parent.Getlistfichier());

                        temp.Supprimer_fichier(temp, true);
                    }
                    //}
                    //else if (dialogResult == DialogResult.No)
                    //{
                    //    //do something else
                    //}
                }
                if (item.ImageIndex == 0 || item.ImageIndex == 4)
                {
                    Dossier temp = new Dossier();


                    // DialogResult dialogResult = MessageBox.Show("are u Sure?", "Delete ", MessageBoxButtons.YesNo);
                    refresh();
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    //do something
                    if (parent == null)
                    {
                        temp = newuser.Open_folder(nom, newuser.Getlistdossier());

                        temp.Supprimer_dossier(temp, false);
                    }
                    else
                    {
                        temp = newuser.Open_folder(nom, parent.Getlistdir());

                        temp.Supprimer_dossier(temp, true);
                    }
                    //}
                    //else if (dialogResult == DialogResult.No)
                    //{
                    //    //do something else
                    //}
                }
            }
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                treeView1.Nodes.Add(mainNode);
                j++;
            }
            refresh();
            refreshpanel();


        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh();
            refreshpanel();
        }
        private void copieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshpanel();
            //Dossier temp;
            //fichier tempf;
            ListViewItem item = listView2.SelectedItems[0];
            string nom = item.Text;
            d--;

            if (item.ImageIndex == 0 || item.ImageIndex == 4)
            {
                if (parent == null)
                {
                    dossier = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());


                }

                else
                {
                    dossier = newuser.Open_folder(nom.Trim(), parent.Getlistdir());

                }
                fichier = null;
            }
            if (item.ImageIndex == 1 || item.ImageIndex == 5)
            {
                if (parent == null)
                {
                    fichier = newuser.Open_file(nom.Trim(), newuser.Getlistfiles());


                }

                else
                {
                    fichier = newuser.Open_file(nom.Trim(), newuser.Getlistfiles());


                }
                dossier = null;
            }
            this.pasteToolStripMenuItem.Enabled = true;
            bunifuButton2.Enabled = true;
            d++;
            copie++;

        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshpanel();
            Dossier temp;
            fichier tempf = new fichier();
            if (fichier == null && dossier != null)
            {
                Dossier d = dossier;
                if (parent == null)
                {
                    temp = dossier.Creation_dossier(dossier.GetNom().Trim() + "-copie(" + copie + ")", dossier.GetDatecreation(), newuser, 0);
                    lastindex = db.lastindex();
                    //newuser.Getlistdirlist().Remove(temp);
                    //  temp.setthedlidt(dossier.Getlistofdir());
                    dossier.Getlistofdir().Clear();
                    dossier.Getlistoffiles().Clear();
                    db.chargerdossierdsd(dossier.GetProprietaire(), dossier);
                    db.Chargerlesfichierdsd(dossier.GetProprietaire(), dossier);
                    dossier.clonelist(dossier.Getlistofdir(), temp);
                    tempf.clonelist(dossier.Getlistoffiles(), temp);

                    // dossier = temp;
                    //d.SetEmplacement(null);
                    //db.updateidd(lastindex, -1);
                    //   newuser.Setlisd(dossier);

                }
                else
                {
                    temp = dossier.Creat_sdirec(dossier.GetNom().Trim() + "-copie(" + copie + ")", dossier.GetDatecreation(), parent, newuser, parent.Getid());
                    lastindex = db.lastindex();
                    //    temp.setthedlidt(dossier.Getlistofdir());
                    //temp.Settheflist(dossier.Getlistoffiles());
                    dossier.Getlistofdir().Clear();
                    dossier.Getlistoffiles().Clear();
                    db.chargerdossierdsd(dossier.GetProprietaire(), dossier);
                    db.Chargerlesfichierdsd(dossier.GetProprietaire(), dossier);
                    dossier.clonelist(dossier.Getlistofdir(), temp);
                    tempf.clonelist(dossier.Getlistoffiles(), temp);
                    //dossier = temp;
                    //d.SetEmplacement(parent);

                    //db.updateidd(lastindex, parent.Getid());
                    // d.copieallfiles(parent, d);
                    //   parent.Setlisd(temp);

                }
                if (cut == 1)
                {
                    db.deletedirectory(dossier.Getid());
                    cut = 0;
                    bunifuButton2.Enabled = false;
                }
            }
            if (fichier != null && dossier == null)
            {
                fichier f = fichier;
                if (parent == null)
                {
                    tempf = fichier.Creation_fichieru(fichier.GetNom().Trim() + "-copie(" + copie + ")", "txt", newuser, 0);

                    if (fichier.GetBlob() != null) tempf.Setblob(fichier.GetBlob());

                    fichier = tempf;

                    //f.SetEmplacemnt(null);
                    // newuser.Setlistfiles(fichier);
                    //db.updatefparent(-1, f.Getid());

                }
                else
                {
                    tempf = fichier.Creation_fichier(parent, fichier.GetNom().Trim() + "-copie(" + copie + ")", "txt", newuser, 0);

                    if (fichier.GetBlob() != null) tempf.Setblob(fichier.GetBlob());

                    fichier = tempf;
                    // f.SetEmplacemnt(parent);
                    // d.copieallfiles(parent, d);
                    parent.Setlistfichier(fichier);
                    // db.updatefparent(parent.Getid(), fichier.Getid());

                }
                if (cut == 1)
                {
                    db.deletefile(fichier.Getid());
                    cut = 0;
                    bunifuButton2.Enabled = false;
                }
            }
            refresh();
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                treeView1.Nodes.Add(mainNode);
                j++;
            }



        }
        private void GetPathToRoot(TreeNode node, List<TreeNode> path, int d)
        {

            // previous node was the root.

            //selectedn.ImageIndex = i;
            //node.ImageIndex = i;

            if (node == null) { return; }


            path.Add(node);
            GetPathToRoot(node.Parent, path, 0);



        }
        private void clearnodesoftheparent(TreeNode node)
        {
            int c = treeView1.Nodes.Count;
            int id = node.Index;
            int i = 0;

            while (i < c)
            {
                if (i != id)
                {
                    treeView1.Nodes[i].Nodes.Clear();
                }
                i++;
            }

        }
        private void newDirectoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            Dossier ds = new Dossier();

            if (parent == null)
            {
                ds.Creation_dossier("new directory" + "(" + nd + ")", date, newuser, 0);
                d = 0;
                ListViewItem item = new ListViewItem("new directory" + "(" + nd + ")", 0);
                listView2.Items.Add(item);
                item.BeginEdit();

                treeView1.Nodes.Clear();
                stop = newuser.Getlistdossier().Length;
                int j = 0;
                while (j < stop)
                {

                    TreeNode mainNode = new TreeNode();
                    mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                    mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                    treeView1.Nodes.Add(mainNode);
                    j++;
                }
            }
            else
            {
                ds.Creat_sdirec("new directory" + "(" + nd + ")", date, parent, newuser, parent.Getid());

                ListViewItem item = new ListViewItem("new directory" + "(" + nd + ")", 0);
                listView2.Items.Add(item);
                item.BeginEdit();
                treeView1.Nodes.Clear();
                stop = newuser.Getlistdossier().Length;
                int j = 0;
                while (j < stop)
                {

                    TreeNode mainNode = new TreeNode();
                    mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                    mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                    treeView1.Nodes.Add(mainNode);
                    j++;
                }
            }

            nd++;
            // changename(true);


        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            bunifuDropdown1.Enabled = true;

            //pictureBox7.Enabled = true;
            bunifuButton1.Enabled = true;

            bunifuButton3.Enabled = true;
            bunifuButton4.Enabled = true;
            bunifuButton5.Enabled = true;
            bunifuButton6.Enabled = true;
            bunifuButton7.Enabled = true;
            bunifuButton8.Enabled = true;

            bunifuDropdown2.Enabled = true;

        }    
        private void newFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fichier newf = new fichier();



            if (parent == null)
            {
                newf.Creation_fichieru("new file" + "(" + ff + ")", "txt", newuser, db.lastindexf());

                ListViewItem item = new ListViewItem("new file" + "(" + ff + ")", 1);
                listView2.Items.Add(item);
                item.BeginEdit();
                //d = 0;
                ff++;
            }
            else
            {


                newf.Creation_fichier(parent, "new file" + "(" + ff + ")", "txt", newuser, db.lastindexf());
                ListViewItem item = new ListViewItem("new file" + "(" + ff + ")", 1);
                listView2.Items.Add(item);
                item.BeginEdit();
                ff++;
                //d++;
            }


            //    changename(false);


        }   
        private void listView2_MouseHover(object sender, EventArgs e)
        {

            Point localPoint = listView2.PointToClient(MousePosition);
            ListViewItem item = listView2.GetItemAt(localPoint.X, localPoint.Y);
            if (item == null && hoveritem != null)
            {
                hoveritem.BackColor = Color.Transparent;
                if (hoveritem.ImageIndex == 4) { hoveritem.ImageIndex = 0; }
                if (hoveritem.ImageIndex == 5) { hoveritem.ImageIndex = 1; }

            }
        }
        private void listView2_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (hoveritem == null)
            {
                e.Item.BackColor = Color.FromArgb(173, 216, 230);
                if (e.Item.ImageIndex == 0) { e.Item.ImageIndex = 4; }
                if (e.Item.ImageIndex == 1) { e.Item.ImageIndex = 5; }
                hoveritem = e.Item;
            }
            else
            {
                hoveritem.BackColor = Color.Transparent;
                if (hoveritem.ImageIndex == 4) { hoveritem.ImageIndex = 0; }
                if (hoveritem.ImageIndex == 5) { hoveritem.ImageIndex = 1; }
                // hoveritem.ImageList.TransparentColor = Color.AliceBlue;
                hoveritem = e.Item;
                //e.Item.ImageList.TransparentColor = Color.AliceBlue;
                e.Item.BackColor = Color.FromArgb(173, 216, 230);
                if (e.Item.ImageIndex == 0) { e.Item.ImageIndex = 4; }
                if (e.Item.ImageIndex == 1) { e.Item.ImageIndex = 5; }
            }

        }
        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)))
            {

                Dossier temp = new Dossier();
                Dossier temp2 = new Dossier();
                fichier tempf = new fichier();
                ListViewItem dropitem = new ListViewItem();
                if (parent == null)
                {
                    if (current.ImageIndex == 0)
                    {

                        Point p = listView2.PointToClient(new Point(e.X, e.Y));
                        dropitem = listView2.GetItemAt(p.X, p.Y);
                        if (dropitem == null)
                        {
                            return;
                        }
                        if (dropitem.ImageIndex == 1)
                        {
                            return;
                        }
                        if (dropitem == current)
                        {
                            return;
                        }


                        temp = temp.Open_folder(current.Text.Trim(), newuser.Getlistdossier());
                        temp2 = temp2.Open_folder(dropitem.Text.Trim(), newuser.Getlistdossier());
                        if (temp.Exists(temp.GetNom(), temp2.Getlistdir()))
                        {
                            temp.SetNom(temp.GetNom() + "(" + drop + ")", temp.GetNom(), temp.Getid());
                            drop++;
                        }


                        db.updatedparent(dropitem.Text.Trim(), temp.Getid(), temp2.Getid());
                        itemdrop = current;
                        current.Remove();
                        temp.SetEmplacement(temp2);
                        newuser.Getlistdirlist().Remove(temp);
                        temp2.Setlisd(temp);
                        refresh();

                    }
                    else
                    {
                        Point p = listView2.PointToClient(new Point(e.X, e.Y));
                        dropitem = listView2.GetItemAt(p.X, p.Y);
                        if (dropitem == null) { return; }
                        if (dropitem.ImageIndex == 1)
                        {
                            return;
                        }
                        tempf = tempf.Open_file(current.Text.Trim(), newuser.Getlistfiles());

                        temp2 = temp2.Open_folder(dropitem.Text.Trim(), newuser.Getlistdossier());
                        db.updatefparent(temp2.Getid(), tempf.Getid());
                        itemdrop = current;
                        current.Remove();
                        tempf.SetEmplacemnt(temp2);
                        newuser.Getlistfilelist().Remove(tempf);
                        temp2.Setlistfichier(tempf);
                        refresh();
                    }

                }
                else
                {
                    if (current.ImageIndex == 0)
                    {

                        Point p = listView2.PointToClient(new Point(e.X, e.Y));
                        dropitem = listView2.GetItemAt(p.X, p.Y); if (dropitem == null)
                        {
                            return;
                        }
                        if (dropitem.ImageIndex == 1)
                        {
                            return;
                        }
                        temp = temp.Open_folder(current.Text, parent.Getlistdir());
                        temp2 = temp2.Open_folder(dropitem.Text, parent.Getlistdir());
                        if (temp.Exists(temp.GetNom(), temp2.Getlistdir()))
                        {
                            temp.SetNom(temp.GetNom() + "(" + drop + ")", temp.GetNom(), temp.Getid());
                            drop++;
                        }

                        db.updatedparent(dropitem.Text, temp.Getid(), temp2.Getid());
                        itemdrop = current;
                        current.Remove();
                        temp.SetEmplacement(temp2);
                        parent.Getlistofdir().Remove(temp);
                        temp2.Setlisd(temp);
                        refresh();

                    }
                    else
                    {
                        Point p = listView2.PointToClient(new Point(e.X, e.Y));
                        dropitem = listView2.GetItemAt(p.X, p.Y); if (dropitem == null)
                        {
                            return;
                        }
                        if (dropitem.ImageIndex == 1)
                        {
                            return;
                        }
                        tempf = tempf.Open_file(current.Text, parent.Getlistfichier());
                        temp2 = temp2.Open_folder(dropitem.Text, parent.Getlistdir());
                        db.updatefparent(temp2.Getid(), tempf.Getid());
                        itemdrop = current;
                        current.Remove();
                        temp.SetEmplacement(temp2);
                        parent.Getlistoffiles().Remove(tempf);
                        temp2.Setlisd(temp);
                        refresh();
                    }
                }

            }
        }
        private void listView2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //itemdrop= (ListViewItem)e.Item;
            //listView2
            listView2.DoDragDrop(listView2.SelectedItems, DragDropEffects.All);
            // listView2.Cursor= Cursor = System.Windows.Forms.Cursors.Hand;
            //  Cursor.ha

        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListViewItem item = listView2.SelectedItems[0];
            copieToolStripMenuItem_Click(sender, e);
            if (item.ImageIndex == 0)
            {
                item.ImageIndex = 2;
            }
            else { item.ImageIndex = 3; }
            cut = 1;
            if (dossier != null && fichier == null)
            {
                dossier = null;
            }
            if (dossier == null && fichier != null)
            {
                fichier = null;
            }


        }
        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proprety pr;
            ListViewItem item = listView2.SelectedItems[0];

            string nom = item.Text;
            if (item.ImageIndex == 1)
            {
                fichier temp = new fichier();

                refresh();

                //do something
                if (parent == null)
                {
                    temp = newuser.Open_file(nom, newuser.Getlistfiles());

                    pr = new Proprety(temp, null);
                    pr.Visible = true;
                }
                else
                {
                    temp = newuser.Open_file(nom, parent.Getlistfichier());

                    pr = new Proprety(temp, null);
                    pr.Visible = true;
                }


            }
            if (item.ImageIndex == 0)
            {
                Dossier temp = new Dossier();



                refresh();

                //do something
                if (parent == null)
                {
                    temp = newuser.Open_folder(nom, newuser.Getlistdossier());

                    pr = new Proprety(null, temp);
                    pr.Visible = true;
                }
                else
                {
                    temp = newuser.Open_folder(nom, parent.Getlistdir());

                    pr = new Proprety(null, temp);
                    pr.Visible = true;
                }


            }
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                treeView1.Nodes.Add(mainNode);
                j++;
            }
            refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (selectedn != null)
            {
                selectedn.BackColor = Color.Transparent;
                selectedn.SelectedImageIndex = 0;
                selectedn = treeView1.SelectedNode;
            }
            if (previousnode != null)
            {
                previousnode.ImageIndex = 0;
            }

            string nom = previousnode.Text;

            beforlist.Clear();

            MF = 0;
            button1.Enabled = true;
            previousnode.Nodes.Clear();


            Dossier temp = new Dossier();

            if (previousnode.Parent == null)
            {
                if (retour == 0)
                {
                    temp = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
                    temp.Getlistoffiles().Clear();
                    temp.Getlistofdir().Clear();
                    db.chargerdossierdsd(newuser, temp);
                    db.Chargerlesfichierdsd(newuser, temp);
                    parent = temp;
                    chemin = "";
                    d = 0;
                    chemin = previousnode.FullPath.Trim() + "/";
                    maskedTextBox1.Text = thenewpath + previousnode.FullPath + "/";
                    string[] parentname = previousnode.FullPath.Split('/');
                    string f = parentname[parentname.Length - 1];
                }
                else
                {
                    string[] parentname = previousnode.FullPath.Split('/');
                    string f = parentname[parentname.Length - 1];

                    temp = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
                    //db.chargerdossierdsd(newuser, temp);
                    // db.Chargerlesfichierdsd(newuser, temp);
                    parent = temp;
                    chemin = "";
                    d = 0;
                    chemin = previousnode.FullPath.Trim() + "/";
                    maskedTextBox1.Text = thenewpath + previousnode.FullPath + "/";
                }
            }

            else
            {
                string[] parentname = previousnode.FullPath.Split('/');
                string f = parentname[parentname.Length - 1];

                temp = newuser.Open_folder(parentname[0].Trim(), newuser.Getlistdossier());
                for (int k = 1; k < parentname.Length; k++)
                {
                    temp = newuser.Open_folder(parentname[k].Trim(), temp.Getlistdir());
                }
              

                chemin = previousnode.FullPath.Trim();
                maskedTextBox1.Text = thenewpath + previousnode.FullPath.Trim() + "/";

                parent = temp;


                if (temp.Getlistdir().Length == 0 && temp.Getlistfichier().Length == 0)
                {
                    db.chargerdossierdsd(newuser, temp);
                    db.Chargerlesfichierdsd(newuser, temp);

                }


            }



            int i = 0;
            int stop = temp.Getlistdir().Length;
            listView2.Clear();
            while (i < stop)
            {


                ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                TreeNode nod = new TreeNode();
                listView2.Items.Add(listitem);
                nod.Name = temp.Getlistdir()[i].GetNom().Trim();
                nod.Text = temp.Getlistdir()[i].GetNom().Trim();
                nod.Tag = temp.Getlistdir()[i].GetNom().Trim();

                previousnode.Nodes.Add(nod);
                previousnode.ExpandAll();
                i++;

            }
            i = 0;
            stop = temp.Getlistfichier().Length;

            while (i < stop)
            {


                ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                TreeNode nod = new TreeNode();
                listView2.Items.Add(listitem);

                i++;

            }


            foreach (TreeNode t in parentsnode)
            {
                t.ImageIndex = 0;
            }
            parentsnode.Clear();
            previousnode.SelectedImageIndex = 2;

            GetPathToRoot(previousnode, parentsnode, 1);

            foreach (TreeNode t in parentsnode)
            {
                t.ImageIndex = 2;
            }
            selectedn = previousnode;


        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            TreeNode test = previousnode;
            string nom = test.Name;
            fichier = null;

            if (previousnode.Parent == null)
            {
                dossier = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
            }

            else
            {
                dossier = parent;
            }
            this.pasteToolStripMenuItem.Enabled = true;
            bunifuButton2.Enabled = true;


        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            TreeNode test = previousnode;
            string nom = test.Name;
            Dossier d = dossier;

            if (treeView1.SelectedNode.Parent == null)
            {
                newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
                d.SetEmplacement(newuser.Open_folder(nom.Trim(), newuser.Getlistdossier()));
                newuser.Setlisd(d);
                refresh();
            }

            else
            {
                d.SetEmplacement(parent);

                d.copieallfiles(parent, d);
                parent.Setlisd(d);
                refresh();
            }
        }   
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            TreeNode item = previousnode;


            string nom = item.Name;


            Dossier temp = new Dossier();




            //do something
            if (parent == null)
            {
                temp = newuser.Open_folder(nom, newuser.Getlistdossier());

                temp.Supprimer_dossier(temp, false);
            }
            else
            {
                temp = newuser.Open_folder(nom, parent.Getlistdir());
                temp.Supprimer_dossier(temp, true);
            }


            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                treeView1.Nodes.Add(mainNode);
                j++;
            }
            refresh();


        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

            if (parent == null)
            {
                fichier.Creation_fichieru("new file" + "(" + ff + ")", "txt", newuser, 0);
                ff++;
                refresh();
                d = 0;
            }
            else
            {

                fichier.Creation_fichier(parent, "new file" + "(" + ff + ")", "txt", newuser, 0);
                refresh();
                ff++;
                d++;
            }


            //changename(false);

        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            dossier = new Dossier();

            dossier.Creation_dossier("new directory" + "(" + nd + ")", date, newuser, 0);

            d = 0;
            refresh();
            treeView1.Nodes.Clear();
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                treeView1.Nodes.Add(mainNode);
                j++;
            }
            stop = treeView1.Nodes.Count - 1;
            treeView1.Nodes[stop].BeginEdit();
            nodeoldname = treeView1.Nodes[stop].Text;




            //  changename(true);


        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // Regex regex = new Regex("(" + textBox1.Text + ")", RegexOptions.IgnoreCase);
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem itemsear in listView2.Items)
            {
                if (itemsear.Text.Contains(textBox1.Text.ToLower()) || itemsear.Text.Contains(textBox1.Text.ToUpper()))
                {
                    // string newtxt;
                    items.Add(itemsear);



                }


            }
            //  ListViewItem[] items= listView2.Item.Find(textBox1.Text,false);
            //  ListViewItem item = listView2.FindItemWithText(textBox1.Text);
            listView2.Clear();

            listView2.Items.AddRange(items.ToArray());
            if (textBox1.Text == "") { refresh(); }
        }
        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

            if (previousnode == null)
            {
                e.Node.BackColor = Color.FromArgb(173, 216, 230);
                e.Node.ImageIndex = 4;
                if (e.Node.ImageIndex == 2 || e.Node.ImageIndex == 3)
                {
                    e.Node.ImageIndex = 5;
                }
                previousnode = e.Node;
            }
            if (previousnode != null)
            {
                previousnode.BackColor = Color.Transparent;

                if (previousnode.ImageIndex == 5)
                {
                    if (previousnode == treeView1.SelectedNode)
                    {
                        previousnode.ImageIndex = 3;
                    }
                    else
                    {
                        previousnode.ImageIndex = 2;
                    }
                }
                else { previousnode.ImageIndex = 0; }
                previousnode = e.Node;
                testnode = e.Node;

                e.Node.BackColor = Color.FromArgb(173, 216, 230);

                if (e.Node.ImageIndex == 2 || e.Node == selectedn)
                {
                    e.Node.ImageIndex = 5;
                }
                else { e.Node.ImageIndex = 4; }
            }




        }
        private void treeView1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (previousnode != null)
            {
                //treeView1.SelectedNode.BackColor = Color.Gray;
                previousnode.BackColor = Color.Transparent;
            }
        }
        private void treeView1_MouseLeave(object sender, EventArgs e)
        {

            if (selectedn == null)
            {
                //treeView1.SelectedNode.BackColor = Color.Gray;
                selectedn = treeView1.SelectedNode;

                if (treeView1.SelectedNode != null)
                {
                    selectedn.BackColor = Color.Gray;
                    selectedn.SelectedImageIndex = 3;
                }

            }
            else
            {

                selectedn.BackColor = Color.Gray;
                selectedn.SelectedImageIndex = 3;


            }
            if (previousnode != null)
            {
                previousnode.BackColor = Color.Transparent;
                previousnode.ImageIndex = 0;
            }

        }
        private void bunifuDropdown2_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            Dossier temp = new Dossier();
            Dossier temp2 = new Dossier();

            temp2 = newuser.Open_folder(bunifuDropdown1.selectedValue.ToString(), newuser.Getlistdossier());
            if (parent != null)
            {
                temp = newuser.Open_folder(listView2.SelectedItems[0].Text, parent.Getlistdir());
                foreach (Dossier d in parent.Getlistofdir())
                {
                    if (d.GetNom() == temp.GetNom())
                    {
                        parent.Getlistofdir().Remove(d);
                        //db.deletedirectory(d.Getid());
                        db.updatedparent(null, d.Getid(), temp2.Getid());
                     

                    }
                }


                temp2.Setlisd(temp);

                temp.SetEmplacement(temp2);

                refresh();
                bunifuDropdown1.Enabled = false;
            }
            else
            {
                temp = newuser.Open_folder(listView2.SelectedItems[0].Text, newuser.Getlistdossier());
                foreach (Dossier d in newuser.Getlistdossier())
                {
                    if (d.GetNom() == temp.GetNom())
                    {
                        newuser.Getlistdirlist().Remove(d);
                        //db.deletedirectory(d.Getid());
                        db.updatedparent(null, d.Getid(), temp2.Getid());


                    }
                }


                temp2.Setlisd(temp);

                temp.SetEmplacement(temp2);

                refresh();
                bunifuDropdown1.Enabled = false; }

            stop = newuser.Getlistdossier().Length;
            int j = 0;

            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();

            while (j < stop)
            {


                bunifuDropdown2.AddItem(newuser.Getlistdossier()[j].GetNom().Trim());
                bunifuDropdown1.AddItem(newuser.Getlistdossier()[j].GetNom().Trim());

                j++;
            }
        }
        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            copieToolStripMenuItem_Click(sender, e);
            Dossier temp;
            Dossier oldp;
            fichier tempf = new fichier();
            if (fichier == null && dossier != null)
            {

                Dossier d = dossier;
                oldp = dossier.Open_folder(bunifuDropdown2.selectedValue, newuser.Getlistdossier());
                temp = dossier.Creat_sdirec(dossier.GetNom().Trim() + "-copie(" + copie + ")", dossier.GetDatecreation(), oldp, newuser, oldp.Getid());
                lastindex = db.lastindex();
                //    temp.setthedlidt(dossier.Getlistofdir());
                //temp.Settheflist(dossier.Getlistoffiles());
                dossier.Getlistofdir().Clear();
                dossier.Getlistoffiles().Clear();
                db.chargerdossierdsd(dossier.GetProprietaire(), dossier);
                db.Chargerlesfichierdsd(dossier.GetProprietaire(), dossier);
                dossier.clonelist(dossier.Getlistofdir(), temp);
                tempf.clonelist(dossier.Getlistoffiles(), temp);
                //dossier = temp;
                //d.SetEmplacement(parent);

                //db.updateidd(lastindex, parent.Getid());
                // d.copieallfiles(parent, d);





                if (cut == 1)
                {
                    db.deletedirectory(dossier.Getid());
                    cut = 0;
                    bunifuButton2.Enabled = false;
                }
            }
            if (fichier != null && dossier == null)
            {
                fichier f = fichier;


                tempf = fichier.Creation_fichier(parent, fichier.GetNom().Trim() + "-copie(" + copie + ")", "txt", newuser, 0);

                if (fichier.GetBlob() != null) tempf.Setblob(fichier.GetBlob());

                fichier = tempf;
                // f.SetEmplacemnt(parent);
                // d.copieallfiles(parent, d);
                parent.Setlistfichier(fichier);
                // db.updatefparent(parent.Getid(), fichier.Getid());


                if (cut == 1)
                {
                    db.deletefile(fichier.Getid());
                    cut = 0;
                    bunifuButton2.Enabled = false;
                }
            }
            refresh();
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();

            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                bunifuDropdown2.AddItem(newuser.Getlistdossier()[j].GetNom().Trim());
                bunifuDropdown1.AddItem(newuser.Getlistdossier()[j].GetNom().Trim());
                treeView1.Nodes.Add(mainNode);
                j++;
            }




        }
        private void treeView1_Leave(object sender, EventArgs e)
        {
            //previousnode.BackColor = Color.Transparent;
            //if (selectedn == null)
            //{
            //    treeView1.SelectedNode.BackColor = Color.Gray;
            //    selectedn = treeView1.SelectedNode;
            //}
            //else
            //{
            //    selectedn.BackColor = Color.Transparent;
            //    selectedn = treeView1.SelectedNode;

            //    treeView1.SelectedNode.BackColor = Color.Gray;
            //}
            //if (previousnode != null)
            //{
            //    previousnode.BackColor = Color.Transparent;
            //}
        }
        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems[0] != null)
            {
                renameToolStripMenuItem_Click(sender, e);
                refreshpanel();
            }
            else
            {
                refreshpanel();
            }

        }
        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                deleteToolStripMenuItem_Click(sender, e);
                refreshpanel();
                bunifuButton2.Enabled = false;
            }
            else
            {
                refreshpanel();
            }
        }
        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                copieToolStripMenuItem_Click(sender, e);
                bunifuButton2.Enabled = true;

            }
            else
            {
                refreshpanel();
            }

        }
        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
            refreshpanel();
            bunifuButton2.Enabled = false;

            refreshpanel();


        }
        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                cutToolStripMenuItem_Click(sender, e);
                bunifuButton2.Enabled = true;
                refreshpanel();

            }
            else
            {
                refreshpanel();
            }


        }
        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(chemin);
            refreshpanel();
            bunifuButton2.Enabled = false;
        }
        private void bunifuButton7_Click_1(object sender, EventArgs e)
        {
            if (listView2.SelectedItems == null)
            {
                propertyToolStripMenuItem_Click(sender, e);
                refreshpanel();
                bunifuButton2.Enabled = false;
            }
            else
            {
                refreshpanel();
            }
        }
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            newDirectoryToolStripMenuItem1_Click(sender, e);
        }
        private void listView2_MouseUp(object sender, MouseEventArgs e)
        {
            ListView tmp_SenderListView = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {

                if (tmp_SenderListView.SelectedItems.Count > 0)
                {
                    listView2.ContextMenuStrip = contextMenuStrip1; ;
                }
                else
                {
                    listView2.ContextMenuStrip = contextMenuStrip3; ;
                }
            }
            if (e.Button == MouseButtons.Left)
            {

                if (tmp_SenderListView.SelectedItems.Count == 0)
                {
                    refreshpanel();

                }

            }
        }
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // listView2.LargeImageList = imageList2;
            //  listView2.Items.Clear();
            listView2.View = View.Details;
            //if (parent == null) { 
            //stop = newuser.Getlistdossier().Length;

            //while (i < stop)
            //{

            //    ListViewItem listitem = new ListViewItem(newuser.Getlistdossier()[i].GetNom().Trim(), 0);
            //    listitem.ImageIndex = 0;

            //    listitem.SubItems.Add("Folder of files");
            //    listitem.SubItems.Add("");
            //    listitem.SubItems.Add(newuser.Getlistdossier()[i].GetDatecreation().ToString());
            //    listitem.SubItems.Add("");
            //    listView2.Items.Add(listitem);
            //    i++;
            //}
            //i = 0;
            //stop = newuser.Getlistfiles().Length;
            //while (i < stop)
            //{
            //    ListViewItem listitem = new ListViewItem(newuser.Getlistfiles()[i].GetNom().Trim(), 1);
            //    listitem.ImageIndex = 1;
            //    listitem.SubItems.Add(" File");
            //    listitem.SubItems.Add("txt");
            //    listitem.SubItems.Add(newuser.Getlistfiles()[i].GetDatecreation().ToString());
            //    listitem.SubItems.Add("");
            //    listView2.Items.Add(listitem);
            //    i++;
            //}
            //i = 0;

            //}
            //else
            //{
            //    stop = parent.Getlistdir().Length;

            //    while (i < stop)
            //    {

            //        ListViewItem listitem = new ListViewItem(parent.Getlistdir()[i].GetNom().Trim(), 0);
            //        listitem.ImageIndex = 0;
            //        listitem.SubItems.Add("Folder of files");
            //        listitem.SubItems.Add("");
            //        listitem.SubItems.Add(parent.Getlistdir()[i].GetDatecreation().ToString());
            //        listitem.SubItems.Add("");
            //        listView2.Items.Add(listitem);                   
            //        i++;
            //    }
            //    i = 0;
            //    stop = newuser.Getlistfiles().Length;
            //    while (i < stop)
            //    {
            //        ListViewItem listitem = new ListViewItem(parent.Getlistfichier()[i].GetNom().Trim(), 1);
            //        listitem.ImageIndex = 1;
            //        listitem.SubItems.Add(" File");

            //        listitem.SubItems.Add("txt");
            //        listitem.SubItems.Add(parent.Getlistfichier()[i].GetDatecreation().ToString());
            //        listitem.SubItems.Add("");

            //        listView2.Items.Add(listitem);

            //        i++;
            //    }
            //    i = 0;

            //}
        }
        private void bigIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // listView2.GridLines = false;
            listView2.View = View.LargeIcon;
            //  listView2.LargeImageList = imageList2;
            // refresh();
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }
        private void newDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDirectoryToolStripMenuItem1_Click(sender, e);
        }
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFileToolStripMenuItem1_Click(sender, e);
        }
        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView2.View = View.SmallIcon;
            //listView2.LargeImageList = imageList3; ;
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {

            TreeNode test = treeView1.GetNodeAt(Cursor.Position.X, Cursor.Position.Y);
            test = treeView1.GetNodeAt(treeView1.PointToClient(Cursor.Position));

        }
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode test = treeView1.GetNodeAt(Cursor.Position.X, Cursor.Position.Y);

            test = treeView1.GetNodeAt(treeView1.PointToClient(Cursor.Position));
            if (e.Button == MouseButtons.Right)
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.Nodes.Contains(test))
                    {
                        treeView1.ContextMenuStrip = contextMenuStrip2;
                        contextMenuStrip1.Show(Cursor.Position);

                    }
                }

            }

        }
        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView2.View = View.List;
        }
        private void listView2_MouseLeave(object sender, EventArgs e)
        {
            if (hoveritem != null)
            {
                if (hoveritem.ImageIndex == 4) { hoveritem.ImageIndex = 0; }
                if (hoveritem.ImageIndex == 5) { hoveritem.ImageIndex = 1; }
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            TreeNode test = previousnode;
            string nom = test.Name;
        }      
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {


            if (selectedn != null)
            {
                selectedn.BackColor = Color.Transparent;
                selectedn.SelectedImageIndex = 0;
                selectedn = treeView1.SelectedNode;
            }
            if (previousnode != null)
            {
                previousnode.ImageIndex = 0;
            }

            string nom = treeView1.SelectedNode.Text;

            beforlist.Clear();


            //if (imagenode == null)
            //{
            //    treeView1.SelectedNode.SelectedImageIndex = 2;
            //    imagenode = treeView1.SelectedNode;
            //}
            //else
            //{
            //    imagenode.SelectedImageIndex = 0;
            //    treeView1.SelectedNode.SelectedImageIndex = 2;
            //    imagenode = treeView1.SelectedNode;

            //}


            //selectedn = treeView1.SelectedNode;
            MF = 0;
            button1.Enabled = true;
            treeView1.SelectedNode.Nodes.Clear();


            Dossier temp = new Dossier();

            if (treeView1.SelectedNode.Parent == null)
            {
                if (retour == 0)
                {
                    temp = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
                    temp.Getlistoffiles().Clear();
                    temp.Getlistofdir().Clear();
                    db.chargerdossierdsd(newuser, temp);
                    db.Chargerlesfichierdsd(newuser, temp);
                    parent = temp;
                    chemin = "";
                    d = 0;
                    chemin = treeView1.SelectedNode.FullPath.Trim() + "/";
                    maskedTextBox1.Text = thenewpath + treeView1.SelectedNode.FullPath + "/";
                    string[] parentname = treeView1.SelectedNode.FullPath.Split('/');
                    string f = parentname[parentname.Length - 1];
                }
                else
                {
                    string[] parentname = treeView1.SelectedNode.FullPath.Split('/');
                    string f = parentname[parentname.Length - 1];

                    temp = newuser.Open_folder(nom.Trim(), newuser.Getlistdossier());
                    //db.chargerdossierdsd(newuser, temp);
                    // db.Chargerlesfichierdsd(newuser, temp);
                    parent = temp;
                    chemin = "";
                    d = 0;
                    chemin = treeView1.SelectedNode.FullPath.Trim() + "/";
                    maskedTextBox1.Text = thenewpath + treeView1.SelectedNode.FullPath + "/";
                }
            }

            else
            {
                string[] parentname = treeView1.SelectedNode.FullPath.Split('/');
                string f = parentname[parentname.Length - 1];

                temp = newuser.Open_folder(parentname[0].Trim(), newuser.Getlistdossier());
                for (int k = 1; k < parentname.Length; k++)
                {
                    temp = newuser.Open_folder(parentname[k].Trim(), temp.Getlistdir());
                }
                //foreach(string name in parentname)
                //{
                //    temp = newuser.Open_folder(nom.Trim(), temp.Getlistdossier());
                //}
                //    temp = newuser.Open_folder(nom.Trim(), parent.Getlistdir());
                //if (parent.GetEmplacement() != null && parent.GetEmplacement().GetEmplacement()!=null && treeView1.SelectedNode.Text.Equals(parent.GetEmplacement().GetNom().Trim()))
                //{
                //    temp = newuser.Open_folder(nom.Trim(), parent.GetEmplacement().GetEmplacement().Getlistdir());

                //    chemin = treeView1.SelectedNode.FullPath.Trim() + "/";


                //    maskedTextBox1.Text = thenewpath + treeView1.SelectedNode.FullPath+ "/";
                //}
                //if (parent.GetEmplacement() != null && treeView1.SelectedNode.Parent!=null && treeView1.SelectedNode.Parent.Text.Trim().Equals(parent.GetEmplacement().GetNom().Trim()))
                //{
                //    temp = newuser.Open_folder(nom.Trim(), parent.GetEmplacement().Getlistdir());

                //    chemin = treeView1.SelectedNode.FullPath.Trim();
                //    maskedTextBox1.Text = thenewpath + treeView1.SelectedNode.FullPath.Trim()+ "/";
                //}
                //else

                chemin = treeView1.SelectedNode.FullPath.Trim();
                maskedTextBox1.Text = thenewpath + treeView1.SelectedNode.FullPath.Trim() + "/";

                parent = temp;


                if (temp.Getlistdir().Length == 0 && temp.Getlistfichier().Length == 0)
                {
                    db.chargerdossierdsd(newuser, temp);
                    db.Chargerlesfichierdsd(newuser, temp);

                }


            }



            int i = 0;
            int stop = temp.Getlistdir().Length;
            listView2.Clear();
            while (i < stop)
            {


                ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                TreeNode nod = new TreeNode();
                listView2.Items.Add(listitem);
                nod.Name = temp.Getlistdir()[i].GetNom().Trim();
                nod.Text = temp.Getlistdir()[i].GetNom().Trim();
                nod.Tag = temp.Getlistdir()[i].GetNom().Trim();

                treeView1.SelectedNode.Nodes.Add(nod);
                treeView1.SelectedNode.ExpandAll();
                i++;

            }
            i = 0;
            stop = temp.Getlistfichier().Length;

            while (i < stop)
            {


                ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                TreeNode nod = new TreeNode();
                listView2.Items.Add(listitem);

                i++;

            }


            foreach (TreeNode t in parentsnode)
            {
                t.ImageIndex = 0;
            }
            parentsnode.Clear();
            treeView1.SelectedNode.SelectedImageIndex = 2;

            GetPathToRoot(treeView1.SelectedNode, parentsnode, 1);

            foreach (TreeNode t in parentsnode)
            {
                t.ImageIndex = 2;
            }


            // clearnodesoftheparent(treeView1.SelectedNode);
            //foreach(TreeNode node in parentsnode)
            //{
            //    node.SelectedImageIndex = -1;
            //}
            //  GetPathToRoot(treeView1.SelectedNode, parentsnode);



        }
        private void treeView1_LocationChanged(object sender, EventArgs e)
        {

            //if (previousnode != null)
            //{
            //    previousnode.BackColor = Color.Transparent;
            //    previousnode.ImageIndex = 0;
            //}
            //var point = treeView1.PointToClient(MousePosition);
            //var node = treeView1.GetNodeAt(point);
            //if (node == null)
            //{
            //    if (previousnode != null)
            //    {
            //        previousnode.BackColor = Color.Transparent;
            //        previousnode.ImageIndex = 0;
            //    }

            //}
        }
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string nom = "";
            foreach (TreeNode item in treeView1.Nodes)
            {
                if (item.Text == e.Label || item.Text == nom)
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Please enter a non-used name.");
                    e.Node.BeginEdit();
                    return;
                }
                nom = item.Text;
            }
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                //  e.Node.BeginEdit();
                // MessageBox.Show("Please enter a valid value.");
                //return;
            }

            else
            {

                Dossier temp = new Dossier();
                fichier tempf = new fichier();
                temp = newuser.Open_folder(nodeoldname, newuser.Getlistdossier());
                temp.SetNom(e.Label, nodeoldname, temp.Getid());
                nd++;
                refresh();


            }
        }
        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Dossier temp;
            string newname;
            if (e.KeyCode == Keys.Enter)
            {

                string[] parentname = maskedTextBox1.Text.Split('/');
                temp = newuser.Open_folder(parentname[1].Trim(), newuser.Getlistdossier());
                if (temp == null)
                {
                    return;
                }
                newname = parentname[1].Trim();
                for (int k = 2; k < parentname.Length; k++)
                {
                    temp = newuser.Open_folder(parentname[k].Trim(), temp.Getlistdir());
                    if (temp == null)
                    {
                        return;
                    }
                    newname = newname + "/" + parentname[k].Trim();
                }

                chemin = newname;
                parent = temp;
                refresh();
                //string[] f = parentname[parentname.Length - 1];
            }
        }  
        private void button2_Click(object sender, EventArgs e)
        {

            if (beforlist != null)
            {
                if (beforlist.ToArray()[0] == null) { return; }
                int index = 0;
                if (c == 0 && MF == 1)
                {
                    return;
                }
                if (MF == 1)
                {
                    c = c - 1;
                    index = c;
                }
                if (MF == 0)
                {
                    index = beforlist.Count;
                    index = index - 1;
                    c = index;
                    MF = 1;
                }


                parent = beforlist.ToArray()[index];
                if (index == 0)
                {
                    g = true;
                }
                i = 0;
                stop = parent.Getlistdir().Length;
                listView2.Clear();
                while (i < stop)
                {

                    ListViewItem listitem = new ListViewItem(parent.Getlistdir()[i].GetNom().Trim(), 0);
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                stop = parent.Getlistfichier().Length;
                while (i < stop)
                {
                    ListViewItem listitem = new ListViewItem(parent.Getlistfichier()[i].GetNom().Trim(), 1);
                    listView2.Items.Add(listitem);
                    i++;
                }
                i = 0;
                refreshpanel();
                chemin = chemin.Trim() + parent.GetNom().Trim() + "/";
                maskedTextBox1.Text = thenewpath + chemin;
            }
        }
        private void listView2_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {


            listV = listView2.SelectedItems[0];
            labeloldname = listV.Text;
            labelitem= listView2.SelectedItems[0];

        }
        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            // listView2.DoDragDrop(listView2.SelectedItems, DragDropEffects.Move);
            e.Effect = DragDropEffects.All;
        }
        private void listView2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
            // DragCursorMove = CursorUtil.CreateCursor((Bitmap)bm.Clone(), DragStart.X, DragStart.Y);
            // listView2.Cursor=Cursor.

        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {


            if (e.Data.GetDataPresent("System.Windows.Forms.ListView+SelectedListViewItemCollection", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode dropitem = ((TreeView)sender).GetNodeAt(pt);
                ListView.SelectedListViewItemCollection lvi = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
                Dossier temp = new Dossier();
                Dossier temp2 = new Dossier();
                Dossier oldp = new Dossier();
                fichier tempf = new fichier();
                oldp = parent;

                foreach (ListViewItem current in lvi)
                {


                    if (parent == null)
                    {
                        if (current.ImageIndex == 0)
                        {
                            if (dropitem == null)
                            {

                                return;
                            }





                            temp = temp.Open_folder(current.Text, newuser.Getlistdossier());
                            temp2 = temp2.Open_folder(dropitem.Text, newuser.Getlistdossier());
                            if (temp == temp2)
                            {
                                return;
                            }
                            db.updatedparent(dropitem.Text, temp.Getid(), temp2.Getid());
                            itemdrop = current;
                            current.Remove();
                            temp.SetEmplacement(temp2);
                            newuser.Getlistdirlist().Remove(temp);
                            temp2.Setlisd(temp);
                            refresh();

                        }
                        else
                        {

                            if (dropitem == null)
                            {
                                temp = temp.Open_folder(current.Text, newuser.Getlistdossier());

                                db.updatedparent(null, temp.Getid(), -1);
                                itemdrop = current;
                                current.Remove();
                                temp.SetEmplacement(null);
                                newuser.AddtlistDossier(temp);

                                refresh();

                                return;
                            }
                            if (dropitem.ImageIndex == 1)
                            {
                                return;
                            }
                            tempf = tempf.Open_file(current.Text, newuser.Getlistfiles());
                            temp2 = temp2.Open_folder(dropitem.Text, newuser.Getlistdossier());
                            db.updatefparent(temp2.Getid(), tempf.Getid());
                            itemdrop = current;
                            current.Remove();
                            tempf.SetEmplacemnt(temp2);

                            newuser.Getlistfilelist().Remove(tempf);
                            temp2.Setlistfichier(tempf);
                            refresh();
                        }

                    }
                    else
                    {
                        if (current.ImageIndex == 0)
                        {

                            if (dropitem == null)
                            {
                                temp = temp.Open_folder(current.Text, parent.Getlistdir());

                                db.updatedparent(null, temp.Getid(), -1);
                                itemdrop = current;
                                current.Remove();
                                temp.GetEmplacement().Getlistofdir().Remove(temp);
                                temp.SetEmplacement(null);
                                newuser.AddtlistDossier(temp);

                                refresh();
                                return;
                            }
                            if (dropitem.ImageIndex == 1)
                            {
                                return;
                            }
                            temp = temp.Open_folder(current.Text, parent.Getlistdir());
                            if (parent != null)
                            {
                                if (dropitem != null)
                                {
                                    string[] parentname = dropitem.FullPath.Split('/');
                                    string f = parentname[parentname.Length - 1];

                                    temp = newuser.Open_folder(parentname[0].Trim(), newuser.Getlistdossier());
                                    for (int k = 1; k < parentname.Length; k++)
                                    {
                                        temp = newuser.Open_folder(parentname[k].Trim(), temp.Getlistdir());
                                    }
                                    if (temp == null) { temp = newuser.Open_folder(dropitem.Text.Trim(), newuser.Getlistdossier()); }
                                    parent = temp;
                                    parent.Getlistofdir().Clear();
                                    parent.Getlistoffiles().Clear();
                                    db.chargerdossierdsd(newuser, parent);
                                    db.Chargerlesfichierdsd(newuser, parent);
                                }
                                temp = temp.Open_folder(current.Text, oldp.Getlistdir());
                                if (parent.GetEmplacement() == null)
                                {
                                    temp2 = temp2.Open_folder(dropitem.Text, newuser.Getlistdossier());
                                }

                                else
                                {
                                    temp2 = temp2.Open_folder(dropitem.Text, parent.GetEmplacement().Getlistdir());
                                }
                            }
                            else { temp2 = temp2.Open_folder(dropitem.Text, newuser.Getlistdossier()); }
                            db.updatedparent(current.Text, temp.Getid(), temp2.Getid());
                            itemdrop = current;
                            current.Remove();
                            oldp.Getlistofdir().Remove(temp);
                            temp.SetEmplacement(temp2);
                            if (oldp == null) { oldp.Getlistofdir().Remove(temp); }
                            else
                            {
                                parent.Getlistofdir().Remove(temp);
                            }

                            temp2.Setlisd(temp);
                            parent = oldp;
                            refresh();

                        }

                    }
                    listthetree();

                    //}
                }
            }
        }
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListViewItem item = listView2.SelectedItems[0];

            labelitem = item;
            labeloldname = item.Text;
            item.BeginEdit();


        }      
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Proprety pr;
            TreeNode item = previousnode;


            string nom = item.Name;
            if (item.ImageIndex == 1)
            {
                fichier temp = new fichier();

                refresh();

                //do something
                if (parent == null)
                {
                    temp = newuser.Open_file(nom, newuser.Getlistfiles());

                    pr = new Proprety(temp, null);
                    pr.Visible = true;
                }
                else
                {
                    temp = newuser.Open_file(nom, parent.Getlistfichier());

                    pr = new Proprety(temp, null);
                    pr.Visible = true;
                }


            }
            if (item.ImageIndex == 0)
            {
                Dossier temp = new Dossier();



                refresh();

                //do something
                if (parent == null)
                {
                    temp = newuser.Open_folder(nom, newuser.Getlistdossier());

                    pr = new Proprety(null, temp);
                    pr.Visible = true;
                }
                else
                {
                    temp = newuser.Open_folder(nom, parent.Getlistdir());

                    pr = new Proprety(null, temp);
                    pr.Visible = true;
                }


            }
            stop = newuser.Getlistdossier().Length;
            int j = 0;
            treeView1.Nodes.Clear();
            while (j < stop)
            {

                TreeNode mainNode = new TreeNode();
                mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                treeView1.Nodes.Add(mainNode);
                j++;
            }
            refresh();
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView2.SelectedItems[0] != null)
                {
                    if (listView2.FocusedItem.Bounds.Contains(e.Location))
                    {
                        listView2.ContextMenuStrip = contextMenuStrip1;
                        contextMenuStrip1.Show(Cursor.Position);
                        treeView1.Nodes.Clear();
                        stop = newuser.Getlistdossier().Length;
                        int j = 0;
                        while (j < stop)
                        {

                            TreeNode mainNode = new TreeNode();
                            mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                            mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                            treeView1.Nodes.Add(mainNode);
                            j++;
                        }
                    }
                }

            }
        }
        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    beforlist.Clear();

                    MF = 0;
                    ListViewItem item = listView2.SelectedItems[0];

                    this.button1.Enabled = true;
                    //ListViewItem item = listView2.SelectedItems[0];
                    listView2.Clear();
                    string nom = item.Text;

                    Dossier temp = new Dossier();
                    fichier tempf = new fichier();
                    if (item.ImageIndex == 1)
                    {
                        if (parent == null)
                        {

                            tempf = newuser.Open_file(nom, newuser.Getlistfiles());



                        }
                        else
                        {

                            tempf = newuser.Open_file(nom, parent.Getlistfichier());

                        }
                        db.chargerblob(tempf);

                        Texteditor txt = new Texteditor(tempf);
                        // txt.Visible = true;
                        refresh();
                        stop = newuser.Getlistdossier().Length;
                        int j = 0;
                        treeView1.Nodes.Clear();
                        while (j < stop)
                        {

                            TreeNode mainNode = new TreeNode();
                            mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                            mainNode.Text = newuser.Getlistdossier()[j].GetNom().Trim();
                            treeView1.Nodes.Add(mainNode);
                            j++;
                        }
                        txt.Visible = true;
                    }
                    if (item.ImageIndex == 0)
                    {
                        if (retour == 0)
                        {
                            if (parent == null)
                            {

                                temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                                parent = temp;
                                temp.Getlistofdir().Clear();
                                temp.Getlistoffiles().Clear();
                                db.chargerdossierdsd(newuser, temp);
                                db.Chargerlesfichierdsd(newuser, temp);
                                parent.Getlistofdir().Clear();
                                db.chargerdossierdsd(newuser, parent);
                                chemin = "";

                            }
                            else
                            {

                                temp = newuser.Open_folder(nom, parent.Getlistdir());
                                db.chargerdossierdsd(newuser, temp);
                                db.Chargerlesfichierdsd(newuser, temp);
                                parent = temp;
                                parent.Getlistofdir().Clear();
                                db.chargerdossierdsd(newuser, parent);
                            }
                        }
                        else
                        {
                            if (parent == null)
                            {
                                temp = newuser.Open_folder(nom, newuser.Getlistdossier());
                                //  chemin =  temp.GetNom().TrimEnd();

                                chemin = "";
                                parent = temp;
                            }
                            else
                            {
                                temp = newuser.Open_folder(nom, parent.Getlistdir());
                                parent.Getlistofdir().Clear();
                                db.chargerdossierdsd(newuser, parent);
                                parent = temp;

                            }

                        }
                        d = 1;
                        //maskedTextBox1.Text = chemin;

                        int i = 0;
                        int stop = temp.Getlistdir().Length;
                        while (i < stop)
                        {
                            ListViewItem listitem = new ListViewItem(temp.Getlistdir()[i].GetNom().Trim(), 0);
                            listView2.Items.Add(listitem);
                            i++;
                        }
                        i = 0;
                        stop = temp.Getlistfichier().Length;
                        while (i < stop)
                        {
                            ListViewItem listitem = new ListViewItem(temp.Getlistfichier()[i].GetNom().Trim(), 1);
                            listView2.Items.Add(listitem);
                            i++;
                        }
                        chemin = chemin.Trim() + temp.GetNom().Trim() + "/";
                        maskedTextBox1.Text = thenewpath + chemin;

                    }
                }

                if (e.Control)
                {
                    if (e.KeyCode == Keys.C) { copieToolStripMenuItem_Click(sender, e); }
                    if (e.KeyCode == Keys.V) { pasteToolStripMenuItem_Click(sender, e); }
                    if (e.KeyCode == Keys.X) { cutToolStripMenuItem_Click(sender, e); }
                }


                if (e.KeyCode == Keys.Delete)
                {
                    deleteToolStripMenuItem_Click(sender, e);
                }
                if (e.KeyCode == Keys.Back)
                {
                    button1_Click(sender, e);
                }

                if (e.KeyCode == Keys.Right && e.KeyCode == Keys.Alt)
                {
                    button2_Click(sender, e);
                }
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {

            retour = 1;

            if (parent == null)
            {

                //chemin = "C:/"; 
                return;
            }
            if (g)
            {
                MF = 0;
                beforlist.Clear();

            }
            if (parent.GetEmplacement() == null)
            {
                beforlist.Add(parent);
                string[] path = chemin.Split('/');
                int f = path.Length - 2;
                if (f >= 0)
                {
                    string[] newpath = new string[f--];
                    for (int i = 0; i < f; i++)
                    {
                        newpath[i] = path[i];
                    }
                    chemin = "";
                    for (int i = 0; i < f; i++)
                    {
                        chemin = chemin + "/" + newpath[i];

                    }
                }




                parent = null;
                d = 0;
            }
            else
            {
                beforlist.Add(parent);
                parent = parent.GetEmplacement();
                string[] path = chemin.Split('/');
                int f = path.Length - 2;
                string[] newpath = new string[f];

                for (int i = 0; i < f; i++)
                {
                    newpath[i] = path[i];
                }
                chemin = "";
                for (int i = 0; i < f; i++)
                {
                    chemin = chemin + newpath[i] + "/";

                }
                //maskedTextBox1.Text = chemin;
                d--;
            }
            maskedTextBox1.Text = "";
            maskedTextBox1.Text = thenewpath + chemin;
            refresh();



            //refreshpanel();
        }
        private void session_Load(object sender, EventArgs e)
        {


            listView2.LargeImageList = imageList2;
            treeView1.ImageList = imageList1;



        }
        private void listView2_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            refreshpanel();
            string nom = "";
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.Text == e.Label && item.ImageIndex == labelitem.ImageIndex || item.Text == nom)
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Please enter a non-used name.");
                    return;
                }
                nom = item.Text;
            }
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                // MessageBox.Show("Please enter a valid value.");
                //return;
            }
            if (e.Label.Contains("/")|| e.Label.Contains("*")|| e.Label.Contains("!")|| e.Label.Contains(".")|| e.Label.Contains("?"))
            {
                e.CancelEdit = true;
                MessageBox.Show("the name of the folder can't contains the specified characters : '|:;/?.* ' ");
                //return;
            }

            else
            {

                Dossier temp = new Dossier();
                fichier tempf = new fichier();
                if (listView2.SelectedItems[0].ImageIndex == 1)
                {
                    if (parent == null)
                    {

                        tempf = newuser.Open_file(labeloldname, newuser.Getlistfiles());
                        tempf.SetNom(e.Label, tempf.Getid());


                    }
                    else
                    {

                        tempf = newuser.Open_file(labeloldname, parent.Getlistfichier());
                        tempf.SetNom(e.Label, tempf.Getid());

                    }

                    refresh();
                    treeView1.Nodes.Clear();
                    stop = newuser.Getlistdossier().Length;
                    int j = 0;
                    while (j < stop)
                    {

                        TreeNode mainNode = new TreeNode();
                        mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                        mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                        treeView1.Nodes.Add(mainNode);
                        j++;
                    }

                }
                else if (listView2.SelectedItems[0].ImageIndex == 0)
                {
                    if (retour == 0)
                    {
                        if (parent == null)
                        {

                            temp = newuser.Open_folder(labeloldname, newuser.Getlistdossier());
                            temp.SetNom(e.Label, labeloldname, temp.Getid());
                            nd++;
                        }
                        else
                        {

                            temp = newuser.Open_folder(labeloldname, parent.Getlistdir());
                            temp.SetNom(e.Label, labeloldname, temp.Getid());
                            nd++;
                        }
                    }
                    else
                    {
                        if (parent == null)
                        {
                            temp = newuser.Open_folder(labeloldname, newuser.Getlistdossier());
                            temp.SetNom(e.Label, labeloldname, temp.Getid());
                            nd++;
                        }
                        else
                        {
                            temp = newuser.Open_folder(labeloldname, parent.Getlistdir());
                            temp.SetNom(e.Label, labeloldname, temp.Getid());
                            nd++;
                        }
                    }


                    treeView1.Nodes.Clear();
                    stop = newuser.Getlistdossier().Length;
                    int j = 0;
                    while (j < stop)
                    {

                        TreeNode mainNode = new TreeNode();
                        mainNode.Name = newuser.Getlistdossier()[j].GetNom().Trim();
                        mainNode.Text = newuser.Getlistdossier()[j].GetNom();
                        treeView1.Nodes.Add(mainNode);
                        j++;
                    }

                }
            }
        }



    }
}

