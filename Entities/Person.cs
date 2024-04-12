using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo.Entities
{
    public class Person
    {
        [Key]
        public required int PersonId { get; set; }
        [MaxLength(128)]
        public required string LastName { get; set; } = string.Empty;
        [MaxLength(128)]
        public required string FirstName { get; set; } = string.Empty;
        public required DateTime BirthDate { get; set; }
    }
}
