using diceGame.Models;
using NuGet.Frameworks;

namespace diceGameTests
{
    [TestClass]
    public class diceGameUT
    {
        [TestMethod]
        public void utCalculateRoll_FIVE_OF_A_KIND_()
        {
            int numDie = 5;

            GameState state = new GameState();

            for (var i = 0; i < numDie; i++) 
            {
                Die die = new Die();
                die.value = 3;
                state.dice.Add(die);
            }

            state.CalculateRoll();

            Assert.AreEqual(GameResult._5_OF_A_KIND, state.result);
        }


        [TestMethod]
        public void utCalculateRoll_FOUR_OF_A_KIND() 
        {
            int numDie = 5;
            int matchNum = 4;

            GameState state = new GameState();

            for (var i = 0; i < numDie; i++) 
            {
                Die die = new Die();
                if (i < matchNum)
                    die.value = 3;
                else
                    die.value = 1;

                state.dice.Add(die);
            }

            state.CalculateRoll();

            Assert.AreEqual(GameResult._4_OF_A_KIND, state.result);
        }

        [TestMethod]
        public void utCalculateRoll_THREE_OF_A_KIND() 
        {
            int numDie = 5;
            int matchNum = 3;

            GameState state = new GameState();

            for (var i = 0; i < numDie; i++) 
            {
                Die die = new Die();
                if (i < matchNum)
                    die.value = 4;
                else
                    die.value = 2;

                state.dice.Add(die);
            }

            state.CalculateRoll();

            Assert.AreEqual(GameResult._3_OF_A_KIND, state.result);
        }

        [TestMethod]
        public void utCalculateRoll_STRAIGHT_1() 
        {
            int numDie = 5;

            GameState state = new GameState();

            for (var i = 0; i < numDie; i++) 
            {
                Die die = new Die();
                die.value = i + 1;
                state.dice.Add(die);
            }

            state.CalculateRoll();

            Assert.AreEqual(GameResult.STRAIGHT, state.result);
        }

        [TestMethod]
        public void utCalculateRoll_STRAIGHT_2() 
        {
            int numDie = 5;

            GameState state = new GameState();

            for (var i = 0; i < numDie; i++) 
            {
                Die die = new Die();
                die.value = i + 2;
                state.dice.Add(die);
            }

            state.CalculateRoll();

            Assert.AreEqual(GameResult.STRAIGHT, state.result);
        }

        [TestMethod]
        public void utCalculateRoll_LOSE() 
        {
            GameState state = new GameState();
            
            Die die1 = new Die();
            die1.value = 1;
            state.dice.Add(die1);

            Die die2 = new Die();
            die2.value = 1;
            state.dice.Add(die2);

            Die die3 = new Die();
            die3.value = 2;
            state.dice.Add(die3);

            Die die4 = new Die();
            die4.value = 2;
            state.dice.Add(die4);

            Die die5 = new Die();
            die5.value = 3;
            state.dice.Add(die5);

            state.CalculateRoll();

            Assert.AreEqual(GameResult.LOSE, state.result);

        }

        [TestMethod]
        public void utCalculateBalance_FIVE_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.balance = 50;
            state.bet = 1;
            state.result = GameResult._5_OF_A_KIND;

            state.CalculateBalance();

            Assert.AreEqual(150, state.balance);
        }

        [TestMethod]
        public void utCalculateBalance_FOUR_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.balance = 100;
            state.bet = 2;
            state.result = GameResult._4_OF_A_KIND;

            state.CalculateBalance();

            Assert.AreEqual(200, state.balance);
        }

        [TestMethod]
        public void utCalculateBalance_THREE_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.balance = 150;
            state.bet = 3;
            state.result = GameResult._3_OF_A_KIND;

            state.CalculateBalance();

            Assert.AreEqual(180, state.balance);
        }

        [TestMethod]
        public void utCalculateBalance_STRAIGHT() 
        {
            GameState state = new GameState();
            state.balance = 200;
            state.bet = 4;
            state.result = GameResult.STRAIGHT;

            state.CalculateBalance();

            Assert.AreEqual(220, state.balance);
        }

        [TestMethod]
        public void utCalculateBalance_LOSE()
        {
            GameState state = new GameState();
            state.balance = 250;
            state.bet = 5;
            state.result = GameResult.LOSE;

            state.CalculateBalance();

            Assert.AreEqual(245, state.balance);
        }

        [TestMethod]
        public void utCalculateBalance_LOSE_GAMEOVER() 
        {
            GameState state = new GameState();
            state.balance = 300;
            state.bet = 300;
            state.result = GameResult.LOSE;

            state.CalculateBalance();

            Assert.AreEqual(GameResult.GAMEOVER, state.result);
        }

        [TestMethod]
        public void utGetMessage_FIVE_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.bet = 10;
            state.result = GameResult._5_OF_A_KIND;
            
            state.GetMessage();

            Assert.AreEqual("5 of a kind, you win $1000", state.message);
        }

        [TestMethod]
        public void utGetMessage_FOUR_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.bet = 5;
            state.result = GameResult._4_OF_A_KIND;

            state.GetMessage();

            Assert.AreEqual("4 of a kind, you win $250", state.message);
        }

        [TestMethod]
        public void utGetMessage_THREE_OF_A_KIND() 
        {
            GameState state = new GameState();
            state.bet = 4;
            state.result = GameResult._3_OF_A_KIND;

            state.GetMessage();

            Assert.AreEqual("3 of a kind, you win $40", state.message);
        }

        [TestMethod]
        public void utGetMessage_STRAIGHT() 
        {
            GameState state = new GameState();
            state.bet = 3;
            state.result = GameResult.STRAIGHT;

            state.GetMessage();

            Assert.AreEqual("Straight, you win $15", state.message);
        }

        [TestMethod]
        public void utGetMessage_LOST()
        {
            GameState state = new GameState();
            state.bet = 2;
            state.result = GameResult.LOSE;

            state.GetMessage();

            Assert.AreEqual("You lost $2", state.message);
        }

        [TestMethod]
        public void utGetMessage_GAME_OVER()
        {
            GameState state = new GameState();
            state.result = GameResult.GAMEOVER;

            state.GetMessage();

            Assert.AreEqual("You are out of money.  Click on \"New Game\"", state.message);
        }

    }
}