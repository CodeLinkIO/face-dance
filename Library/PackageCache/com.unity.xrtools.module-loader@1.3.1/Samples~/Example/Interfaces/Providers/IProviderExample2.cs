namespace Unity.XRTools.ModuleLoader.Example
{
    /// <summary>
    /// Provide example functionality in a generic interface
    /// </summary>
    /// <typeparam name="T">The type returned by the example getter method</typeparam>
    public interface IProviderExample2<T> : IFunctionalityProvider
    {
        /// <summary>
        /// An example method
        /// </summary>
        /// <param name="int1">Example argument</param>
        /// <param name="int2">Example argument</param>
        /// <returns>An int value</returns>
        int ExampleMethod(int int1, int int2);

        /// <summary>
        /// An example method following the TryGet pattern
        /// </summary>
        /// <param name="input">Example input data</param>
        /// <param name="output">Example out parameter</param>
        /// <returns>True if the operation succeeded</returns>
        bool TryGetMethod(int input, out int output);

        /// <summary>
        /// An example getter
        /// </summary>
        /// <returns>An object of type T</returns>
        T ExampleGetter();

        /// <summary>
        /// An example property
        /// </summary>
        int ExampleProperty { get; set; }
    }
}
