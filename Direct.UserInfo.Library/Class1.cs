using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Direct.Shared;
using log4net;
using System.DirectoryServices.AccountManagement;

namespace Direct.UserInfo.Library
{
    [DirectSealed]
    [DirectDom("UserInfo")]
    [ParameterType(false)]
    public class UserInfo
    {
        private static readonly ILog logArchitect = LogManager.GetLogger(Loggers.LibraryObjects);

        [DirectDom("Get Property of User")]
        [DirectDomMethod("Get property {firstname/lastname} of currently logged in user")]
        [MethodDescription("Get AD properties of currently logged in user.")]
        public static string GetUserInfo(string property)
        {
            try
            {
                if (logArchitect.IsDebugEnabled)
                {
                    logArchitect.Debug("Direct.UserInfo.Library - Getting property of currently logged in user: " + property);
                }
                UserPrincipal userPrincipal = UserPrincipal.Current;
                switch (property)
                {
                    case "firstname":
                        return userPrincipal.GivenName;
                    case "lastname":
                        return userPrincipal.Surname;
                }
                return "wrong property passed, try firstname or lastname";

            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.UserInfo.Library - UserInfo Exception", e);
                return "";
            }
        }
    }
}
