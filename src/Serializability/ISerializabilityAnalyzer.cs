using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	/// <summary>
	/// Represents an analyzation process which can determine whether or not 
	/// a given schedule is conflict serializable.
	/// </summary>
	public interface ISerializabilityAnalyzer
	{
		bool IsConflictSerializable(Schedule schedule);
	}
}