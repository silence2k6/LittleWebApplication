using System.Xml.Serialization;
using static LittleWebApplication.ProfilData;
using static LittleWebApplication.PrivatUserDummy;
using System.Security.Cryptography.X509Certificates;

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

            PrivatUserDummy newPrivatUser = CreateNewPrivatUserDummy();            
        }
    }
}