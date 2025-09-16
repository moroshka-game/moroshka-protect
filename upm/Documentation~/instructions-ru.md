# Инструкции по использованию

`Moroshka.Protect` предоставляет систему валидации аргументов и состояний с использованием контрактных требований. Библиотека предотвращает ошибки, вызванные недопустимыми данными, выбрасывая исключения с информативными сообщениями.

## Основные принципы

Система работает через расширения метода `Require()`, который принимает:

- Контекстный объект для диагностики
- Значение для проверки
- Имя параметра для сообщения об ошибке
- Требование для валидации

## Создание требований

Все требования создаются через статический класс `Is`:

```csharp
using Moroshka.Protect;

// Проверка на null
Is.Null

// Проверка строк
Is.NullOrEmpty        // строка null или пустая
Is.NullOrWhiteSpace   // строка null или содержит только пробелы
Is.EqualTo("expected") // строка равна ожидаемому значению

// Проверка чисел
Is.EqualTo(42)                    // число равно ожидаемому
Is.InRange(0, 100)                // число в диапазоне [0, 100]
Is.NaNf                          // float является NaN
Is.NaNd                          // double является NaN

// Проверка булевых значений
Is.True                          // значение true
Is.False                         // значение false

// Проверка типов
Is.TypeOf<string>()              // объект имеет точный тип
Is.AssignableTo<IDisposable>()   // тип можно присвоить переменной

// Проверка коллекций
Is.CollectionEmpty               // коллекция пустая
```

## Инвертированные требования

Используйте `Is.Not` для создания противоположных требований:

```csharp
Is.Not.Null                      // значение не null
Is.Not.NullOrEmpty               // строка не null и не пустая
Is.Not.EqualTo("invalid")        // значение не равно ожидаемому
Is.Not.InRange(0, 100)          // число не в диапазоне
Is.Not.TypeOf<string>()         // объект не имеет указанный тип
```

## Примеры использования

### Валидация параметров методов

```csharp
public void ProcessUser(string name, int age, bool isActive)
{
    // Проверяем, что имя не null и не пустое
    this.Require(name, nameof(name), Is.Not.NullOrEmpty);

    // Проверяем, что возраст в допустимом диапазоне
    this.Require(age, nameof(age), Is.InRange(0, 150));

    // Проверяем, что пользователь активен
    this.Require(isActive, nameof(isActive), Is.True);

    // Обработка...
}
```

### Валидация состояний объектов

```csharp
public class Calculator
{
    private bool _initialized = false;

    public double Calculate(double value)
    {
        // Проверяем, что калькулятор инициализирован
        this.Require(_initialized, nameof(_initialized), Is.True);

        // Проверяем, что значение не NaN
        this.Require(value, nameof(value), Is.Not.NaNd);

        return value * 2;
    }
}
```

### Валидация коллекций

```csharp
public void ProcessItems(List<string> items)
{
    // Проверяем, что список не null и не пустой
    this.Require(items, nameof(items), Is.Not.CollectionEmpty);

    // Обработка элементов...
}
```

### Валидация типов

```csharp
public void ProcessObject(object obj)
{
    // Проверяем, что объект не null
    this.Require(obj, nameof(obj), Is.Not.Null);

    // Проверяем, что объект реализует IDisposable
    this.Require(obj, nameof(obj), Is.AssignableTo<IDisposable>());

    // Безопасное приведение типа
    var disposable = (IDisposable)obj;
    disposable.Dispose();
}
```

## Обработка ошибок

При нарушении требования выбрасывается `RequireException` с подробной диагностической информацией:

```csharp
try
{
    this.Require(someValue, nameof(someValue), Is.True);
}
catch (RequireException ex)
{
    // ex.Param содержит имя параметра
    // ex.Context содержит тип контекстного объекта
    // ex.Member содержит имя метода
    // ex.Line содержит номер строки
    Console.WriteLine($"Ошибка в {ex.Context}.{ex.Member} на строке {ex.Line}: параметр '{ex.Param}' не соответствует требованию");
}
```

## Рекомендации

1. **Используйте `this` как контекст** для методов экземпляра класса
2. **Используйте имя класса** как контекст для статических методов
3. **Используйте `nameof()`** для имен параметров - это обеспечивает рефакторинг-безопасность
4. **Проверяйте критические параметры** в начале методов
5. **Группируйте проверки** для лучшей читаемости кода

```csharp
public class UserService
{
    public void CreateUser(string email, string password, UserRole role)
    {
        // Группируем все проверки в начале метода
        this.Require(email, nameof(email), Is.Not.NullOrWhiteSpace);
        this.Require(password, nameof(password), Is.Not.NullOrEmpty);
        this.Require(role, nameof(role), Is.Not.Null);

        // Основная логика...
    }
}
```
