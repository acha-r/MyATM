using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInFrench
    {
        static void Withdrawal()
        {
        enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEntrez le montant ci-dessous:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && double.TryParse(amountString, out double amount))
            {
                if (amount > AcctBal)
                {
                    Console.WriteLine("\nFonds insuffisants\n");
                    return;
                }
                else if (amount < 100)
                {
                    Console.WriteLine("Le montant doit être jusqu'à 100");
                    return;
                }
                else
                {
                    AcctBal -= amount;
                    Console.WriteLine("\nS'il vous plaît, attendez...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nPrenez votre argent. Presse\n\n1. Pour imprimer le reçu\n\n2. Pour revenir au menu précédent\n\n" +
                        "3. Pour finir\n");

                    string nextSteps = Console.ReadLine();

                    switch (nextSteps)
                    {
                        case "1":
                            Console.WriteLine($"\nDebit\nAmt: ${amount}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                            $"\nAvailBal: ${AcctBal}\n");
                            Console.WriteLine("Merci de faire affaire avec nous\n");
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
            else
            {
                Console.WriteLine("\nMontant invalide\n");
                goto enterAmount;
            }
        }
    }
}
