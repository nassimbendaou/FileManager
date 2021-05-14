using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client ;
using filemanager.Métier;

namespace filemanager.DAO
{
    class mydb
    {
         
        private SqlConnection conn;
        SqlCommand cmd;
        
        public static string ConnetionString = @"Data Source=$$$$$ data base";
     
        public static string GetCnnString()
        {
            return ConnetionString;
        }
        public static void SetCnnString(string cnnstring)
        {
            ConnetionString = cnnstring;
        }

        public mydb()
        {
            conn = new SqlConnection(ConnetionString);
            try { conn.Open(); }
            catch (Exception e)
            { Console.Write(e.Message); }
        }

        public void InsertUser(string nom, string password)
        {
            string smt = "INSERT INTO dbo.Utilisateur(nom,password) VALUES( @Name,@password)";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();

        }
        public void Insertdirectory(string nom, string proprietair, string droiacces, DateTime date, int taille)
        {
            string smt = "INSERT INTO dbo.Dossier(nom,proprietair,taille,droitacces,datecreation) VALUES( @Name,@owner,@taille,@droitacces,@datecreation)";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom.Trim());
            cmd.Parameters.AddWithValue("@owner", proprietair.Trim());
            cmd.Parameters.AddWithValue("@taille", taille);
            cmd.Parameters.AddWithValue("@droitacces", droiacces);
            cmd.Parameters.AddWithValue("@datecreation", date);
            cmd.ExecuteNonQuery();

        }
        public void Insertdirectoryd(string nom,  string proprietair, string droiacces, DateTime date, float taille, string name,int id)
        {
            string smt = "INSERT INTO dbo.Dossier(nom,proprietair,taille,droitacces,datecreation,emplacement,idemplacement) VALUES( @Name,@owner,@taille,@droitacces,@datecreation,@emplacement,@idemplacement)";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom);
            cmd.Parameters.AddWithValue("@owner", proprietair);
            cmd.Parameters.AddWithValue("@taille", taille);
            cmd.Parameters.AddWithValue("@droitacces", droiacces);
            cmd.Parameters.AddWithValue("@datecreation", date);
            cmd.Parameters.AddWithValue("@emplacement", name);
            cmd.Parameters.AddWithValue("@idemplacement", id);
            cmd.ExecuteNonQuery();

        }
        public void Chargerlesinfos(Utulisateur user)
        {


            string smt = "SELECT nom,password FROM dbo.Utilisateur ";
            cmd = new SqlCommand(smt, conn);
            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                Utulisateur u = new Utulisateur(rs.GetString(0), rs.GetString(0));
                user.Setlistusers(u);

            }
            rs.Close();


        }
        public void Chargerlesdossier(Utulisateur user)
        {
            try
            {
                Dossier dir = new Dossier();
                string smt = "SELECT Id,nom,proprietair,taille,droitacces,datecreation,emplacement FROM dbo.Dossier Where proprietair=@owner and idemplacement IS NULL or idemplacement<0";
                cmd = new SqlCommand(smt, conn);
                cmd.Parameters.AddWithValue("@owner", user.GetNom());

                SqlDataReader rs = cmd.ExecuteReader();

                while (rs.Read())
                {
                    Dossier d = new Dossier(rs.GetString(1), rs.GetDateTime(5), user, null, rs.GetInt32(0));
                    user.AddtlistDossier(d);

                }
                rs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int lastindex()
        {
            int i = 0 ;
            string smt = "SELECT TOP 1 ID FROM Dossier ORDER BY ID DESC";
            cmd = new SqlCommand(smt, conn);
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                i =rs.GetInt32(0);
               
            }
            rs.Close();
            return i;
        }
        public int lastindexf()
        {
            int i = 0;
            string smt = "SELECT TOP 1 id FROM Fichier ORDER BY id DESC";
            cmd = new SqlCommand(smt, conn);
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                i = rs.GetInt32(0);

            }
            rs.Close();
            return i;
        }
        public void updatedname(string newn, string oldn,int id)
        {

            string smt = "Update Dossier Set nom=@newname where id=@id";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@newname", newn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            
        }
        public void updatefname(string newn, int oldn)
        {

            string smt = "Update Fichier Set nom=@newname where id=@oldname";
         
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@newname", newn);
            cmd.Parameters.AddWithValue("@oldname", oldn);
            cmd.ExecuteNonQuery();
        }
        public void updateidd(int id, int ide)
        {

            string smt = "Update Dossier Set idemplacement=@ide where id=@id";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@ide", ide);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
           
        }

        //public List<Dossier> getallthefolders(Utulisateur user)
        //{
           
        //    string smt = "SELECT nom,datecreation,idemplacement FROM dbo.Dossier; ";
        //    cmd = new SqlCommand(smt, conn);
        //    SqlDataReader rs = cmd.ExecuteReader();
        //    List<Dossier> dir = new List<Dossier>();

        //    while (rs.Read())
        //    {
               
                

        //         Dossier d = new Dossier(rs.GetString(0), rs.GetDateTime(1), user, null, 0);
        //            dir.Add(d); 
                
              
                


        //    }
        //    rs.Close();
        //    return dir;
        //}
        public void updatefparent(int emplacement, int oldn)
        {


            string smt = "Update Fichier Set emplacement=@emplacement where id=@oldname";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@emplacement", emplacement);
            cmd.Parameters.AddWithValue("@oldname", oldn);
            cmd.ExecuteNonQuery();
        }
        public void updatedparent(string emplacement, int oldn,int id)
        {

            string smt = "Update Dossier Set idemplacement=@id where id=@oldname ";
           
           
                cmd = new SqlCommand(smt, conn);
                cmd.Parameters.AddWithValue("@oldname", oldn);
                cmd.Parameters.AddWithValue("@id", id);
            
           
      
          
            cmd.ExecuteNonQuery();
        }

        public void chargerdossierdsd(Utulisateur user, Dossier directory)
        {
            string smt = "SELECT nom,proprietair,taille,droitacces,datecreation,emplacement,idemplacement,Id FROM dbo.Dossier Where proprietair=@owner and   idemplacement=@idemplacement ";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@owner", user.GetNom());

            cmd.Parameters.AddWithValue("@idemplacement", directory.Getid());
           
            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {


                Dossier d = new Dossier(rs.GetString(0), rs.GetDateTime(4), user, directory, rs.GetInt32(7));
                directory.Setlisd(d);


            }
            rs.Close();
        }
        public void Chargerlesfichierdsd(Utulisateur user, Dossier directory)
        {
            fichier d;
            string smt = "SELECT nom,proprietair,emplacement,format,droitacces,datecreation,blob,id FROM dbo.Fichier Where proprietair=@owner and  emplacement=@parent ";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@owner", user.GetNom());
            cmd.Parameters.AddWithValue("@parent", directory.Getid());
            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {




                if (rs.IsDBNull(6))
                {
                    d = new fichier(rs.GetString(0), rs.GetString(3), user, directory,rs.GetInt32(7));
                }
                else
                {
                    byte[] byteData = (byte[])rs[6];
                    d = new fichier(rs.GetString(0), rs.GetString(3), user, directory, byteData);
                }
                directory.Setlistfichier(d);


            }
            rs.Close();

        }
        public void chargerblob(fichier file)
        {
            string smt = "SELECT blob FROM dbo.Fichier Where nom=@Name";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", file.GetNom());
            SqlDataReader rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                if (DBNull.Value != rs[0])
                {
                    byte[] byteData = (byte[])rs[0];
                    file.Setblob(byteData);
                }
            }
            rs.Close();
        }
        public void Chargerlesfichierofuser(Utulisateur user)
        {
            Dossier dir = new Dossier();
            string smt = "SELECT nom,proprietair,emplacement,format,droitacces,datecreation,id FROM dbo.Fichier Where proprietair=@owner and  emplacement =-1";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@owner", user.GetNom());
            
            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                fichier d = new fichier(rs.GetString(0), rs.GetString(3), user, null,rs.GetInt32(6));
                user.Setlistfiles(d);

            }
            rs.Close();
        }
        public void chargerlesfichier(Utulisateur user)
        {

            int stop = user.Getlistdossier().Length - 1;
            int i = 0;
            if (stop == 0)
            {
                return;
            }
            else
                while (stop > i)

                {


                    Chargerlesfichierdsd(user, user.Getlistdossier()[i]);
                    i++;
                }

        }
        public void Chargerlesdossierdsd(Utulisateur u)
        {

            int stop = u.Getlistdossier().Length - 1;
            int i = 0;
            if (stop == 0)
            {
                return;
            }
            else
                while (stop > i)

                {


                    chargerdossierdsd(u, u.Getlistdossier()[i]);
                    i++;
                }

        }
        public void insertfile(Dossier d, Utulisateur user, string format, string nom, DateTime date, float taille, string droitacces)
        {
            string smt = "INSERT INTO dbo.Fichier(nom,emplacement,proprietair,datecreation,format,taille,droitacces) VALUES( @Name,@emplacement,@proprietair,@datecreation,@format,@taille,@droitacces)";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom);
            cmd.Parameters.AddWithValue("@emplacement", d.Getid());
            cmd.Parameters.AddWithValue("@proprietair", user.GetNom());
            cmd.Parameters.AddWithValue("@datecreation", date);
            cmd.Parameters.AddWithValue("@format", format);
            cmd.Parameters.AddWithValue("@taille", taille);
            cmd.Parameters.AddWithValue("@droitacces", droitacces);
            cmd.ExecuteNonQuery();

        }
        public void insertfileuser(Utulisateur user, string format, string nom, DateTime date, float taille, string droitacces)
        {
            string smt = "INSERT INTO dbo.Fichier(nom,emplacement,proprietair,datecreation,format,taille,droitacces) VALUES( @Name,@emplacement,@proprietair,@datecreation,@format,@taille,@droitacces)";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom);
            cmd.Parameters.AddWithValue("@emplacement", -1);
            cmd.Parameters.AddWithValue("@proprietair", user.GetNom());
            cmd.Parameters.AddWithValue("@datecreation", date);
            cmd.Parameters.AddWithValue("@format", format);
            cmd.Parameters.AddWithValue("@taille", taille);
            cmd.Parameters.AddWithValue("@droitacces", droitacces);
            cmd.ExecuteNonQuery();

        }
        public void insertfilblob(fichier file)
        {
            string smt = "UPDATE Fichier SET blob = @blob  WHERE id = @id;";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@blob", file.GetBlob());
            cmd.Parameters.AddWithValue("@id", file.Getid());


            cmd.ExecuteNonQuery();

        }
        public void deletedirectory(int nom)
        {
            string smt = "Delete From Dossier Where id =@Name";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", nom);

            cmd.ExecuteNonQuery();


        }
        public void deletefile(int id)
        {
            string smt = "Delete From Fichier Where id =@Name";
            cmd = new SqlCommand(smt, conn);
            cmd.Parameters.AddWithValue("@Name", id);

            cmd.ExecuteNonQuery();


        }



    }
}
