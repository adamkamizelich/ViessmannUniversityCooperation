using System;
using System.IO;
using System.IO.IsolatedStorage;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CredentialsService))]

namespace UniversityIot.UI.UWP.Services
{
    internal class CredentialsService : ICredentialsService
    {
        private const string AuthUserStoreFile = "Userdata";
        private const string AuthPassStoreFile = "Passdata";

        public string UserName => ReadFromStorage(AuthUserStoreFile);

        public string Password => ReadFromStorage(AuthPassStoreFile);

        public void SaveCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("", nameof(userName));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("", nameof(password));

            WriteToStorage(AuthUserStoreFile, userName);
            WriteToStorage(AuthPassStoreFile, password);
        }

        public void DeleteCredentials()
        {
            WriteToStorage(AuthUserStoreFile, null);
            WriteToStorage(AuthPassStoreFile, null);
        }

        public bool CredentialsExist()
        {
            return !string.IsNullOrEmpty(ReadFromStorage(AuthUserStoreFile));
        }


        private string ReadFromStorage(string file)
        {
            var store = IsolatedStorageFile.GetUserStoreForApplication();

            if (store.FileExists(file))
                using (var stream = new IsolatedStorageFileStream(file, FileMode.Open, store))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = reader.ReadToEnd();

                        if (string.IsNullOrEmpty(result))
                            return null;

                        return result;
                    }
                }

            return null;
        }

        private void WriteToStorage(string file, string data)
        {
            if (data == null)
            {
                data = string.Empty;
            }

            var store = IsolatedStorageFile.GetUserStoreForApplication();

            if (store.FileExists(file))
                using (var stream = new IsolatedStorageFileStream(file, FileMode.OpenOrCreate, store))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(data);
                    }
                }
        }
    }
}