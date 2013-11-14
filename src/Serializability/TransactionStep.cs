using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	/// <summary>
	/// Represents a step in a transaction.  
	/// A step consists of an operation and a target object.
	/// The step belongs to a transaction.
	/// </summary>
	public class TransactionStep
	{
		public Operation Operation { get; set; }

		public Object Target { get; set; }

		public Transaction Transaction { get; set; }

		public override string ToString()
		{
			return string.Format("{0}{1}({2})", 
				Operation.Equals(Operation.Write) ? "w" : "r", Transaction.ID, Target);
		}
	}
}
