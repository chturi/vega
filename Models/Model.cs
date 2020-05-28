using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("Models")]
    public class Model
    {
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        //Navigation property
        public Make Make { get; set; }

        public int MakeId { get; set; } //Make Model has to have same type of variable to connect object Make and ID

        public Feature Feature {get; set;}

        public int FeatureId { get; set; }

    }
}