using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInGerman
    {
        static void Withdrawal()
        {
        enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nGeben Sie unten den Betrag ein:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && double.TryParse(amountString, out double amount))
            {
                if (amount > AcctBal)
                {
                    Console.WriteLine("\nUnzureichende Mittel\n");
                    return;
                }
                else if (amount < 100)
                {
                    Console.WriteLine("Der Betrag muss bis zu 100 betragen");
                    return;
                }
                else
                {
                    AcctBal -= amount;
                    Console.WriteLine("\nWarten Sie mal...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nNimm dein Bargeld. Drücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren\n\n" +
                        "3. Beenden\n");

                    string nextSteps = Console.ReadLine();

                    switch (nextSteps)
                    {
                        case "1":
                            Console.WriteLine($"\nDebit\nAmt: ${amount}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                            $"\nAvailBal: ${AcctBal}\n");
                            Console.WriteLine("Vielen Dank, dass Sie mit uns Bankgeschäfte tätigen");
                            break;
                        case "2":
                            TakeAction();
                            break;
                        case "3":
                            Console.WriteLine("\nDanke dir, bis bald");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("UNGÜLTIGE EINGABE.\nDrücken Sie eine beliebige Taste, um den Vorgang zu beenden");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nungültige Menge\n");
                goto enterAmount;
            }
        }
    }
}
