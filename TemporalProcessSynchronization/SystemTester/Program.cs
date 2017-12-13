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
			var mediatorProcess = new Process
			{
				StartInfo =
				{
					FileName = "Mediator.exe",
					WorkingDirectory = "C:\\Users\\Martin\\Desktop\\TemporalProcessSynchronization\\TemporalProcessSynchronization\\Mediator\\bin\\Debug",
					Arguments = $"Hello world message!"
				}
			};

			mediatorProcess.Start();

			var userProcess = new Process
			{
				StartInfo =
				{
					FileName = "User.exe",
					WorkingDirectory = "C:\\Users\\Martin\\Desktop\\TemporalProcessSynchronization\\TemporalProcessSynchronization\\User\\bin\\Debug"
				}
			};

			userProcess.Start();
		}
	}
}
