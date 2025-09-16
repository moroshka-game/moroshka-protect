using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Moroshka.Protect.Benchmark;

[MemoryDiagnoser]
[RankColumn]
[SuppressMessage("Performance", "CA1822")]
public class Benchmark
{
	private readonly object _obj = new();
	[Benchmark]
	public void Protect_System()
	{
		try
		{
			Require(_obj, nameof(_obj));
		}
		catch (Exception)
		{
			// ignored
		}
	}

	[Benchmark]
	public void Protect_Moroshka()
	{
		try
		{
			this.Require(_obj, nameof(_obj), Is.Null);
		}
		catch (Exception)
		{
			// ignored
		}
	}

	private static void Require(
		object value,
		string paramName,
		[CallerMemberName] string member = "",
		[CallerLineNumber] int line = 0)
	{
		if (value == null) return;
		ThrowArgNull(paramName, nameof(Benchmark), member, line);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ThrowArgNull(string paramName, object context, string member, int line)
	{
		throw new RequireException
		{
			Param = paramName,
			Context = context.GetType().Name,
			Member = member,
			Line = line.ToString()
		};
	}
}
