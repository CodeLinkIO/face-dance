using System;

namespace Unity.XRTools.ModuleLoader.Example
{
    /// <summary>
    /// An example functionality provider, used to test basic functionality
    /// </summary>
    public interface IProviderExample : IFunctionalityProvider
    {
        /// <summary>
        /// An example method with multiple arguments
        /// </summary>
        /// <param name="str1">Example argument</param>
        /// <param name="str2">Example argument</param>
        void ExampleMethod(string str1, string str2);

        /// <summary>
        /// An example Action event
        /// </summary>
        event Action ExampleAction;

        /// <summary>
        /// An example Action event with an int argument
        /// </summary>
        event Action<int> ExampleIntAction;

        /// <summary>
        /// An example Func event which returns a bool
        /// </summary>
        event Func<bool> ExampleFunc;

        /// <summary>
        /// An example Func event which returns a bool and accepts an int as an argument
        /// </summary>
        event Func<int, bool> ExampleIntFunc;
    }
}
