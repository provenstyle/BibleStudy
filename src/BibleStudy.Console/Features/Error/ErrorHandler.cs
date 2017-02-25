namespace BibleStudy.Console.Features.Error
{
    using System;
    using Miruken.Callback;
    using Miruken.Error;

    public class ErrorHandler : IErrors, IResolving
    {
        public bool HandleException(Exception exception, object context = null)
        {
            throw new NotImplementedException();
        }
    }
}
