namespace diceGame.Models
{
    public class GameState
    {
        public GameResult result { get; set; } = GameResult.INIT;
        public int balance { get; set; } = 50;
        public int bet { get; set; }
        public List<Die> dice { get; set; } = new List<Die>();
        public string message { get; set; } = string.Empty;
        public void CalculateRoll()
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;

            foreach (var die in this.dice)
            {
                switch (die.value)
                {
                    case 1:
                        count1++;
                        break;

                    case 2:
                        count2++;
                        break;

                    case 3:
                        count3++;
                        break;

                    case 4:
                        count4++;
                        break;

                    case 5:
                        count5++;
                        break;

                    default:
                        count6++;
                        break;
                }

            }

            if (count1 == 5
                    || count2 == 5
                    || count3 == 5
                    || count4 == 5
                    || count5 == 5
                    || count6 == 5)
            {
                this.result = GameResult._5_OF_A_KIND;
            }
            else if (count1 == 4 || count2 == 4 || count3 == 4 || count4 == 4 || count5 == 4 || count6 == 4)
            {
                this.result = GameResult._4_OF_A_KIND;
            }
            else if (count1 == 3 || count2 == 3 || count3 == 3 || count4 == 3 || count5 == 3 || count6 == 3)
            {
                this.result = GameResult._3_OF_A_KIND;
            }
            else if ((count1 == 1 && count2 == 1 && count3 == 1 && count4 == 1 && count5 == 1)
                || (count2 == 1 && count3 == 1 && count4 == 1 && count5 == 1 && count6 == 1))
            {
                this.result = GameResult.STRAIGHT;
            }
            else
            {
                this.result = GameResult.LOSE;
            }

        }

        public void GetMessage() 
        {

            switch (this.result)
            {
                case GameResult._5_OF_A_KIND:
                    this.message = "5 of a kind, you win $" + (this.bet * 100).ToString();
                    break;

                case GameResult._4_OF_A_KIND:
                    this.message = "4 of a kind, you win $" + (this.bet * 50).ToString();
                    break;

                case GameResult._3_OF_A_KIND:
                    this.message = "3 of a kind, you win $" + (this.bet * 10).ToString();
                    break;

                case GameResult.STRAIGHT:
                    this.message = "Straight, you win $" + (this.bet * 5);
                    break;

                case GameResult.GAMEOVER:
                    this.message = "You are out of money.  Click on \"New Game\"";
                    break;

                default:
                    this.message = "You lost $" + this.bet.ToString();
                    break;
            }
        }

        public void CalculateBalance() 
        {
            switch (this.result) 
            {
                case GameResult._5_OF_A_KIND:
                    this.balance += (this.bet * 100);
                    break;

                case GameResult._4_OF_A_KIND:
                    this.balance += (this.bet * 50);
                    break;

                case GameResult._3_OF_A_KIND:
                    this.balance += (this.bet * 10);
                    break;

                case GameResult.STRAIGHT:
                    this.balance += (this.bet * 5);
                    break;

                default:
                    this.balance -= this.bet;
                    break;
            }

            if (this.balance == 0)
                this.result = GameResult.GAMEOVER;
        }
    }
}
