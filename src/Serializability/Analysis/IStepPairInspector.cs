using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Analysis
{
	public interface IStepPairInspector
	{
		TransactionStepPair[] GetPairs(Schedule schedule);
	}
}
