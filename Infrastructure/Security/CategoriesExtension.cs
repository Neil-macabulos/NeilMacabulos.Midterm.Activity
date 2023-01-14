using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NeilMacabulos.Midterm_.Infrastructure.Security
{
    public static class UserExtension
    {
        public static string? Name(this ClaimsPrincipal categories)
            => categories.Identity?.Name;

        public static string? Categories(this ClaimsPrincipal categories)
            => (categories.FindFirstValue("Categories")) ?? null;

        public static Guid? Id(this ClaimsPrincipal categories)
            => (Guid.TryParse(categories.FindFirstValue(ClaimTypes.NameIdentifier), out var id)) ? id : null;

    }
}