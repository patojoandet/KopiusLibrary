using KopiusLibrary.Model.DTO;
using KopiusLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Books()
        {
            IEnumerable<BookDTO> books = bookRepository.Get().ToList();
            return books.Any() ? Ok(books) : NotFound();
        }
        [HttpGet("{title}")]
        public ActionResult<IEnumerable<BookDTO>> GetByName(string title)
        {
            IEnumerable<BookDTO> books = bookRepository.GetByName(title).ToList();
            return books.Any() ? Ok(books) : NotFound();
        }
        //[HttpPost]
        //public ActionResult Post([FromBody] Book book)
        //{
        //    if (book != null)
        //    {
        //        if(book.AuthorBook != null)
        //        {

        //        }
        //        else
        //        {

        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }           
        //}

        private bool AlreadyExists(string isbn)
        {
            return !Books().Value.Any(b => b.Equals(isbn));
        }
    }
}
