using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App2.Models
{
    public class Position
    {

        [Key]
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }


        [ForeignKey("FacilitatorId")]
        public List<Facilitator> facilitator { get; set; }
        [ForeignKey("InternId")]
        public List<Intern> intern { get; set; }
    }
}
