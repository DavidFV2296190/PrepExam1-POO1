using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepExam1_POO1
{
    public class Dossier
    {
        private string m_nas;
        public enum statutfamilial { Marié, Célibataire, Conjoint };
        private statutfamilial m_statutfamilial;
        private DateOnly m_datecreationdossier;


        public string Nas { get { return this.m_nas; } }
        public statutfamilial StatutFamilial { get { return this.m_statutfamilial; } }
        public DateOnly DateCreationdossier { get { return this.m_datecreationdossier; } }
        public Dossier()
        {
            Dossier d = new Dossier(this.Nas, this.StatutFamilial, this.DateCreationdossier);
        }
        public Dossier(string p_nas, statutfamilial p_statutFamilial, DateOnly p_datecreationdossier)
        {
            this.m_nas = p_nas;
            this.m_statutfamilial = p_statutFamilial;
            this.m_datecreationdossier = p_datecreationdossier;
        }
        public static void AfficherDossierEmploye(Employe p_employe)
        {
            Console.Write("Dossier employé: ");
            Console.WriteLine(p_employe.Dossier.ToString());
        }
        public string VerifierEtatMatrimonial()
        {
            return this.m_statutfamilial.ToString();
        }
        public override string ToString()
        {
            return "NAS: " + this.Nas + " Date création dossier: " + this.DateCreationdossier + " Statut familial: " + this.StatutFamilial;
        }
    }
}
