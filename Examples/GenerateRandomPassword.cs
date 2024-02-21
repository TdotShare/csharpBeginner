using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpBeginner.Examples
{
    public class GenerateRandomPassword
    {

        public void StartProgram()
        {
            List<string> passwordList = new List<string>();

            Console.WriteLine("GenerateRandomPassword StartProgram !");
            Random rdm = new Random();

            var passwordSet = RandomCreateSetPassword(passwordList , 10 , rdm);


            foreach (var item in passwordSet)
            {
                Console.WriteLine($"=> {item}");
            }

        }

        private List<string> RandomCreateSetPassword(List<string> passwordList , int maxPassword , Random rdm)
        {

            if (passwordList.Count == 0)
            {
                passwordList.Add(CreatePassword(rdm));
            }

            string newPwd = CreatePassword(rdm);
            int chkItem = passwordList.Where(x => x == newPwd).Count();
            
            if (chkItem > 0)
            {
                RandomCreateSetPassword(passwordList, maxPassword , rdm);
            }
            else
            {
                passwordList.Add(newPwd);
            }
            
            if (passwordList.Count != maxPassword)
            {
                RandomCreateSetPassword(passwordList, maxPassword, rdm);
            }
            
          
            return passwordList;
        }

        private string CreatePassword(Random random)
        {
            try
            {
                string charSet = "abcdefghijklmnopqrstuvwxyz";
                string passwordText = "";

                for (int i = 0; i < 8; i++)
                {
                    passwordText += random.Next(10).ToString();
                }

                StringBuilder newEditPassword = new StringBuilder(passwordText);
                newEditPassword[3] = charSet[random.Next(0, charSet.Length)];
                newEditPassword[4] = charSet[random.Next(0, charSet.Length)];
                newEditPassword[5] = charSet[random.Next(0, charSet.Length)];

                return newEditPassword.ToString();
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
