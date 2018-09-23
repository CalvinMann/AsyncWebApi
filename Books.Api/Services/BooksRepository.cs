using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Api.Contexts;
using Books.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Services
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        //ALWAYS BE SURE TO DISPOSE 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            await _context.Database.ExecuteSqlCommandAsync("WAITFOR DELAY '00:00:02';");

            return await _context.Books.Include(b => b.Author).
                FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            //Adding the include, includes the object references
            //Without the include we'd only have the AuthorId  
            return await _context.Books.Include(b => b.Author).ToListAsync(); //Extension method 
        }

        public Book GetBook(Guid id)
        {
             _context.Database.ExecuteSqlCommandAsync("WAITFOR DELAY '00:00:02';");

        
            return _context.Books.Include(b => b.Author).
                FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            //Adding the include, includes the object references
            //Without the include we'd only have the AuthorId  
            return  _context.Books.Include(b => b.Author).ToList(); //Extension method 
        }

        public void  AddBook(Book book)
        {
            if(book == null)
            { throw new ArgumentNullException(nameof(book)); }

             _context.AddAsync(book);
        }

        public void AddBooks(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> bookIds)
        {
            return await _context.Books.Where(b => bookIds.Contains(b.Id)).
                Include(b => b.Author).ToListAsync();
        }
    }
}
