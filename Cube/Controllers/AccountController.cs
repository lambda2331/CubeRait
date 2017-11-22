using System.Threading.Tasks;
using System.Web.Http;
using Cube.Models;

namespace Cube.Controllers {
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController {
        private readonly AuthRepository m_repo;

        public AccountController(AuthRepository repo) {
            this.m_repo = repo;
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterUserModel userModel) {
            if(!this.ModelState.IsValid) return this.BadRequest(this.ModelState);
            var result = await this.m_repo.RegisterUserAsync(userModel);
            if(result != null) return this.Ok();
            return this.BadRequest();
        }

        protected override void Dispose(bool disposing) {
            if(disposing) this.m_repo.Dispose();

            base.Dispose(disposing);
        }
    }
}
