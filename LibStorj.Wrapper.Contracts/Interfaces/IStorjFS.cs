using LibStorj.Wrapper.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Contracts.Interfaces
{
    public interface IStorjFS
    {
        Task<List<Entry>> ListRootAsync();
        Task<List<Entry>> ListEntriesAsync(Directory dir);
    }
}
