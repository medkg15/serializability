using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	/// <summary>
	/// Represents a process which can provide a Schedule to be analyzed.
	/// </summary>
	public interface IScheduleInput
	{
		/// <summary>
		/// The schedule to be analyzed.
		/// </summary>
		Schedule Schedule { get; }
	}
}
