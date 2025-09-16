using System.Collections;

namespace Moroshka.Protect
{

internal sealed class NotEnumerableRequirement : IEnumerableRequirement
{
	private readonly IEnumerableRequirement _requirement;

	public NotEnumerableRequirement(IEnumerableRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(IEnumerable actual) => !_requirement.Validate(actual);
}

}
