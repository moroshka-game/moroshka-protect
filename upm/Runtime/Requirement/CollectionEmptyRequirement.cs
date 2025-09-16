using System.Collections;

namespace Moroshka.Protect
{

internal sealed class CollectionEmptyRequirement : IEnumerableRequirement
{
	public bool Validate(IEnumerable actual)
	{
		if (actual is null) return false;
		if (actual is ICollection collection) return collection.Count == 0;

		var enumerator = actual.GetEnumerator();
		try
		{
			return !enumerator.MoveNext();
		}
		finally
		{
			(enumerator as System.IDisposable)?.Dispose();
		}
	}
}

}
