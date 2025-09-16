namespace Moroshka.Protect
{

/// <summary>
/// Defines a generic requirement that validates an object value.
/// </summary>
/// <remarks>
/// Implementations should ensure type-safety internally and return true when the provided value satisfies the rule.
/// </remarks>
public interface IRequirement
{
	/// <summary>
	/// Checks whether the provided value satisfies the requirement.
	/// </summary>
	/// <param name="actual">The value to validate.</param>
	/// <returns>True if the requirement is satisfied; otherwise, false.</returns>
	bool Validate(object actual);
}

}
