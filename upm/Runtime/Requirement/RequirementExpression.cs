using System;

namespace Moroshka.Protect
{

/// <summary>
/// Implementation of inverted requirements (<c>Not</c> variants) for validation expressions.
/// </summary>
public sealed class RequirementExpression : IRequirementExpression
{
	/// <inheritdoc />
	IRequirement IRequirementExpression.Null { get; } =
		new NotRequirement(
			new NullRequirement());

	/// <inheritdoc />
	IStrRequirement IRequirementExpression.NullOrEmpty { get; } =
		new NotStrRequirement(
			new NullOrEmptyRequirement());

	/// <inheritdoc />
	IStrRequirement IRequirementExpression.NullOrWhiteSpace { get; } =
		new NotStrRequirement(
			new NullOrWhiteSpaceRequirement());

	/// <inheritdoc />
	IFloatRequirement IRequirementExpression.NaNf { get; } =
		new NotFloatRequirement(
			new NanFRequirement());

	/// <inheritdoc />
	IDoubleRequirement IRequirementExpression.NaNd { get; } =
		new NotDoubleRequirement(
			new NanDRequirement());

	/// <inheritdoc />
	IBoolRequirement IRequirementExpression.True { get; } =
		new NotBoolRequirement(
			new TrueRequirement());

	/// <inheritdoc />
	IBoolRequirement IRequirementExpression.False { get; } =
		new NotBoolRequirement(
			new FalseRequirement());

	/// <inheritdoc />
	IEnumerableRequirement IRequirementExpression.CollectionEmpty { get; } =
		new NotEnumerableRequirement(
			new CollectionEmptyRequirement());

	/// <inheritdoc />
	IRequirement IRequirementExpression.TypeOf(Type type) =>
		new NotRequirement(
			new TypeOfRequirement(type));

	/// <inheritdoc />
	IRequirement IRequirementExpression.TypeOf<TExpected>() =>
		new NotRequirement(
			new TypeOfRequirement(typeof(TExpected)));

	/// <inheritdoc />
	IRequirement IRequirementExpression.AssignableFrom(Type type) =>
		new NotRequirement(
			new AssignableFromRequirement(type));

	/// <inheritdoc />
	IRequirement IRequirementExpression.AssignableFrom<TExpected>() =>
		new NotRequirement(
			new AssignableFromRequirement(typeof(TExpected)));

	/// <inheritdoc />
	IRequirement IRequirementExpression.AssignableTo(Type type) =>
		new NotRequirement(
			new AssignableToRequirement(type));

	/// <inheritdoc />
	IRequirement IRequirementExpression.AssignableTo<TExpected>() =>
		new NotRequirement(
			new AssignableToRequirement(typeof(TExpected)));

	/// <inheritdoc />
	IRequirement IRequirementExpression.EqualTo(object expected) =>
		new NotRequirement(
			new EqualToRequirement(expected));

	/// <inheritdoc />
	IIntRequirement IRequirementExpression.EqualTo(int expected) =>
		new NotIntRequirement(
			new EqualToIntRequirement(expected));

	/// <inheritdoc />
	IFloatRequirement IRequirementExpression.EqualTo(float expected) =>
		new NotFloatRequirement(
			new EqualToFloatRequirement(expected));

	/// <inheritdoc />
	IDoubleRequirement IRequirementExpression.EqualTo(double expected) =>
		new NotDoubleRequirement(
			new EqualToDoubleRequirement(expected));

	/// <inheritdoc />
	IStrRequirement IRequirementExpression.EqualTo(string expected) =>
		new NotStrRequirement(
			new EqualToStrRequirement(expected));

	/// <inheritdoc />
	IIntRequirement IRequirementExpression.InRange(int min, int max) =>
		new NotIntRequirement(
			new InRangeRequirement(min, max));

	/// <inheritdoc />
	IFloatRequirement IRequirementExpression.InRange(float min, float max) =>
		new NotFloatRequirement(
			new InRangeFRequirement(min, max));

	/// <inheritdoc />
	IDoubleRequirement IRequirementExpression.InRange(double min, double max) =>
		new NotDoubleRequirement(
			new InRangeDRequirement(min, max));
}

}
