namespace Moroshka.Protect
{

internal sealed class NotRequirement : IRequirement
{
	private readonly IRequirement _requirement;

	public NotRequirement(IRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(object actual) => !_requirement.Validate(actual);
}

}