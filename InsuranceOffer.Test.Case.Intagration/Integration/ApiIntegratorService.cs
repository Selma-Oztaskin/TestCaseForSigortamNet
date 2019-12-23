using InsuranceOffer.Test.Case.Service.Common;
using InsuranceOffer.Test.Case.Service.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Test.Case.Service.Integration
{
    public class ApiIntegratorService : IApiIntegratorService
    {
        IConfiguration _configuration;
        private readonly InsuranceSettings _settings;

        public ApiIntegratorService(IConfiguration configuration, IOptions<InsuranceSettings> settings)
        {
            _configuration = configuration;
            _settings = settings.Value;
        }
        public T GetServiceResponse<T>(string serviceName, string jsonRequest) where T : class
        {
            EndPointSettings endPointSettings = GetEndPointSetting(serviceName, _settings);
            HttpClientHandler clientHandler = new HttpClientHandler() { UseProxy = false };
            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(endPointSettings.EndPoint);
            string result = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(endPointSettings.EndPoint);
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var response1 = (HttpWebResponse)request.GetResponse();
                    using (var streamReader = new StreamReader(response1.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                var response = JsonConvert.DeserializeObject<T>(result);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private EndPointSettings GetEndPointSetting(string serviceName, InsuranceSettings settings)
        {
            var endPoint = new EndPointSettings();
            try
            {
                switch (serviceName)
                {
                    case "Sigorta_A":
                        endPoint.Method = settings.SigortaA.Method;
                        endPoint.EndPoint = settings.SigortaA.EndPoint;
                        break;
                    case "Sigorta_B":
                        endPoint.Method = settings.SigortaB.Method;
                        endPoint.EndPoint = settings.SigortaB.EndPoint;
                        break;
                    case "Sigorta_C":
                        endPoint.Method = settings.SigortaC.Method;
                        endPoint.EndPoint = settings.SigortaC.EndPoint;
                        break;
                    default:
                        endPoint.Method = string.Empty;
                        endPoint.EndPoint = string.Empty;
                        break;
                }
                endPoint.ServiceName = serviceName;
                return endPoint;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
