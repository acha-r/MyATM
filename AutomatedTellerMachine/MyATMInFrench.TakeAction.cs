namespace AutomatedTellerMachine
{
    internal partial class MyATMInFrench
    {
        private static void TakeAction()
        {
            Console.WriteLine("\nQu'est-ce que tu aimerais faire? Presse\n\n1. Pour le retrait\n\n2. Pour transfert\n\n3. Pour vérifier le solde" +
                "\n\nAppuyez sur 0 pour annuler\n");
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
                    Console.WriteLine("\nA une autre fois");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nOPTION INVALIDE");
                    break;
            }
        }
    }
}
