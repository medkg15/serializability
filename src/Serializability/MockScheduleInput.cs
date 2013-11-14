using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	public class MockScheduleInput : IScheduleInput
	{
		public Schedule Schedule
		{
			get
			{
				var targetX = "x";

				var trans1 = new Transaction()
				{
					ID = 1
				};

				var trans1Steps = new List<TransactionStep>
				{
					new TransactionStep()
					{
						Operation = Operation.Read,
						Transaction = trans1,
						Target = targetX
					}
				};

				trans1.Steps = trans1Steps;

				var trans2 = new Transaction()
				{
					ID = 2
				};

				var trans2Steps = new List<TransactionStep>
				{
					new TransactionStep()
					{
						Operation = Operation.Read,
						Transaction = trans2,
						Target = targetX
					},
					new TransactionStep()
					{
						Operation = Operation.Write,
						Transaction = trans2,
						Target = targetX
					}
				};

				trans2.Steps = trans2Steps;

				var trans3 = new Transaction()
				{
					ID = 3
				};

				var trans3Steps = new List<TransactionStep>
				{
					new TransactionStep
					{
						Operation = Operation.Read,
						Transaction = trans3,
						Target = targetX
					},
					new TransactionStep
					{
						Operation = Operation.Write,
						Transaction = trans3,
						Target = targetX
					}
				};

				trans3.Steps = trans3Steps;

				var schedule = new Schedule()
				{
					Steps = new TransactionStep[]
					{
						trans2Steps[0],
						trans3Steps[0],
						trans2Steps[1],
						trans1Steps[0],
						trans3Steps[1]
					}
				};

				return schedule;
			}
		}
	}
}
