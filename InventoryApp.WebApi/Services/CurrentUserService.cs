using InventoryApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InventoryApp.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        public string Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue("InventoryAppRole");
    }
}
