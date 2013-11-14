using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public class AllStepPairInspector : IStepPairInspector
	{
		public TransactionStepPair[] GetPairs(Schedule schedule)
		{
			var pairs = new List<TransactionStepPair>();

			for (var currentIndex = 0; currentIndex < schedule.Steps.Length; currentIndex++)
			{
				var current = schedule.Steps[currentIndex];
				
				// look through the previous steps (if any)
				for (var previousStep = currentIndex - 1; previousStep >= 0; previousStep--)
				{
					var previous = schedule.Steps[previousStep];

					if (Equals(previous.Target, current.Target))
					{
						if (Equals(previous.Transaction, current.Transaction))
						{
							continue;
						}

						if (previous.Operation.Equals(Operation.Write) || current.Operation.Equals(Operation.Write))
						{
							pairs.Add(new TransactionStepPair
							{
								FirstStep = previous,
								SecondStep = current
							});
						}
					}
				}
			}

			return pairs.ToArray();
		}
	}
}
