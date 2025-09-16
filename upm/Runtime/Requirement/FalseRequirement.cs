namespace Moroshka.Protect
{

internal sealed class FalseRequirement : IBoolRequirement
{
	public bool Validate(bool actual) => !actual;
}

}
