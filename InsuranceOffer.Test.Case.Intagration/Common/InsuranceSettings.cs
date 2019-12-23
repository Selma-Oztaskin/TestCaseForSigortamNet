using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceOffer.Test.Case.Service.Common
{
    public class InsuranceSettings
    {
        public Sigorta_A SigortaA { get; set; }
        public Sigorta_B SigortaB { get; set; }
        public Sigorta_C SigortaC { get; set; }
    }

    public class Sigorta_A
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ServiceName { get; set; }
    }

    public class Sigorta_B
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ServiceName { get; set; }
    }

    public class Sigorta_C
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ServiceName { get; set; }
    }
    //public class EndPointSettings
    //{
    //    public string EndPoint { get; set; }
    //    public string Method { get; set; }
    //    public string ServiceName { get; set; }
    //}
}
