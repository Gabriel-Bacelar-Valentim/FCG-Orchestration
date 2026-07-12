using System.Text.RegularExpressions;

namespace FCG.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; set; }

        public Password() { }

        public Password(string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword) || plainTextPassword.Length < 8)
                throw new ArgumentException("A senha deve ter no mínimo 8 caracteres.");

            if (!Regex.IsMatch(plainTextPassword, @"[a-zA-Z]") ||
                !Regex.IsMatch(plainTextPassword, @"[0-9]") ||
                !Regex.IsMatch(plainTextPassword, @"[\W_]"))
                throw new ArgumentException("A senha deve conter letras, números e caracteres especiais.");

            Value = plainTextPassword;
        }
    }
}