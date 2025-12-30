using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filter
{
    public class RolAutorizadoAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _rolesPermitidos;

        public RolAutorizadoAttribute(params string[] rolesPermitidos)
        {
            _rolesPermitidos = rolesPermitidos;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (rol == null || !_rolesPermitidos.Contains(rol))
            {
                context.Result = new RedirectResult("../Home/Index");
            }
        }
    }

}
