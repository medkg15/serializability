using System.Collections.Generic;

namespace Serializability.Analysis
{
	public interface IDependencyGraphBuilder
	{
		IEnumerable<DependencyGraphNode> GetGraph(Schedule schedule);
	}
}