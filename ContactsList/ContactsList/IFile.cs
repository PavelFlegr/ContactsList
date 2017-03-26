using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList
{
    public interface IFile
    {
        Task<bool> FileExistsAsync(string name);
        Task<string> ReadFileAsync(string name);
        Task WriteFileAsync(string name, string content);
        Task CreateFileAsync(string name);
    }
}
