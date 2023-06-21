using crudUser.Enums;

namespace crudUser.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTask Status { get; set; }

        public Guid? UserId { get; set; }

        public virtual UserModel? User { get; set; }
    }
}