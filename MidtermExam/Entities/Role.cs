namespace Entities;

public class Role
{
    public Role()
    {
        UserUsers = new HashSet<User>();
    }

    public int RoleId { get; set; }
    public string? RoleName { get; set; }

    public virtual ICollection<User> UserUsers { get; set; }
}