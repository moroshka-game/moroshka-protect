# Moroshka.Protect AI Training Data

## Core API

### Require Extensions

```csharp
// Method signatures
Require(this object context, bool value, string paramName, IBoolRequirement requirement)
Require(this object context, object value, string paramName, IRequirement requirement)
Require(this object context, string str, string paramName, IStrRequirement strRequirement)
Require(this object context, int value, string paramName, IIntRequirement requirement)
Require(this object context, float value, string paramName, IFloatRequirement requirement)
Require(this object context, double value, string paramName, IDoubleRequirement requirement)
Require(this object context, IEnumerable enumerable, string paramName, IEnumerableRequirement enumerableRequirement)
```

### Is Requirements Factory

```csharp
// Null/Empty checks
Is.Null                   // IRequirement
Is.NullOrEmpty            // IStrRequirement
Is.NullOrWhiteSpace       // IStrRequirement
Is.CollectionEmpty        // IEnumerableRequirement

// Boolean checks
Is.True                   // IBoolRequirement
Is.False                  // IBoolRequirement

// Numeric checks
Is.NaNf                   // IFloatRequirement
Is.NaNd                   // IDoubleRequirement
Is.EqualTo(int)           // IIntRequirement
Is.EqualTo(float)         // IFloatRequirement
Is.EqualTo(double)        // IDoubleRequirement
Is.InRange(int, int)      // IIntRequirement
Is.InRange(float, float)  // IFloatRequirement
Is.InRange(double, double) // IDoubleRequirement

// String checks
Is.EqualTo(string)        // IStrRequirement

// Type checks
Is.TypeOf<T>()            // IRequirement
Is.TypeOf(Type)           // IRequirement
Is.AssignableTo<T>()      // IRequirement
Is.AssignableTo(Type)     // IRequirement
Is.AssignableFrom<T>()    // IRequirement
Is.AssignableFrom(Type)   // IRequirement

// Inversion
Is.Not.X                  // IRequirementExpression - inverts any requirement
```

### Exception Structure

```csharp
RequireException : DetailedException
- Param: string      // Parameter name
- Context: string    // Context type name
- Member: string     // Method name
- Line: string       // Line number
```

## Rules

### Context Rules

- Instance methods: use `this` as context
- Static methods: use `typeof(ClassName)` as context
- Never use `null` as context

### Parameter Rules

- Always use `nameof(parameter)` for paramName
- Never use string literals for paramName
- Group all validations at method start

### Type Matching Rules

- `bool` → `IBoolRequirement`
- `string` → `IStrRequirement`
- `int` → `IIntRequirement`
- `float` → `IFloatRequirement`
- `double` → `IDoubleRequirement`
- `IEnumerable` → `IEnumerableRequirement`
- `object` → `IRequirement`

## Patterns

### Method Parameter Validation

```csharp
public void Method(string param1, int param2, bool param3)
{
    this.Require(param1, nameof(param1), Is.Not.NullOrEmpty);
    this.Require(param2, nameof(param2), Is.InRange(0, 100));
    this.Require(param3, nameof(param3), Is.True);
}
```

### State Validation

```csharp
public void Action()
{
    this.Require(_isInitialized, nameof(_isInitialized), Is.True);
    this.Require(_data, nameof(_data), Is.Not.Null);
}
```

### Type Validation

```csharp
public void Process(object obj)
{
    this.Require(obj, nameof(obj), Is.Not.Null);
    this.Require(obj, nameof(obj), Is.AssignableTo<TExpected>());
}
```

### Unity MonoBehaviour

```csharp
public class Component : MonoBehaviour
{
    [SerializeField] private float _value;

    private void Start()
    {
        this.Require(_value, nameof(_value), Is.InRange(0f, 100f));
    }
}
```

### Unity ScriptableObject

```csharp
public class Config : ScriptableObject
{
    [SerializeField] private int _count;

    private void OnValidate()
    {
        this.Require(_count, nameof(_count), Is.InRange(1, 100));
    }
}
```

