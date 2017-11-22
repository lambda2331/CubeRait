using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Cube.Models;

namespace Cube.Controllers {
    [RoutePrefix("api/User")]
    public class UserController : ApiController {
        private readonly IAuthRepository m_repo;

        public UserController(IAuthRepository repo) {
            this.m_repo = repo;
        }

        [Authorize]
        [Route("Users")]
        public List<User> GetUsers() {
            return this.m_repo.GetAll().Users.ToList();
        }

        [Authorize]
        [Route("AddCube")]
        public async Task<IHttpActionResult> PostAddCube(CubeModel cube) {
            var userName = GetClaimsIdentity.GetInfo().FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;

            var user = this.m_repo.GetAll().Users.FirstOrDefault(u => u.Login.Equals(userName, StringComparison.OrdinalIgnoreCase));
            if(user == null) return this.BadRequest();

            var usersRaiting = this.m_repo.GetAll().UsersRaitings.FirstOrDefault(u => u.TypeOfCube == cube.TypeOfCube && u.UserId == user.UserId);
            if(usersRaiting != null) {
                usersRaiting.Time = cube.Time;
                this.m_repo.GetAll().Entry(usersRaiting).State = EntityState.Modified;
            } else {
                this.m_repo.GetAll().UsersRaitings.Add(new UsersRaiting {
                    TypeOfCube = cube.TypeOfCube,
                    Time = cube.Time,
                    User = user,
                    UserId = user.UserId
                });
            }
            await this.m_repo.GetAll().SaveChangesAsync();
            return this.Ok();
        }
    }
}
