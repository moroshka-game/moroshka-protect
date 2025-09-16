namespace Moroshka.Protect
{

/// <summary>
/// Defines a requirement that validates a string value.
/// </summary>
/// <remarks>
/// Implementations should return true when the provided string satisfies the specific rule.
/// </remarks>
public interface IStrRequirement
{
	/// <summary>
	/// Checks whether the provided value satisfies the requirement.
	/// </summary>
	/// <param name="actual">The string value to validate.</param>
	/// <returns>True if the requirement is satisfied; otherwise, false.</returns>
	bool Validate(string actual);
}

}
