using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationFootBall.Common
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                string condition = string.Empty;
                for (int i = 0; i < context.ModelState.Count; i++)
                {
                    var attr = context.ModelState.Keys.ElementAt(i);
                    if (context.ModelState.Values.ElementAt(i).ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        var errorCode = context.ModelState.Values.ElementAt(i)
                                               .Errors[context.ModelState.Values.ElementAt(i)
                                                              .Errors.Count - 1]
                        .ErrorMessage;

                        errors.Add(errorCode);
                    }
                }
                context.Result = new OkObjectResult(errors);
            }
        }
    }
}
