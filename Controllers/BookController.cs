﻿using KopiusLibrary.Model.Entities;
using KopiusLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Books()
        {
            IEnumerable<Book> books = bookRepository.Get().ToList();
            return books.Any() ? Ok(books) : NotFound();
        }

       [HttpGet("{title}")]
       public ActionResult<IEnumerable<Book>> GetByName(string title)
       {
            return bookRepository.GetByName(title).ToList();
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
