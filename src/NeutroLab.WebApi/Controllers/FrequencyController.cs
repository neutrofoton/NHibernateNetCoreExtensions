using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeutroLab.BusinessLogic.Model;
using NeutroLab.BusinessLogic.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeutroLab.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookRepository.GetAll();
        }

    }
}
