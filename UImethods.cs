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
        public static string AskForUserLoginNumber()
        {
            Console.Write("Benutzername:\t");
            string userLoginNumberInput = Console.ReadLine().ToUpper();
            return userLoginNumberInput;
        }

        public static Enums.UserType CheckUserLoginForArtOfUser(string userLoginNumberInput)
        {
            Enums.UserType artOfUser = new();

            if (userLoginNumberInput[0].Equals('P'))
            {
                artOfUser = Enums.UserType.privateUser;
            }
            if (userLoginNumberInput[0].Equals('B'))
            {
                artOfUser = Enums.UserType.businessUser;
            }
            if (userLoginNumberInput[0].Equals('S'))
            {
                artOfUser = Enums.UserType.serviceUser;
            }
            if (userLoginNumberInput[0].Equals('A'))
            {
                artOfUser = Enums.UserType.adminUser;
            }
            return artOfUser;
        }


        public static CreateUser CheckUserLoginForUserNumberExist(string userLoginNumberInput, Enums.UserType artOfUser)
        {
            List<CreateUser> userList = new();

            if (artOfUser == Enums.UserType.privateUser)
            {
                userList = Backup.LoadPrivateUserRepository();
            }
            //if(artOfUser == Enums.UserType.businessUser)
            //{
            //    userList = businessUserList;
            //}
            //if(artOfUser == Enums.UserType.serviceUser)
            //{
            //    userList = serviceUserList;
            //}
            //if(artOfUser == Enums.UserType.adminUser)
            //{
            //    userList = adminUserList;
            //}

            int userObjectPos = 0;
            CreateUser user = new();

            while (userObjectPos <= userList.Count)
            {
                user = userList[userObjectPos];
                
                if (string.Equals(userLoginNumberInput, user.userLogin.userLoginNumber))
                {
                    user = userList[userObjectPos];
                    break;
                }
                else
                {
                    userObjectPos++;

                    if (userObjectPos == userList.Count)
                    {
                        Console.WriteLine("Benutzername exitiert nicht!");
                        user = null;
                        break;
                    }
                }
            }
            return user;
        }

        public static string AskForUserLoginPassword()
        { 
            Console.Write("Passwort:\t");
            string userPasswordInput = Console.ReadLine();
            return userPasswordInput;
        }

        public static bool CheckUserLoginForValidPassword(CreateUser user, string userPasswordInput)
        {
            bool validUserPassword = false;
            
            if(string.Equals(user.userLogin.userLoginPassword, userPasswordInput))
            {
                validUserPassword = true;
            }
            return validUserPassword;
        }

        public static void CheckUserLoginForValidity(bool validUserNumber, bool validUserPassword)
        {
            while (validUserNumber == false || validUserPassword == false)
            {
                if (validUserNumber == false)
                {
                    Console.WriteLine("Ihr eingegebener Benutzername existiert leider nicht!");
                }
                if (validUserPassword == false)
                {
                    Console.WriteLine("Ihr eingegebenes Password stimmt leider nicht mit Ihrem Benutzer überein!");
                }
                Console.Write("Bitte wählen Sie aus folgenden Optionen:\n(1) Erneut versuchen\n(2) Neu registrieren\n(3) Password vergessen");
            }
        }
    }
}
