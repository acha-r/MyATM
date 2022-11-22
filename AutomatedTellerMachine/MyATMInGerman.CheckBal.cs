using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInGerman
    {
        static void CheckBalance()
        {
            Console.WriteLine($"Ihr Kontostand beträgt ${AcctBal}.\nDrücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren" +
                $"\n\n3. Beenden\n");

            string nextSteps = Console.ReadLine();

            switch (nextSteps)
            {
                case "1":
                    Console.WriteLine($"\nBalance\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
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
}
