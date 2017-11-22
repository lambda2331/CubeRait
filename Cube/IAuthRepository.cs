using System.Threading.Tasks;
using Cube.Models;

namespace Cube {
    public interface IAuthRepository {
        UserContext GetAll();
        Task<User> RegisterUserAsync(RegisterUserModel userModel);
        Task<User> FindUserAsync(string userName, string password);
    }
}
