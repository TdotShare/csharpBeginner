using csharpBeginner.Database;
using csharpBeginner.Database.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace csharpBeginner.Examples
{
    public class GenerateRandomPassword
    {

        public void StartProgram()
        {

            try
            {

                string connectionString = "server=localhost;port=3306;database=tpci3;uid=root;password=";

                List<string> passwordList = new List<string>();

                Console.WriteLine("GenerateRandomPassword StartProgram !");
                Random rdm = new Random();

                var passwordSet = RandomCreateSetPassword(passwordList, 2, rdm);

   


                
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var context = new JourneyContext(connection, false))
                    {
                        List<Dtgen> dtgenItem = new List<Dtgen>();


                        foreach (var item in passwordList)
                        {

                            dtgenItem.Add(new Dtgen
                            {
                                genUserId = "1",
                                genPassword = item,
                                genCreateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                genUpdateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            }
                            );
                        }

                        context.Dtgens.AddRange(dtgenItem);
                        context.SaveChanges();
                    }
                    connection.Close();
                }
                

                /*
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var context = new JourneyContext(connection, false))
                    {

                        context.Dtgens.Add(
                            new Dtgen { 
                                genUserId = "1", 
                                genPassword = CreatePassword(rdm) ,
                                genCreateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                genUpdateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            });
                        context.SaveChanges();
    
                    }
                    connection.Close();
                }
                */

                Console.WriteLine("GenerateRandomPassword EndProgram !");

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }
            }


        }

        private List<string> RandomCreateSetPassword(List<string> passwordList, int maxPassword, Random rdm)
        {

            if (passwordList.Count == 0)
            {
                passwordList.Add(CreatePassword(rdm));
            }

            string newPwd = CreatePassword(rdm);
            int chkItem = passwordList.Where(x => x == newPwd).Count();

            if (chkItem > 0)
            {
                RandomCreateSetPassword(passwordList, maxPassword, rdm);
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
