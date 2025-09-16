using System;
using System.Collections;
using NUnit.Framework;

namespace Moroshka.Protect.Tests
{

public class RequiresTests
{
	private TextContext _context;

	[SetUp]
	public void SetUp()
	{
		_context = new TextContext();
	}

	[Test]
	public void Require_Null_NotException()
	{
		Assert.DoesNotThrow(() => _context.TestNull(null));
		Assert.DoesNotThrow(() => _context.TestNotNull(new object()));
		Assert.DoesNotThrow(() => _context.TestNullOrEmpty(null));
		Assert.DoesNotThrow(() => _context.TestNullOrEmpty(""));
		Assert.DoesNotThrow(() => _context.TestNotNullOrEmpty("test"));
		Assert.DoesNotThrow(() => _context.TestNullOrWhiteSpace(null));
		Assert.DoesNotThrow(() => _context.TestNullOrWhiteSpace(""));
		Assert.DoesNotThrow(() => _context.TestNullOrWhiteSpace("   "));
		Assert.DoesNotThrow(() => _context.TestNotNullOrWhiteSpace("test"));
		Assert.DoesNotThrow(() => _context.TestTypeOf(string.Empty));
		Assert.DoesNotThrow(() => _context.TestTypeOfGeneric(string.Empty));
		Assert.DoesNotThrow(() => _context.TestNotTypeOf(new object()));
		Assert.DoesNotThrow(() => _context.TestNotTypeOfGeneric(new object()));
		Assert.DoesNotThrow(() => _context.TestAssignableFrom(string.Empty));
		Assert.DoesNotThrow(() => _context.TestAssignableFromGeneric(string.Empty));
		Assert.DoesNotThrow(() => _context.TestNotAssignableFrom(new object()));
		Assert.DoesNotThrow(() => _context.TestNotAssignableFromGeneric(new object()));
		Assert.DoesNotThrow(() => _context.TestAssignableTo(string.Empty));
		Assert.DoesNotThrow(() => _context.TestAssignableToGeneric(string.Empty));
		Assert.DoesNotThrow(() => _context.TestNotAssignableTo(new object()));
		Assert.DoesNotThrow(() => _context.TestNotAssignableToGeneric(new object()));
		Assert.DoesNotThrow(() => _context.TestInRange(1));
		Assert.DoesNotThrow(() => _context.TestInRange(2));
		Assert.DoesNotThrow(() => _context.TestInRange(3));
		Assert.DoesNotThrow(() => _context.TestInRangeF(1f));
		Assert.DoesNotThrow(() => _context.TestInRangeF(2f));
		Assert.DoesNotThrow(() => _context.TestInRangeF(3f));
		Assert.DoesNotThrow(() => _context.TestInRangeD(1d));
		Assert.DoesNotThrow(() => _context.TestInRangeD(2d));
		Assert.DoesNotThrow(() => _context.TestInRangeD(3d));
		Assert.DoesNotThrow(() => _context.TestNotInRange(0));
		Assert.DoesNotThrow(() => _context.TestNotInRange(4));
		Assert.DoesNotThrow(() => _context.TestNotInRangeF(0.5f));
		Assert.DoesNotThrow(() => _context.TestNotInRangeF(3.5f));
		Assert.DoesNotThrow(() => _context.TestNotInRangeD(0.5d));
		Assert.DoesNotThrow(() => _context.TestNotInRangeD(3.5d));
		Assert.DoesNotThrow(() => _context.TestTrue(true));
		Assert.DoesNotThrow(() => _context.TestNotTrue(false));
		Assert.DoesNotThrow(() => _context.TestFalse(false));
		Assert.DoesNotThrow(() => _context.TestNotFalse(true));
		Assert.DoesNotThrow(() => _context.TestNaNf(float.NaN));
		Assert.DoesNotThrow(() => _context.TestNaNd(double.NaN));
		Assert.DoesNotThrow(() => _context.TestNotNaNf(0f));
		Assert.DoesNotThrow(() => _context.TestNotNaNd(0d));
		Assert.DoesNotThrow(() => _context.TestCollectionEmpty(Array.Empty<int>()));
		Assert.DoesNotThrow(() => _context.TestNotCollectionEmpty(new[] { 1 }));
		Assert.DoesNotThrow(() => _context.TestEqualToObject("abc"));
		Assert.DoesNotThrow(() => _context.TestEqualToString("hello"));
		Assert.DoesNotThrow(() => _context.TestEqualToInt(42));
		Assert.DoesNotThrow(() => _context.TestEqualToFloat(1.5f));
		Assert.DoesNotThrow(() => _context.TestEqualToDouble(2.5d));
		Assert.DoesNotThrow(() => _context.TestNotEqualToObject("zzz"));
		Assert.DoesNotThrow(() => _context.TestNotEqualToString("zzz"));
		Assert.DoesNotThrow(() => _context.TestNotEqualToInt(0));
		Assert.DoesNotThrow(() => _context.TestNotEqualToFloat(0.5f));
		Assert.DoesNotThrow(() => _context.TestNotEqualToDouble(0.5d));
		Assert.DoesNotThrow(() => _context.TestCollectionEmpty(new EmptyEnumerable()));
	}

