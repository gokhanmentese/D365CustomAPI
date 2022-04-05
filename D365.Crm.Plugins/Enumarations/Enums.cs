using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365.CustomApi.Enumarations
{
    class Enums
    {
    }

    internal enum Stages
    {
        PreValidation = 10,
        PreOpertion = 20,
        MainOperation = 30,
        PostOperation = 40
        // PostOpertionDeprecated = 50 only MS CRM 4.0
    }

    internal enum LeadStatus
    {
        New = 1,
        Contacted = 2,
        SecondContact = 974230003,
        LastContact = 974230004
    }

}
