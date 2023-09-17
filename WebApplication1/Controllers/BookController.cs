using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;


        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }


        [Authorize(Roles = "Librarian")]
        [HttpGet(Name = "GetBooks")]
        [ProducesResponseType(200)]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [Authorize(Roles = "Librarian")]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto book)
        {
            var newBook = await _bookService.CreateBook(book);
            return Ok(newBook);
        }

        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, BookDto bookDto)
        {
             await _bookService.UpdateBook(id, bookDto);
            return Ok();
        }
       

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            await _bookService.DeleteBook(Id);
            return Ok();
        }
    }
}
