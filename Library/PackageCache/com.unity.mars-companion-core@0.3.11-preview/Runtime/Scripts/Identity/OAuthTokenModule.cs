using System;
using System.Collections;

namespace Unity.MARS.Companion
{
    abstract class OAuthTokenModule : IMarsIdentity
    {
        static readonly string[] k_RandomCharactersTable =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
            "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8","9"
        };

        //TODO: Increase validity test coverage
        public virtual bool IsValid => !string.IsNullOrEmpty(Token);

        public abstract string Token { get; }
        public abstract IEnumerator SignIn(Action<bool> callback = null, string intent = "", bool onlyCached = false);
        public abstract void SignOut();

        protected string m_Token;

        /// <summary>
        /// Returns a random string that is compliant with the sign-in process
        /// </summary>
        /// <param name="stringLength"> Length of the generated string to be returned </param>
        protected static string CreateRandomString(int stringLength = 10) {
            var arrayLength = stringLength - 1;
            var randomString = "";
            var tableLength = k_RandomCharactersTable.Length;

            for (var i = 0; i <= arrayLength; i++)
            {
                randomString += k_RandomCharactersTable[UnityEngine.Random.Range(0, tableLength)];
            }

            return randomString;
        }
    }
}
