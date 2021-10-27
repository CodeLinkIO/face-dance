using System;
using System.Collections;

namespace Unity.MARS.Companion
{
    /// <summary>
    /// Defines the API for a MarsIdentity Provider
    /// To be used with identity and authentication providers such as OAuth
    /// </summary>
    interface IMarsIdentity
    {
        /// <summary>
        /// Get the current state of the Credential
        /// </summary>
        /// <value>True if the credential is in good standing and within the expiration date, false otherwise.</value>
        bool IsValid { get; }

        /// <summary>
        /// Get the current authentication token
        /// </summary>
        string Token { get; }

        /// <summary>
        /// Start the sign-in process
        /// </summary>
        /// <param name="callback">Method to be called on completion</param>
        /// <param name="intent"> Species the intent string, for devices that do not support launching with intent (or debugging)</param>
        /// <param name="onlyCached">Only sign in if there is a cached intent--do not open login URL in browser</param>
        IEnumerator SignIn(Action<bool> callback = null, string intent = "", bool onlyCached = false);

        /// <summary>
        /// Sign out of the account and invalidate the credential
        /// </summary>
        void SignOut();
    }
}
