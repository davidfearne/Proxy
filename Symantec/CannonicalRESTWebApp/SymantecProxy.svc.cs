using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using CannonicalRESTWebApp.SymantecAPI;
using System.Text;

namespace CannonicalRESTWebApp
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    public class SymantecRestProxy
    {
        static IResourceRepository<int, Resource> resourceRepository = ResourceRepository.Create();
        const int MaxResourcesPerRequest = 10;


        [Description("Return Echo Test")]
        [WebGet(UriTemplate = "/Echo?Echo={request}")]
        public string Echo(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                return "500";
            else
            {

                ProvisioningApiClient client = new ProvisioningApiClient();
                client.ClientCredentials.UserName.UserName = "ArrowAPI";
                client.ClientCredentials.UserName.Password = "Root@123";
                EchoResponse echoResponse = null;
                try
                {
                    client.Open();
                    echoResponse = client.Echo(new EchoRequest() { Request = request });
                    client.Close();
                }
                catch (Exception)
                {
                    client.Abort();
                    return string.Format("501");
                }
                if (echoResponse != null)
                {

                    return string.Format
                        (

                        echoResponse.Response

                        );
                }
                else
                {
                    return string.Format("500");

                }

               
            }
            
        }

        [Description("Provision Reseller Call")]
        [WebGet(UriTemplate = "/ProvisionReseller?OrganisationName={OrgName}&PartnersCustomerId={PartCustomerId}&CustomerExternalReference={CustExternalReference}&IsoCountryCode={CountryCode}&ContactFirstName={ConFirstName}&ContactLastName={ConLastName}&ContactEmailAddress={ConEmailAddress}&Address={Addres}&Address2={Addres2}&Address3={Addres3}&Town={Ton}&State={Stat}&Zip={Zi}&Country={Cuntry}&InitialNumberOfUser={InitialNumber}&BasedOnCustomerTemplateId={BasedOnCustomerTemplate}&IsReseller={IsReselle}")]

        public string ProvisionReseller
            (
                string OrgName,
                int PartCustomerId,
                string CustExternalReference,
                string CountryCode,
                string ConFirstName,
                string ConLastName,
                string ConEmailAddress,
                string Addres,
                string Addres2,
                string Addres3,
                string Ton,
                string Stat,
                string Zi,
                string Cuntry,
                int InitialNumber,
                int BasedOnCustomerTemplate,
                bool IsReselle
            )
        {
            if (string.IsNullOrWhiteSpace(ConFirstName + ConLastName))
                return "500";
            else
            {

                ProvisioningApiClient client = new ProvisioningApiClient();
                client.ClientCredentials.UserName.UserName = "ArrowAPI";
                client.ClientCredentials.UserName.Password = "Root@123";
                ProvisionOrganisationResponse provisionOrgResponse = null;


                try
                {
                    client.Open();
                    provisionOrgResponse = client.ProvisionOrganisation(new ProvisionOrganisationRequest()

                    {
                        OrganisationName = OrgName,
                        PartnersCustomerId = PartCustomerId,
                        CustomerExternalReference = CustExternalReference,
                        IsoCountryCode = CountryCode,
                        ContactFirstName = ConFirstName,
                        ContactLastName = ConLastName,
                        ContactEmailAddress = ConEmailAddress,
                        Address = Addres,
                        Address2 = Addres2,
                        Address3 = Addres3,
                        Town = Ton,
                        State = Stat,
                        Zip = Zi,
                        Country = Cuntry,
                        InitialNumberOfUser = InitialNumber,
                        BasedOnCustomerTemplateId = BasedOnCustomerTemplate,
                        IsReseller = IsReselle
                    });

                    client.Close();
                }
                catch (FaultException<ProvisioningApiFault> ex)
                {
                    if (ex.Detail.ErrorCode != "PA1000")
                    {
                        client.Abort();
                        return string.Format("{0}: {1}: {2}:",
                             ex.Detail.ErrorMessage,
                             ex.Detail.ErrorCode,
                             ex.Detail.EventId
                             );
                    }
                    else
                    {
                        if (provisionOrgResponse != null)
                        {

                            client.Close();
                            return string.Format("{0}: {1}: {2}:",
                                 provisionOrgResponse.AccountNumber,
                                 provisionOrgResponse.Password,
                                 provisionOrgResponse.CustomerId
                                 );
                        }

                        else
                        {

                            return string.Format("500");

                        }

                    }

                }

                return "503";
            }
        }  

      [Description("Provision End User Call")]
        [WebGet(UriTemplate = "/ProvisionEnduser?OrganisationName={OrgName}&PartnersCustomerId={PartCustomerId}&CustomerExternalReference={CustExternalReference}&IsoCountryCode={CountryCode}&ContactFirstName={ConFirstName}&ContactLastName={ConLastName}&ContactEmailAddress={ConEmailAddress}&Address={Addres}&Address2={Addres2}&Address3={Addres3}&Town={Ton}&State={Stat}&Zip={Zi}&Country={Cuntry}&InitialNumberOfUser={InitialNumber}&BasedOnCustomerTemplateId={BasedOnCustomerTemplate}&IsReseller={IsReselle}")]

        public string ProvisionEnduser
            (
                string OrgName,
                int PartCustomerId,
                string CustExternalReference,
                string CountryCode,
                string ConFirstName,
                string ConLastName,
                string ConEmailAddress,
                string Addres,
                string Addres2,
                string Addres3,
                string Ton,
                string Stat,
                string Zi,
                string Cuntry,
                int InitialNumber,
                int BasedOnCustomerTemplate,
                bool IsReselle
            )
        {
            if (string.IsNullOrWhiteSpace(ConFirstName + ConLastName))
                return "500";
            else
            {

                ProvisioningApiClient client = new ProvisioningApiClient();
                client.ClientCredentials.UserName.UserName = "ArrowAPI";
                client.ClientCredentials.UserName.Password = "Root@123";
                ProvisionOrganisationResponse provisionOrgResponse = null;


                try
                {
                    client.Open();
                    provisionOrgResponse = client.ProvisionOrganisation(new ProvisionOrganisationRequest()

                    {
                        OrganisationName = OrgName,
                        PartnersCustomerId = PartCustomerId,
                        CustomerExternalReference = CustExternalReference,
                        IsoCountryCode = CountryCode,
                        ContactFirstName = ConFirstName,
                        ContactLastName = ConLastName,
                        ContactEmailAddress = ConEmailAddress,
                        Address = Addres,
                        Address2 = Addres2,
                        Address3 = Addres3,
                        Town = Ton,
                        State = Stat,
                        Zip = Zi,
                        Country = Cuntry,
                        InitialNumberOfUser = InitialNumber,
                        BasedOnCustomerTemplateId = BasedOnCustomerTemplate,
                        IsReseller = IsReselle
                    });

                    client.Close();
                }
                catch (FaultException<ProvisioningApiFault> ex)
                {
                    if (ex.Detail.ErrorCode != "PA1000")
                    {
                        client.Abort();
                        return string.Format("{0}: {1}: {2}:",
                             ex.Detail.ErrorMessage,
                             ex.Detail.ErrorCode,
                             ex.Detail.EventId
                             );
                    }
                    else
                    {
                        if (provisionOrgResponse != null)
                        {

                            client.Close();
                            return string.Format("{0}: {1}: {2}:",
                                 provisionOrgResponse.AccountNumber,
                                 provisionOrgResponse.Password,
                                 provisionOrgResponse.CustomerId
                                 );
                        }

                        else
                        {

                            return string.Format("500");

                        }

                    }

                }

                return "503";
            }
        }

     /* [Description("Provision Service Call")]
      [WebGet(UriTemplate = "/ProvisionService?Service={Serv}&PartnersCustomerId={PartCustomerId}&TotalEndPointCount={EndPointCount}&IsTrial={Trail}&HasOtherServices={OtherServices}&ContactEmailAddress={ConEmailAddress}")]

      public string ProvisionService
          (
              int PartCustomerId,
              int EndPointCount,
              bool Trail,
              bool OtherServices,
              string ConEmailAddress,
              SimpleServiceType Serv
              
          )
      {
          if (string.IsNullOrWhiteSpace(ConEmailAddress))
              return "500";
          else
          {
              
              ProvisioningApiClient client = new ProvisioningApiClient();
              client.ClientCredentials.UserName.UserName = "ArrowAPI";
              client.ClientCredentials.UserName.Password = "Root@123";
              ProvisionEntitlementRequest request = new ProvisionEntitlementRequest();
             

              try 
              {
                  client.Open();
                 request = client(new ProvisionEntitlementRequest()

                  {
                      CustomerId = PartCustomerId,
                      Capacity = EndPointCount
                      //request.IsTrial = Trail;
                      //request.UseELS = OtherServices;
                      //request.EmailAddress = ConEmailAddress;
                      //request.Service = Serv;
                  )};

                  client.Close();
              }
              catch (FaultException<ProvisioningApiFault> ex)
              {
                  if (ex.Detail.ErrorCode != "PA1000")
                  {
                      client.Abort();
                      return string.Format("{0}: {1}: {2}:",
                           ex.Detail.ErrorMessage,
                           ex.Detail.ErrorCode,
                           ex.Detail.EventId
                           );
                  }
                  else
                  {
                      

                          client.Close();
                          return string.Format("200");
                               
                      }

                   

                  }

              }

              return "503";
          }*/
      }
    }




