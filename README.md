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
