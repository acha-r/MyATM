namespace AutomatedTellerMachine
{
    internal partial class MyATMInEng
    {
        private static void TakeAction()
        {
            Console.WriteLine("\nWhat would you like to do? Press\n\n1. For withdrawal\n\n2. For transfer\n\n3. To check Balance\n" +
                "\nPress 0 to cancel");
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
                    Console.WriteLine("\nSee you some other time");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nINVALID OPTION");
                    break;
            }
        }
    }
}
