namespace Moroshka.Protect
{

internal sealed class EqualToFloatRequirement : IFloatRequirement
{
	private readonly float _expected;

	public EqualToFloatRequirement(float expected)
	{
		_expected = expected;
	}

	public bool Validate(float actual)
	{
		if (float.IsNaN(_expected) || float.IsNaN(actual)) return false;
		return actual.Equals(_expected);
	}
}

}
