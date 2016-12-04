namespace UniversityIot.UsersService.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordEncoder
    {
        public static string Hash(string input)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(input);

            using (var md5Hash = MD5.Create())
            {
                var hash = md5Hash.ComputeHash(passwordBytes);

                StringBuilder sBuilder = new StringBuilder();

                foreach (var b in hash)
                {
                    sBuilder.Append(b.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static bool Verify(string input, string hash)
        {
            var hashOfInput = Hash(input);

            return string.Equals(hashOfInput, hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}