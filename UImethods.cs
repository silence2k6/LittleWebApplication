using LittleWebApplication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class UImethods
    {
        public static Enums AskForLogin(List<CreateUser> userList)
        {
            Console.WriteLine("Benutzername:\t");
            string userLoginNumber = Console.ReadLine().ToUpper();
            //int i = 0;

            //while (userList[i] <= userList.Count)
            //{
            //    CreateUser objectToCheck = userList[i];

            //    if (objectToCheck.userNumber == userLoginNumber)
            //    {

            //    }
            //}

            Console.WriteLine("Passwort:\t");
            string userPasswort = Console.ReadLine();
        }
    }
}
