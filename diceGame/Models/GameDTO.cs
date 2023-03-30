using System.ComponentModel.DataAnnotations;

namespace diceGame.Models
{
    public class GameDTO
    {
        [Required(ErrorMessage = "Valid bet required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Valid Bet Required")]
        public int bet { get; set; }
        [Required(ErrorMessage = "Valid bet required.")]
        public int balance { get; set; }
    }
}
