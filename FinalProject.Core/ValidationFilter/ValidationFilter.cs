using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.Core.ValidationFilter;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => new 
                {
                    Field = e.Key,
                    Errors = e.Value.Errors.Select(x => x.ErrorMessage).ToList()
                }).ToList();
            
            context.Result = new BadRequestObjectResult(new
            {
                Success = false,
                Errors = errors
            });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}