using System.Collections;

namespace Moroshka.Protect
{

/// <summary>
/// Contract for requirements that validate collections/enumerables.
/// </summary>
public interface IEnumerableRequirement
{
	/// <summary>
	/// Validates the collection against the requirement.
	/// </summary>
	/// <param name="actual">The collection to validate.</param>
	/// <returns><c>true</c> if the collection satisfies the requirement; otherwise <c>false</c>.</returns>
	bool Validate(IEnumerable actual);
}

}
