using InsuranceOffer.Test.Case.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InsuranceOffer.Test.Case.DataLayer.Repository
{
    public interface IDataRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        CustomerInfo GetByTckn(string tckn);
        List<CustomerInsuranceOffers> GetOffersByCustomerID(int id);
        T Create(T entity);
        int Delete(int id);
        int Update(T entity);
        T GetAsQueryable(Expression<Func<T, bool>> predicate = null);
    }
}
