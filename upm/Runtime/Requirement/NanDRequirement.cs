namespace Moroshka.Protect
{

internal sealed class NanDRequirement : IDoubleRequirement
{
	public bool Validate(double actual) => double.IsNaN(actual);
}

}
