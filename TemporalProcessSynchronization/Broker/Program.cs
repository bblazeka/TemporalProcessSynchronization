using System;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Base;
using Base.Extensions;
using MessageCommunication;

namespace Broker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var broker = new AlertsBroker();
            broker.Listen();
        }
    }
}