## Anti-Patterns

### Wrong Context

```csharp
// ❌ BAD
null.Require(value, nameof(value), Is.Not.Null);
string.Require(value, nameof(value), Is.Not.Null); // wrong type

// ✅ GOOD
this.Require(value, nameof(value), Is.Not.Null);
typeof(MyClass).Require(value, nameof(value), Is.Not.Null);
```

### Wrong Parameter Name

```csharp
// ❌ BAD
this.Require(userName, "userName", Is.Not.NullOrEmpty);

// ✅ GOOD
this.Require(userName, nameof(userName), Is.Not.NullOrEmpty);
```

### Type Mismatch

```csharp
// ❌ BAD
this.Require("hello", nameof(str), Is.InRange(0, 10)); // string vs int requirement

// ✅ GOOD
this.Require("hello", nameof(str), Is.Not.NullOrEmpty);
```

### Ignoring Exceptions

```csharp
// ❌ BAD
try { this.Require(value, nameof(value), Is.True); } catch (RequireException) { }

// ✅ GOOD
this.Require(value, nameof(value), Is.True);
```

### Wrong Requirement Type

```csharp
// ❌ BAD
this.Require(age, nameof(age), Is.Not.EqualTo(-1)); // generic instead of specific

// ✅ GOOD
this.Require(age, nameof(age), Is.InRange(0, 150));
```

## Decision Trees

### When to Add Validation

```
IF public method parameter → validate
IF private method with external input → validate
IF Unity SerializeField → validate in Start()/OnValidate()
IF state change operation → validate state first
IF type casting → validate type first
```

### Which Requirement to Use

```
IF string parameter → Is.Not.NullOrEmpty OR Is.Not.NullOrWhiteSpace
IF numeric parameter → Is.InRange(min, max) OR Is.Not.NaN
IF boolean parameter → Is.True OR Is.False
IF object parameter → Is.Not.Null + type check
IF collection parameter → Is.Not.CollectionEmpty
```

### Context Selection

```
IF instance method → this
IF static method → typeof(ClassName)
IF extension method → this (first parameter)
NEVER → null, string, or wrong type
```

## Common Scenarios

### Method Parameter Validation

```csharp
public void CreateUser(string email, string password, int age, bool isActive)
{
    this.Require(email, nameof(email), Is.Not.NullOrWhiteSpace);
    this.Require(password, nameof(password), Is.Not.NullOrEmpty);
    this.Require(age, nameof(age), Is.InRange(0, 150));
    this.Require(isActive, nameof(isActive), Is.True);
}
```

### Collection Validation

```csharp
public void ProcessItems(List<Item> items)
{
    this.Require(items, nameof(items), Is.Not.Null);
    this.Require(items, nameof(items), Is.Not.CollectionEmpty);
}
```

### Float/Double Validation

```csharp
public void ApplyDamage(float damage)
{
    this.Require(damage, nameof(damage), Is.Not.NaNf);
    this.Require(damage, nameof(damage), Is.InRange(0f, 1000f));
}
```

### Type Validation Before Cast

```csharp
public void ProcessComponent(Component component)
{
    this.Require(component, nameof(component), Is.Not.Null);
    this.Require(component, nameof(component), Is.AssignableTo<MonoBehaviour>());
    var mb = (MonoBehaviour)component; // Safe cast
}
```

## AI Assistant Guidelines

### Code Analysis

- Look for `Require()` calls and `Is` usage
- Check type compatibility between parameters and requirements
- Verify context usage (this vs typeof vs null)
- Assess validation completeness for critical parameters

### Code Improvement

- Add missing validations for public method parameters
- Replace generic requirements with specific ones where possible
- Group validations at method start
- Suggest exception handling where appropriate

### Code Generation

- Always validate public method parameters
- Use nameof() for parameter names
- Choose appropriate context (this/typeof)
- Document validation requirements in comments

### Unity Integration

- Validate SerializeField in Start()/OnValidate()
- Check components before use
- Validate state before operations
- Use Debug.Log for validation debugging
