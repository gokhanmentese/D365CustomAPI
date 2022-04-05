using CrmService.AppSetting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace CrmService.CrmHelper
{
    public class CrmServiceSingleton : IDisposable
    {
        private static CrmServiceSingleton _serviceInstance;
        private IOrganizationService _organizationService;
        private Guid _controlID;
        private static object _lockObject = new object();

        public IOrganizationService OrganizationService
        {
            get { return _organizationService; }
        }

        public Guid ControlID
        {
            get { return _controlID; }
        }

        private CrmServiceSingleton(Guid controlID)
        {
            _organizationService = GetCrmServiceAppUser();
            _controlID = controlID;
        }

        public static CrmServiceSingleton GetService()
        {
            try
            {
                if (_serviceInstance == null)
                {
                    lock (_lockObject)
                    {
                        if (_serviceInstance == null)
                            _serviceInstance = new CrmServiceSingleton(Guid.NewGuid());
                    }
                }

                return _serviceInstance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IOrganizationService GetCrmServiceAppUser()
        {
            try
            {
                var organizationUri = appKeys.GetOrganizationUri;
                var clientId = appKeys.GetClientId;
                var clientSecret = appKeys.GetClientSecret;

                var _CrmConnectionString = $@"AuthType=ClientSecret;url={organizationUri};ClientId={clientId};ClientSecret={clientSecret}";
                CrmServiceClient crmConn = new CrmServiceClient(_CrmConnectionString);
                // var svcContext = new XrmSvc(crmConn);

                var organizationService = crmConn.OrganizationWebProxyClient != null
                    ? crmConn.OrganizationWebProxyClient : (IOrganizationService)crmConn.OrganizationServiceProxy;

                return organizationService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _organizationService = null;
            _serviceInstance = null;
        }
    }
}
