using FCG.Domain.Entities.UserEntity.Params;
using FCG.Domain.Enums;
using FCG.Domain.ValueObjects;

namespace FCG.Domain.Entities.UserEntity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public UserRole Role { get; set; }

        public User() { }

        public User(UpsertUserParams @params)
        {
            if (string.IsNullOrWhiteSpace(@params.Name))
                throw new ArgumentException("O nome é obrigatório.");

            Id = Guid.NewGuid();
            Name = @params.Name;
            Email = @params.Email;
            Password = @params.Password;
            Role = @params.Role;
        }
    }
}
