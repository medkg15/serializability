using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serializability.Analysis;

namespace Serializability
{
	class Program
	{
		static void Main(string[] args)
		{
			string input;

			var analyzer = new DependencyGraphScheduleAnalyzer(new DependencyGraphBuilder(new AllStepPairInspector()), new DepthFirstCycleChecker());

			Console.WriteLine("Welcome.  Please enter a schedule: ");

			while (!Equals(input = Console.ReadLine(), "exit"))
			{
				var scheduleInput = new StringScheduleInput(new ScheduleParser(), input);

				Console.WriteLine("Conflict Serializable: {0}", analyzer.IsConflictSerializable(scheduleInput.Schedule));

				Console.WriteLine("Please enter a schedule: ");
			}
		}
	}
}
