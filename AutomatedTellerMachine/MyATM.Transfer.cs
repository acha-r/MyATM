using System.Text.RegularExpressions;

namespace AutomatedTellerMachine
{
    internal partial class MyATMInEng
    {
        static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEnter amount below:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && double.TryParse(amount, out double amt))
            {
                if (AcctBal < amt)
                {
                    Console.WriteLine("\nInsufficient funds\n");
                    return;
                }
                else if (amt < 100)
                {
                    Console.WriteLine("Amount must be up tp 100");
                    return;
                }
                else
                {
                    AcctBal -= amt;
                    Console.WriteLine("\nEnter account number\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nSelect bank\n\n1. Zenith Bank\n2. Access Bank\n3. Wema Bank\n4. AchA Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\nPlease wait\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("Transaction successful. Press\n\n1. To print receipt\n\n2. To return to previous menu\n\n" +
                                "3. To end\n");

                            string nextSteps = Console.ReadLine();

                            switch (nextSteps)
                            {
                                case "1":
                                    Console.WriteLine($"\nDebit\nAmt: ${amt}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\n" +
                                        $"Time:{DateTime.Now}\nAvailBal: ${AcctBal}\n");
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
                    else Console.WriteLine("\nAccount number must be a 10-digit number");
                }
            }
            Console.WriteLine("\nInvalid amount\n");
        }
    }
}
