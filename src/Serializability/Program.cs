using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serializability.Analysis;
using Serializability.Generation;
using Serializability.Parsing;

namespace Serializability
{
	class Program
	{
		static void Main(string[] args)
		{
			string input;


			var dependencyGraphBuilder = new CachingDependencyGraphBuilder(new DependencyGraphBuilder(new AllStepPairInspector()));

			ISerializabilityAnalyzer analyzer = new DependencyGraphSerializabilityAnalyzer(dependencyGraphBuilder, new DepthFirstCycleChecker());

			ISerialScheduleGenerator generator = new DependencyGraphSerialScheduleGenerator(dependencyGraphBuilder, analyzer);

			Console.WriteLine("Welcome.  Please enter a schedule: ");

			while (!Equals(input = Console.ReadLine(), "exit"))
			{
				// we want three outputs:

				// is the given schedule conflict serializable?
				// what are the dependencies for each transaction?
				// what is the serial schedule, if it is conflict serializable?
				
				var scheduleInput = new StringScheduleInput(new ScheduleParser(), input);

				var dependencyGraph = dependencyGraphBuilder.GetGraph(scheduleInput.Schedule);

				var isConflictSerializable = analyzer.IsConflictSerializable(scheduleInput.Schedule);


				Console.WriteLine("Conflict Serializable: {0}", isConflictSerializable);

				foreach (var node in dependencyGraph)
				{
					Console.WriteLine("Transaction {0} depends upon: {1}", node.Transaction, string.Join(", ", node.Dependencies.Select(n => n.Transaction)));
				}

				if (isConflictSerializable)
				{
					var serialSchedule = generator.GetSerialSchedule(scheduleInput.Schedule);

					Console.WriteLine("Serial Schedule: {0}", serialSchedule);
				}

				Console.WriteLine("Please enter a schedule: ");
			}
		}
	}
}
