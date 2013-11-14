using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serializability.Parsing;

namespace Serializability
{
	/// <summary>
	/// Provides a Schedule based on a string, which will be parsed into a schedule with the given parser.
	/// </summary>
	public class StringScheduleInput : IScheduleInput
	{
		private readonly ScheduleParser _parser;
		private readonly string _input;
		private readonly Lazy<Schedule> _lazySchedule; 

		public StringScheduleInput(ScheduleParser parser, string input)
		{
			this._parser = parser;
			this._input = input;
			this._lazySchedule = new Lazy<Schedule>(() => _parser.Parse(input));
		}

		public Schedule Schedule
		{
			get
			{
				return _lazySchedule.Value;
			}
		}
	}
}
