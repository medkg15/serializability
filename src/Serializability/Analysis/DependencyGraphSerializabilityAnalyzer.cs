using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class DependencyGraphSerializabilityAnalyzer : ISerializabilityAnalyzer
	{
		private readonly IDependencyGraphBuilder _builder;
		private readonly ICycleChecker _cycleChecker;

		public DependencyGraphSerializabilityAnalyzer(IDependencyGraphBuilder builder, ICycleChecker cycleChecker)
		{
			this._builder = builder;
			this._cycleChecker = cycleChecker;
		}

		public bool IsConflictSerializable(Schedule schedule)
		{
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
