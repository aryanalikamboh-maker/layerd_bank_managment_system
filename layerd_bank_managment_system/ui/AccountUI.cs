using System;

namespace bankmanagment
{
    public class AccountUI
    {
        private AccountService service = new AccountService();

        public void ShowMenu()
        {
            int ch = 0;
            while (ch != 10)
            {
                Console.Clear();
                Console.WriteLine("===== BANK MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. View All Accounts");
                Console.WriteLine("3. Search Account");
                Console.WriteLine("4. Deposit Money");
                Console.WriteLine("5. Withdraw Money");
                Console.WriteLine("6. Edit Account Name");
                Console.WriteLine("7. Delete Account");
                Console.WriteLine("8. Clear All Accounts");
                Console.WriteLine("9. Sort Accounts");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");
                ch = Convert.ToInt32(Console.ReadLine());

                if (ch == 1) CreateUI();
                else if (ch == 2) ViewUI();
                else if (ch == 3) SearchUI();
                else if (ch == 4) DepositUI();
                else if (ch == 5) WithdrawUI();
                else if (ch == 6) EditUI();
                else if (ch == 7) DeleteUI();
                else if (ch == 8) ClearUI();
                else if (ch == 9) SortUI();
                else if (ch == 10) Console.WriteLine("Thank You!");
                else
                {
                    Console.WriteLine("Invalid Choice!");
                    Console.ReadKey();
                }
            }
        }

        private void CreateUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Account Holder Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Opening Balance: ");
            double bal = Convert.ToDouble(Console.ReadLine());

            if (service.AddAccount(accNo, name, bal))
                Console.WriteLine("Account Created Successfully!");
            else
                Console.WriteLine("Account Limit Reached!");
            Console.ReadKey();
        }

        private void ViewUI()
        {
            Console.WriteLine("=== Account List ===");
            for (int i = 0; i < service.Count(); i++)
            {
                Account a = service.GetAt(i);
                Console.WriteLine("Account: " + a.AccNo + " | Name: " + a.Name + " | Balance: " + a.Balance);
            }
            Console.ReadKey();
        }

        private void SearchUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());
            int index = service.SearchAccount(accNo);

            if (index != -1)
            {
                Account a = service.GetAt(index);
                Console.WriteLine("Account: " + a.AccNo);
                Console.WriteLine("Name: " + a.Name);
                Console.WriteLine("Balance: " + a.Balance);
            }
            else
            {
                Console.WriteLine("Account Not Found!");
            }
            Console.ReadKey();
        }

        private void DepositUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Deposit Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (service.Deposit(accNo, amount))
                Console.WriteLine("Deposit Successful!");
            else
                Console.WriteLine("Account Not Found!");
            Console.ReadKey();
        }

        private void WithdrawUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Withdraw Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            int result = service.Withdraw(accNo, amount);
            if (result == 1)
                Console.WriteLine("Withdrawal Successful!");
            else if (result == 2)
                Console.WriteLine("Insufficient Balance!");
            else
                Console.WriteLine("Account Not Found!");
            Console.ReadKey();
        }

        private void EditUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            if (service.UpdateAccountName(accNo, newName))
                Console.WriteLine("Name Updated Successfully!");
            else
                Console.WriteLine("Account Not Found!");
            Console.ReadKey();
        }

        private void DeleteUI()
        {
            Console.Write("Enter Account Number: ");
            int accNo = Convert.ToInt32(Console.ReadLine());

            if (service.DeleteAccount(accNo))
                Console.WriteLine("Account Deleted Successfully!");
            else
                Console.WriteLine("Account Not Found!");
            Console.ReadKey();
        }

        private void ClearUI()
        {
            service.ClearAllAccounts();
            Console.WriteLine("All Accounts Cleared!");
            Console.ReadKey();
        }

        private void SortUI()
        {
            service.SortAccounts();
            Console.WriteLine("Accounts Sorted Successfully!");
            Console.ReadKey();
        }
    }
}