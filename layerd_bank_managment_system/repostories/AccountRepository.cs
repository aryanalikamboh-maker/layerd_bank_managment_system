using System;
using System.IO;

namespace bankmanagment
{
    public class AccountRepository
    {
        private string filePath = "accounts.txt";

        public int LoadFromFile(Account[] accounts)
        {
            int n = 0;
            if (File.Exists(filePath))
            {
                string s;
                StreamReader reader = new StreamReader(filePath);
                while ((s = reader.ReadLine()) != null && n < 100)
                {
                    string[] data = s.Split('|');
                    if (data.Length >= 3)
                    {
                        accounts[n] = new Account(
                            Convert.ToInt32(data[0]),
                            data[1],
                            Convert.ToDouble(data[2]));
                        n++;
                    }
                }
                reader.Close();
            }
            return n;
        }

        public void SaveToFile(Account[] accounts, int n)
        {
            StreamWriter writer = new StreamWriter(filePath);
            for (int i = 0; i < n; i++)
            {
                writer.WriteLine(accounts[i].ToString());
            }
            writer.Close();
        }
    }
}