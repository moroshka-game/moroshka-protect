namespace Moroshka.Protect
{

internal sealed class NotDoubleRequirement : IDoubleRequirement
{
	private readonly IDoubleRequirement _requirement;

	public NotDoubleRequirement(IDoubleRequirement requirement)
	{
		_requirement = requirement;
	}

	public bool Validate(double actual) => !_requirement.Validate(actual);
}

}