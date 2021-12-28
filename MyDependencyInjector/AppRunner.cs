namespace MyDependencyInjector;

public static class AppRunner<T>
{
    public delegate void startingFunctionToInvoke(T instance, params object[] parameters);

    public static void Run(startingFunctionToInvoke func, IServiceProvider serviceProvider, object[] parameter){
        T? instance = (T?)serviceProvider.GetService(typeof(T));

        if(instance is null){
            throw new NullReferenceException($"The type {nameof(T)} or one of its dependencies was not registered.");
        }
        func(instance!, parameter);
    }
}