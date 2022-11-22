namespace AutomatedTellerMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AchA Bank\n... everyone is a baller\n");
            Console.WriteLine("Choose your preferred language\nChoisissez votre langue préférée\nWählen Sie Ihre bevorzugte Sprache");
            Console.WriteLine("\nPress\\Presse\\Drücken Sie \n\n1. English\n\n2. French\n\n3. German\n");
            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    MyATMInEng myATMInEng = new MyATMInEng();
                    break;
                case "2":
                    MyATMInFrench myATMInFrench = new MyATMInFrench();
                    break;
                case "3":
                    MyATMInGerman myATMInGerman = new MyATMInGerman();
                    break;
                default:
                    Console.WriteLine("\nINVALID INPUT\nNON VALIDE\nUNGÜLTIG");
                    break;
            }
        }
    }
}
