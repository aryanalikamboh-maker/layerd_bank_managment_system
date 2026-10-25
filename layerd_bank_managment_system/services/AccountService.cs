namespace bankmanagment
{
    public class AccountService
    {
        private AccountRepository repo = new AccountRepository();
        private Account[] accounts = new Account[100];
        private int n = 0;

        public AccountService()
        {
            n = repo.LoadFromFile(accounts);
        }

        private void SaveData()
        {
            repo.SaveToFile(accounts, n);
        }

        // UI ko data dene ke liye (array private hai)
        public int Count()
        {
            return n;
        }

        public Account GetAt(int index)
        {
            return accounts[index];
        }

        public bool AddAccount(int accNo, string name, double openingBal)
        {
            if (n >= 100)
                return false;
            accounts[n] = new Account(accNo, name, openingBal);
            n++;
            SaveData();
            return true;
        }

        // index wapas deta hai, nahi mila to -1
        public int SearchAccount(int accNo)
        {
            for (int i = 0; i < n; i++)
            {
                if (accounts[i].AccNo == accNo)
                    return i;
            }
            return -1;
        }

        public bool Deposit(int accNo, double amount)
        {
            int i = SearchAccount(accNo);
            if (i == -1) return false;
            accounts[i].Balance = accounts[i].Balance + amount;
            SaveData();
            return true;
        }

        // 0 = not found, 1 = success, 2 = insufficient balance
        public int Withdraw(int accNo, double amount)
        {
            int i = SearchAccount(accNo);
            if (i == -1) return 0;
            if (amount > accounts[i].Balance) return 2;
            accounts[i].Balance = accounts[i].Balance - amount;
            SaveData();
            return 1;
        }

        public bool UpdateAccountName(int accNo, string newName)
        {
            int i = SearchAccount(accNo);
            if (i == -1) return false;
            accounts[i].Name = newName;
            SaveData();
            return true;
        }

        public bool DeleteAccount(int accNo)
        {
            int i = SearchAccount(accNo);
            if (i == -1) return false;
            for (int j = i; j < n - 1; j++)
            {
                accounts[j] = accounts[j + 1];
            }
            n--;
            SaveData();
            return true;
        }

        public void ClearAllAccounts()
        {
            n = 0;
            SaveData();
        }

        // Bubble sort (manual)
        public void SortAccounts()
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (accounts[j].AccNo > accounts[j + 1].AccNo)
                    {
                        Account temp = accounts[j];
                        accounts[j] = accounts[j + 1];
                        accounts[j + 1] = temp;
                    }
                }
            }
            SaveData();
        }
    }
}