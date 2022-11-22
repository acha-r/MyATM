using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInGerman : IMyATM
    {
        private bool _insertCard;
        private int _cardPin;
        private string _cardUser;
        private static double _acctBal;
        Regex rgx = new Regex("[^A-Za-z]");
        public static double AcctBal { get { return _acctBal; } set { _acctBal = value; } }

        public bool GetCard()
        {
            Console.WriteLine("\nWarten Sie mal...\n");
            Thread.Sleep(1000);
            Console.WriteLine("\nKarte eingelegt\n");
            return true;
        }

        public string GetCardUserName()
        {
            Console.WriteLine("\nGib deinen Namen ein\n");
            string userName = (Console.ReadLine().ToUpper());
            if (rgx.IsMatch(userName))
            {
                Console.WriteLine("Ungültiges Detail angegeben.\nIhr Name ist jetzt OKORO\n");
                userName = "OKORO";
            }
            return userName;
        }

        public int GetPin()
        {
            int allowedpinTries = 3;
            Console.WriteLine("\nGeben Sie die 4-stellige PIN ein\n");

        enterpin:
            string pin = Console.ReadLine();

            if (pin.Length == 4 && int.TryParse(pin, out int pinNumber))
            {
                Console.WriteLine("\nAnmeldung erfolgreich\n");
                Console.WriteLine($"\nWillkommen {_cardUser}\n");
                return pinNumber;
            }
            else
            {
                for (int i = 1; i <= allowedpinTries; i++)
                {
                    allowedpinTries--;
                    Console.WriteLine($"Die PIN muss eine 4-stellige Zahl sein.\nSie haben noch {allowedpinTries} Versuche\n");
                    goto enterpin;
                }
                if (allowedpinTries == 0)
                {
                    Console.WriteLine("\nKarte gesperrt. Besuchen Sie die Bank für weitere Unterstützung");
                    Environment.Exit(1);
                }
            }
            return 0;
        }

        public MyATMInGerman()
        {
            _insertCard = GetCard();
            _cardUser = GetCardUserName();
            _cardPin = GetPin();
            AcctBal = 1000.00;
            TakeAction();
        }
    }
}
