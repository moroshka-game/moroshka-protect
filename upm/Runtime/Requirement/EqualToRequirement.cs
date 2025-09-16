namespace Moroshka.Protect
{

internal sealed class EqualToRequirement : IRequirement
{
	private readonly object _expected;

	public EqualToRequirement(object expected)
	{
		_expected = expected;
	}

	public bool Validate(object actual)
	{
		if (_expected == null && actual == null) return true;
		if (_expected == null || actual == null) return false;
		return Equals(actual, _expected);
	}
}

}
