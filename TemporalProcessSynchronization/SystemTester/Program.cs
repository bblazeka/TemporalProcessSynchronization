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
					Arguments = $"Hello world message!"
				}
			};

			broker.Start();

			var user = new Process
			{
				StartInfo =
				{
					FileName = Properties.Resources.UserExe,
					WorkingDirectory = Properties.Resources.UserDirectory
				}
			};

			user.Start();
		}
	}
}
