using APIClass1.Data;
using APIClass1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClass1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private EFCoreDbContext context;
        public QuoteController(EFCoreDbContext _context)
        {
            context = _context;
        }

        //GetAll
        [HttpGet("getAll")]
        public List<Quote> GetAll() 
        {
            var list = context.Quote.ToList();
            return list;
        }

        //GetById
        [HttpGet("getById/{id}")]
        public Quote GetById(int id)
        {
            var obj = context.Quote.Find(id);
            return obj;
        }

        //Insert
        [HttpPost]
        public Quote Insert(Quote obj)
        {
            context.Quote.Add(obj);
            context.SaveChanges();

            return obj;
        }

        //Update
        [HttpPut]
        public Quote Update(Quote obj)
        {
            context.Quote.Update(obj);
            context.SaveChanges();

            return obj;
        }

        //Delete
        [HttpDelete("{id}")]
        public List<Quote> Delete(int id)
        {
            var obj = context.Quote.Find(id);
            context.Quote.Remove(obj);
            context.SaveChanges();

            return context.Quote.ToList();
        }
    }
}
