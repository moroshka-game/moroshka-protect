namespace Moroshka.Protect
{

internal sealed class NotStrRequirement : IStrRequirement
{
	private readonly IStrRequirement _requirement;

	public NotStrRequirement(IStrRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(string actual) => !_requirement.Validate(actual);
}

}