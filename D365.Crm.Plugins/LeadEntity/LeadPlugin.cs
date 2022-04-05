using D365.CustomApi.Enumarations;
using D365.CustomApi.Ext;
using D365.CustomApi.Model;
using D365.CustomApi.PluginCore;
using D365.CustomApi.Serialize;
using Microsoft.Xrm.Sdk;
using System;

namespace D365.CustomApi.LeadEntity
{
    public class CreateLead : Plugin
    {
        public CreateLead() : base(typeof(CreateLead))
        {
            base.RegisteredEvents.Add(
                new Tuple<int, string, string, Action<LocalPluginContext>>((int)Stages.MainOperation, PluginMessages.AddLead
                , CrmEntityName.Global, new Action<LocalPluginContext>(ExecuteCreateLead)));
        }

        protected void ExecuteCreateLead(LocalPluginContext localContext)
        {
            try
            {
                #region Plugin Tanımlamaları
                ITracingService tracing = localContext.TracingService;
                IPluginExecutionContext context = localContext.PluginExecutionContext;
                IOrganizationService crmService = localContext.OrganizationService;

                #endregion

                #region MainCode

                tracing.Trace("Starting CreateLead...");

                Guid recordId = Guid.Empty;
                string message = string.Empty;

                if (!context.InputParameters.Contains("Lead"))
                    throw new Exception("Lead not found.");
                else
                {
                    if (context.InputParameters["Lead"] == null)
                        throw new Exception("Lead not found.");
                }

                // Entity leadJson = context.InputParameters["Lead"] as Entity;
                string leadJson = context.InputParameters["Lead"] as string;

                tracing.Trace($"Lead value: { (leadJson != null ? leadJson : "is null")}");

                lock ("CreateLead")
                {
                    ISerializer serializer = new JsonSerializer();

                    var lead = serializer.Deserialize<Lead>(leadJson);
                    if (lead != null && !string.IsNullOrEmpty(lead.FirstName))
                    {
                        tracing.Trace($"Lead FullName value: { (lead != null ? lead.FirstName + " " + lead.LastName : "is null")}");

                        var newLead = new Entity("lead");

                        newLead.Id = Guid.NewGuid();
                        newLead.Attributes["statuscode"] = new OptionSetValue(lead.Status.ToStatusCodeVal());
                        newLead.Attributes["firstname"] = lead.FirstName;
                        newLead.Attributes["lastname"] = lead.LastName;
                        newLead.Attributes["emailaddress1"] = lead.Email;
                        newLead.Attributes["companyname"] = lead.Company;
                        newLead.Attributes["telephone1"] = lead.Phone;
                        newLead.Attributes["address1_line1"] = lead.Street;
                        newLead.Attributes["address1_city"] = lead.City;
                        newLead.Attributes["address1_stateorprovince"] = lead.State;
                        newLead.Attributes["address1_postalcode"] = lead.PostalCode;
                        newLead.Attributes["subject"] = lead.Subject;

                        recordId = crmService.Create(newLead);

                        message = "Lead is successfully created!";
                    }
                }

                context.OutputParameters["RecordId"] = recordId;
                context.OutputParameters["Result"] = message;

                tracing.Trace("Ending CreateLead...");

                #endregion
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.InnerException != null && ex.InnerException.Message != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
