namespace AutomatedTellerMachine
{
    internal partial class MyATMInEng
    {
        static void CheckBalance()
        {
            Console.WriteLine($"\nYour account balance is ${AcctBal}. \nPress\n\n1. To print receipt\n\n2. To return to previous menu\n\n" +
                $"3. To end\nPour finir\nBeenden\n");

            string nextSteps = Console.ReadLine();

            switch (nextSteps)
            {
                case "1":
                    Console.WriteLine($"\nBalance\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
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
}
