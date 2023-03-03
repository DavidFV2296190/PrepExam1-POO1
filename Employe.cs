using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrepExam1_POO1
{
    public class Employe
    {
        private string m_matricule = GenererMatricule();
        private string m_nom;
        private string m_prenom;
        private DateOnly m_dateNaissance;
        private DateOnly m_dateEmbauche;
        private int m_salaire;
        private Dossier m_dossier;

        private static string GenererMatricule()
        {
            Random random = new Random();
            string chiffres = "";
            for (int i = 0; i < 6; i++)
            {
                chiffres += random.Next(0, 10).ToString();
            }
            return chiffres;
        }

        public static string GMatricule()
        {
            return GenererMatricule();
        }

        public string Matricule { get { return this.m_matricule; } }
        public string Nom { get { return this.m_nom; } }
        public string Prenom { get { return this.m_prenom; } }
        public DateOnly DateNaissance { get { return this.m_dateNaissance; } }
        public DateOnly DateEmbauche { get { return this.m_dateEmbauche; } }
        public int Salaire
        {
            get { return this.m_salaire; }
            set { this.m_salaire = value; }
        }
        public Dossier Dossier { get { return this.m_dossier; } }
        public Employe()
        {
            Employe e = new Employe(this.Matricule, this.Nom, this.Prenom, this.DateNaissance, this.DateEmbauche, this.Salaire, this.Dossier);
        }
        public Employe(string p_matricule, string p_nom, string p_prenom, DateOnly p_dateNaissance, DateOnly p_dateEmbauche, int p_salaire, Dossier p_dossier)
        {
            this.m_matricule = p_matricule;
            this.m_nom = p_nom;
            this.m_prenom = p_prenom;
            this.m_dateNaissance = p_dateNaissance;
            this.m_dateEmbauche = p_dateEmbauche;
            this.m_salaire = p_salaire;
            this.m_dossier = p_dossier;
        }
        public int CalculerNombreAnneesTravaillees(DateOnly p_datembauche)
        {
            DateOnly ajd = DateOnly.FromDateTime(DateTime.Now);
            return ajd.Year - p_datembauche.Year;
        }

        public void AugmenterSalaire()
        {
            double salaire = this.Salaire;
            int anciennete = CalculerNombreAnneesTravaillees(this.DateEmbauche);
            if (anciennete < 5)
            {
                this.Salaire += Convert.ToInt32(salaire * 0.02);
            }
            else if (anciennete >= 5 && anciennete <= 10)
            {
                this.Salaire += Convert.ToInt32(salaire * 0.05);
            }
            else if (anciennete > 10)
            {
                this.Salaire += Convert.ToInt32(salaire * 0.10);
            }
        }
        public void AfficherEmploye()
        {
            Console.WriteLine("EMPLOYÉ");
            Console.WriteLine("Matricule: " + this.Matricule);
            Console.WriteLine("Nom: " + this.Nom);
            Console.WriteLine("Prenom: " + this.Prenom);
            Console.WriteLine("DDN: " + this.DateNaissance.ToString());
            Console.WriteLine("Date d'embauche: " + this.DateEmbauche.ToString());
            Console.WriteLine("Salaire annuel: " + this.Salaire.ToString());
            Dossier.AfficherDossierEmploye(this);
        }

        public override string ToString()
        {
            return "Employé: (ID: " + this.Matricule + " Nom: " + this.Nom + " Prenom: "
                + this.Prenom + " Date de naissance: " + this.DateNaissance.ToString()
                + " Date d'embauche: " + this.DateEmbauche.ToString() + " Salaire : " + this.Salaire.ToString() + "$)";
        }

        public static bool operator ==(Employe p_gauche, Employe p_droit)
        {
            return object.ReferenceEquals(p_gauche, p_droit) || (!object.ReferenceEquals(p_gauche, null)
                    && !object.ReferenceEquals(p_droit, null)
                    && p_gauche.Equals(p_droit)
                    );
        }
        public static bool operator !=(Employe p_gauche, Employe p_droit)
        {
            return !(p_gauche == p_droit);
        }
        public override bool Equals(object p_employe)
        {
            bool egaux = false;
            Employe conversionEmploye = p_employe as Employe;
            if (conversionEmploye == null)
            { return false; }
            if (conversionEmploye != null)
            {
                egaux = this.Matricule.CompareTo(conversionEmploye.Matricule) == 0
                    && this.Nom.CompareTo(conversionEmploye.Nom) == 0
                    && this.Prenom.CompareTo(conversionEmploye.Prenom) == 0
                    && this.DateNaissance.CompareTo(conversionEmploye.DateNaissance) == 0
                    && this.DateEmbauche.CompareTo(conversionEmploye.DateEmbauche) == 0;
                // && this.Dossier.CompareTo(conversionEmploye.Dossier) == 0;
            }
            return egaux;
        }
    }
}
