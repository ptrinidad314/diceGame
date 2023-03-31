using System.ComponentModel.DataAnnotations;

namespace diceGame.Models
{
    public class GameDTO
    {
        [Required(ErrorMessage = "valid bet required.")]
        [Range(1, int.MaxValue, ErrorMessage = "valid bet required")]
        public int bet { get; set; }
        [Required(ErrorMessage = "valid bet required.")]
        public int balance { get; set; }
    }
}
