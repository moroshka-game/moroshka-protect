using System;

namespace Moroshka.Protect
{

/// <summary>
/// Set of inverted requirements (<c>Not</c> variants) for argument validations.
/// </summary>
public interface IRequirementExpression
{
	/// <summary>
	/// Value is not <c>null</c>.
	/// </summary>
	IRequirement Null { get; }

	/// <summary>
	/// String is not <c>null</c> and not empty.
	/// </summary>
	IStrRequirement NullOrEmpty { get; }

	/// <summary>
	/// String is not <c>null</c> and contains non-whitespace characters.
	/// </summary>
	IStrRequirement NullOrWhiteSpace { get; }

	/// <summary>
	/// <see cref="float"/> value is not <see cref="float.NaN"/>.
	/// </summary>
	IFloatRequirement NaNf { get; }

	/// <summary>
	/// <see cref="double"/> value is not <see cref="double.NaN"/>.
	/// </summary>
	IDoubleRequirement NaNd { get; }

	/// <summary>
	/// Boolean value is not true.
	/// </summary>
	IBoolRequirement True { get; }

	/// <summary>
	/// Boolean value is not false.
	/// </summary>
	IBoolRequirement False { get; }

	/// <summary>
	/// Collection is not empty.
	/// </summary>
	IEnumerableRequirement CollectionEmpty { get; }

	/// <summary>
	/// Object is not of the exact specified type.
	/// </summary>
	IRequirement TypeOf(Type type);

	/// <summary>
	/// Object is not exactly of type <typeparamref name="TExpected"/>.
	/// </summary>
	IRequirement TypeOf<TExpected>();

	/// <summary>
	/// The object's type is not assignable to the specified type (inverse of <c>IsAssignableFrom</c>).
	/// </summary>
	IRequirement AssignableFrom(Type type);

	/// <summary>
	/// The object's type is not assignable to type <typeparamref name="TExpected"/>.
	/// </summary>
	IRequirement AssignableFrom<TExpected>();

	/// <summary>
	/// The object's type cannot be assigned to a variable of the specified type.
	/// </summary>
	IRequirement AssignableTo(Type type);

	/// <summary>
	/// The object's type cannot be assigned to a variable of type <typeparamref name="TExpected"/>.
	/// </summary>
	IRequirement AssignableTo<TExpected>();

	/// <summary>
	/// Object is not equal to the expected value.
	/// </summary>
	IRequirement EqualTo(object expected);

	/// <summary>
	/// Integer is not equal to the expected value.
	/// </summary>
	IIntRequirement EqualTo(int expected);

	/// <summary>
	/// <see cref="float"/> value is not equal to the expected value.
	/// </summary>
	IFloatRequirement EqualTo(float expected);

	/// <summary>
	/// <see cref="double"/> value is not equal to the expected value.
	/// </summary>
	IDoubleRequirement EqualTo(double expected);

	/// <summary>
	/// String is not equal to the expected value.
	/// </summary>
	IStrRequirement EqualTo(string expected);

	/// <summary>
	/// Integer is not within the range [min, max].
	/// </summary>
	IIntRequirement InRange(int min, int max);

	/// <summary>
	/// <see cref="float"/> value is not within the range [min, max].
	/// </summary>
	IFloatRequirement InRange(float min, float max);

	/// <summary>
	/// <see cref="double"/> value is not within the range [min, max].
	/// </summary>
	IDoubleRequirement InRange(double min, double max);
}

}
