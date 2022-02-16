using AutoMapper;
using LibApp_Gr3.Data;
using LibApp_Gr3.Interfaces;
using LibApp_Gr3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp_Gr3.Services
{
    public class CustomerService : IBaseContext<Customer>
    {
        protected ApplicationDbContext Context { get; }
        protected IMapper Mapper { get; }
        public CustomerService(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public Customer GetItem(int id)
        {
            var _entity = Context.Customers.SingleOrDefault(p => p.Id == id);

            return _entity;
        }

        public IEnumerable<Customer> GetList()
        {
            return Context.Customers.Include(p => p.MembershipType).ToList();
        }

        public void Insert(Customer item)
        {
            Context.Customers.Add(item);

            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var _entity = Context.Customers.SingleOrDefault(p => p.Id == id);

            if (_entity == null)
                throw new KeyNotFoundException();

            Context.Customers.Remove(_entity);
            Context.SaveChanges();
        }

        public void Update(int id, Customer item)
        {
            var _entity = Context.Customers.AsNoTracking().SingleOrDefault(p => p.Id == id);

            if (_entity == null)
                throw new KeyNotFoundException();

            _entity = Mapper.Map(item, _entity);

            Context.Customers.Update(_entity);
            Context.SaveChanges();
        }
    }
}
