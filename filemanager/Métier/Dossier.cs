using filemanager.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filemanager.Métier
{
    class Dossier
    {


        private string nom;
        private DateTime date_creation = DateTime.Now;
        private Utulisateur proprietaire;
        private float taille;
        private Dossier emplacement;
        private droitacces droit_acces;
        private int _id;
        public mydb db = new mydb();
        public fichier f = new fichier();
        private List<Dossier> listesd = new List<Dossier>();
        private List<fichier> listesf = new List<fichier>();
        public Dossier GetEmplacement()
        {
            return emplacement;
        }
        public void SetEmplacement(Dossier value)
        {
            emplacement = value;
        }
        public int Getid() { return _id; }
        public void Setid(int i) { _id = i; }
        public string GetNom()
        {
            return nom;
        }
        public DateTime GetDatecreation() => date_creation;
        public Utulisateur GetProprietaire() => proprietaire;
        public float GetTaille() => taille;
        public string GetDroitacces()
        {
            return droit_acces.Getdroitacces();
        }
        public void SetNom(string name, string oldn,int id)
        {
            db.updatedname(name, oldn,id);
            nom = name;
        }

        public void SetDatecreation(DateTime date) => date_creation = date;
        public void SetProprietaire(Utulisateur user) => proprietaire = user;
        public void SetTaille(float ko) => taille = ko;
        public Dossier[] Getlistdir()
        {
          
            return listesd.ToArray();
        }
        public List<Dossier> Getlistofdir() {
  
            return listesd;
        }
        public void setthedlidt(List<Dossier> d) { listesd = d; }
        public void Settheflist(List<fichier> f) => listesf = f;
        public void SetDroitacces(droitacces d) => droit_acces = d;
        public List<fichier> Getlistoffiles()
        {
         
            return listesf;
        }
        public fichier[] Getlistfichier() { 
            
            return listesf.ToArray();
        }
        public void Setlistfichier(fichier file) => listesf.Add(file);
        public void Setlisd(Dossier dir) => listesd.Add(dir);
        public void Addlistfichier(fichier[] file) => listesf.AddRange(file);
        public Dossier(string name, DateTime d, Utulisateur user, Dossier emplacementf, int id)
        {

            nom = name;
            date_creation = d;
            proprietaire = user;
            _id = id;
            emplacement = emplacementf;
            droitacces droita = new droitacces();
            droita.Setdroitacces("RW");

            droit_acces = droita;


        }
        public Dossier()
        {
            nom = null;
            date_creation = DateTime.Now;
            proprietaire = null;
            taille = 0;
            emplacement = null;

            droitacces droita = new droitacces();
            droita.Setdroitacces("RW");
            droit_acces = droita;

        }
        public Dossier(Dossier d,Dossier ds)
        {
            nom = d.GetNom();
            date_creation = DateTime.Now;
            proprietaire = d.GetProprietaire();
            taille = 0;
            emplacement = ds;
            _id = db.lastindex()+1;
            droitacces droita = new droitacces();
            droita.Setdroitacces("RW");
            droit_acces = droita;

        }

      
        public bool Exists(string name, Dossier[] list)
        {

           foreach(Dossier d in list)
            {
                if (d.GetNom().Equals(name))
                {
                    return true; }
            }
            return false;
        }
        public Dossier Open_folder(string name, Dossier[] list)
        {
            int i = 0;
            string nom;
            Dossier d;
            int stop = list.Length;
            while (i < stop)
            {
                d = list[i];
                nom = d.GetNom().TrimEnd();
                if (nom.Equals(name.Trim()))
                {
                    return d;
                }
                else i++;

            }
            return null;

        }
        public Dossier getthefolder(string name, Utulisateur user)
        {
            Dossier[] list = user.Getlistdossier();
            int i = 0;
            int stop = list.Length - 1;

            while (i < stop)
            {
                Dossier d = list[i];
                string nom;
                while ((d != null) && (i < stop))

                {

                    nom = d.GetNom().Trim();
                    if (nom.Equals(name))
                    {
                        return d;


                    }
                    else i++;


                }
                return null;
            }
            return null;
        }
      
        public void Rename_dossier(Dossier dossier, string name)
        {
            if (dossier.GetDroitacces().Equals("RW") || dossier.GetDroitacces().Equals("W"))
            {
             //   dossier.SetNom(name);
            }
            else return;

        }

     

        public string parentstring(Dossier director)
        {
            if (director.GetEmplacement() != null)
            {
                string g = director.GetNom().Trim() + "-" + director.GetEmplacement().GetNom().Trim() + "-";
                return parentstring(director.GetEmplacement()) + g;
            }
            return null;
        }
        public string Supprimer_dossier(Dossier directory, bool u)
        {
            string ok = null, nok = null;
            List<Dossier> list = new List<Dossier>();

            if (!u)
            {
                list = directory.GetProprietaire().Getlistdirlist();
            }
            if (u)
            {
                list = directory.GetEmplacement().Getlistofdir();
            }

            ok = "your directory was deleted  !";
            nok = "you can't !";


            int stop = list.Count;
            if (directory.GetDroitacces().Equals("RW"))
            {
                list.Remove(directory);
                db.deletedirectory(directory.Getid());
                return ok;
            }
            else return nok + ", you don't have the right ";
        }
        public void copieallfiles(Dossier d, Dossier dir)
        {

            int i = 0;
            if (dir.Getlistdir() != null)
            {
                int p = dir.Getlistdir().Length;
                while (i < p)
                {
                    dir.Getlistdir()[i].SetEmplacement(d);
                    dir.Getlistdir()[i].copieallfiles(d, dir.Getlistdir()[i]);
                    i++;
                }
            }
            else return;


        }
        public List<Dossier> Searchuser(string nom, Utulisateur user)
        {
            List<Dossier> ds = new List<Dossier>();
            string nom2 = nom;
            int i = 0;
            if (user.Getlistdossier() != null)
            {
                int p = user.Getlistdossier().Length;
                while (i < p)
                {
                    if (user.Getlistdossier()[i].GetNom().Equals(nom))
                    {
                        ds.Add(user.Getlistdossier()[i]);
                    }
                    //ds =  Searchussersdirectory(nom2, user.Getlistdossier()[i], user,ds);
                    i++;
                }
                return ds;

            }
            else return ds;
        }
        public List<Dossier> Searchussersdirectory(string nom, Dossier dir, Utulisateur user, List<Dossier> ds)
        {
            int i = 0;
            if (dir.Getlistdir() != null)
            {
                int p = dir.Getlistdir().Length;
                while (i < p)
                {
                    if (dir.Getlistdir()[i].Equals(nom))
                    {
                        ds.Add(dir.Getlistdir()[i]);

                    }
                    dir.Getlistdir()[i].Searchussersdirectory(nom, dir.Getlistdir()[i], user, ds);

                    i++;
                }
                return ds;
            }
            else return ds;

        }
        public void Deplacer_Dossier(Dossier pathd, Dossier d)
        {

            if (!d.Exists(d.GetNom(), pathd.Getlistdir()))
            {
                if (d.GetDroitacces().Equals("RW") || d.GetDroitacces().Equals("RWX"))
                {
                    if (d.GetEmplacement() == null) { d.GetProprietaire().Getlistdirlist().Remove(d); }
                    else { d.GetEmplacement().Getlistofdir().Remove(d); }
                    d.SetEmplacement(pathd);
                    pathd.Setlisd(d);


                }
                else return;
            }

            else return;




        }
    
        private void Dispose()
        {


            GC.SuppressFinalize(this);

        }
        public Dossier Creation_dossier(string name, DateTime d, Utulisateur user, int id)
        {
            if (Exists(name, user.Getlistdossier()))
            {
                return null;
            }
            else

            {
                db.Insertdirectory(name, user.GetNom(), "RW", d, 0);
                Dossier newdirectory = new Dossier(name, d, user, null, db.lastindex());


                user.AddtlistDossier(newdirectory);
                
                return newdirectory;
            }

        }
        public Dossier Creat_sdirec(string name, DateTime d, Dossier user, Utulisateur newuser,int id)
        {
            Dossier[] list = user.Getlistdir();
            if (Exists(name, list))
            {
                return null;
            }
            else

            {
                db.Insertdirectoryd(name, newuser.GetNom(), "RW", d, 0, user.GetNom(), id);
                Dossier newdirectory = new Dossier(name, d, user.GetProprietaire(), user, db.lastindex()) ;
                user.Setlisd(newdirectory);
               

                return newdirectory;
            }

        }
        public void clonelist( List<Dossier> oldlist,Dossier ds)
        {
            List<Dossier> newlist = ds.Getlistofdir();
         
            oldlist.ForEach((item) =>
            {

                Dossier d = new Dossier(item,ds);
                item.Getlistofdir().Clear();
                item.Getlistoffiles().Clear();
                db.chargerdossierdsd(ds.GetProprietaire(), item);
                db.Chargerlesfichierdsd(ds.GetProprietaire(), item);
                newlist.Add(d);
                db.Insertdirectoryd(item.GetNom(), ds.GetProprietaire().GetNom(), "RW", item.GetDatecreation(), 0, ds.GetNom(), ds.Getid());
              
                    clonelist( item.Getlistofdir(),d);
                    f.clonelist(item.Getlistoffiles(), d);
                    

                
               
            });
            ds.setthedlidt(newlist);
            //return newlist;
        }
     
    }
}
