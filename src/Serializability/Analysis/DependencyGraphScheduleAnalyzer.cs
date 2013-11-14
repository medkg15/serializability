using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class DependencyGraphScheduleAnalyzer : IScheduleAnalyzer
	{
		private readonly DependencyGraphBuilder _builder;
		private readonly ICycleChecker _cycleChecker;

		public DependencyGraphScheduleAnalyzer(DependencyGraphBuilder builder, ICycleChecker cycleChecker)
		{
			this._builder = builder;
			this._cycleChecker = cycleChecker;
		}

		public bool IsConflictSerializable(Schedule schedule)
		{
			// produce the dependency graph 
			var graph = _builder.GetGraph(schedule);

			foreach (var node in graph)
			{
				if (_cycleChecker.HasCycles(node))
				{
					return false;
				}
			}

			return true;
		}
	}
}
