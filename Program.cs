using Cookbook.App.Repository;
using Cookbook.App;
using Cookbook.App.UI;

namespace CookbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInteraction ui = new ConsoleUserInteraction();
            ICookbookInteraction cookbookUI = new CookbookInteraction();
            IFileManager fileManager = new FileManager();
            IIngredientRepository ingredientRepository = new IngredientRepository();

            IStringRepoManager _stringRepoManager = fileManager.ChooseFormat();
            IRecipeRepository recipeRepository = new RecipeRepository(_stringRepoManager);

            recipeRepository.ReadRecipes();

            ICookbook cookbook = new CookieCookbook(recipeRepository, ingredientRepository, ui, cookbookUI);            
            try
            {
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

