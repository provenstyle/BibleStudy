namespace BibleStudy.Console.Features.Error
{
    using System;
    using Miruken.Error;

    public class ErrorHandler : IErrors
    {
        public bool HandleException(Exception exception, object context = null)
        {
            throw new NotImplementedException();
        }
    }
}
