using System.Xml.Serialization;

namespace LittleWebApplication
{
    public enum UserType
    {
        privatUser,
        businessUser,
        serviceUser,
        adminUser
    }

    public class DateTime
    {
        string donationDate;
        string donationTime;
    }

    public enum Status
    {
        activ,
        disabled,
        expired,
        used
    }

    public enum Service
    {
        emptying,
        repair,
        remove,
        installation
    }


    internal class Program
    {
    }
}