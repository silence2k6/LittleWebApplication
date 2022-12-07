using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Progamm
    {
        

        public XmlSerializer serializerForUserNumberCounter = new XmlSerializer(typeof(List<int>));
        public string pathForUserNumberCounter = @"C:\Users\user\source\repos\LittleWebApplication\Backup\userNumberCounter.xml";

        public class DateTime
        {
            string donationDate;
            string donationTime;
        }
    }
}