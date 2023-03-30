using diceGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace diceGame.Controllers
{
    public class HomeController : Controller
    {
        readonly int numDice = 5;

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            GameState state = new GameState(numDice);

            return View(state);
        }



        public IActionResult PlayGame(GameDTO gameDTO) 
        {
            GameState state = new GameState(numDice);
            state.bet = gameDTO.bet;
            state.balance = gameDTO.balance;

            if (gameDTO.bet == 0) 
            {
                state.result = GameResult.ERROR;
                state.message = "Valid Bet Required";
                return View(state);
            }

            //invalid model state
            if (!ModelState.IsValid)
            {
                state.result = GameResult.ERROR;

                string errMsg = "Error"; 

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        var test = modelState.GetModelStateForProperty;

                        errMsg = errMsg + "," + modelError.ErrorMessage; 
                    }
                }

                errMsg.TrimStart(',');
                state.message = errMsg; 
                return View(state);
            }


            //invalid bet amount
            if (gameDTO.bet > gameDTO.balance) 
            {
                state.result = GameResult.ERROR;
                state.message = "You don't have enough for that bet";
                return View(state);
            }

           
            //calculate roll results
            state.CalculateRoll();
            state.CalculateBalance();
            state.GetMessage();

            return View(state);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}