namespace Moroshka.Protect
{

internal sealed class TrueRequirement : IBoolRequirement
{
	public bool Validate(bool actual) => actual;
}

}
