using AutoMapper;
using LibApp_Gr3.Data;
using LibApp_Gr3.Interfaces;
using LibApp_Gr3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp_Gr3.Services
{
    public class MembershipTypeService : IBaseContext<MembershipType>
    {
        protected ApplicationDbContext Context { get; }
        protected IMapper Mapper { get; }
        public MembershipTypeService(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public MembershipType GetItem(int id)
        {
            var _entity = Context.MembershipTypes.SingleOrDefault(p => p.Id == id);

            return _entity;
        }

        public IEnumerable<MembershipType> GetList()
        {
            return Context.MembershipTypes.ToList();
        }

        public void Insert(MembershipType item)
        {
            Context.MembershipTypes.Add(item);

            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var _entity = Context.MembershipTypes.SingleOrDefault(p => p.Id == id);

            if (_entity == null)
                throw new KeyNotFoundException();

            Context.MembershipTypes.Remove(_entity);
            Context.SaveChanges();
        }

        public void Update(int id, MembershipType item)
        {
            var _entity = Context.MembershipTypes.AsNoTracking().SingleOrDefault(p => p.Id == id);

            if (_entity == null)
                throw new KeyNotFoundException();

            _entity = Mapper.Map(item, _entity);

            Context.MembershipTypes.Update(_entity);
            Context.SaveChanges();
        }
    }
}
