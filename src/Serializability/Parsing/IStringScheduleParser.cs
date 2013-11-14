namespace Serializability.Parsing
{
	/// <summary>
	/// A parser which is capable of converting a string containing 
	/// a schedule to a schedule object.
	/// </summary>
	public interface IStringScheduleParser
	{
		Schedule Parse(string input);
	}
}