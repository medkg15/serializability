using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class TransactionStepPair
	{
		public TransactionStep FirstStep { get; set; }

		public TransactionStep SecondStep { get; set; }
	}
}
