
using FluentValidation.Results;

namespace NS.Application.Exceptions;

public class CommandValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }
    public CommandValidationException(ValidationResult validationResult)
    {
        ValidationErrors = new List<string>();
        foreach (var validationError in validationResult.Errors)
        {
            ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}