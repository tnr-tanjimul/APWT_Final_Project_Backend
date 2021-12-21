using BLL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TierApp.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {

        [Route("api/Category/All")]
        [HttpGet]
        public List<CategoryModel> GetAll()
        {

            return CategoryService.GetAll();
        }
        [Route("api/Category/Names")]
        [HttpGet]
        public List<string> Names()
        {
            return CategoryService.GetCategory();
        }
        [HttpGet]
        [Route("api/Category/delete")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (CategoryService.Delete(id))
            {
                return Ok(new { Message = "Category Delete Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/Category/add")]
        public IHttpActionResult Add(CategoryModel n)
        {
            if (CategoryService.Add(n))
            {
                return Ok(new { Message = "Category Added Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/Category/edit")]
        public IHttpActionResult Edit(CategoryModel n)
        {
            if (CategoryService.Edit(n))
            {
                return Ok(new { Message = "Category Update Successfully" });
            }
            return BadRequest();
        }
    }
}
