using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Model
{

    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [StringLength(30)]
        public string Especie { get; set; }

        [StringLength(30)]
        public string Raca { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1900-01-01", "9999-12-31")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [ForeignKey("TutorId")]
        public int TutorId { get; set; }

        [JsonIgnore]
        public string Tutor { get; set;}

    }
}
