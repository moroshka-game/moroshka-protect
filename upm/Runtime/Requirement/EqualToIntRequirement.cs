namespace Moroshka.Protect
{

internal sealed class EqualToIntRequirement : IIntRequirement
{
	private readonly int _expected;

	public EqualToIntRequirement(int expected)
	{
		_expected = expected;
	}

	public bool Validate(int actual) => actual == _expected;
}

}
