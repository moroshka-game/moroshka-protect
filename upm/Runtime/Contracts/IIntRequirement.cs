namespace Moroshka.Protect
{

/// <summary>
/// Defines a requirement that validates an integer value.
/// </summary>
/// <remarks>
/// Implementations should return true when the provided value satisfies the specific rule.
/// </remarks>
public interface IIntRequirement
{
	/// <summary>
	/// Checks whether the provided value satisfies the requirement.
	/// </summary>
	/// <param name="actual">The integer value to validate.</param>
	/// <returns>True if the requirement is satisfied; otherwise, false.</returns>
	bool Validate(int actual);
}

}
