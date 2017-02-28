namespace BibleStudy.Data.Test
{
    using System;
    using System.Collections.Generic;
    using Api.Observations;
    using Api.Verses;
    using Console.Features.Observations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateObservationIntegrityTest
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
                    Text = "my observation",
                    Verses = new List<VerseData>
                    {
                        new VerseData()
                    }
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

        [TestMethod]
        public void MustHaveAVerse()
        {
            createObservation.Resource.Verses = new List<VerseData>();
            var result = validator.Validate(createObservation);
            Assert.IsFalse(result.IsValid);
        }
    }
}
