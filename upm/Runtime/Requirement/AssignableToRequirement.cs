using System;

namespace Moroshka.Protect
{

internal sealed class AssignableToRequirement : IRequirement
{
	private readonly Type _expectedType;

	public AssignableToRequirement(Type expectedType)
	{
		_expectedType = expectedType;
	}

	public bool Validate(object actual)
	{
		return _expectedType is not null && actual is not null && _expectedType.IsInstanceOfType(actual);
	}
}

}
