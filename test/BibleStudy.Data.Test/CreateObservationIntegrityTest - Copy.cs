namespace BibleStudy.Data.Test
{
    using Api.Observations;
    using Console.Features.Observations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateEntityIntegrityTest
    {
        private CreateObservation createObservation;
        private CreateObservationIntegrity validator;

        [TestInitialize]
        public void TestInitialize()
        {
            createObservation =  new CreateObservation
            {
                 Resource = new ObservationData
                 {
                    Text = "my text"
                 }
            };

            validator = new CreateObservationIntegrity();
        }

        [TestMethod]
        public void Valid()
        {
            var result = validator.Validate(createObservation);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void MustHaveText()
        {
            createObservation.Resource.Text = string.Empty;
            var result = validator.Validate(createObservation);
            Assert.IsFalse(result.IsValid);
        }
    }
}
