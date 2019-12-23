using InsuranceOffer.Test.Case.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InsuranceOffer.Test.Case.DataLayer.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly InsuranceDBContext _insuranceDBContext;

        public DataRepository(InsuranceDBContext insuranceDBContext)
        {
            _insuranceDBContext = insuranceDBContext;
        }
        public T Create(T entity)
        {
            try
            {
                _insuranceDBContext.Set<T>().Add(entity);
                _insuranceDBContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int id)
        {
            var item = GetById(id);
            _insuranceDBContext.Set<T>().Remove(item);
            return _insuranceDBContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _insuranceDBContext.Set<T>().ToList();
        }

        public T GetAsQueryable(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _insuranceDBContext.Set<T>().FirstOrDefault();
            else
                return _insuranceDBContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _insuranceDBContext.Set<T>().Find(id);
        }

        public CustomerInfo GetByTckn(string tckn)
        {
            return _insuranceDBContext.Set<CustomerInfo>().Where(x => x.TCKN == tckn).FirstOrDefault();
        }

        public List<CustomerInsuranceOffers> GetOffersByCustomerID(int id)
        {
            return _insuranceDBContext.Set<CustomerInsuranceOffers>().Where(x => x.CustomerID == id).ToList();
        }

        public int Update(T entity)
        {
            _insuranceDBContext.Set<T>().Update(entity);
            return _insuranceDBContext.SaveChanges();
        }
    }
}
