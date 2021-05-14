using filemanager.DAO;
using filemanager.Métier;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class Form1 : MaterialForm
    {

        public Form1()
        {
            InitializeComponent();
            var skinmanager = MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkinManager.Themes.LIGHT;
            
        }
        private void LOGIN_Click(object sender, EventArgs e)
        {
            mydb db = new mydb();
            bool b;
            Utulisateur newusers = new Utulisateur();
            droitacces droit = new droitacces();
            db.Chargerlesinfos(newusers);
            string nom = username.Text.ToString();
            string password = this.password.Text.ToString();
            Utulisateur newuser = newusers.Session(newusers, nom, password);
            if (newuser == null) { b = false; } else b = true;
            if (b)
            {
                session session = new session(newuser, this);
                username.Text = "";
                this.password.Text = "";
                this.Visible = false;
                session.Visible = true;
            }

            else MessageBox.Show("wrong passwordor username !");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
