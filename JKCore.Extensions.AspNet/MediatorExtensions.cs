using JKCore.Mediator.Abstracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JKCore.Extensions.AspNet
{
    public static class MediatorExtensions
    {
        public static void PopuplateError<T>(this IMediatorResult<T> result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                if (error.Exception != null)
                {
                    modelState.AddModelError("", error.Message);
                }
                else
                {
                    modelState.AddModelError("", error.Exception, null);
                }
            }
        }
    }
}
