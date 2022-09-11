using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBook([FromRoute] int Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);
            if (book == null)
                return NotFound();
            else
                return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel book)
        {
            int bookId = await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBook),new { Id = bookId, controller = "books" },bookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookModel book)
        {
            await _bookRepository.UpdateBookAsync(id, book);
            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook([FromRoute] int id, [FromBody] JsonPatchDocument book)
        {
            await _bookRepository.PatchBookAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
