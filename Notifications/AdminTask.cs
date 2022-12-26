using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.Notifications
{
    public class AdminTask
    {
        string taskNumber;
        private DateTime taskDateTime = new DateTime();
        private DateTime taskDateTimeDeadline = new DateTime();
        string taskTitel;
        string taskAdminText;
        string taskServiceUserText;
        string taskStatus;
    }
}
