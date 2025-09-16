namespace Moroshka.Protect
{

internal sealed class NotIntRequirement : IIntRequirement
{
	private readonly IIntRequirement _requirement;

	public NotIntRequirement(IIntRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(int actual) => !_requirement.Validate(actual);
}

}