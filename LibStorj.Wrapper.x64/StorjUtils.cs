using LibStorj.Wrapper.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper
{
    /// <summary>
    /// Contains utility-methods for Storj
    /// </summary>
    public class StorjUtils : IStorjUtils
    {
        /// <summary>
        /// Checks if the given mnemonic is valid
        /// </summary>
        /// <param name="mnemonic">The mnemonic to check</param>
        /// <returns>True, if the mnemonic is valid; false, if not</returns>
        public bool CheckMnemonic(string mnemonic)
        {
            return io.storj.libstorj.Storj.checkMnemonic(mnemonic);
        }

        /// <summary>
        /// This will generate a new random mnemonic with 128 to 256 bits of entropy.
        /// </summary>
        /// <param name="strength">The bits of entropy (128 or 256)</param>
        /// <returns>The generated mnemonic - a 12 or 24 word mnemonic</returns>
        public string GenerateMnemonic(int strength)
        {
            return io.storj.libstorj.Storj.generateMnemonic(strength);
        }

        /// <summary>
        /// Provides the message for a given error-code
        /// </summary>
        /// <param name="errorCode">The error code</param>
        /// <returns>The error message for the given code</returns>
        public string GetErrorMessage(int errorCode)
        {
            return io.storj.libstorj.Storj.getErrorMessage(errorCode);
        }

        /// <summary>
        /// Returns the current unix timestamp in milliseconds.
        /// </summary>
        /// <returns>The current unix timestamp</returns>
        public long GetTimestamp()
        {
            return io.storj.libstorj.Storj.getTimestamp();
        }
    }
}
