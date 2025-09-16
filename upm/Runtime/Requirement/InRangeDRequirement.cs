namespace Moroshka.Protect
{

internal sealed class InRangeDRequirement : IDoubleRequirement
{
	private readonly double _min;
	private readonly double _max;

	public InRangeDRequirement(double min, double max)
	{
		_min = min;
		_max = max;
	}

	public bool Validate(double actual) => actual >= _min && actual <= _max;
}

}


