using System.Collections;
using System.Runtime.CompilerServices;

namespace Moroshka.Protect
{

/// <summary>
/// Extensions for validating arguments and states using contract requirements.
/// Throws <see cref="RequireException"/> with diagnostic context when the requirement is not met.
/// </summary>
public static class RequireExtensions
{
	/// <summary>
	/// Validates a boolean value against a requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="value">Boolean value to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="requirement">Boolean requirement.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		bool value,
		string paramName,
		IBoolRequirement requirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (requirement.Validate(value)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates an arbitrary value against a requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="value">Value to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="requirement">Requirement for the value.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		object value,
		string paramName,
		IRequirement requirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (requirement.Validate(value)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates a string against a string requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="str">String to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="strRequirement">String requirement.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		string str,
		string paramName,
		IStrRequirement strRequirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (strRequirement.Validate(str)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates an integer against a requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="value">Integer value to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="requirement">Numeric requirement for <see cref="int"/>.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		int value,
		string paramName,
		IIntRequirement requirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (requirement.Validate(value)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates a floating-point number (float) against a requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="value">Value of type <see cref="float"/> to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="requirement">Numeric requirement for <see cref="float"/>.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		float value,
		string paramName,
		IFloatRequirement requirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (requirement.Validate(value)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates a floating-point number (double) against a requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="value">Value of type <see cref="double"/> to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="requirement">Numeric requirement for <see cref="double"/>.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		double value,
		string paramName,
		IDoubleRequirement requirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (requirement.Validate(value)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	/// <summary>
	/// Validates an enumerable/collection against a collection requirement.
	/// </summary>
	/// <param name="context">Context object for diagnostics.</param>
	/// <param name="enumerable">Collection to validate.</param>
	/// <param name="paramName">Parameter name for the error message.</param>
	/// <param name="enumerableRequirement">Requirement for collections.</param>
	/// <param name="member">Caller member name (filled automatically).</param>
	/// <param name="line">Caller line number (filled automatically).</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Require(
		this object context,
		IEnumerable enumerable,
		string paramName,
		IEnumerableRequirement enumerableRequirement,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (enumerableRequirement.Validate(enumerable)) return;
		ThrowArgNull(paramName, context, member, line);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ThrowArgNull(string paramName, object context, string member, int line)
	{
		throw new RequireException
		{
			Param = paramName,
			Context = context.GetType().Name,
			Member = member,
			Line = line.ToString()
		};
	}
}

}
