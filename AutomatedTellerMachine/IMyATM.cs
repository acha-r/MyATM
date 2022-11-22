namespace AutomatedTellerMachine
{
    internal interface IMyATM
    {
        static double AcctBal { get; set; }
        bool GetCard() { return true; }
        string GetCardUserName() { return ""; }
        int GetPin() { return 0; }
        void TakeAction() { }
        void Withdrawal() { }
        void CheckBal() { }
        void Transfer() { }
    }
}
