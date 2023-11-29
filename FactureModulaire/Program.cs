using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FactureModulaire
{
    class Program
    {
        public static void saisie_client(out string nom, out string adr, out string
        ville, out string cp)
        {
            Console.WriteLine("entrez le nom du client");
            nom = Console.ReadLine();
            Console.WriteLine("entrez l'adresse du client");
            adr = Console.ReadLine();
            Console.WriteLine("entrez le code postal");
            cp = Console.ReadLine();
            Console.WriteLine("entrez la ville");
            ville = Console.ReadLine();
        }
        public static void saisie_achat(out string desprod, out double prix, out int
        q, out double taux)
        {
            Console.WriteLine("entrez la désignation du produit");
            desprod = Console.ReadLine();
            Console.WriteLine("entrez la quantité");
            q = Int16.Parse(Console.ReadLine());
            Console.WriteLine("entrez le prix unitaire du produit");
            prix = Double.Parse(Console.ReadLine());
            Console.WriteLine("entrez le taux de tva");
            taux = Double.Parse(Console.ReadLine());
        }
        public static double calcul_montant(double prix, int q)
        {
            double prixart;
            prixart = prix * q;
            return prixart;
        }
        public static double calcul_ttc(double prixart, double taux, out double mtva)
        {
            double ttc, pttc;
            mtva = prixart * taux / 100;
            ttc = prixart + mtva;
            pttc = ttc;
            return ttc;
        }
        public static double Calcul_remise(double prixht)
        {
            double montantRemise, pttc;
            montantRemise = 0;
            if (prixht < 150)
            {
                pttc = 0;
            }
            else
            {
                if (prixht <= 300)
                {
                    pttc = 5;
                }
                else
                {
                    pttc = 10;
                }
            }
            montantRemise = pttc;
            return montantRemise;
        }
        public static void edition_client(string nom, string adr, string ville, string
        cp)
        {
            Console.WriteLine("Facture");
            Console.WriteLine();
            Console.WriteLine("Pour M " + nom);
            Console.WriteLine(adr);
            Console.WriteLine(cp + " " + ville);
            Console.WriteLine();
            Console.WriteLine("Désignation      Pu       Q        Montant");
        }
        public static void edition_ligne(string desprod, double prix, double q, double
        prixart)
        {
            Console.WriteLine(desprod + "                " + prix + "       " + q + "         " + prixart);
        }
        public static void edition_pied_facture(double mtva, double taux, double ttc)
        {
            Console.WriteLine("Taux de tva              " + taux + "%" + "         {0:###.##}",
            mtva);
            Console.WriteLine("Prix Net                             {0:###.##}", ttc);
        }
        static void Main(string[] args)
        {
            double pu, montant, t, montva, pttc, montantr, prixht, fac, remise;
            int qt;
            string nomcli, adrcli, villecli, cpcli, designation;
            saisie_client(out nomcli, out adrcli, out villecli, out cpcli);
            saisie_achat(out designation, out pu, out qt, out t);
            prixht = calcul_montant(pu, qt);
            montant = calcul_montant(pu, qt);
            pttc = calcul_ttc(montant, t, out montva);
            montantr = Calcul_remise(prixht);
            fac = pttc;
            remise = montantr;
            montantr = montantr * fac / 100;
            fac = fac - montantr;
            edition_client(nomcli, adrcli, villecli, cpcli);
            edition_ligne(designation, pu, qt, montant);
            Console.WriteLine("Remise de " + remise + "%                         {0:###.##} ", montantr);
            Console.WriteLine("                                    ------");
            edition_pied_facture(montva, t, pttc);
            Console.WriteLine("Total facture                       {0:###.##} ", fac);
            Console.ReadLine();
        }
    }
}
