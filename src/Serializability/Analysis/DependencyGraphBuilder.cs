using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class DependencyGraphBuilder : IDependencyGraphBuilder
	{
		private readonly IStepPairInspector _pairInspector;

		public DependencyGraphBuilder(IStepPairInspector pairInspector)
		{
			this._pairInspector = pairInspector;
		}

		public IEnumerable<DependencyGraphNode> GetGraph(Schedule schedule)
		{
			List<Transaction> transactions = new List<Transaction>();

			// iterate through the schedule.  store references to each pair of steps that affect the same object on different transactions where at least one is a write.

			var pairs = _pairInspector.GetPairs(schedule);

			foreach (var pair in pairs)
			{
				if (!transactions.Contains(pair.FirstStep.Transaction))
				{
					transactions.Add(pair.FirstStep.Transaction);
				}

				if (!transactions.Contains(pair.SecondStep.Transaction))
				{
					transactions.Add(pair.SecondStep.Transaction);
				}
			}

			// create a node for each transaction

			var nodes = new Dictionary<Transaction, DependencyGraphNode>(transactions.Count);

			foreach (var transaction in transactions)
			{
				nodes.Add(transaction, new DependencyGraphNode
				{
					Transaction = transaction
				});
			}
			
			// iterate through the pairs identifying dependencies.  

			foreach (var pair in pairs)
			{
				var node = nodes[pair.SecondStep.Transaction];

				var dependentNode = nodes[pair.FirstStep.Transaction];

				if (!node.Dependencies.Contains(dependentNode))
				{
					node.Dependencies.Add(dependentNode);
				}
			}

			return nodes.Values;
		}
	}
}
