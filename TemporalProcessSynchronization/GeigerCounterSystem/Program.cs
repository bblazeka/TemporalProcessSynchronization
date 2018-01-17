using System;
using Base;
using MessageCommunication;
using System.Threading;

namespace GeigerCounterSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new GeigerSystemForm().ShowDialog();
        }
    }
}
