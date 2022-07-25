using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenFlixAPI.Domain.Models.Errors;
using System.Collections.Generic;

namespace OpenFlixAPI.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Keys.Select(property =>
                {
                    var errorMessages = context.ModelState[property].Errors
                        .Select(error => error.ErrorMessage);

                    return KeyValuePair.Create(property.ToLower(), errorMessages);
                });

                context.Result = new BadRequestObjectResult(new ValidationError()
                {
                    Code = 400,
                    Message = "Alguns campos estão incorretos",
                    Errors = new Dictionary<string, IEnumerable<string>>(errors)
                });
            }
        }
    }
}
