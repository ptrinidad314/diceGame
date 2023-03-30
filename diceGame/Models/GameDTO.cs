using System.ComponentModel.DataAnnotations;

namespace diceGame.Models
{
    public class GameDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Valid Bet Required")]
        public int bet { get; set; }
        [Required]
        public int balance { get; set; }
    }
}
