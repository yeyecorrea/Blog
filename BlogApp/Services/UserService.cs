using System.Security.Claims;

namespace BlogApp.Services
{
    public class UserService : IUserService
    {
        private HttpContext _httpContext;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string GetUserId()
        {
            if (_httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = _httpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                return idClaim.Value;
            }
            else
            {
                throw new Exception("El usuario no está autenticado");
            }
        }
    }
}
