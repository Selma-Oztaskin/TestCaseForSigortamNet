using InsuranceOffer.Test.Case.DataLayer.Model;
using InsuranceOffer.Test.Case.UI.Common;
using Microsoft.Extensions.Configuration;
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

namespace InsuranceOffer.Test.Case.UI.Business
{
    public class TeklifHesapla
    {
        IConfiguration _configuration;
        public TeklifHesapla(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CustomerInsuranceOffers> TeklifGetir1(string jsonRequest)
        {
            var projeAyarlari = _configuration.GetSection("ApiEndpoint").Get<ApiEndpoint>();
            HttpClientHandler clientHandler = new HttpClientHandler() { UseProxy = false };
            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(projeAyarlari.Endpoint);
            string uri = string.Format("{0}", client.BaseAddress);
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = new HttpMethod(projeAyarlari.Method)
            };

            if (!string.IsNullOrEmpty(jsonRequest))
            {
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestMessage.Content = content;
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            Task<HttpResponseMessage> httpResponse = client.SendAsync(requestMessage);
            var jsonApiResponse = httpResponse.Result.Content.ReadAsStringAsync().Result;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var response = JsonConvert.DeserializeObject<List<CustomerInsuranceOffers>>(jsonApiResponse, settings);
            return response;
        }

        public string TeklifGetir(string json)
        {
            var projeAyarlari = _configuration.GetSection("ApiEndpoint").Get<ApiEndpoint>();
            HttpClientHandler clientHandler = new HttpClientHandler() { UseProxy = false };
            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(projeAyarlari.Endpoint);
            string result = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(projeAyarlari.Endpoint);
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var response = (HttpWebResponse)request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
