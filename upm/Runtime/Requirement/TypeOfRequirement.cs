using System;

namespace Moroshka.Protect
{

internal sealed class TypeOfRequirement : IRequirement
{
	private readonly Type _expectedType;

	public TypeOfRequirement(Type expectedType)
	{
		_expectedType = expectedType;
	}

	public bool Validate(object actual) => actual is not null && actual.GetType() == _expectedType;
}

}