namespace SuperDiploma.Core.Models.Contracts;

public interface ISuperDiplomaBaseDbo
{
    int Id { get; set; }
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset ModifiedAt { get; set; }
    int CreatedBy { get; set; }
    int ModifiedBy { get; set; }
    bool IsDeleted { get; set; }
}