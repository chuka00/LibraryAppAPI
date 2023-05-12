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
        private readonly IBookServices _bookInterface;

        public BookController(IBookServices bookInterface)
        {
            _bookInterface = bookInterface;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetBooks")]
        [ProducesResponseType(200)]
        public IActionResult GetBooks()
        {
            var books = _bookInterface.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        public IActionResult GetBook(int id)
        {
            var book = _bookInterface.GetBookById(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto book)
        {
            var newBook = await _bookInterface.CreateBook(book);
            return Ok(newBook);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            await _bookInterface.DeleteBook(Id);
            return Ok();
        }
    }
}
