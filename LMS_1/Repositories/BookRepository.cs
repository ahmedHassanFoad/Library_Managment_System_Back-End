using AutoMapper;
using LMS_1.Data;
using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Interfaces;
using LMS_1.Sharing;
using Microsoft.EntityFrameworkCore;

namespace LMS_1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;
        public BookRepository(LMSDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);  
            await _context.Books.AddAsync(book);
           var res=  await _context.SaveChangesAsync();
            
        }


        public Task DeleteBookAsync(int BookId)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<BookDto>, int totalCount)> GetAllAvilableBooksAsync(BookParams bookParams)
        {
            List<Book> query;
            query = await _context.Books.AsNoTracking().Where(c=>c.IsAvilable==true).Include(b=>b.Catagory).ToListAsync();

            if (!string.IsNullOrEmpty(bookParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(bookParams.Search.ToLower())).ToList();

            int totalCount = query.Count();

            //sorting
           
            query = query.Skip((bookParams.PageSize) * (bookParams.PageNumber - 1)).Take(bookParams.PageSize).ToList();
            var bookDto=_mapper.Map<IEnumerable<BookDto>>(query);
            return (bookDto, totalCount);
        }

        public async Task<(IEnumerable<BookDto>, int totalCount)> GetAllIssuedBooksAsync(BookParams bookParams)
        {
            List<Book> query;
            query = await _context.Books.AsNoTracking().Where(c => c.IsAvilable == false).ToListAsync();

            if (!string.IsNullOrEmpty(bookParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(bookParams.Search.ToLower())).ToList();

            int totalCount = query.Count();

            //sorting

            query = query.Skip((bookParams.PageSize) * (bookParams.PageNumber - 1)).Take(bookParams.PageSize).ToList();
            var bookDto = _mapper.Map<IEnumerable<BookDto>>(query);
            return (bookDto, totalCount);
        }

        public async Task<Book> GetBookByIdAsync(int BookId)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == BookId);
        }

        public async Task IssueBooktAsync(int BookId)
        {
            var book= await _context.Books.FindAsync( BookId);

            if (book != null)
            {               
                book.IsAvilable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
