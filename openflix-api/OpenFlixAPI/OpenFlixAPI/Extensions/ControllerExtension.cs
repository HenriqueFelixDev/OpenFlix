using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OpenFlixAPI.Extensions
{
    public static class ControllerExtension
    {
        public static int GetUserId(this ControllerBase controller)
        {
            var identifier = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (identifier == null) return 0;

            return Convert.ToInt32(identifier);
        }
    }
}
