using AutoMapper;
using Cube.Models;

namespace Cube {
    public static class AutoMapperConfig {
        public static IMapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserModel>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
