using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInFrench : IMyATM
    {
        private bool _insertCard;
        private int _cardPin;
        private string _cardUser;
        private static double _acctBal;
        Regex rgx = new Regex("[^A-Za-z]");
        public static double AcctBal { get { return _acctBal; } set { _acctBal = value; } }

        public bool GetCard()
        {
            Console.WriteLine("\nS'il vous plaît, attendez...\n");
            Thread.Sleep(1000);
            Console.WriteLine("\nCarte insérée\n");
            return true;
        }

        public string GetCardUserName()
        {
            Console.WriteLine("\nEntrez votre nom\n");
            string userName = (Console.ReadLine().ToUpper());
            if (rgx.IsMatch(userName))
            {
                Console.WriteLine("Détail non valide fourni.\nTu t'appelles maintenant OKORO\n");
                userName = "OKORO";
            }
            return userName;
        }

        public int GetPin()
        {
            int allowedpinTries = 3;
            Console.WriteLine("\nEntrez le code PIN à 4 chiffres\n");

        enterpin:
            string pin = Console.ReadLine();

            if (pin.Length == 4 && int.TryParse(pin, out int pinNumber))
            {
                Console.WriteLine("\nConnexion réussie\n");
                Console.WriteLine($"\nBienvenu {_cardUser}\n");
                return pinNumber;
            }
            else
            {
                for (int i = 1; i <= allowedpinTries; i++)
                {
                    allowedpinTries--;
                    Console.WriteLine($"Le code PIN doit être un numéro à 4 chiffres.\nIl vous reste {allowedpinTries} essais\n");
                    goto enterpin;
                }
                if (allowedpinTries == 0)
                {                  
                    Console.WriteLine("\nCarte bloquée. Rendez-vous à la banque pour obtenir de l'aide");
                    Environment.Exit(1);
                }
            }
            return 0;
        }

        public MyATMInFrench()
        {
            _insertCard = GetCard();
            _cardUser = GetCardUserName();
            _cardPin = GetPin();
            AcctBal = 1000.00;
            TakeAction();
        }
    }
}
