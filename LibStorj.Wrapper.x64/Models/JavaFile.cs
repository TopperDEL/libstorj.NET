using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibStorj.Wrapper.x64.Models
{
    internal class JavaFile:File
    {
        internal io.storj.libstorj.File JavaF { get; private set; }

        public JavaFile(io.storj.libstorj.File javaFile) : base(javaFile.getId(), javaFile.getBucketId(), javaFile.getName(), javaFile.getSimpleName(), javaFile.getCreated(), javaFile.isDecrypted(), javaFile.getSize(),javaFile.getMimeType(),javaFile.getErasure(),javaFile.getIndex(),javaFile.getHMAC(),javaFile.isDirectory())
        {
            JavaF = javaFile;
        }
    }
}
