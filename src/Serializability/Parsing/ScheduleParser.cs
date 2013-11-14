using System;
using System.Collections.Generic;
using System.Linq;

namespace Serializability.Parsing
{
	public class ScheduleParser : IStringScheduleParser
	{
		public Schedule Parse(string input)
		{
			// todo: this method handles both tokenization and parsing.  split into two.

			var stepsInput = input
				.Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries)
				.Where(i => !string.IsNullOrWhiteSpace(i));

			var steps = new List<TransactionStep>();
			var transactions = new Dictionary<Object, Transaction>();
			var targets = new List<object>();

			foreach (var stepInput in stepsInput)
			{
				var trimmedInput = stepInput.Trim();

				if (trimmedInput.Length <= 4)
				{
					throw new FormatException("Invalid step format: " + stepInput);
				}

				var operation = trimmedInput[0];

				var openParen = trimmedInput.IndexOf('(');

				var transaction = trimmedInput.Substring(1, openParen - 1);

				if (!transactions.ContainsKey(transaction))
				{
					transactions.Add(transaction, new Transaction
					{
						ID = transaction 
					});
				}

				var start = openParen + 1;

				var target = trimmedInput.Substring(start, trimmedInput.LastIndexOf(')') - start);

				if (!targets.Any(t => t.Equals(target)))
				{
					targets.Add(target);
				}

				var step = new TransactionStep()
				{
					Transaction = transactions[transaction],
					Operation = 'w'.Equals(char.ToLower(operation)) ? Operation.Write : Operation.Read,
					Target = targets.First(t => Equals(t, target))
				};

				transactions[transaction].Steps.Add(step);

				steps.Add(step);
			}

			return new Schedule()
			{
				Steps = steps.ToArray()
			};
		}
	}
}
