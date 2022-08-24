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
    public class CategorysController : ControllerBase
    {
        private EFCoreDbContext context;
        public CategorysController(EFCoreDbContext _context)
        {
            context = _context;
        }

        List<Categorys> list = new List<Categorys>()
            {
                new Categorys() { CategoryId = 1, Name = "Food" },
                new Categorys() { CategoryId = 2, Name = "Fruits" },
                new Categorys() { CategoryId = 3, Name = "Vegetables" }
            };

        //GetAll
        [HttpGet("getAll")]
        public List<Categorys> GetAll()
        {
            //context.categorys.tolist()
            return list;
        }


        //GetbyId
        [HttpGet("getById/{cid}")]
        public Categorys GetById(int cid)
        {
            Categorys obj = list.Where(x => x.CategoryId == cid).FirstOrDefault();
            return obj;
        }

        //Insert

        [HttpPost]
        public List<Categorys> Insert(Categorys model)
        {
            list.Add(model);
            return list;
        }

        //Update
        [HttpPut]
        public Categorys Update(Categorys model)
        {
            Categorys obj = list.Where(x => x.CategoryId == model.CategoryId).FirstOrDefault();

            obj.Name = model.Name;

            return obj;

        }

        //Delete
        [HttpDelete("delete/{id}")]
        public List<Categorys> Delete(int id)
        {
            Categorys obj = list.Where(x => x.CategoryId == id).FirstOrDefault();
            list.Remove(obj);

            return list;
        }
    }
}
