using LibStorj.Wrapper.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LibStorj.Wrapper.Contracts.Models;
using System.Threading.Tasks;
using LibStorj.Wrapper.AsyncCallbackWrapper;
using LibStorj.Wrapper.x64.Models;

namespace LibStorj.Wrapper.x64
{
    public class StorjFS : IStorjFS
    {
        internal io.storj.libstorj.fs.StorjFS _storjFSJava;

        public StorjFS(IStorj storj)
        {
            _storjFSJava = new io.storj.libstorj.fs.StorjFS(((Storj)storj)._storjJava);
        }

        public Task<List<Entry>> ListRootAsync()
        {
            return new ListEntriesCallbackAsync(_storjFSJava).Task;
        }

        public Task<List<Entry>> ListEntriesAsync(Directory dir)
        {
            return new ListEntriesCallbackAsync(_storjFSJava, dir).Task;
        }
    }
}
