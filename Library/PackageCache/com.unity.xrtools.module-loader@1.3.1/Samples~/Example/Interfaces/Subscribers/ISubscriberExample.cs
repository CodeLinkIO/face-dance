using System;

namespace Unity.XRTools.ModuleLoader.Example
{
    /// <summary>
    /// Provides access to example functionality
    /// </summary>
    public interface ISubscriberExample : IFunctionalitySubscriber<IProviderExample>
    {
    }

    /// <summary>
    /// Extension methods for users of example functionality
    /// </summary>
    public static class SubscriberExampleMethods
    {
        /// <summary>
        /// An example method with multiple arguments
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="str1">Example argument</param>
        /// <param name="str2">Example argument</param>
        public static void ExampleMethod(this ISubscriberExample user, string str1, string str2)
        {
            user.provider.ExampleMethod(str1, str2);
        }

        /// <summary>
        /// Subscribe to the example action event
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="action">The action which will be subscribed to the provider event</param>
        public static void SubscribeToExampleAction(this ISubscriberExample user, Action action)
        {
            user.provider.ExampleAction += action;
        }

        /// <summary>
        /// Unsubscribe from the example action event
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="action">The action which will be unsubscribed from the provider action</param>
        public static void UnsubscribeFromExampleAction(this ISubscriberExample user, Action action)
        {
            user.provider.ExampleAction -= action;
        }

        /// <summary>
        /// Subscribe to the example Action event with an int argument
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider to use</param>
        /// <param name="action">The action which will be subscribed to the provider action</param>
        public static void SubscribeToExampleIntAction(this ISubscriberExample user, Action<int> action)
        {
            user.provider.ExampleIntAction += action;
        }

        /// <summary>
        /// Unsubscribe from the example Action event with an int argument
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="action">The action which will be unsubscribed from the provider action</param>
        public static void UnsubscribeFromExampleIntAction(this ISubscriberExample user, Action<int> action)
        {
            user.provider.ExampleIntAction += action;
        }

        /// <summary>
        /// Subscribe to the example Func event which returns a bool
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider to use</param>
        /// <param name="func">The action which will be subscribed to the provider function</param>
        public static void SubscribeToExampleFunc(this ISubscriberExample user, Func<bool> func)
        {
            user.provider.ExampleFunc += func;
        }

        /// <summary>
        /// Unsubscribe from the example Func event which returns a bool
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="func">The action which will be unsubscribed from the provider function</param>
        public static void UnsubscribeFromExampleFunc(this ISubscriberExample user, Func<bool> func)
        {
            user.provider.ExampleFunc -= func;
        }

        /// <summary>
        /// Subscribe to the example Func event which returns a bool and accepts an int as an argument
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider to use</param>
        /// <param name="func">The action which will be subscribed to the provider function</param>
        public static void SubscribeToExampleIntFunc(this ISubscriberExample user, Func<int, bool> func)
        {
            user.provider.ExampleIntFunc += func;
        }

        /// <summary>
        /// Unsubscribe from the example Func event which returns a bool and accepts an int as an argument
        /// </summary>
        /// <param name="user">The functionality subscriber whose provider will be used</param>
        /// <param name="func">The action which will be unsubscribed from the provider function</param>
        public static void UnsubscribeFromExampleIntFunc(this ISubscriberExample user, Func<int, bool> func)
        {
            user.provider.ExampleIntFunc -= func;
        }

        /// <summary>
        /// An example extension method in the same class as Functionality Injection extensions to test that it is not
        /// modified by code generation
        /// </summary>
        /// <param name="int1">Example argument</param>
        /// <param name="int2">Example argument</param>
        public static void ExampleExtension(this int int1, int int2)
        {
            // Just a test that this method isn't modified
        }
    }
}
