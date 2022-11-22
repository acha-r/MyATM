using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInEng
    {
        static void Withdrawal()
        {
        enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEnter amount below:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && double.TryParse(amountString, out double amount))
            {
                if (amount > AcctBal)
                {
                    Console.WriteLine("\nInsufficient funds\n");
                    return;
                }
                else if (amount < 100)
                {
                    Console.WriteLine("Amount must be up tp 100");
                    return;
                }
                else
                {
                    AcctBal -= amount;
                    Console.WriteLine("\nPlease wait...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nTake your cash. Press\n\n1. To print receipt\n\n2. To return to previous menu\n\n" +
                        "3. To end\n");

                    string nextSteps = Console.ReadLine();

                    switch (nextSteps)
                    {
                        case "1":
                            Console.WriteLine($"\nDebit\nAmt: ${amount}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                            $"\nAvailBal: ${AcctBal}\n");
                            Console.WriteLine("Thank you for banking with us");
                            break;
                        case "2":
                            TakeAction();
                            break;
                        case "3":
                            Console.WriteLine("\nThank you. See you");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nINVALID INPUT.\nPress any key to end operation\n");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid amount\n");
                goto enterAmount;
            }
        }
    }
}


