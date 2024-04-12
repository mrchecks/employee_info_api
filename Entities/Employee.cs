namespace EmployeeInfo.Entities
{
    public class Employee : Person
    {
        public required int EmployeeNum { get; set; }
        public required DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
    }
}
