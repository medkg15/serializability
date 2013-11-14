using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializability
{
	/// <summary>
	/// Enumerates the types of operations a transaction can perform on an object.
	/// </summary>
	public enum Operation
	{
		Read,
		Write
	}
}
