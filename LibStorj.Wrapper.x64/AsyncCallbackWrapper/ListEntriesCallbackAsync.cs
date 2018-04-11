using LibStorj.Wrapper.Contracts.Exceptions;
using LibStorj.Wrapper.Contracts.Models;
using LibStorj.Wrapper.x64.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.AsyncCallbackWrapper
{
    /// <summary>
    /// The callback for the bucket-creation.
    /// </summary>
    class ListEntriesCallbackAsync : TaskCompletionSource<List<Entry>>, io.storj.libstorj.fs.ListCallback
    {
        /// <summary>
        /// Lists the entries of a directory or the root entries
        /// Throws KeysNotFoundException.
        /// </summary>
        /// <param name="storj">The storj-object</param>
        public ListEntriesCallbackAsync(io.storj.libstorj.fs.StorjFS storjFS, Directory dir = null)
        {
            try
            {
                if (dir == null)
                    storjFS.list(this);
                else
                {
                    if (dir is JavaDirectory)
                        storjFS.list(((JavaDirectory)dir).JavaDir, this);
                    else
                        throw new ListEntriesFailedException(99, "Directory is not a Java-Directory");
                }
            }
            catch (io.storj.libstorj.KeysNotFoundException)
            {
                throw new KeysNotFoundException();
            }
        }

        public void onEntriesReceived(io.storj.libstorj.Entry[] earr)
        {
            List<Entry> entries = new List<Entry>();
            foreach (var entry in earr)
            {
                if (entry is io.storj.libstorj.fs.Dir)
                    entries.Add(new JavaDirectory((io.storj.libstorj.fs.Dir)entry));
                else if (entry is io.storj.libstorj.File)
                    entries.Add(new JavaFile((io.storj.libstorj.File)entry));
            }

            SetResult(entries);
        }

        /// <summary>
        /// Gets called if the listEntries failed
        /// </summary>
        /// <param name="bucketName">The bucketName that failed</param>
        /// <param name="code">The error-code</param>
        /// <param name="message">The error-message</param>
        public void onError(int code, string message)
        {
            SetException(new ListEntriesFailedException(code, message));
        }
    }
}
