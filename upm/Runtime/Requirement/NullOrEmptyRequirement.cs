namespace Moroshka.Protect
{

internal sealed class NullOrEmptyRequirement : IStrRequirement
{
	public bool Validate(string actual) => string.IsNullOrEmpty(actual);
}

}