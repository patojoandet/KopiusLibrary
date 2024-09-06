using AutoMapper;
using KopiusLibrary.Model.DTO;
using KopiusLibrary.Model.Entities;
using KopiusLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KopiusLibrary.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            _mapper = mapper;
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
        [HttpPost]
        public ActionResult Post([FromBody] BookDTO book)
        {
            if (bookRepository.InvalidBook(book))
            {
                return BadRequest();
            }
            bookRepository.Add(book);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookUpdateDTO bookDTO)
        {
            Response res = bookRepository.Update(bookDTO);
            return res.Code == 200 ? Ok(res) : BadRequest(res);
        }
    }
}
