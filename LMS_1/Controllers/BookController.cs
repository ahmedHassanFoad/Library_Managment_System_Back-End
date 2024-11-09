using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Helpers;
using LMS_1.Interfaces;
using LMS_1.Sharing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("AllAvilableBooks")]
        public async Task<ActionResult> GetAvilableBooks([FromQuery] BookParams bookParams)
        {
            var (books, totalContacts) = await _bookRepository.GetAllAvilableBooksAsync(bookParams);



            return Ok(new Pagination<BookDto>(totalContacts, bookParams.PageSize, bookParams.PageNumber, books));
        }
        [HttpGet("AllIssuedBooks")]
        public async Task<ActionResult> GetIssuedBooks([FromQuery] BookParams bookParams)
        {
            var (books, totalContacts) = await _bookRepository.GetAllIssuedBooksAsync(bookParams);



            return Ok(new Pagination<BookDto>(totalContacts, bookParams.PageSize, bookParams.PageNumber, books));
        }
        [HttpGet("BookById")]
        public async Task<ActionResult> GetBookById(int id) 
        {
            if(id==null)
            {
                return BadRequest("ID not Found");
            }
            var book=_bookRepository.GetBookByIdAsync(id);
            return Ok(book);
        }
        [HttpPut("IssueBook")]
        public async Task<ActionResult> IssueBook(int id)
        {
            if (id == null)
            {
                return BadRequest("ID not Found");
            }

            var Change=_bookRepository.IssueBooktAsync(id);
            return Ok(Change);
        }
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is null.");
            }

            await _bookRepository.AddBookAsync(bookDto);

            return Ok("Book added successfully.");
        }
    }
}
