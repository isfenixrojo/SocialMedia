using FluentValidation;
using SocialMedia.Core.DTOs;
using System;

namespace SocialMedia.Infrastructure.Validators
{
    public class PublicacionValidator : AbstractValidator<PublicacionDTO>
    {
        public PublicacionValidator()
        {
            RuleFor(publicacion => publicacion.Descripcion)
                .NotNull()
                .Length(10, 100);

            RuleFor(publicacion => publicacion.Fecha)
                .NotNull()
                .LessThan(DateTime.Now);

        }
    }
}
