using SuperDiploma.Core.Models.Contracts;

namespace SuperDiploma.Core.Models;

public class SuperDiplomaBaseDbo : ISuperDiplomaBaseDbo
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    public int CreatedBy { get; set; }
    public int ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}