using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Application.AnimeApplication.Command.AddAnime;

public class AddAnimeCommandValidator : AbstractValidator<AddAnimeCommand>
{
    public AddAnimeCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Anime name cannot be empty.")
            .Length(1, 50).WithMessage("Anime name must be between 1 and 50 characters.");

        RuleFor(c => c.Description)
            .MaximumLength(255).WithMessage("Description must be less than 255 characters.");

        RuleFor(c => c.Status)
            .IsInEnum().WithMessage("Invalid anime status");

        RuleForEach(c => c.Genres)
            .NotEmpty().WithMessage("Genre name cannot be empty.")
            .Length(1, 20).WithMessage("Genre name must be between 1 and 20 characters.");

        RuleForEach(c => c.Episodes)
            .NotNull().WithMessage("Each episode must be valid.")
            .ChildRules(e =>
            {
                e.RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Episode name is required.")
                .Length(1, 50).WithMessage("Episode name must be between 1 and 50 characters.");

                e.RuleFor(x => x.Description)
                .MaximumLength(50).WithMessage("Episode description must be less than 50 characters.");

                e.RuleFor(x => x.EpisodeNumber)
                .NotEmpty().WithMessage("Episode number is required.")
                .Length(1, 4).WithMessage("Episode number must be between 1 and 4 characters.");
            });
    }
}
