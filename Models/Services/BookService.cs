using AutoMapper;
using LibApp_Gr3.Data;
using LibApp_Gr3.Interfaces;
using LibApp_Gr3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp_Gr3.Services
{
    public class BookService : IBaseContext<Book>
    {
        protected ApplicationDbContext Context { get; }
        protected IMapper Mapper { get; }
        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public Book GetItem(int id)
        {
            var _entity = Context.Books.SingleOrDefault(p => p.Id == id);

            return _entity;
        }

        public IEnumerable<Book> GetList()
        {
            return Context.Books.ToList();
        }

        public void Insert(Book item)
        {
            Context.Books.Add(item);

            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var _entity = Context.Books.SingleOrDefault(p => p.Id == id);

            if(_entity == null)
                throw new KeyNotFoundException();

            Context.Books.Remove(_entity);
            Context.SaveChanges();
        }

        public void Update(int id, Book item)
        {
            var _entity = Context.Books.AsNoTracking().SingleOrDefault(p => p.Id == id);

            if (_entity == null)
                throw new KeyNotFoundException();

            _entity = Mapper.Map(item, _entity);

            Context.Books.Update(_entity);
            Context.SaveChanges();
        }
    }
}
