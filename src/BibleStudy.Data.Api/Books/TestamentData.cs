namespace BibleStudy.Data.Api.Books
{
    using Improving.MediatR;

    public class TestamentData : IKeyProperties<int>
    {
        public static TestamentData OldTestament { get; }

        public static TestamentData NewTestament { get; }

        static TestamentData()
        {
            OldTestament = new TestamentData
            {
                Id   = 1,
                Name = "Old"
            };

            NewTestament = new TestamentData
            {
                Id   = 2,
                Name = "New"
            };
        }

        public int    Id   { get; set; }
        public string Name { get; set; }
    }
}