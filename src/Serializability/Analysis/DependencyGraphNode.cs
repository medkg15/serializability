using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class DependencyGraphNode
	{
		public DependencyGraphNode()
		{
			this.Dependencies = new List<DependencyGraphNode>();
		}

		public Transaction Transaction { get; set; }
		public IList<DependencyGraphNode> Dependencies { get; set; }

		public override string ToString()
		{
			return Transaction.ToString();
		}
	}
}
