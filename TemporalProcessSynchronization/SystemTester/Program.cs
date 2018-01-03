using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeigerCounterSystem;

namespace SystemTester
{
	class Program
	{
		static void Main(string[] args)
		{
			var user = new Process
			{
				StartInfo =
				{
					FileName = Properties.Resources.TesterExe,
					WorkingDirectory = Properties.Resources.TesterDirectory
				}
			};

			user.Start();

			var broker = new Process
			{
				StartInfo =
				{
					FileName = Properties.Resources.BrokerExe,
					WorkingDirectory = Properties.Resources.BrokerDirectory
				}
			};

			broker.Start();

			//         var user2 = new Process
			//         {
			//             StartInfo =
			//             {
			//                 FileName = Properties.Resources.UserExe,
			//                 WorkingDirectory = Properties.Resources.UserDirectory,
			//                 Arguments = "2"
			//             }
			//         };

			//         user2.Start();

			//         var user3 = new Process
			//         {
			//             StartInfo =
			//             {
			//                 FileName = Properties.Resources.UserExe,
			//                 WorkingDirectory = Properties.Resources.UserDirectory,
			//                 Arguments = "3"
			//             }
			//         };

			//         user3.Start();
		}
	}
}
