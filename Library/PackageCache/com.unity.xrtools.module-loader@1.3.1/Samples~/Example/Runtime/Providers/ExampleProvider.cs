using System;
using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    // ReSharper disable once UnusedMember.Global
    class ExampleProvider : MonoBehaviour, IProviderExample, IProviderExample2<int>
    {
        public event Action ExampleAction;
        public event Action<int> ExampleIntAction;
        public event Func<bool> ExampleFunc;
        public event Func<int, bool> ExampleIntFunc;

        public int ExampleProperty { get; set; }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProviderExample>(obj);
            this.TryConnectSubscriber<IProviderExample2<int>>(obj);
        }

        void Start()
        {
            if (ExampleAction != null)
                ExampleAction();

            if (ExampleIntAction != null)
                ExampleIntAction(3);

            if (ExampleFunc != null && ExampleFunc())
                Debug.Log("ExampleFunc returned true");

            if (ExampleFunc != null && ExampleIntFunc(42))
                Debug.Log("ExampleIntFunc returned true");
        }

        public void ExampleMethod(string str1, string str2)
        {
            Debug.Log(str1 + " " + str2);
        }

        public int ExampleMethod(int int1, int int2)
        {
            return int1 + int2;
        }

        public bool TryGetMethod(int input, out int output)
        {
            output = input + 3;
            return true;
        }

        public int ExampleGetter()
        {
            return 0;
        }

        void IFunctionalityProvider.LoadProvider()
        {
        }

        void IFunctionalityProvider.UnloadProvider()
        {
        }
    }
}
