namespace LittleWebApplication
{
    public class Enums
    {
        public enum AccountType
        {
            privateUser = 1,
            businessUser,
            serviceUser,
            adminUser,
            fundraiser,
            terminal
        }

        public enum Status
        {
            active = 1,
            disabled,
            expired,
            used
        }

        public enum TerminalService
        {
            emptying = 1,
            repair,
            remove,
            installation
        }
    }
}
