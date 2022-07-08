using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App2.Models
{
    public class Facilitator
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PrinterCode { get; set; }

        public int DepartmentId { get; set; }
        
        public int PositionId { get; set; }

        [ForeignKey("DepartmentId")]
        public  Department department { get; set; }

        [ForeignKey("PositionId")]
        public Position position { get; set; }
    }
}
