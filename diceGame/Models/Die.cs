namespace diceGame.Models
{
    public class Die
    {
        public int value { get; set; } = 1;
        public string url { get; set; } = @"/images/1.gif"; 

        public string getDieImageUrl() 
        {
            return "/images/" + this.value.ToString() + ".gif";
        }

        public int getDieValue() 
        {
            var rand = new Random();
            return rand.Next(1, 6);
        }

    }
}
