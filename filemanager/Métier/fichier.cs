using filemanager.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filemanager.Métier
{
    class fichier
    {
        private String nom;
        private String format;
        private float taille;
        private DateTime d = DateTime.Now;
        private int _id;
        public int Getid() { return _id; }
        public void Setid(int i) { _id = i; }

        private Dossier emplacement;
        private Utulisateur proprietair;
        private droitacces droit_acces;
        private byte[] Blob;
        public mydb db = new mydb();

        public String GetNom() { return nom; }

        public String GetFormat() { return format; }
        public float GetTaille() { return taille; }
        public DateTime GetDatecreation() { return d; }
        public Dossier GetEmplacement() { return emplacement; }
        public Utulisateur GetPropritaire() { return proprietair; }
        public droitacces GetDroitaccesobj() { return droit_acces; }
        public string GetDroitacces() { return droit_acces.Getdroitacces(); }
        public byte[] GetBlob() { return Blob; }
        public void Setblob(Byte[] bl) => Blob = bl;
        public void SetDroitacces(string d) { droit_acces.Setdroitacces(d); }
        public void SetNom(String name, int oldn)
        {

            nom = name;
            db.updatefname(name, oldn);
        }
        public void SetTaille(float ko) { taille = ko; }
        public void SetFormat(String frm) { format = frm; }
        public void SetDatecreation(DateTime date) { d = date; }
        public void SetEmplacemnt(Dossier directory) { emplacement = directory; }
        public void SetPropritaire(Utulisateur user) { proprietair = user; }
        public fichier(string name, string format, Utulisateur user, Dossier directoty)
        {
            nom = name;
            this.format = format;
            proprietair = user;
            emplacement = directoty;
            taille = 1;
            _id = 0;
            Blob = null;
            droitacces dr = new droitacces();
            dr.Setdroitacces("RW");
            droit_acces = dr;

        }
        public fichier(string name, string format, Utulisateur user, Dossier directoty, int id)
        {
            nom = name;
            this.format = format;
            proprietair = user;
            emplacement = directoty;
            taille = 1;
            _id = id;
            Blob = null;
            droitacces dr = new droitacces();
            dr.Setdroitacces("RW");
            droit_acces = dr;

        }
        public fichier(string name, string format, Utulisateur user, Dossier directoty, byte[] blobl)
        {
            nom = name;
            this.format = format;
            proprietair = user;
            emplacement = directoty;
            taille = 1;
            _id = 0;
            Blob = blobl;
            droitacces dr = new droitacces();
            dr.Setdroitacces("RW");
            droit_acces = dr;

        }
        public fichier()
        {
            nom = null;
            this.format = null;
            proprietair = null;
            emplacement = null;
            taille = 1;

            Blob = null;
            droitacces dr = new droitacces();
            dr.Setdroitacces("RW");
            droit_acces = dr;

        }
        public fichier(fichier f,Dossier ds)
        {
            nom = f.GetNom();
            this.format = f.GetFormat();
            proprietair = f.GetPropritaire();
            emplacement = ds;
            taille = 1;
            _id = db.lastindexf()+1;
            Blob = f.GetBlob();
            droitacces dr = new droitacces();
            dr.Setdroitacces("RW");
            droit_acces = dr;

        }
        private bool Exists(Dossier directory, string name)
        {
            fichier[] list = directory.Getlistfichier();
            int i = 0;
            int stop = list.Length - 1;

            while (i < stop)
            {
                while ((list[i] != null))

                {


                    if (list[i].GetNom().Equals(name))
                    {
                        return true;


                    }
                    else i++;


                }
                return false;
            }
            return false;
        }
        private bool Existsfileu(Utulisateur directory, string name)
        {
            fichier[] list = directory.Getlistfiles();
            int i = 0;
            int stop = list.Length - 1;

            while (i < stop)
            {
                while ((list[i] != null))

                {


                    if (list[i].GetNom().Equals(name))
                    {
                        return true;


                    }
                    else i++;


                }
                return false;
            }
            return false;
        }
        public void Deplacer_fichier(Dossier pathd, fichier file)
        {

            if (!file.Exists(pathd, file.GetNom()))
            {
                if (file.GetDroitacces().Equals("RW") || file.GetDroitacces().Equals("RWX"))
                {

                    file.SetEmplacemnt(pathd);
                    pathd.Setlistfichier(file);

                }
                else return;
            }

            else return;




        }
        private void Dispose(bool v)
        {

            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Modifier_fichier(byte[] newblob, fichier file)
        {
            try
            {
                file.Setblob(newblob);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }
        public fichier Open_file(string name, fichier[] list)
        {
            int i = 0;
            string nom;
            fichier d;
            int stop = list.Length;
            while (i < stop)
            {
                d = list[i];
                nom = d.GetNom().TrimEnd();
                if (nom.Equals(name))
                {
                    return d;
                }
                else i++;

            }
            return null;
        }
      
        public fichier Creation_fichier(Dossier directory, string name, string format, Utulisateur user, int i)
        {


            if (Exists(directory, name))
            {
                return null;
            }
            else
            {
                db.insertfile(directory, user, format, name, d, 1, directory.GetDroitacces());
                fichier newfile = new fichier(name, format, user, directory,  db.lastindexf());
                directory.Setlistfichier(newfile);
                //db.insertfile(directory, user, format, name, d, 1, directory.GetDroitacces());
                return newfile;
            }
        }
        public fichier Creation_fichieru(string name, string format, Utulisateur user,  int i)
        {

            //if (Exists(user.Getlistfiles, name))
            //{
            //    return null;
            //}

            db.insertfileuser(user, format, name, d, 0, "RW");
            fichier newfile = new fichier(name, format, user, null ,db.lastindexf());
            user.Setlistfiles(newfile);
            
            return newfile;

        }
        public string Supprimer_fichier(fichier file, bool u)
        {
            List<fichier> list = new List<fichier>();

            if (!u)
            {
                list = file.GetPropritaire().Getlistfilelist();
            }
            if (u)
            {
                list = file.GetEmplacement().Getlistoffiles();
            }

            string ok = "your file was deleted !", nok = "you can't !";


            int stop = list.Count;
            if (file.GetDroitacces().Equals("RW"))
            {
                list.Remove(file);
                db.deletefile(file.Getid());
                return ok;
            }
            else return nok + "you don't have the right ";
        }
        public string BinaryToText(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
        public byte[] texttobinary(string input)
        {

            byte[] array = Encoding.ASCII.GetBytes(input);
            return array;

        }
        public void clonelist( List<fichier> oldlist, Dossier ds)
        {
            List<fichier> newlist = ds.Getlistoffiles();

            oldlist.ForEach((item) =>
            {
                fichier newf = new fichier(item, ds);
                newlist.Add(newf);
                db.insertfile(ds, ds.GetProprietaire(), "txt", item.GetNom(), d, 0, "RW");
                newf.Setblob(item.GetBlob());
                

            });

             ds.Settheflist(newlist);
        }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }
}