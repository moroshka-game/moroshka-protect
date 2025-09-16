# Usage Instructions

`Moroshka.Protect` provides a system for validating arguments and states using contract requirements. The library prevents errors caused by invalid data by throwing exceptions with informative messages.

## Basic Principles

The system works through the `Require()` method extension, which takes:

- A context object for diagnostics
- A value to check
- A parameter name for error messages
- A requirement for validation

## Creating Requirements

All requirements are created through the static `Is` class:

```csharp
using Moroshka.Protect;

// Null checks
Is.Null

// String checks
Is.NullOrEmpty        // string is null or empty
Is.NullOrWhiteSpace   // string is null or contains only whitespace
Is.EqualTo("expected") // string equals expected value

// Number checks
Is.EqualTo(42)                    // number equals expected
Is.InRange(0, 100)                // number is in range [0, 100]
Is.NaNf                          // float is NaN
Is.NaNd                          // double is NaN

// Boolean checks
Is.True                          // value is true
Is.False                         // value is false

// Type checks
Is.TypeOf<string>()              // object has exact type
Is.AssignableTo<IDisposable>()   // type can be assigned to variable

// Collection checks
Is.CollectionEmpty               // collection is empty
```

## Inverted Requirements

Use `Is.Not` to create opposite requirements:

```csharp
Is.Not.Null                      // value is not null
Is.Not.NullOrEmpty               // string is not null and not empty
Is.Not.EqualTo("invalid")        // value is not equal to expected
Is.Not.InRange(0, 100)          // number is not in range
Is.Not.TypeOf<string>()         // object does not have specified type
```

## Usage Examples

### Method Parameter Validation

```csharp
public void ProcessUser(string name, int age, bool isActive)
{
    // Check that name is not null and not empty
    this.Require(name, nameof(name), Is.Not.NullOrEmpty);

    // Check that age is in valid range
    this.Require(age, nameof(age), Is.InRange(0, 150));

    // Check that user is active
    this.Require(isActive, nameof(isActive), Is.True);

    // Processing...
}
```

### Object State Validation

```csharp
public class Calculator
{
    private bool _initialized = false;

    public double Calculate(double value)
    {
        // Check that calculator is initialized
        this.Require(_initialized, nameof(_initialized), Is.True);

        // Check that value is not NaN
        this.Require(value, nameof(value), Is.Not.NaNd);

        return value * 2;
    }
}
```

### Collection Validation

```csharp
public void ProcessItems(List<string> items)
{
    // Check that list is not null and not empty
    this.Require(items, nameof(items), Is.Not.CollectionEmpty);

    // Process elements...
}
```

### Type Validation

```csharp
public void ProcessObject(object obj)
{
    // Check that object is not null
    this.Require(obj, nameof(obj), Is.Not.Null);

    // Check that object implements IDisposable
    this.Require(obj, nameof(obj), Is.AssignableTo<IDisposable>());

    // Safe type casting
    var disposable = (IDisposable)obj;
    disposable.Dispose();
}
```

## Error Handling

When a requirement is violated, a `RequireException` is thrown with detailed diagnostic information:

```csharp
try
{
    this.Require(someValue, nameof(someValue), Is.True);
}
catch (RequireException ex)
{
    // ex.Param contains parameter name
    // ex.Context contains context object type
    // ex.Member contains method name
    // ex.Line contains line number
    Console.WriteLine($"Error in {ex.Context}.{ex.Member} at line {ex.Line}: parameter '{ex.Param}' does not meet requirement");
}
```

## Recommendations

1. **Use `this` as context** for instance class methods
2. **Use class name** as context for static methods
3. **Use `nameof()`** for parameter names - this ensures refactoring safety
4. **Check critical parameters** at the beginning of methods
5. **Group checks** for better code readability

```csharp
public class UserService
{
    public void CreateUser(string email, string password, UserRole role)
    {
        // Group all checks at the beginning of the method
        this.Require(email, nameof(email), Is.Not.NullOrWhiteSpace);
        this.Require(password, nameof(password), Is.Not.NullOrEmpty);
        this.Require(role, nameof(role), Is.Not.Null);

        // Main logic...
    }
}
```
