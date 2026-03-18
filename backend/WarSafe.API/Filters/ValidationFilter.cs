using Microsoft.AspNetCore.Mvc.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
            throw new Exception("Invalid request");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
