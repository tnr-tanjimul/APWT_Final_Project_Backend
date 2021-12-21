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
    public class CommentController : ApiController
    {

        [Route("api/Comment/All")]
        [HttpGet]
        public List<CommentModel> GetAll()
        {

            return CommentService.GetAll();
        }
        [Route("api/Comment/Names")]
        [HttpGet]
        public List<string> Names()
        {
            return CommentService.GetNames();
        }
        [HttpGet]
        [Route("api/Comment/delete")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (CommentService.Delete(id))
            {
                return Ok(new { Message = "Comment Delete Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/Comment/add")]
        public IHttpActionResult Add(CommentModel n)
        {
            if (CommentService.Add(n))
            {
                return Ok(new { Message = "Comment Added Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/Comment/edit")]
        public IHttpActionResult Edit(CommentModel n)
        {
            if (CommentService.Edit(n))
            {
                return Ok(new { Message = "Comment Update Successfully" });
            }
            return BadRequest();
        }
    }
}
