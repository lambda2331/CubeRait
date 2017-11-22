using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Cube.Models;

namespace Cube.Controllers {
    [RoutePrefix("api/Rait")]
    public class RaitController : ApiController {
        private readonly IAuthRepository m_repo;

        public RaitController(IAuthRepository repo) {
            this.m_repo = repo;
        }

        [AllowAnonymous]
        [Route("{cubeType}")]
        public List<RaitModel> GetUserRait(int cubeType) {
            var rait = new List<RaitModel>();
            var list = this.m_repo.GetAll().UsersRaitings.Include(ur => ur.User).Where(ur => ur.TypeOfCube == (CubeType)cubeType).ToList();
            foreach(var t in list) rait.Add(new RaitModel { UserName = $"{t.User.FirstName} {t.User.SecondName}", Time = t.Time });
            return rait.OrderBy(u => u.Time).ToList();
        }
    }
}
