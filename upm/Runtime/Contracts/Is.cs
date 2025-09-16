using System;

namespace Moroshka.Protect
{

/// <summary>
/// Factory of predefined requirements and predicates for validations.
/// Used together with <c>Require(...)</c> extension methods.
/// </summary>
public abstract class Is
{
	/// <summary>
	/// Inversion of any requirement: <c>Not.X</c> means "not X".
	/// </summary>
	public static IRequirementExpression Not { get; } = new RequirementExpression();

	/// <summary>
	/// Value is <c>null</c>.
	/// </summary>
	public static IRequirement Null { get; } = new NullRequirement();

	/// <summary>
	/// String is <c>null</c> or empty.
	/// </summary>
	public static IStrRequirement NullOrEmpty { get; } = new NullOrEmptyRequirement();

	/// <summary>
	/// String is <c>null</c> or contains only whitespace characters.
	/// </summary>
	public static IStrRequirement NullOrWhiteSpace { get; } = new NullOrWhiteSpaceRequirement();

	/// <summary>
	/// Value is <see cref="float.NaN"/>.
	/// </summary>
	public static IFloatRequirement NaNf { get; } = new NanFRequirement();

	/// <summary>
	/// Value is <see cref="double.NaN"/>.
	/// </summary>
	public static IDoubleRequirement NaNd { get; } = new NanDRequirement();

	/// <summary>
	/// Boolean value is <c>true</c>.
	/// </summary>
	public static IBoolRequirement True { get; } = new TrueRequirement();

	/// <summary>
	/// Boolean value is <c>false</c>.
	/// </summary>
	public static IBoolRequirement False { get; } = new FalseRequirement();

	/// <summary>
	/// Collection is empty.
	/// </summary>
	public static IEnumerableRequirement CollectionEmpty { get; } = new CollectionEmptyRequirement();

	/// <summary>
	/// Object has the exact specified <see cref="Type"/>.
	/// </summary>
	public static IRequirement TypeOf(Type type) => new TypeOfRequirement(type);

	/// <summary>
	/// Object is exactly of type <typeparamref name="TExpected"/>.
	/// </summary>
	public static IRequirement TypeOf<TExpected>() => new TypeOfRequirement(typeof(TExpected));

	/// <summary>
	/// The specified type can be assigned to a variable of the given base/interface type.
	/// Equivalent to <c>type.IsAssignableFrom(actualType)</c>.
	/// </summary>
	public static IRequirement AssignableFrom(Type type) => new AssignableFromRequirement(type);

	/// <summary>
	/// Type <typeparamref name="TExpected"/> is assignable from the actual type.
	/// </summary>
	public static IRequirement AssignableFrom<TExpected>() => new AssignableFromRequirement(typeof(TExpected));

	/// <summary>
	/// The actual type can be assigned to a variable of the specified type.
	/// Equivalent to <c>actualType.IsAssignableTo(type)</c>.
	/// </summary>
	public static IRequirement AssignableTo(Type type) => new AssignableToRequirement(type);

	/// <summary>
	/// The actual type can be assigned to a variable of type <typeparamref name="TExpected"/>.
	/// </summary>
	public static IRequirement AssignableTo<TExpected>() => new AssignableToRequirement(typeof(TExpected));

	/// <summary>
	/// Equality with the expected value via <see cref="object.Equals(object, object)"/>.
	/// </summary>
	public static IRequirement EqualTo(object expected) => new EqualToRequirement(expected);

	/// <summary>
	/// Integer equals the expected value.
	/// </summary>
	public static IIntRequirement EqualTo(int expected) => new EqualToIntRequirement(expected);

	/// <summary>
	/// <see cref="float"/> value equals the expected one (exact comparison).
	/// </summary>
	public static IFloatRequirement EqualTo(float expected) => new EqualToFloatRequirement(expected);

	/// <summary>
	/// <see cref="double"/> value equals the expected one (exact comparison).
	/// </summary>
	public static IDoubleRequirement EqualTo(double expected) => new EqualToDoubleRequirement(expected);

	/// <summary>
	/// String equals the expected value.
	/// </summary>
	public static IStrRequirement EqualTo(string expected) => new EqualToStrRequirement(expected);

	/// <summary>
	/// Integer is within the range [min, max].
	/// </summary>
	public static IIntRequirement InRange(int min, int max) => new InRangeRequirement(min, max);

	/// <summary>
	/// <see cref="float"/> value is within the range [min, max].
	/// </summary>
	public static IFloatRequirement InRange(float min, float max) => new InRangeFRequirement(min, max);

	/// <summary>
	/// <see cref="double"/> value is within the range [min, max].
	/// </summary>
	public static IDoubleRequirement InRange(double min, double max) => new InRangeDRequirement(min, max);
}

}
