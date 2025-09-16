namespace Moroshka.Protect
{

internal sealed class InRangeRequirement : IIntRequirement
{
	private readonly int _min;
	private readonly int _max;

	public InRangeRequirement(int min, int max)
	{
		_min = min;
		_max = max;
	}

	public bool Validate(int actual) => actual >= _min && actual <= _max;
}

}