using filemanager.DAO;
using filemanager.Métier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filemanager.Présentation
{
    class Texteditor : Form
    {
            private fichier file;
            private MenuStrip menuStrip1;
            private ToolStripMenuItem fichierToolStripMenuItem;
            private ToolStripMenuItem editionToolStripMenuItem;
            private ToolStripMenuItem formatToolStripMenuItem;
            private ToolStripMenuItem aideToolStripMenuItem;
            private ToolStripMenuItem nouveauToolStripMenuItem;
            private ToolStripMenuItem ouvriToolStripMenuItem;
            private ToolStripMenuItem enregistrerToolStripMenuItem;
            private ToolStripMenuItem quitterToolStripMenuItem;
            private mydb db = new mydb();
            private string oldtext="";
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Texteditor));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(654, 384);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvriToolStripMenuItem,
            this.enregistrerToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // ouvriToolStripMenuItem
            // 
            this.ouvriToolStripMenuItem.Name = "ouvriToolStripMenuItem";
            this.ouvriToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ouvriToolStripMenuItem.Text = "Ouvrir";
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // Texteditor
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(656, 412);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Texteditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.Texteditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            public Texteditor(fichier f)
            {
                InitializeComponent();
                file = f;
                if (f.GetBlob() != null)
                {
                    richTextBox1.Text = f.BinaryToText(f.GetBlob());
                    oldtext = richTextBox1.Text;
                }

            }

            private void button1_Click(object sender, System.EventArgs e)
            {
                file.Setblob(file.texttobinary(richTextBox1.Text));
                db.insertfilblob(file);
                this.Visible = false;
            }

            private void button2_Click(object sender, System.EventArgs e)
            {
                richTextBox1.Text = "";
            }

            private void enregistrerToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                file.Setblob(file.texttobinary(richTextBox1.Text));
                db.insertfilblob(file);
                this.Visible = false;
            }

            private void nouveauToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                fichier newf;
                if (file.GetEmplacement() != null)
                {
                    newf = file.Creation_fichier(file.GetEmplacement(), "sans nom", "txt", file.GetPropritaire(), 0);
                }
                else { newf = file.Creation_fichieru("sans nom", "txt", file.GetPropritaire(), 0); }
                Texteditor newt = new Texteditor(newf);
                newt.Visible = true;
                this.Visible = false;
            }

            private void quitterToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                if (richTextBox1.Text == "" || oldtext.Equals(richTextBox1.Text))
                {
                    this.Visible = false;
                    return;
                }
                {
                    string message =
         "est ce que vous voulez enregistrer votre text?";
                    const string caption = "enregistrer";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    if (result == DialogResult.No) { this.Visible = false; }
                    else if (result == DialogResult.Yes)
                    {
                        file.Setblob(file.texttobinary(richTextBox1.Text));
                        db.insertfilblob(file);
                        this.Visible = false;
                    }
                }
            }
            private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (richTextBox1.Text == "" || oldtext.Equals(richTextBox1.Text))
                {
                    this.Visible = false;
                    return;
                }
                {
                    string message =
         "est ce que vous voulez enregistrer votre text?";
                    const string caption = "enregistrer";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    if (result == DialogResult.No) { this.Visible = false; }
                    else if (result == DialogResult.Yes)
                    {
                        file.Setblob(file.texttobinary(richTextBox1.Text));
                        db.insertfilblob(file);
                        this.Visible = false;
                    }
                }
            }


            private void Texteditor_Load(object sender, System.EventArgs e)
            {

            }

            private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
            {

                if (e.KeyCode == Keys.S && e.Control)
                {
                    enregistrerToolStripMenuItem_Click(sender, e);
                }

            }

        private RichTextBox richTextBox1;
    }
    }

