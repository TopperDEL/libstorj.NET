using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibStorj.Wrapper.x64.Models
{
    internal class JavaDirectory : Directory
    {
        internal io.storj.libstorj.fs.Dir JavaDir { get; private set; }
        
        public JavaDirectory(io.storj.libstorj.fs.Dir javaDir) : base(javaDir.getId(), javaDir.getName(), javaDir.getSimpleName(), javaDir.getCreated(), javaDir.isDecrypted())
        {
            JavaDir = javaDir;
        }
    }
}
