using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App2.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }


        [ForeignKey("FacilitatorId")]
        public List<Facilitator> facilitator { get; set; }
        [ForeignKey("InternId")]
        public List<Intern> intern { get; set; }
    }
    }

