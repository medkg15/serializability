using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	class StringScheduleInput : IScheduleInput
	{
		private readonly ScheduleParser _parser;
		private readonly string _input;

		public StringScheduleInput(ScheduleParser parser, string input)
		{
			this._parser = parser;
			this._input = input;
		}

		public Schedule Schedule
		{
			get
			{
				return _parser.Parse(_input);
			}
		}
	}
}
