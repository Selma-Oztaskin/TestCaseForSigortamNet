using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceOffer.Test.Case.Service.Model
{
    public class TeklifHesaplamaRequest
    {
        [JsonProperty("plaka")]
        public string Plaka { get; set; }

        [JsonProperty("TCKN")]
        public string TCKN { get; set; }

        [JsonProperty("ruhsatSeriKod")]
        public string RuhsatSeriKod { get; set; }

        [JsonProperty("ruhsatSeriNo")]
        public string RuhsatSeriNo { get; set; }
    }
}
