using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public enum MainMenueSection
        //{
        //    adminAdministration = 1,
        //    finances,
        //    terminals,
        //    donations,
        //    rewards,
        //    littleLocations,
        //    notifications,
        //    settings,
        //    contact
        //}

        //public enum SubMenueSection
        //{
        //    privatUserAdministration = 1,
        //    businessUserAdministraion,
        //    serviceUserAdministraion,
        //    adminUserAdministraion,
        //    fundraiserAdministration,
        //    terminalAdministration,
        //    rewardAdministration,
        //    notificationAdministration,
        //    terminalOverview,
        //    donationOverview,
        //    terminalEmptyingOverview,
        //    fundraiserPaymentOverview,
        //    rewardOverview,
        //    achievementOverview,
        //    couponOverview,
        //    notificationOverview,
        //    userSettings,
        //    safetySettings,
        //}
    }
}
