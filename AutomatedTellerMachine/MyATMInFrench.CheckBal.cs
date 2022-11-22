using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInFrench
    {
        static void CheckBalance()
        {
            Console.WriteLine($"\nLe solde de votre compte est de ${AcctBal}.nPresse\n\n1. Pour imprimer le reçu\n\n2. Pour revenir au menu précédent\n\n" +
                "3. Pour finir\n");

            string nextSteps = Console.ReadLine();

            switch (nextSteps)
            {
                case "1":
                    Console.WriteLine($"\nBalance\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                    $"\nAvailBal: ${AcctBal}\n");
                    Console.WriteLine("Merci de faire affaire avec nous");
                    break;
                case "2":
                    TakeAction();
                    break;
                case "3":
                    Console.WriteLine("\nMerci a bientôt");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ENTRÉE INVALIDE.\nAppuyez sur n'importe quelle touche pour terminer l'opération\n");
                    break;
            }
        }
    }
}
