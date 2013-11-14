using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	public class TransactionStep
	{
		public Operation Operation { get; set; }

		public Transaction Transaction { get; set; }

		public Object Target { get; set; }

		public override string ToString()
		{
			return string.Format("{0}{1}({2})", Operation.Equals(Operation.Write) ? "w" : "r", Transaction.ID, Target);
		}
	}
}
