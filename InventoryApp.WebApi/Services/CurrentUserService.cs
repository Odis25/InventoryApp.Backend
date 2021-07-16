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
        public string UserName => GetFullName();
        public string Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue("inventoryapp_role");

        private string GetFullName()
        {
            var givenName = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
            var familyName = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);

            return $"{familyName} {givenName}";
        }
    }
}
