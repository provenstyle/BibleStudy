namespace BibleStudy.Data.Api
{
    using FluentValidation;
    using Prayers;

    public class CreatePrayerIntegrity : AbstractValidator<CreatePrayer>
    {
        public CreatePrayerIntegrity()
        {
            RuleFor(x => x.Resource)
                .NotNull()
                .SetValidator(new PrayerDataIntegrity());
        }

        private class PrayerDataIntegrity : AbstractValidator<PrayerData>
        {
            public PrayerDataIntegrity()
            {
            }
        }
    }
}