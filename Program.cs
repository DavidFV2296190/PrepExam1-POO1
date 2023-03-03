using System.Runtime.CompilerServices;

namespace PrepExam1_POO1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employe test = new Employe(Employe.GMatricule(), "Bacon", "Bob", new DateOnly(1984, 1,1), DateOnly.FromDateTime(DateTime.Now), 50000, new Dossier());
            Employe james = new Employe("007", "Bond", "James", new DateOnly(1956, 10, 10), new DateOnly(1992, 1, 1), 15000000, new Dossier("007", Dossier.statutfamilial.Célibataire, DateOnly.FromDateTime(DateTime.Now)));
            Console.WriteLine(test.ToString());
            Console.WriteLine(test.DateEmbauche.Year.ToString());
            Console.WriteLine(test.CalculerNombreAnneesTravaillees(test.DateEmbauche));
            Console.WriteLine("AUGMENTATION");
            test.AugmenterSalaire();
            james.AugmenterSalaire();
            Console.WriteLine(james.ToString());
            Console.WriteLine(test.Equals(james));
            Console.WriteLine("-------------");
            james.AfficherEmploye();
            Dossier.AfficherDossierEmploye(james);
            Console.WriteLine(james.Dossier.VerifierEtatMatrimonial());

        }

    }
}