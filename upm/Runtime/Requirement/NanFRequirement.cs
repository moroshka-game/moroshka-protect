namespace Moroshka.Protect
{

internal sealed class NanFRequirement : IFloatRequirement
{
	public bool Validate(float actual) => float.IsNaN(actual);
}

}
