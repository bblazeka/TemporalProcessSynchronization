using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTester
{
	class Program
	{
		static void Main(string[] args)
		{
			var broker = new Process
			{
				StartInfo =
				{
					FileName = Properties.Resources.BrokerExe,
					WorkingDirectory = Properties.Resources.BrokerDirectory,
					Arguments = $"Customer call!"
				}
			};

			broker.Start();

			var user = new Process
			{
				StartInfo =
				{
					FileName = Properties.Resources.UserExe,
					WorkingDirectory = Properties.Resources.UserDirectory,
                    Arguments = "1"
				}
			};

			user.Start();

            var user2 = new Process
            {
                StartInfo =
                {
                    FileName = Properties.Resources.UserExe,
                    WorkingDirectory = Properties.Resources.UserDirectory,
                    Arguments = "2"
                }
            };

            user2.Start();

            var user3 = new Process
            {
                StartInfo =
                {
                    FileName = Properties.Resources.UserExe,
                    WorkingDirectory = Properties.Resources.UserDirectory,
                    Arguments = "3"
                }
            };

            user3.Start();
        }
	}
}
