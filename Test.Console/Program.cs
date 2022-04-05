using CrmService.CrmHelper;
using D365.CustomApi.Model;
using D365.CustomApi.Serialize;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting ");

            var crmServiceSingleton = CrmServiceSingleton.GetService();
            var crmService = crmServiceSingleton.OrganizationService;

            if (crmService==null)
                System.Console.WriteLine("No Connected to Organization Service!");

            CallCustomApi(crmService);

            System.Console.WriteLine("Ending ");
            System.Console.ReadLine();
        }

        public static void CallCustomApi(IOrganizationService crmService)
        {
            try
            {
                var lead = new Lead();
                lead.FirstName = "Gökhan";
                lead.LastName = "Menteşe";
                lead.Company = "AGC Yazılım";
                lead.Phone = "+905512027000";
                lead.Email = "gokhanm@agcyazilim.com";
                lead.Subject = "Demo Custom API";

                ISerializer serializer = new JsonSerializer();
                var leadJson = serializer.Serialize(lead);

                var req = new OrganizationRequest("new_addlead")
                {
                    ["Lead"] = leadJson
                };

                var resp = crmService.Execute(req);

                var result = (string)resp["Result"];

                System.Console.WriteLine("Custom api response :{0} ", result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
