using System;

namespace Moroshka.Protect
{

internal sealed class AssignableFromRequirement : IRequirement
{
	private readonly Type _expectedType;

	public AssignableFromRequirement(Type expectedType)
	{
		_expectedType = expectedType;
	}

	public bool Validate(object actual) => actual is not null && _expectedType.IsAssignableFrom(actual.GetType());
}

}
