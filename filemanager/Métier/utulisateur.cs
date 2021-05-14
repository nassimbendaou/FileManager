using filemanager.DAO;
using filemanager.Métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class  Utulisateur
    {

        private string nom;
        private string password;
        private int Id;
        private List<Utulisateur> listutulisateur = new List<Utulisateur>();
        private List<fichier> listfiles = new List<fichier>();
        private List<Dossier> listdossier = new List<Dossier>();
    mydb db = new mydb();
        public int Getid()
        {
            return Id;
        }
        public int getdcount()
        {
            return listdossier.Count;
        }
        public int getfcount()
        {
            return listfiles.Count;
        }
        public void Setid(int i) { Id = i; }
        public Utulisateur(string name, string passe)
        {
            Id = 0;

            nom = name;


            password = passe;

        }
        public Utulisateur()
        {

        }
        public Utulisateur Creation_user(Utulisateur newuser, string user, string pass)
        {
            newuser = new Utulisateur(user, pass);

            newuser.Setlistusers(newuser);
            return newuser;





        }
        public void Addtolistusers(Utulisateur[] user) => listutulisateur.AddRange(user);
        public void Setlistusers(Utulisateur user) => listutulisateur.Add(user);
        public void Setlistfiles(fichier user) => listfiles.Add(user);
        public Utulisateur[] Getlistusers() => listutulisateur.ToArray();
        public List<Dossier> Getlistdirlist() => listdossier;
        public string Getpassword()
        {
            return password;
        }
        public void Setpassword(string pass) => password = pass;
        public string GetNom() => nom;
        public fichier[] Getlistfiles() => listfiles.ToArray();
        public List<fichier> Getlistfilelist() => listfiles;
        public void SetNom(string nom)
        {
            this.nom = nom;
        }
        public Dossier[] Getlistdossier()
        {
            return listdossier.ToArray();
        }
    public Dossier getth(int node, Utulisateur user, List<Dossier> listof, List<Dossier> searchpath)
    {


        // List<Dossier> searchpath = new List<Dossier>();
        foreach (Dossier get in listof)
        {
            get.Getlistofdir().Clear();
            db.chargerdossierdsd(user, get);
            searchpath.Add(get);
            if (get.Getid().Equals(node))
            {
                return get;
            }
            
            return getth(node, user, get.Getlistofdir(), searchpath);
        }


        return null;
    }
    public Utulisateur Session(Utulisateur user, string name, string pass)
        {
            Utulisateur[] list = user.Getlistusers();
            int i = 0;
            int stop = list.Length;


            while (i < stop)
            {

                if (list[i].GetNom().Trim().Equals(name) && list[i].Getpassword().Trim().Equals(pass))
                {
                    return list[i];

                }
                else i++;



            }
            return null;

        }
        public bool Login(Utulisateur user, string name, string pass)
        {
            Utulisateur[] list = user.Getlistusers();
            int i = 0;
            while (list[i] != null)
            {
                if (list[i].GetNom().Equals(name) && list[i].Getpassword().Equals(pass))
                {
                    return true;
                }
                else i++;

            }
            return false;
        }
        public void Setlisd(Dossier dir) => listdossier.Add(dir);
        public void Lister_dossier(Utulisateur directory, float taille)
        {

            int i = 0;
            int stop = directory.Getlistfiles().Length;


            while (directory.Getlistfiles()[i] != null)
            {
                while (i < stop)
                {
                    Console.WriteLine(i + 1 + "-" + directory.Getlistfiles()[i].GetNom()
                        + "-" + directory.Getlistfiles()[i].GetDatecreation() + "-" + taille + directory.GetNom());
                    i++;

                }
                return;
            }

        }
        private void Dispose(bool v)
        {

            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Showmyinfos(Utulisateur user)
        {

            int i = 0;
            int stop = Getlistdossier().Length;
            stop--;

            while (i <= stop)
            {
                while (user.Getlistdossier()[i] != null)
                {

                    Console.WriteLine(i + 1 + "-" + user.Getlistdossier()[i].GetNom() +
                        "-" + user.Getlistdossier()[i].GetProprietaire().GetNom() +
                        "-" + user.Getlistdossier()[i].GetDroitacces() + "-" +
                        user.Getlistdossier()[i].GetTaille() + "-" + user.Getlistdossier()[i].GetDatecreation());
                    i++;
                    break;

                }
            }

            return;

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
                if (nom.Equals(name))
                {
                    return d;
                }
                else i++;

            }
            return null;

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
        public bool Exists(Utulisateur user, string name)
        {
            Dossier[] list = user.Getlistdossier();
            int i = 0;
            int stop = list.Length;
            stop--;
            while (i <= stop)
            {
                while ((list[i] != null))
                {
                    if (list[i].GetNom().Equals(name))
                    {
                        return true;
                    }
                    i++;
                    break;
                }
            }
            return false;
        }
        public void Logout(Utulisateur user) => user.Dispose(true);
        public void SetlistDossier(Dossier[] directory) => listdossier.AddRange(directory);
        public void AddtlistDossier(Dossier directory) => listdossier.Add(directory);
        public override string ToString() => base.ToString();
        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }

