namespace Moroshka.Protect
{

internal sealed class NotBoolRequirement : IBoolRequirement
{
	private readonly IBoolRequirement _requirement;

	public NotBoolRequirement(IBoolRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(bool actual) => !_requirement.Validate(actual);
}

}
