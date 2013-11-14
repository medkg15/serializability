using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serializability.Parsing.Tokens;

namespace Serializability.Parsing
{
	public class ScheduleTokenizer : IScheduleTokenizer
	{
		private readonly string _input;
		private int _position;

		public ScheduleTokenizer(string input)
		{
			this._position = 0;
			this._input = input;
		}

		public bool HasNext()
		{
			throw new NotImplementedException();
		}

		public Tokens.Token Next
		{
			get
			{
				throw new NotImplementedException();

				var value = string.Empty;

				foreach (var character in _input)
				{
					if (_position == 0 && "rw".Contains(character))
					{
						return new Token(TokenType.Operation, character.ToString());
					}
				}
			}
		}
	}
}
