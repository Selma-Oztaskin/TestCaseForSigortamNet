using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceOffer.Test.Case.Service.Common;
using InsuranceOffer.Test.Case.Service.Integration;
using InsuranceOffer.Test.Case.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceOffer.Test.Case.Service.Controllers
{
    [Route("api/TeklifHesaplama")]
    public class TeklifHesaplamaController : Controller
    {
        private readonly InsuranceSettings _settings;
        private readonly IApiIntegratorService _apiIntegratorService;
        IConfiguration _configuration;
        public TeklifHesaplamaController(IOptions<InsuranceSettings> settings, IConfiguration configuration, IApiIntegratorService apiIntegratorService)
        {
            _settings = settings.Value;
            _configuration = configuration;
            _apiIntegratorService = apiIntegratorService;
        }
        [HttpPost("TeklifHesaplamaService")]
        public IActionResult TeklifHesaplamaService([FromBody] TeklifHesaplamaRequest request)
        {
            TeklifHesaplamaResponse response = new TeklifHesaplamaResponse();
            List<TeklifHesaplamaResponse> teklifList = new List<TeklifHesaplamaResponse>();
            if (request != null)
            {
                //********** Comment*******
                //Sigorta firmlarının servisleri olmadığı için servis çağırımlarını yorum satırı haline getirip static değerler döndürdüm.
                //--------------------------------------------------------------------------------------------------------------------------

                //var jsonRequest = JsonConvert.SerializeObject(request);
                //var serviceNames = new List<string>() { "Sigorta_A", "Sigorta_B", "Sigorta_C" };

                //foreach (var item in serviceNames)
                //{
                //    response = _apiIntegratorService.GetServiceResponse<TeklifHesaplamaResponse>(item, jsonRequest);
                //    teklifList.Add(response);
                //}
                
                Random random = new Random();
                var teklifA = new TeklifHesaplamaResponse()
                {
                    FirmaAdi = "Sigorta_A",
                    FirmaLogosu = "SigortaA Logo",
                    Plaka = request.Plaka,
                    TeklifAciklamasi = "34klm45 plakalı araç için B sigortasının teklifidir.",
                    TeklifTutari = random.Next(141421, 314160).ToString()
                };
                var teklifB = new TeklifHesaplamaResponse()
                {
                    FirmaAdi = "Sigorta_C",
                    FirmaLogosu = "SigortaC Logo",
                    Plaka = request.Plaka,
                    TeklifAciklamasi = "34klm45 plakalı araç için B sigortasının teklifidir.",
                    TeklifTutari = random.Next(141421, 314160).ToString()
                };
                var teklifC = new TeklifHesaplamaResponse()
                {
                    FirmaAdi = "Sigorta_A",
                    FirmaLogosu = "SigortaA Logo",
                    Plaka = request.Plaka,
                    TeklifAciklamasi = "34klm45 plakalı araç için A sigortasının teklifidir.",
                    TeklifTutari = random.Next(141421, 314160).ToString()
                };

                teklifList.Add(teklifA);
                teklifList.Add(teklifB);
                teklifList.Add(teklifA);
                var result = JsonConvert.SerializeObject(teklifList);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
