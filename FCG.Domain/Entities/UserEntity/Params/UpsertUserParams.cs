using FCG.Domain.Enums;
using FCG.Domain.ValueObjects;

namespace FCG.Domain.Entities.UserEntity.Params
{
    public class UpsertUserParams
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public Email Email { get;  set; }
        public Password Password { get;  set; }
        public UserRole Role { get;  set; }
    }
}
