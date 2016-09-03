using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityIot.UI.Core.Services
{
    public class UserManagementService
    {
        public bool Login(string userName, string password)
        {
            // TODO
            return true;

            return String.Equals(userName, "admin", StringComparison.Ordinal) 
                && String.Equals(password, "admin", StringComparison.Ordinal);
        }
    }
}
