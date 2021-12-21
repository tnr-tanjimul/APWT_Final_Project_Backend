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
    public class UserController : ApiController
    {

        [Route("api/User/All")]
        [HttpGet]
        public List<UserModel> GetAll()
        {

            return UserService.GetAll();
        }
        [Route("api/User/Names")]
        [HttpGet]
        public List<string> Names()
        {
            return UserService.GetUserName();
        }
        [HttpGet]
        [Route("api/User/delete")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (UserService.Delete(id))
            {
                return Ok(new { Message = "User Delete Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/User/add")]
        public IHttpActionResult Add(UserModel n)
        {
            if (UserService.Add(n))
            {
                return Ok(new { Message = "User Added Successfully" });
            }
            return BadRequest();
        }



        [HttpPost]
        [Route("api/User/edit")]
        public IHttpActionResult Edit(UserModel n)
        {
            if (UserService.Edit(n))
            {
                return Ok(new { Message = "User Update Successfully" });
            }
            return BadRequest();
        }



    }
}
