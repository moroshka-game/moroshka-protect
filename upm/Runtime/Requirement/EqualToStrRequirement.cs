namespace Moroshka.Protect
{

internal sealed class EqualToStrRequirement : IStrRequirement
{
	private readonly string _expected;

	public EqualToStrRequirement(string expected)
	{
		_expected = expected;
	}

	public bool Validate(string actual)
	{
		if (_expected == null && actual == null) return true;
		if (_expected == null || actual == null) return false;
		return actual.Equals(_expected);
	}
}

}
