using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	/// <summary>
	/// Represents a transaction, which consists of a series of steps.
	/// </summary>
	public class Transaction
	{
		public Transaction()
		{
			this.Steps = new List<TransactionStep>();
		}

		public object ID { get; set; }

		public List<TransactionStep> Steps { get; set; }

		public override string ToString()
		{
			return ID.ToString();
		}
	}
}
