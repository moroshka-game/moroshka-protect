using System;
using Moroshka.Xcp;

namespace Moroshka.Protect
{

/// <summary>
/// Exception thrown when method preconditions/contracts are violated.
/// Contains diagnostic context: parameter name, context type, member, and call site.
/// </summary>
[Serializable]
public class RequireException : DetailedException
{
	private const string ParamKey = "Param";

	/// <summary>
	/// Creates an exception with a message and an optional inner exception.
	/// </summary>
	/// <param name="message">The message text.</param>
	/// <param name="innerException">The inner exception.</param>
	public RequireException(string message, Exception innerException = null)
		: base(message, innerException)
	{
		Code = "REQUIRE";
	}

	/// <summary>
	/// Creates an exception with the default message "Invalid argument value".
	/// </summary>
	/// <param name="innerException">The inner exception.</param>
	public RequireException(Exception innerException = null)
		: this("Invalid argument value", innerException)
	{
	}

	/// <summary>
	/// Name of the parameter whose value does not satisfy the requirement.
	/// </summary>
	public string Param
	{
		get => (string)Data[ParamKey];
		set => Data[ParamKey] = value;
	}
}

}
