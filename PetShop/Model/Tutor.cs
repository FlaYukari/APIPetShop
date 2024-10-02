using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Model
{
    [Table("Tutores")]
    public class Tutor
    {
        public Tutor() 
        {
            Pets = new Collection<Pet>();
        }

        [Key]
        public int TutorId { get; set; }
        [Required]
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        [Required]
        public string Cpf { get; set; }

        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }

        [Required]
        [JsonIgnore]
        public ICollection<Pet>? Pets { get; set; }
    }
}
