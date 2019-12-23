using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InsuranceOffer.Test.Case.DataLayer.Model;
using InsuranceOffer.Test.Case.DataLayer.Repository;
using InsuranceOffer.Test.Case.UI.Business;
using InsuranceOffer.Test.Case.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InsuranceOffer.Test.Case.UI.Controllers
{
    public class TeklifAlController : Controller
    {
        private readonly IDataRepository<CustomerInfo> _customerInfoRepository;
        private readonly IDataRepository<CustomerInsuranceOffers> _customerInsuranceOffersDataRepo;
        IConfiguration _configuration;
        public TeklifAlController(IDataRepository<CustomerInfo> customerInfoRepository, IConfiguration configuration, IDataRepository<CustomerInsuranceOffers> customerInsuranceOffersDataRepo)
        {
            _customerInfoRepository = customerInfoRepository;
            _configuration = configuration;
            _customerInsuranceOffersDataRepo = customerInsuranceOffersDataRepo;
        }
        public IActionResult Index()
        {
            CustomerInfo model = new CustomerInfo();
            return View(model);
        }
        public IActionResult AllOffers(CustomerInfo model)
        {
            var jsonRequest = JsonConvert.SerializeObject(model);
            TeklifHesapla teklifHesapla = new TeklifHesapla(_configuration);
            if (model.ID == 0)
            {
                var result = _customerInfoRepository.Create(model);
                var response = teklifHesapla.TeklifGetir(jsonRequest);
                var customerInsuranceOffers = JsonConvert.DeserializeObject<List<CustomerInsuranceOffers>>(response);
                foreach (var item in customerInsuranceOffers)
                {
                    item.CustomerID = result.ID;
                    _customerInsuranceOffersDataRepo.Create(item);
                };

                return View(customerInsuranceOffers);
            }
            else
            {
                var customer = _customerInfoRepository.GetByTckn(model.TCKN);
                var custInsuranceOffer = _customerInsuranceOffersDataRepo.GetOffersByCustomerID(customer.ID);

                return View(custInsuranceOffer);
            }
        }
        [HttpGet]
        public ActionResult GetCustomerInfo(string tckn, string plaka)
        {
            var result = _customerInfoRepository.GetAll().Where(x => x.TCKN == tckn && x.Plaka == plaka).FirstOrDefault();
            //var result = _dataRepository.GetAsQueryable(x => x.TCKN == tckn && x.Plaka == plaka);
            return Json(result);
            // Do some work and return View()
        }

        public ActionResult GetAllOffersByTckn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAllOffersByTcknForCustomer(string tckn)
        {
            var customer = _customerInfoRepository.GetByTckn(tckn);
            if (customer!=null)
            {

                var custInsuranceOffer = _customerInsuranceOffersDataRepo.GetOffersByCustomerID(customer.ID);
                return View("AllOffers", custInsuranceOffer);
            }
            return View("CustomerNotFound");
        }
    }
}