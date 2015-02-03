using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAPI.DAL;
using WebAPI.DAL.Models;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController(AuthRepository repo)
        {
            _repo = new AuthRepository();
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(User userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            throw new System.NotImplementedException();
        }
    }
}
