using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	public interface IScheduleAnalyzer
	{
		bool IsConflictSerializable(Schedule schedule);
	}
}
