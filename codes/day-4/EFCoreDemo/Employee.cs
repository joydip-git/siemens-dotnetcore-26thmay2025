using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employeeid", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("employeename", TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("employeesalary", TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal Salary { get; set; }

        //[Column("deptname", TypeName ="varchar(10)")]
        //public string? DepartmentName { get; set; }
    }
}
