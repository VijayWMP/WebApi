using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMWebApi.Data;
using CRMWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private QuotesDbContext _QuotesDbContext;

        public PersonController(QuotesDbContext quotesDbContext)
        {
            _QuotesDbContext = quotesDbContext;
        }
        // GET: api/Person
        [HttpGet]
        [ResponseCache(Duration =60,Location =ResponseCacheLocation.Client)]
        public IActionResult Get(string sort,int? pageNumber,int? pageSize,string search)
        {
            var currentPageNum = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 2;
            IQueryable<PersonModel> People;
            if (search!=null)
            {
                switch (sort)
                {
                    case "desc":
                        People = _QuotesDbContext.People.Where(m => m.Description.StartsWith(search)).OrderByDescending(m => m.ID);
                        break;
                    case "asc":
                        People = _QuotesDbContext.People.Where(m => m.Description.StartsWith(search)).OrderBy(m => m.ID);
                        break;
                    default:
                        People = _QuotesDbContext.People.Where(m => m.Description.StartsWith(search));
                        break;

                }
            }
            else { 
            switch (sort)
            {
                case "desc":
                    People = _QuotesDbContext.People.OrderByDescending(m => m.ID);
                    break;
                case "asc":
                    People = _QuotesDbContext.People.OrderBy(m=>m.ID);
                    break;
                default:
                    People = _QuotesDbContext.People;
                    break;

            }
            }
            return Ok(People.Skip((currentPageNum-1)* currentPageSize).Take(currentPageSize));
        }

       

        //GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var data = _QuotesDbContext.People.Find(id);
            if (data == null)
            {
                return NotFound("Data not found");
            }
            return Ok(data);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody] PersonModel person)
        {
            _QuotesDbContext.People.Add(person);
            _QuotesDbContext.SaveChanges();
            return Ok("Record Saved Successfully...");
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonModel person)
        {
            var per = _QuotesDbContext.People.Find(id);
            if (per == null)
            {
                return NotFound("No Record found with this Id");
            }
            else
            {
                per.Title = person.Title;
                per.Author = person.Author;
                per.Description = person.Description;
                _QuotesDbContext.SaveChanges();
                return Ok("Record Updated Successfully...");
            }            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var per1 = _QuotesDbContext.People.Where(m => m.ID == id).FirstOrDefault();
            var per = _QuotesDbContext.People.Find(id);
            _QuotesDbContext.People.Remove(per);
            _QuotesDbContext.SaveChanges();
        }
    }
}
