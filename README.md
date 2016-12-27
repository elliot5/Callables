# Callables
Callabes are useful ways of storing, grouping and calling functions and actions in C#!

Use
------------

Using Callables is quite simple, here we have used the DLL and imported the package statically.
```cs
using static Callables.Callables;
```

You must add a callable before 'Invoking' it which will run the method. 

```cs
AddCallable("CallableName", (Action)CallableAction);
InvokeCallable("CallableName");
```

If you do not provide a name, it will automatically use the function name

```cs
AddCallable((Action)Woof);
InvokeCallable("Woof"); 

static void Woof()
{
    Console.WriteLine("Woof, Woof!");
}
```

When getting a value, you must provide a return type in the `InvokeCallable` and when adding a callable you must cast it to a `Func<>` with the last element being the return type and the ones before it being the parameter types. 

```cs
AddCallable("Under10", (Func<int, bool>)IsUnderTen);
bool result = InvokeCallable<bool>("Under10");                                                                     
static bool IsUnderTen(int number)
{
    if(number < 10)
    {
        return true;
    }
    return false;
}
```
