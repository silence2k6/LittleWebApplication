using System.Xml.Serialization;
using static LittleWebApplication.ProfilData.ProfilData;
using static LittleWebApplication.Users.PrivatUserDummy;
using System.Security.Cryptography.X509Certificates;
using LittleWebApplication.ProfilData;

namespace LittleWebApplication
{
    internal class Progamm
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new(typeof(List<ProfilData>));
            string privatUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privatUserList.xml";
            List<ProfilData> privatUserList = new();
            privatUserList = Backup.PrivatUserRepository(privatUserList, serializer, privatUserListPath);
            //for test phase: create each time starting the programm 5 new privatUserDummys and bring them into repository
        }
    }
}