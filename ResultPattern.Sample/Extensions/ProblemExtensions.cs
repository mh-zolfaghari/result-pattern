using Microsoft.AspNetCore.Mvc;
using ResultPattern.Tools;

namespace ResultPattern.Sample.Extensions
{
    public static class ProblemExtensions
    {
        public static ProblemDetails MapToProblemDetails(this Result result)
            => new()
            {
                Status = (int)(result.Error!.Type),
                Type = nameof(result.Error.Type),
                Title = result.Error.Type.GetDescription(),
                Detail = result.Error.Message
            };
    }
}
