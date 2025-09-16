namespace Moroshka.Protect
{

internal sealed class InRangeFRequirement : IFloatRequirement
{
	private readonly float _min;
	private readonly float _max;

	public InRangeFRequirement(float min, float max)
	{
		_min = min;
		_max = max;
	}

	public bool Validate(float actual) => actual >= _min && actual <= _max;
}

}