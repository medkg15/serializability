using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serializability.Parsing.Tokens;

namespace Serializability.Parsing
{
	public interface IScheduleTokenizer
	{
		bool HasNext();
		Token Next { get; }
	}
}
