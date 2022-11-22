using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInGerman
    {
        static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nGeben Sie unten den Betrag ein:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && double.TryParse(amount, out double amt))
            {
                if (AcctBal < amt)
                {
                    Console.WriteLine("\nUnzureichende Mittel\n");
                    return;
                }
                else if (amt < 100)
                {
                    Console.WriteLine("Der Betrag muss bis zu 100 betragen");
                    return;
                }
                else
                {
                    AcctBal -= amt;
                    Console.WriteLine("\nKontonummer eingeben\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nBank auswählen\n\n1. Zenith Bank\n2. Access Bank\n3. Wema Bank\n4. AchA Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\nWarten Sie mal\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("Transaktion Erfolgreich. Drücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren" +
                                "\n\n3. Pour finir\nBeenden\n");

                            string nextSteps = Console.ReadLine();

                            switch (nextSteps)
                            {
                                case "1":
                                    Console.WriteLine($"\nDebit\nAmt: ${amt}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\n" +
                                        $"Time:{DateTime.Now}\nAvailBal: ${AcctBal}\n");
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
                    else Console.WriteLine("\nDie Kontonummer muss eine 10-stellige Zahl sein");
                }
            }
            Console.WriteLine("\nungültige Menge\n");
        }
    }
}
