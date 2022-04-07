
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Data
{
    public class Enpoints
    {
        #region Leave
        public static string CreateLeave = $"{ApiBase.BaseUrl}Leave/CreateLeave";
        public static string GetAllLeaveByUserId = $"{ApiBase.BaseUrl}Leave/GetAllLeaveByUserId";
        public static string GetAllTypeOfLeave = $"{ApiBase.BaseUrl}Leave/GetAllTypeOfLeave";
        #endregion

        #region User
        public static string GetAllUsers = $"{ApiBase.BaseUrl}User/GetAllUsers";
        public static string UpdateUser = $"{ApiBase.BaseUrl}User/UpdateUser";
        public static string CreateUser = $"{ApiBase.BaseUrl}User/CreateUser";
        #endregion
    }

    public class ApiBase
    {
        public static string BaseUrl { get; set; }

        static ApiBase()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            BaseUrl = root.GetValue<string>("ApiSettings:BaseUrl");
        }

    }
}
