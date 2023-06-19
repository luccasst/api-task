namespace crudUser.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public static implicit operator List<object>(UserModel v)
        {
            throw new NotImplementedException();
        }
    }
}