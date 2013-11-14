using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Parsing.Tokens
{
	public class Token
	{
		public Token(TokenType type, string value)
		{
			this.Type = type;
			this.Value = value;
		}

		public TokenType Type { get; private set; }
		public string Value { get; private set; }
	}
}
