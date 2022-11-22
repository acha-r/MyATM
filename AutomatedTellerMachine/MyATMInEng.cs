using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInEng : IMyATM
    {
        private bool _insertCard;
        private int _cardPin;
        private string _cardUser;
        private static double _acctBal;
        Regex rgx = new Regex("[^A-Za-z]");
        public static double AcctBal { get { return _acctBal; } set { _acctBal = value; } }

        public bool GetCard()
        {
            Console.WriteLine("\nPlease wait...\n");
            Thread.Sleep(1000);
            Console.WriteLine("\nCard inserted\n");
            return true;
        }

        public string GetCardUserName()
        {
            Console.WriteLine("\nEnter your name\n");
            string userName = (Console.ReadLine().ToUpper());
            if (rgx.IsMatch(userName))
            {
                Console.WriteLine("\nInvalid detail supplied.\nYour name is now OKORO\n");
                userName = "OKORO";
            }
            return userName;
        }

        public int GetPin()
        {
            int allowedpinTries = 3;
            Console.WriteLine("\nEnter 4 digit pin\n");

        enterpin:
            string pin = Console.ReadLine();

            if (pin.Length == 4 && int.TryParse(pin, out int pinNumber))
            {
                Console.WriteLine("\nLogin successful\n");
                Console.WriteLine($"\nWelcome {_cardUser}\n");
                return pinNumber;
            }
            else
            {
                for (int i = 1; i <= allowedpinTries; i++)
                {
                    allowedpinTries--;
                    Console.WriteLine($"\nPin must be a 4-digit number.\nYou have {allowedpinTries} tries left\n");
                    goto enterpin;
                }
                if (allowedpinTries == 0)
                {
                    Console.WriteLine("\nCard blocked. Visit the bank for further assistance");
                    Environment.Exit(1);
                }
            }
            return 0;
        }

        public MyATMInEng()
        {
            _insertCard = GetCard();
            _cardUser = GetCardUserName();
            _cardPin = GetPin();
            AcctBal = 1000.00;
            TakeAction();
        }
    }
}

