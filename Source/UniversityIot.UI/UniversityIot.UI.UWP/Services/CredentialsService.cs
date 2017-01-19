using UniversityIot.UI.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CredentialsService))]

namespace UniversityIot.UI.UWP.Services
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using UniversityIot.UI.Core.Services;

    internal class CredentialsService : ICredentialsService
    {
        private const string AuthUserStoreFile = "Userdata";
        private const string AuthPassStoreFile = "Passdata";
        public string UserName => this.ReadFromStorage(AuthUserStoreFile);
        public string Password => this.ReadFromStorage(AuthPassStoreFile);

        public void SaveCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("", nameof(password));
            }

            this.WriteToStorage(AuthUserStoreFile, userName);
            this.WriteToStorage(AuthPassStoreFile, password);
        }

        public void DeleteCredentials()
        {
            this.WriteToStorage(AuthUserStoreFile, null);
            this.WriteToStorage(AuthPassStoreFile, null);
        }

        public bool CredentialsExist()
        {
            return !string.IsNullOrEmpty(this.ReadFromStorage(AuthUserStoreFile));
        }

        private string ReadFromStorage(string file)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

            if (store.FileExists(file))
            {
                using (var stream = new IsolatedStorageFileStream(file, FileMode.Open, store))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();

                        if (string.IsNullOrEmpty(result))
                        {
                            return null;
                        }

                        return result;
                    }
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

            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

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