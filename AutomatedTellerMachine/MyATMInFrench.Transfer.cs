using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInFrench
    {
        static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEntrez le montant ci-dessous:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && double.TryParse(amount, out double amt))
            {
                if (AcctBal < amt)
                {
                    Console.WriteLine("\nFonds insuffisants\n");
                }
                else if (amt < 100)
                {
                    Console.WriteLine("Le montant doit être jusqu'à 100");
                    return;
                }
                else
                {
                    AcctBal -= amt;
                    Console.WriteLine("\nEntrez le numéro de compte\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nSélectionnez la banque\n\n1. Zenith Bank\n2. Access Bank\n" +
                            "3. Wema Bank\n4. AchA Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\nPlease wait\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("Transaction réussie. Presse\n\n1. Pour imprimer le reçu\n\n2. Pour revenir au menu précédent" +
                                "\n\n3. Pour finir\n");

                            string nextSteps = Console.ReadLine();

                            switch (nextSteps)
                            {
                                case "1":
                                    Console.WriteLine($"\nDebit\nAmt: ${amt}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\n" +
                                        $"Time:{DateTime.Now}\nAvailBal: ${AcctBal}\n");
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
                    else Console.WriteLine("\nLe numéro de compte doit être un numéro à 10 chiffres");
                }
            }
            Console.WriteLine("\nMontant invalide\n");
        }
    }
}
