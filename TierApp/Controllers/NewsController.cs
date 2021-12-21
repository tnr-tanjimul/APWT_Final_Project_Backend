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
    public class NewsController : ApiController
    {
        
        [Route("api/News/All")]
        [HttpGet]
        public List<NewsModel> GetAll() {
            
            return NewsService.GetAll();
        }
        [Route("api/News/Names")]
        [HttpGet]
        public List<string> Names() {
            return NewsService.GetCategory();
        }
        [HttpGet]
        [Route("api/News/delete")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (NewsService.Delete(id))
            {
                return Ok(new { Message = "News Delete Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/News/add")]
        public IHttpActionResult Add(NewsModel n)
        {
            if (NewsService.Add(n))
            {
                return Ok(new { Message = "News Added Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/News/edit")]
        public IHttpActionResult Edit(NewsModel n)
        {
            if (NewsService.Edit(n))
            {
                return Ok(new { Message = "News Update Successfully" });
            }
            return BadRequest();
        }



        [HttpGet]
        [Route("api/news/bydate")]
        public IHttpActionResult Get([FromUri] DateTime dateTime)
        {
            var data = NewsService.GetByDate(dateTime);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/news/bycategory")]
        public IHttpActionResult Get([FromUri] string category)
        {
            var data = NewsService.GetByCategory(category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/news/bydate/category")]
        public IHttpActionResult Get([FromUri] DateTime dateTime, [FromUri] string category)
        {
            var data = NewsService.GetByDateCategory(dateTime, category);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
