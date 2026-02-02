
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskList.Domain.Tools.ResultPattern;

namespace TaskList.Presentation.Extensions;

public static class ResultExtensions
{
    public async static Task<IActionResult> ToActionResult(this Task<Result> result)
    {
        var val = await result;

        if (val.IsSuccess)
        {
            return new NoContentResult();
        }

        return ExtractError(val.Error!);
    }

    public async static Task<IActionResult> ToValueActionResult<T>(this Task<Result<T>> result)
    {
        var val = await result;

        if (val.IsSuccess)
        {
            return new OkObjectResult(val.Value);
        }

        return ExtractError(val.Error!);
    }

    private static ObjectResult ExtractError(Error error)
        => error.Kind switch
        {
            ErrorKind.NotFound => new NotFoundObjectResult(error.Message),
            ErrorKind.BadRequest => new BadRequestObjectResult(error.Message),
            ErrorKind.InternalServer or _ =>  new ObjectResult(error.Message) { StatusCode = StatusCodes.Status500InternalServerError }
        };
}
