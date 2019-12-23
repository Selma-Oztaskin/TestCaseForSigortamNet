using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceOffer.Test.Case.DataLayer.Model
{
    public class CustomerInsuranceOffers
    {
        public int ID { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaLogosu { get; set; }
        public string TeklifAciklamasi { get; set; }
        public string TeklifTutari { get; set; }
        public string Plaka { get; set; }
        public int CustomerID { get; set; }
    }
}
