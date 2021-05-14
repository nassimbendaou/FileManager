using filemanager.Métier;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filemanager.Présentation
{
    class Proprety:MetroForm
    {
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private Label label8;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox textBox1;
        private GroupBox Proreties;
        private PictureBox pictureBox1;
        private Label label7;

        public Proprety(fichier f,Dossier d)
        {
            InitializeComponent();
            int size;
            
            if (f != null && d==null)
            {
                
                pictureBox1.BackgroundImage = imageList1.Images[1];
                textBox1.Text = f.GetNom().Trim() + "." + f.GetFormat().Trim();
                label4.Text = f.GetFormat();

                if (f.GetBlob() != null)
                { size = f.GetBlob().Length; } else { size = 0; }
                
                label5.Text = size.ToString()+ " Octets";
                label3.Text = null;
                label6.Text = null;
                label8.Text = f.GetDatecreation().ToString();
            }
            if (d != null && f == null)
            {
                pictureBox1.BackgroundImage = imageList1.Images[0];
                textBox1.Text = d.GetNom().Trim();
                label4.Text = "Dossier";
                size = d.Getlistoffiles().Count+d.Getlistofdir().Count;
                label5.Text = size.ToString();
                label3.Text = "Contains : ";
                label6.Text = d.Getlistoffiles().Count+" files,"+ d.Getlistofdir().Count+" directorys";
                label8.Text = d.GetDatecreation().ToString();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proprety));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.Proreties = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Proreties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(138, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(28, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(28, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(28, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(138, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
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
            this.textBox1.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.textBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.textBox1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.textBox1.BorderColorIdle = System.Drawing.Color.Silver;
            this.textBox1.BorderRadius = 1;
            this.textBox1.BorderThickness = 1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.textBox1.DefaultText = "";
            this.textBox1.Enabled = false;
            this.textBox1.FillColor = System.Drawing.Color.White;
            this.textBox1.HideSelection = true;
            this.textBox1.IconLeft = null;
            this.textBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.IconPadding = 10;
            this.textBox1.IconRight = null;
            this.textBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(142, 63);
            this.textBox1.MaxLength = 32767;
            this.textBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.textBox1.Modified = false;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBox1.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.textBox1.OnIdleState = stateProperties4;
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.textBox1.PlaceholderText = "Enter text";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(193, 30);
            this.textBox1.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.textBox1.TabIndex = 8;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox1.TextMarginBottom = 0;
            this.textBox1.TextMarginLeft = 5;
            this.textBox1.TextMarginTop = 0;
            this.textBox1.TextPlaceholder = "Enter text";
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.WordWrap = true;
            // 
            // Proreties
            // 
            this.Proreties.Controls.Add(this.label8);
            this.Proreties.Controls.Add(this.label6);
            this.Proreties.Controls.Add(this.label7);
            this.Proreties.Controls.Add(this.label5);
            this.Proreties.Controls.Add(this.label4);
            this.Proreties.Controls.Add(this.label3);
            this.Proreties.Controls.Add(this.label1);
            this.Proreties.Controls.Add(this.label2);
            this.Proreties.Font = new System.Drawing.Font("Sitka Heading", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proreties.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Proreties.Location = new System.Drawing.Point(23, 169);
            this.Proreties.Name = "Proreties";
            this.Proreties.Size = new System.Drawing.Size(312, 203);
            this.Proreties.TabIndex = 9;
            this.Proreties.TabStop = false;
            this.Proreties.Text = "Proreties";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 121);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Proprety
            // 
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(358, 430);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Proreties);
            this.Controls.Add(this.textBox1);
            this.Name = "Proprety";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Load += new System.EventHandler(this.Proprety_Load);
            this.Proreties.ResumeLayout(false);
            this.Proreties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Proprety_Load(object sender, EventArgs e)
        {

        }
    }
}
