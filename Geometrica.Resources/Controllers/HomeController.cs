using System.Collections.Generic;
using Geometrica.Auth.Resources.Models;
using Geometrica.Auth.Resources.Repository;
using Geometrica.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geometrica.Auth.Resources.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet("countries")]
        public IEnumerable<Country> GetCountries()
        {
            return repository.GetCountries();
        }
        
        [HttpGet("genders")]
        public IEnumerable<Gender> GetGenders()
        {
            return repository.GetGenders();
        }
    }
}