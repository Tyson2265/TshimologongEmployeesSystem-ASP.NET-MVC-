using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App2.Models
{
    public class Intern
    {
       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DeviceCode { get; set; }


        public string InstitutionName { get; set; }
        public bool Graduated { get; set; }
        public int GraduationYear { get; set; }
        public bool isWorkIntegratedLearning { get; set; }


        public int DepartmentId { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department department { get; set; }

        [ForeignKey("PositionId")]
        public Position position { get; set; }
    }
}
