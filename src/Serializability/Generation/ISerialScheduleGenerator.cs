using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability.Generation
{
	public interface ISerialScheduleGenerator
	{
		Schedule GetSerialSchedule(Schedule originalSchedule);
	}
}
