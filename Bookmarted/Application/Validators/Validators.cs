using Bookmarted.Application.DTOs;
using FluentValidation;

namespace Bookmarted.Application.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Condition).NotEmpty();
        }
    }

    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Condition).NotEmpty();
        }
    }

    public class CreateStoreValidator : AbstractValidator<CreateStoreDto>
    {
        public CreateStoreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

    public class UpdateStoreValidator : AbstractValidator<UpdateStoreDto>
    {
        public UpdateStoreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }

    public class CreateBookAvailabilityValidator : AbstractValidator<CreateBookAvailabilityDto>
    {
        public CreateBookAvailabilityValidator()
        {
            RuleFor(x => x.StoreId).GreaterThan(0);
            RuleFor(x => x.BookId).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        }
    }

    public class UpdateBookAvailabilityValidator : AbstractValidator<UpdateBookAvailabilityDto>
    {
        public UpdateBookAvailabilityValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        }
    }
}
