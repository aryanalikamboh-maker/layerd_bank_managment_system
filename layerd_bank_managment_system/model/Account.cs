namespace bankmanagment
{
    public class Account
    {
        public int AccNo;
        public string Name;
        public double Balance;

        public Account() { }

        public Account(int accNo, string name, double balance)
        {
            AccNo = accNo;
            Name = name;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{AccNo}|{Name}|{Balance}";
        }
    }
}