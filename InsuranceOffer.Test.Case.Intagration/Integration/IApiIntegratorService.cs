using InsuranceOffer.Test.Case.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceOffer.Test.Case.Service.Integration
{
    public interface IApiIntegratorService
    {
        T GetServiceResponse<T>(string serviceName, string jsonRequest) where T : class;
    }
}
