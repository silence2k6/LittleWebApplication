namespace LittleWebApplication
{
    public class Enums
    {
        public enum AccountType
        {
            UNDEFINED,
            privateUser,
            businessUser,
            serviceUser,
            adminUser,
            fundraiser,
            terminal
        }

        public enum Status
        {
            UNDEFINED,
            active,
            disabled,
            expired,
            used,
            incomplete
        }

        public enum TerminalService
        {
            UNDEFINED,
            emptying,
            repair,
            remove,
            installation
        }
    }
}
