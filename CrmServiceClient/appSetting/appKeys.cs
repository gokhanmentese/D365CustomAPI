using System.Configuration;

namespace CrmService.AppSetting
{
    public static class appKeys
    {
        #region settingFactory
   
        public static string GetClientId
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientId"];
            }
        }

        public static string GetClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientSecret"];
            }
        }

        public static string GetOrganizationUri
        {
            get
            {
                return ConfigurationManager.AppSettings["OrganizationUri"];
            }
        }

        #endregion
    }
}
