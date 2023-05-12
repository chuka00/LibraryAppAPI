using System.Collections.ObjectModel;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IBookServices
    {
        List<BookDto> GetBooks();
        BookDto GetBookById(int id);
        //Task<BookDto> GetBookById(int id);
        Task<string> CreateBook(BookDto book);
        Task DeleteBook(int Id);
    }
}
