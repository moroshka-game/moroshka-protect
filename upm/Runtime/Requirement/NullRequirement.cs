namespace Moroshka.Protect
{

internal sealed class NullRequirement : IRequirement
{
	public bool Validate(object actual) => actual is null;
}

}