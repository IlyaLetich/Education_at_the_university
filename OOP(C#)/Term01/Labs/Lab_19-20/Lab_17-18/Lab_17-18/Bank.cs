namespace Lab_19_20
{
    internal class Bank
    {
        private static int idCount = -1;

        public BankAccount CreateBankAccount(string name)
        {
            idCount++;
            return (new BankAccount(idCount.ToString(), name));
        }
    }
}
