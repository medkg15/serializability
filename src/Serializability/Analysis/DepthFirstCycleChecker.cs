using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	/// <summary>
	/// A recursive depth first search to determine if a graph has a cycle.
	/// </summary>
	public class DepthFirstCycleChecker : ICycleChecker
	{
		public bool HasCycles(DependencyGraphNode node)
		{
			return HasCycles(node, new List<DependencyGraphNode>());
		}

		private bool HasCycles(DependencyGraphNode node, List<DependencyGraphNode> seenNodes)
		{
			if (seenNodes.Contains(node))
			{
				return true;
			}

			seenNodes.Add(node);

			foreach (var dependency in node.Dependencies)
			{
				var seenNodesClone = new List<DependencyGraphNode>(seenNodes);

				if (HasCycles(dependency, seenNodesClone))
				{
					return true;
				}
			}

			return false;
		}
	}
}
