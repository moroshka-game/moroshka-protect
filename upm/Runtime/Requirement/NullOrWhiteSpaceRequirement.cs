namespace Moroshka.Protect
{

internal sealed class NullOrWhiteSpaceRequirement : IStrRequirement
{
	public bool Validate(string actual) => string.IsNullOrWhiteSpace(actual);
}

}