	[Test]
	public void Require_NaNf_Exception()
	{
		try
		{
			_context.TestNaNf(0f);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNaNf)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NaNf_Exception()
	{
		try
		{
			_context.TestNotNaNf(float.NaN);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNaNf)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_NaNd_Exception()
	{
		try
		{
			_context.TestNaNd(0d);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNaNd)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NaNd_Exception()
	{
		try
		{
			_context.TestNotNaNd(double.NaN);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNaNd)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_True_Exception()
	{
		try
		{
			_context.TestTrue(false);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestTrue)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_True_Exception()
	{
		try
		{
			_context.TestNotTrue(true);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotTrue)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_False_Exception()
	{
		try
		{
			_context.TestFalse(true);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestFalse)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_False_Exception()
	{
		try
		{
			_context.TestNotFalse(false);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotFalse)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Null_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNull(new object());
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNull)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_Null_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNull(null);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNull)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_InRange_Int_Exception()
	{
		try
		{
			_context.TestInRange(0);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestInRange)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_InRange_Int_Exception()
	{
		try
		{
			_context.TestNotInRange(2);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotInRange)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_InRange_Float_Exception()
	{
		try
		{
			_context.TestInRangeF(0.5f);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestInRangeF)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_InRange_Float_Exception()
	{
		try
		{
			_context.TestNotInRangeF(2f);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotInRangeF)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_InRange_Double_Exception()
	{
		try
		{
			_context.TestInRangeD(0.5d);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestInRangeD)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_InRange_Double_Exception()
	{
		try
		{
			_context.TestNotInRangeD(2d);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotInRangeD)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_NullOrEmpty_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNullOrEmpty("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNullOrEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NullOrEmpty_Null_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNullOrEmpty(null);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNullOrEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NullOrEmpty_Empty_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNullOrEmpty(string.Empty);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNullOrEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_NullOrWhiteSpace_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNullOrWhiteSpace("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNullOrWhiteSpace)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NullOrWhiteSpace_Null_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNullOrWhiteSpace(null);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNullOrWhiteSpace)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NullOrWhiteSpace_Empty_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNullOrWhiteSpace(string.Empty);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNullOrWhiteSpace)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_NullOrWhiteSpace_White_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotNullOrWhiteSpace("   ");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotNullOrWhiteSpace)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_TypeOf_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestTypeOf(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestTypeOf)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_TypeOf_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestTypeOfGeneric(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestTypeOfGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_TypeOf_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotTypeOf("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotTypeOf)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_TypeOf_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotTypeOfGeneric("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotTypeOfGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_AssignableFrom_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestAssignableFrom(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestAssignableFrom)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_AssignableFrom_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestAssignableFromGeneric(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestAssignableFromGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_AssignableFrom_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotAssignableFrom("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotAssignableFrom)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_AssignableFrom_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotAssignableFromGeneric("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotAssignableFromGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_AssignableTo_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestAssignableTo(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestAssignableTo)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_AssignableTo_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestAssignableToGeneric(123);
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestAssignableToGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_AssignableTo_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotAssignableTo("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotAssignableTo)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_AssignableTo_Generic_Exception()
	{
		try
		{
			// Arrange & Act
			_context.TestNotAssignableToGeneric("test");
		}
		catch (RequireException ex)
		{
			// Assert
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotAssignableToGeneric)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_CollectionEmpty_Null_Exception()
	{
		try
		{
			_context.TestCollectionEmpty(null);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("collection"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestCollectionEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_CollectionEmpty_NotEmpty_Exception()
	{
		try
		{
			_context.TestCollectionEmpty(new[] { 1 });
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("collection"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestCollectionEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_CollectionEmpty_Empty_Exception()
	{
		try
		{
			_context.TestNotCollectionEmpty(Array.Empty<int>());
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("collection"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotCollectionEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_CollectionEmpty_IEnumerable_NotICollection_NotEmpty_Exception()
	{
		try
		{
			_context.TestCollectionEmpty(new SingleItemEnumerable());
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("collection"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestCollectionEmpty)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_EqualTo_Object_Exception()
	{
		try
		{
			_context.TestEqualToObject("zzz");
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestEqualToObject)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_EqualTo_String_Exception()
	{
		try
		{
			_context.TestEqualToString("zzz");
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestEqualToString)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_EqualTo_Int_Exception()
	{
		try
		{
			_context.TestEqualToInt(0);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestEqualToInt)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_EqualTo_Float_Exception()
	{
		try
		{
			_context.TestEqualToFloat(0.5f);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestEqualToFloat)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_EqualTo_Double_Exception()
	{
		try
		{
			_context.TestEqualToDouble(0.5d);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestEqualToDouble)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_EqualTo_Object_Exception()
	{
		try
		{
			_context.TestNotEqualToObject("abc");
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("obj"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotEqualToObject)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_EqualTo_String_Exception()
	{
		try
		{
			_context.TestNotEqualToString("hello");
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("str"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotEqualToString)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_EqualTo_Int_Exception()
	{
		try
		{
			_context.TestNotEqualToInt(42);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotEqualToInt)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_EqualTo_Float_Exception()
	{
		try
		{
			_context.TestNotEqualToFloat(1.5f);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotEqualToFloat)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	[Test]
	public void Require_Not_EqualTo_Double_Exception()
	{
		try
		{
			_context.TestNotEqualToDouble(2.5d);
		}
		catch (RequireException ex)
		{
			Assert.That(ex.Param, NUnit.Framework.Is.EqualTo("value"));
			Assert.That(ex.Context, NUnit.Framework.Is.EqualTo(_context.GetType().Name));
			Assert.That(ex.Member, NUnit.Framework.Is.EqualTo(nameof(TextContext.TestNotEqualToDouble)));
			Assert.That(ex.Line, NUnit.Framework.Is.Not.Null.Or.Empty);
			return;
		}

		Assert.Fail("No exception thrown");
	}

	#region Nested

	private sealed class TextContext
	{
		public void TestCollectionEmpty(IEnumerable collection)
		{
			this.Require(collection, nameof(collection), Is.CollectionEmpty);
		}

		public void TestNotCollectionEmpty(IEnumerable collection)
		{
			this.Require(collection, nameof(collection), Is.Not.CollectionEmpty);
		}
		public void TestNull(object obj)
		{
			this.Require(obj, nameof(obj), Is.Null);
		}

		public void TestEqualToObject(object obj)
		{
			this.Require(obj, nameof(obj), Is.EqualTo((object)"abc"));
		}

		public void TestEqualToString(string str)
		{
			this.Require(str, nameof(str), Is.EqualTo("hello"));
		}

		public void TestEqualToInt(int value)
		{
			this.Require(value, nameof(value), Is.EqualTo(42));
		}

		public void TestEqualToFloat(float value)
		{
			this.Require(value, nameof(value), Is.EqualTo(1.5f));
		}

		public void TestEqualToDouble(double value)
		{
			this.Require(value, nameof(value), Is.EqualTo(2.5d));
		}

		public void TestNotEqualToObject(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.EqualTo((object)"abc"));
		}

		public void TestNotEqualToString(string str)
		{
			this.Require(str, nameof(str), Is.Not.EqualTo("hello"));
		}

		public void TestNotEqualToInt(int value)
		{
			this.Require(value, nameof(value), Is.Not.EqualTo(42));
		}

		public void TestNotEqualToFloat(float value)
		{
			this.Require(value, nameof(value), Is.Not.EqualTo(1.5f));
		}

		public void TestNotEqualToDouble(double value)
		{
			this.Require(value, nameof(value), Is.Not.EqualTo(2.5d));
		}

		public void TestNotNull(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.Null);
		}

		public void TestNullOrEmpty(string str)
		{
			this.Require(str, nameof(str), Is.NullOrEmpty);
		}

		public void TestNotNullOrEmpty(string str)
		{
			this.Require(str, nameof(str), Is.Not.NullOrEmpty);
		}

		public void TestNullOrWhiteSpace(string str)
		{
			this.Require(str, nameof(str), Is.NullOrWhiteSpace);
		}

		public void TestNotNullOrWhiteSpace(string str)
		{
			this.Require(str, nameof(str), Is.Not.NullOrWhiteSpace);
		}

		public void TestTypeOf(object obj)
		{
			this.Require(obj, nameof(obj), Is.TypeOf(typeof(string)));
		}

		public void TestTypeOfGeneric<T>(T obj)
		{
			this.Require(obj, nameof(obj), Is.TypeOf<string>());
		}

		public void TestNotTypeOf(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.TypeOf(typeof(string)));
		}

		public void TestNotTypeOfGeneric(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.TypeOf<string>());
		}

		public void TestAssignableFrom(object obj)
		{
			this.Require(obj, nameof(obj), Is.AssignableFrom(typeof(string)));
		}

		public void TestAssignableFromGeneric<T>(T obj)
		{
			this.Require(obj, nameof(obj), Is.AssignableFrom<string>());
		}

		public void TestNotAssignableFrom(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.AssignableFrom(typeof(string)));
		}

		public void TestNotAssignableFromGeneric(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.AssignableFrom<string>());
		}

		public void TestAssignableTo(object obj)
		{
			this.Require(obj, nameof(obj), Is.AssignableTo(typeof(string)));
		}

		public void TestAssignableToGeneric<T>(T obj)
		{
			this.Require(obj, nameof(obj), Is.AssignableTo<string>());
		}

		public void TestNotAssignableTo(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.AssignableTo(typeof(string)));
		}

		public void TestNotAssignableToGeneric(object obj)
		{
			this.Require(obj, nameof(obj), Is.Not.AssignableTo<string>());
		}

		public void TestInRange(int value)
		{
			this.Require(value, nameof(value), Is.InRange(1, 3));
		}

		public void TestNotInRange(int value)
		{
			this.Require(value, nameof(value), Is.Not.InRange(1, 3));
		}

		public void TestInRangeF(float value)
		{
			this.Require(value, nameof(value), Is.InRange(1f, 3f));
		}

		public void TestNotInRangeF(float value)
		{
			this.Require(value, nameof(value), Is.Not.InRange(1f, 3f));
		}

		public void TestInRangeD(double value)
		{
			this.Require(value, nameof(value), Is.InRange(1d, 3d));
		}

		public void TestNotInRangeD(double value)
		{
			this.Require(value, nameof(value), Is.Not.InRange(1d, 3d));
		}

		public void TestTrue(bool value)
		{
			this.Require(value, nameof(value), Is.True);
		}

		public void TestNotTrue(bool value)
		{
			this.Require(value, nameof(value), Is.Not.True);
		}

		public void TestFalse(bool value)
		{
			this.Require(value, nameof(value), Is.False);
		}

		public void TestNotFalse(bool value)
		{
			this.Require(value, nameof(value), Is.Not.False);
		}

		public void TestNaNf(float value)
		{
			this.Require(value, nameof(value), Is.NaNf);
		}

		public void TestNaNd(double value)
		{
			this.Require(value, nameof(value), Is.NaNd);
		}

		public void TestNotNaNf(float value)
		{
			this.Require(value, nameof(value), Is.Not.NaNf);
		}

		public void TestNotNaNd(double value)
		{
			this.Require(value, nameof(value), Is.Not.NaNd);
		}
	}

	private sealed class EmptyEnumerable : IEnumerable
	{
		public IEnumerator GetEnumerator() => new EmptyEnumerator();

		private sealed class EmptyEnumerator : IEnumerator
		{
			public bool MoveNext() => false;
			public void Reset() { }
			public object Current => null;
		}
	}

	private sealed class SingleItemEnumerable : IEnumerable
	{
		public IEnumerator GetEnumerator() => new SingleItemEnumerator();

		private sealed class SingleItemEnumerator : IEnumerator
		{
			private int _state;

			public bool MoveNext()
			{
				if (_state != 0) return false;
				Current = 1;
				_state = 1;
				return true;
			}

			public void Reset()
			{
				_state = 0;
				Current = null;
			}

			public object Current { get; private set; }
		}
	}

	#endregion
}

}
