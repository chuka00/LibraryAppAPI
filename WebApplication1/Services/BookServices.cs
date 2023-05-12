using AutoMapper;
using System.Collections.ObjectModel;
using TodoList.DAL.Repository;
using WebApplication1.Dtos;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepo;

        public BookServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookRepo = _unitOfWork.GetRepository<Book>();
        }

        public List<BookDto> GetBooks()
        {
            var books = _bookRepo.GetAll()
                .Select(b => new BookDto
                {
                    //Id = b.id,
                    Title = b.Title,
                    Genre = b.Genre
                })
                .ToList();

            return books;
        }



        public BookDto GetBookById(int id)
        {
            var book = _bookRepo.GetById(id);

            if (book == null)
            {
                return null;
            }
            return new BookDto
            {
                Title = book.Title,
                Genre = book.Genre
            };
        }

        public async Task<string> CreateBook(BookDto book)
        {
            Book newBook = new Book
            {
                Title = book.Title,
                Genre = book.Genre
            };
            var newBookResult = await _bookRepo.AddAsync(newBook);
            if (newBookResult == null)
            {
                throw new Exception("Unable to create new book");
            }

            return "Sucessfully created!";
        }

        public async Task DeleteBook(int Id)
        {
            Book book = await _bookRepo.GetSingleByAsync(b => b.id == Id);
            if (book == null)
                throw new Exception("Book doesn't exist");
            await _bookRepo.DeleteAsync(book);
            return;
        }

        
    }
}
