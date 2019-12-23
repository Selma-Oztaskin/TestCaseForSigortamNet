using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsuranceOffer.Test.Case.DataLayer.Model
{
    public class CustomerInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(11)]
        public string TCKN { get; set; }

        [Required]
        public string Plaka { get; set; }

        [Required]
        public string RuhsatSeriKodu { get; set; }

        [Required]
        public string RuhsatSeriNo { get; set; }
    }
}
