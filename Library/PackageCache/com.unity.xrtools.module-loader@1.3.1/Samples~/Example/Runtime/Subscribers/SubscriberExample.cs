using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    class SubscriberExample : MonoBehaviour, ISubscriberExample, ISubscriberExample2<int>
    {
        IProviderExample IFunctionalitySubscriber<IProviderExample>.provider { get; set; }
        IProviderExample2<int> IFunctionalitySubscriber<IProviderExample2<int>>.provider { get; set; }

        void OnEnable()
        {
            this.SubscribeToExampleAction(ExampleAction);
            this.SubscribeToExampleIntAction(ExampleIntAction);
            this.SubscribeToExampleFunc(ExampleFunc);
            this.SubscribeToExampleIntFunc(ExampleIntFunc);
        }

        void Start()
        {
            this.ExampleMethod("Hello", "World");
            Debug.Log("Sum of 3 + 4 is: " + this.ExampleMethod(3, 4));
        }

        void OnDisable()
        {
            this.UnsubscribeFromExampleAction(ExampleAction);
            this.UnsubscribeFromExampleIntAction(ExampleIntAction);
            this.UnsubscribeFromExampleFunc(ExampleFunc);
            this.UnsubscribeFromExampleIntFunc(ExampleIntFunc);
        }

        static void ExampleAction()
        {
            Debug.Log("Example action invoked");
        }

        static void ExampleIntAction(int a)
        {
            Debug.Log("Example int action invoked with value " + a);
        }

        static bool ExampleFunc()
        {
            return true;
        }

        static bool ExampleIntFunc(int a)
        {
            return a == 42;
        }
    }
}
