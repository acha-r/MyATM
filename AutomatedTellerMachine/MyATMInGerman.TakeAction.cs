using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInGerman
    {
        private static void TakeAction()
        {
            Console.WriteLine("\nWas würdest du gern tun? Drücken Sie\n\n1. Zum Abheben\n\n2. Zur Überweisung\n\n" +
                "3. Um das Guthaben zu überprüfen\n\nPress 0 to cancel\nAppuyez sur 0 pour annuler\nDrücken Sie 0, um abzubrechen");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Withdrawal();
                    break;
                case "2":
                    Transfer();
                    break;
                case "3":
                    CheckBalance();
                    break;
                case "0":
                    Console.WriteLine("\nWir sehen uns ein andermal");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nUNGÜLTIGE OPTION");
                    break;
            }
        }
    }
}
