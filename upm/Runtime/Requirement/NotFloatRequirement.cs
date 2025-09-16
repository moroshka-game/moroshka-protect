namespace Moroshka.Protect
{

internal sealed class NotFloatRequirement : IFloatRequirement
{
	private readonly IFloatRequirement _requirement;

	public NotFloatRequirement(IFloatRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(float actual) => !_requirement.Validate(actual);
}

}