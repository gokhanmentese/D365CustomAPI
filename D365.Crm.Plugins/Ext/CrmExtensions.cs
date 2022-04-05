using D365.CustomApi.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365.CustomApi.Ext
{
    public static class CrmExtensions
    {
        public static int ToStatusCodeVal(this string status)
        {
            int returnVal = (int)LeadStatus.New;

            if (string.IsNullOrEmpty(status))
                return (int)LeadStatus.New;

            switch (status)
            {
                case "New Lead to contact":
                    returnVal = (int)LeadStatus.New;
                    break;
                case "Contacted":
                    returnVal = (int)LeadStatus.Contacted;
                    break;
                case "Second Contact":
                    returnVal = (int)LeadStatus.SecondContact;
                    break;
                case "Last Contact":
                    returnVal = (int)LeadStatus.LastContact;
                    break;
                default:
                    break;
            }
            return returnVal;
        }
    }
}
