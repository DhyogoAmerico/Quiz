using System.Security.Cryptography;
using System.Text;

namespace Quiz.Domain.ValueType
{
    public struct Password
    {
        // private static string Salt => "zyd4ztBj2LedC5nkAlpF1D6v9";
        private readonly string _password;

        public Password(string password)
        {
            _password = password;
        }

        public static implicit operator string(Password password) => password._password;
        public static implicit operator Password(string email) => new (email);

        public string ToMD5()
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_password));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}