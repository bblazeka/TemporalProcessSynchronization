using System;

namespace MessageCommunication
{
    public class ConsumerNotSubscribedException : Exception
    {
        private const string ExceptionMessage = "Consumer is not bounded to exchange!";

        public ConsumerNotSubscribedException() : base(ExceptionMessage)
        {
        }
    }
}
