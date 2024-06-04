using FluentValidation;
using FluentValidation.Results;

namespace Core.Common;

public abstract class Entity
{
    protected static void Validate<T>(AbstractValidator<T> validator, T data)
    {
        var validationResult = validator.Validate(data);
        ThrowIfNotValid(validationResult);
    }

    protected static async Task ValidateAsync<T>(AbstractValidator<T> validator, T data, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(data, cancellationToken);
        ThrowIfNotValid(validationResult);
    }
    
    private static void ThrowIfNotValid(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            var errors = string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}