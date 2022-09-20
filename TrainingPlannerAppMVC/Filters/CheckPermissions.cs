using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TrainingPlannerAppMVC.Filters;

public class CheckPermissions : Attribute, IAuthorizationFilter
{
    private readonly string _permission;
    
    public CheckPermissions(string permission)
    {
        _permission = permission;
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
        if(!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
        }
    }
    
    private bool CheckUserPermission(ClaimsPrincipal user, string permission)
    {
        //Połącz z bazą danych
        //Pobrała użytkownika
        //Sprawdziła czy ten użytkownik ma prawa dostępu do tej akcji
        return permission == "Read";
    }
}