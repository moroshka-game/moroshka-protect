namespace Moroshka.Protect
{

internal sealed class EqualToDoubleRequirement : IDoubleRequirement
{
	private readonly double _expected;

	public EqualToDoubleRequirement(double expected)
	{
		_expected = expected;
	}

	public bool Validate(double actual)
	{
		if (double.IsNaN(_expected) || double.IsNaN(actual)) return false;
		return actual.Equals(_expected);
	}
}

}
