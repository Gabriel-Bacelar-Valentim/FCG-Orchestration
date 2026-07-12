using System.Text.RegularExpressions;

namespace FCG.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; set; }

        public Email() { }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !Regex.IsMatch(address, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Formato de e-mail inválido.");

            Address = address;
        }
    }
}