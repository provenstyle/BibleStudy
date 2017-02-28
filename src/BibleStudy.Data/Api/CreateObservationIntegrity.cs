namespace BibleStudy.Console.Features.Observations
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Api.Observations;
    using Data.Api.Verses;
    using FluentValidation;

    public class CreateObservationIntegrity : AbstractValidator<CreateObservation>
    {
        public CreateObservationIntegrity()
        {
            RuleFor(x => x.Resource)
                .NotNull()
                .SetValidator(new ObservationDataIntegrity());
        }

        private class ObservationDataIntegrity : AbstractValidator<ObservationData>
        {
            public ObservationDataIntegrity()
            {
                RuleFor(x => x.Verses)
                    .Must(HaveAtLeastOneVerse);
                RuleFor(x => x.Text)
                    .NotEmpty();
            }

            private bool HaveAtLeastOneVerse(IEnumerable<VerseData> arg)
            {
                return arg.Any();
            }
        }
    }
}
