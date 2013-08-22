/*This is the Colt REST to REST proxy server
 * We are not using native CastIron becuase there was an issue uploading the certs
 * All Logic remains inside CastIron Orchestration ColtSyncSpecific 
 * This has been written and is maintained by David Fearne.
 * David.fearne@arrowecs.co.uk
 * This is the property of Arrow ECS*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;

namespace CannonicalRESTWebApp
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    public class CannonicalRESTService
    {

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        [Description("Provision Reseller Call")]
        [WebGet(UriTemplate = "/ProvisionReseller?vendorAccountID={VAI}&provisioningItemsCounter={PIC}&planID={PID}&planPeriodID={PPID}&currencyID={CID}&contactDataCounter={CDC}&loginID={LID}&passwordID={PWDID}&companyNameID={CNID}&firstNameID={FNID}&lastNameID={LNID}&addressID={ADID}&cityID={CI}&zipID={ZID}&countryID={CUNID}&emailID={EID}&phoneCountryID={PCID}&phoneAreaID={PAID}&phoneNumberID={PNID}")]
        //Intialise variables from URI query string
        public Stream ProvisionReseller
            (

                string VAI,
                string PIC,
                string PID,
                string PPID,
                string CID,
                string CDC,
                string LID,
                string PWDID,
                string CNID,
                string FNID,
                string LNID,
                string ADID,
                string CI,
                string ZID,
                string CUNID,
                string EID,
                string PCID,
                string PAID,
                string PNID



            )

                   

        {   
                


                    //Initailise Variables select for URL and Creds

                    var url = "";

                    if (CUNID == "UK")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
                    }
                    if (CUNID == "FR")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
                    }
                    if (CUNID == "DE")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
                    }
                    if (CUNID == "ES")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
                    }

                    string un = "CloudStorage_user";
                    string pw = "Cl0udSt0rag3";

                    //Intailise Web Client
                    WebClient wc = new WebClient();
                    //Base64 Encode Credentails for Auth and add to header
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(un + ":" + pw));
                    wc.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;


                    //Map Name Value Pairs for Query String
                    wc.QueryString.Add("vendorAccountID", VAI);
                    wc.QueryString.Add("provisioningItemsCounter", PIC);
                    wc.QueryString.Add("planID", PID);
                    wc.QueryString.Add("planPeriodID", PPID);
                    wc.QueryString.Add("currencyID", CID);
                    wc.QueryString.Add("contactDataCounter", CDC);
                    wc.QueryString.Add("loginID", LID);
                    wc.QueryString.Add("passwordID", PWDID);
                    wc.QueryString.Add("companyNameID", CNID);
                    wc.QueryString.Add("firstNameID", FNID);
                    wc.QueryString.Add("lastNameID", LNID);
                    wc.QueryString.Add("addressID", ADID);
                    wc.QueryString.Add("city", CI);
                    wc.QueryString.Add("zipID", ZID);
                    wc.QueryString.Add("countryID", CUNID);
                    wc.QueryString.Add("emailID", EID);
                    wc.QueryString.Add("phoneCountryID", PCID);
                    wc.QueryString.Add("phoneAreaID", PAID);
                    wc.QueryString.Add("phoneNumberID", PNID);


                        //Deal with Colt Certs
                        ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                        //Send Request
                        var stream = wc.OpenRead(url);

                        //Send Response                
                        var reader = new StreamReader(stream);
                        var response = reader.ReadToEnd().Trim();
                        WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
                        MemoryStream result = new MemoryStream(Encoding.UTF8.GetBytes(response));
                  
                        //Clean up the stream and HTTP connection
                        stream.Close();
                        reader.Close();
     


                        return result;
                    
        }


    
        [Description("Provision End User Call")]
        [WebGet(UriTemplate = "/ProvisionEnduser?vendorAccountID={VAI}&provisioningItemsCounter={PIC}&planID={PID}&planPeriodID={PPID}&currencyID={CID}&contactDataCounter={CDC}&loginID={LID}&passwordID={PWDID}&companyNameID={CNID}&firstNameID={FNID}&lastNameID={LNID}&addressID={ADID}&cityID={CI}&zipID={ZID}&countryID={CUNID}&emailID={EID}&phoneCountryID={PCID}&phoneAreaID={PAID}&phoneNumberID={PNID}")]
        //Intialise variables from URI query string
        public Stream ProvisionEnduser
            (

                string VAI,
                string PIC,
                string PID,
                string PPID,
                string CID,
                string CDC,
                string LID,
                string PWDID,
                string CNID,
                string FNID,
                string LNID,
                string ADID,
                string CI,
                string ZID,
                string CUNID,
                string EID,
                string PCID,
                string PAID,
                string PNID



            )
        
            
                {

                    //Initailise Variables for URL and Creds

                    var url = "";

                    if (CUNID == "UK")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/reseller/endCustomer/create";
                    }
                    if (CUNID == "FR")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/reseller/endCustomer/create";
                    }
                    if (CUNID == "DE")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/reseller/endCustomer/create";
                    }
                    if (CUNID == "ES")
                    {
                        url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/reseller/endCustomer/create";
                    }


                    string un = "CloudStorage_user";
                    string pw = "Cl0udSt0rag3";

                    //Intailise Web Client
                    WebClient wc = new WebClient();
                    //Base64 Encode Credentails for Auth and add to header
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(un + ":" + pw));
                    wc.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;

                    //Map Name Value Pairs for Query String
                    wc.QueryString.Add("vendorAccountID", VAI);
                    wc.QueryString.Add("provisioningItemsCounter", PIC);
                    wc.QueryString.Add("planID", PID);
                    wc.QueryString.Add("planPeriodID", PPID);
                    wc.QueryString.Add("currencyID", CID);
                    wc.QueryString.Add("contactDataCounter", CDC);
                    wc.QueryString.Add("loginID", LID);
                    wc.QueryString.Add("passwordID", PWDID);
                    wc.QueryString.Add("companyNameID", CNID);
                    wc.QueryString.Add("firstNameID", FNID);
                    wc.QueryString.Add("lastNameID", LNID);
                    wc.QueryString.Add("addressID", ADID);
                    wc.QueryString.Add("city", CI);
                    wc.QueryString.Add("zipID", ZID);
                    wc.QueryString.Add("countryID", CUNID);
                    wc.QueryString.Add("emailID", EID);
                    wc.QueryString.Add("phoneCountryID", PCID);
                    wc.QueryString.Add("phoneAreaID", PAID);
                    wc.QueryString.Add("phoneNumberID", PNID);






                    //Deal with Colt Certs
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                    //Send Request
                    var stream = wc.OpenRead(url);

                    //Send Response                
                    var reader = new StreamReader(stream);
                    var response = reader.ReadToEnd().Trim();
                    WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
                    MemoryStream result = new MemoryStream(Encoding.UTF8.GetBytes(response));

                    //Clean up the stream and HTTP connection
                    stream.Close();
                    reader.Close();



                    return result;
                   
            }




        [Description("Provision Additional Resources")]
        [WebGet(UriTemplate = "/ProvisionAdditional?vendorAccountID={VAI}&customerAccountID={CAI}&loginID={LID}&planID={PID}&planPeriodID={PPID}&countryID={CUNID}")]

        //Intialise variables from URI query string
        public Stream ProvisionAdditional
            (
                string VAI,
                string CAI,
                string LID,
                string PID,
                string PPID,
                string CUNID
            )
        {

            //Initailise Variables for URL and Creds

            var url = "";

            if (CUNID == "UK")
            {
                url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
            }
            if (CUNID == "FR")
            {
                url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
            }
            if (CUNID == "DE")
            {
                url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
            }
            if (CUNID == "ES")
            {
                url = "https://wbmdmzws21.colt.net/rest/ColtCloudStorage/common/restSvc/distributor/reseller/create";
            }


            string un = "CloudStorage_user";
            string pw = "Cl0udSt0rag3";

            //Intailise Web Client
            WebClient wc = new WebClient();
            //Base64 Encode Credentails for Auth and add to header
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(un + ":" + pw));
            wc.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;

            //Map Name Value Pairs for Query String
            wc.QueryString.Add("vendorAccountID", VAI);
            wc.QueryString.Add("customerAccountID", CAI);
            wc.QueryString.Add("loginID", LID);
            wc.QueryString.Add("planID", PID);
            wc.QueryString.Add("planPeriodID", PPID);


            //Deal with Colt Certs
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            //Send Request
            var stream = wc.OpenRead(url);

            //Send Response                
            var reader = new StreamReader(stream);
            var response = reader.ReadToEnd().Trim();
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            MemoryStream result = new MemoryStream(Encoding.UTF8.GetBytes(response));

            //Clean up the stream and HTTP connection
            stream.Close();
            reader.Close();



            return result;

        }       
    }

}

