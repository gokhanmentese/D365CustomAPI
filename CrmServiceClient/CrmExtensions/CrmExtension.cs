using CrmService.AppSetting;
using CrmService.CrmEnumarations;
using System;

namespace CrmService.CrmExtensions
{
    public static class CrmExtension
    {
        public static string ToCrmOrgUri(this Organizations s)
        {
            if (s == Organizations.LiveCRM)
                return appKeys.GetOrganizationUri;
            else if (s == Organizations.TestCRM)
                return appKeys.GetOrganizationUri;
            else
                return appKeys.GetOrganizationUri;
        }
    }
}
