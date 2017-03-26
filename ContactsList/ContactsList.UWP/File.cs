using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(ContactsList.UWP.File))]
namespace ContactsList.UWP
{
    public class File : IFile
    {
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        public async Task CreateFileAsync(string name)
        {
            await folder.CreateFileAsync(name);
        }

        public async Task<bool> FileExistsAsync(string name)
        {
            IStorageItem item = await folder.TryGetItemAsync(name);
            return item != null && item.IsOfType(StorageItemTypes.File);
        }

        public async Task<string> ReadFileAsync(string name)
        {
            IStorageFile file = await folder.GetFileAsync(name);
            return await FileIO.ReadTextAsync(file);
        }

        public async Task WriteFileAsync(string name, string content)
        {
            IStorageFile file = await folder.GetFileAsync(name);
            await FileIO.WriteTextAsync(file, content);
        }
    }
}
