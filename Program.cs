using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using LittleWebApplication.Users;
using LittleWebApplication.Accounts;

namespace LittleWebApplication
{
    internal class Progamm
    {
        static void Main(string[] args)
        {
            XmlSerializer accountSerializer = new XmlSerializer(typeof(List<AccountInformations>));
            string accountRepositoryPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountRepository.xml";
            XmlSerializer userSerializer = new(typeof(List<CreateUser>));
            string privatUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privatUserList.xml";

            List<AccountInformations> accountList = new();
            accountList = Backup.AccountListRepository(accountList, accountSerializer, accountRepositoryPath);
            List<CreateUser> privatUserList = new();
            privatUserList = Backup.PrivatUserRepository(privatUserList, userSerializer, privatUserListPath);

            int accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.UserType.privatUser, accountNumber);
            DateTime datetime = DateTime.Now;

            CreateUser newPrivatUserDummy = new();
            newPrivatUserDummy.userName = CreateUser.CreatePrivatUserDummyName();
            newPrivatUserDummy.userAdress = CreateUser.CreatePrivatUserDummyAdress();
            newPrivatUserDummy.userContact = CreateUser.CreatePrivatUserDummyContact(newPrivatUserDummy.userName);
            newPrivatUserDummy.userLogin = CreateUser.CreatePrivatUserDummyLogin(userNumber);
            privatUserList.Add(newPrivatUserDummy);

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.UserType.privatUser, datetime);
            accountList.Add(newAccount);

            Backup.PrivatUserRepository(privatUserList, userSerializer, privatUserListPath);
            Backup.AccountListRepository(accountList, accountSerializer, accountRepositoryPath);
        }
    }
}