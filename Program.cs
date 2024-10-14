using Cookbook.App.Repository;
using Cookbook.App;
using Cookbook.App.UI;
using Cookbook.Model;
using Cookbook.Enums;

namespace CookbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredient = new List<Ingredient>{
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocoaPowder()
        };
            IUserInteraction ui = new ConsoleUserInteraction();
            IngredientRepository ingredientRepository = new IngredientRepository(ingredient);
            ICookbookInteraction cookbookUI = new CookbookInteraction(ingredientRepository);


            IStringRepoManager _stringRepoManager;
            cookbookUI.WriteMessage("Choose format to save recipes: 1. JSON 2. TXT");
            string userInput = ui.GetUserInput();
            FormatFile file = ui.TryReadEnum<FormatFile>(userInput);

            if (file == FormatFile.Json)
            {
                _stringRepoManager = new JsonBasedStringRepo("./File/recipes.json");
            }
            else
            {
                _stringRepoManager = new TxtBasedStringRepo("./File/recipes.txt");
            }
            IRecipeRepository recipeRepository = new RecipeRepository(_stringRepoManager);

            ICookbook cookbook = new CookieCookbook(recipeRepository, ingredientRepository, ui, cookbookUI);
            try
            {
                cookbook.DisplayRecipe();
                var result = cookbook.MakeNewRecipe();

            }
            catch (Exception e)
            {
                //Log and close the application gracefully
                Console.WriteLine($"{e}");
            }
        }
    }
}

