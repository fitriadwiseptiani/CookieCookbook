using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App;

public class CookieCookbook : ICookbook
{
    //Avalilable Ingredients
    private readonly List<Ingredient> _ingredient;

    //Recipes
    private readonly IEnumerable<Recipe> _recipes;
    Recipe recipe;

    //User Interaction
    private readonly IUserInteraction _ui;

    // CookbookUserInteraction
    private readonly ICookbookInteraction _cookbookUI;

    //Recipe Repository
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientRepository _ingredientRepository;

    private readonly List<string> recipes;

    //Dependency Injection & Inverison
    public CookieCookbook(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IUserInteraction ui, ICookbookInteraction cookbookUI)
    {
        _ingredient = new List<Ingredient>();
        recipe = new(_ingredient);
        _recipeRepository = recipeRepository;
        _ingredientRepository = ingredientRepository;
        _ui = ui;
        _cookbookUI = cookbookUI;
        recipes = _recipeRepository.LoadFile();
    }
    public void DisplayRecipe()
    {
        List<string> recipe = _recipeRepository.ReadRecipes();
        _cookbookUI.DisplayRecipe(recipe);
    }
    public CookbookErrorCode MakeNewRecipe()
    {
        while (true)
        {
            UserAction userAction = _cookbookUI.ChooseAction();
            if (userAction == UserAction.EndSession)
            {
                if (_ingredient.Count > 0)
                {
                    _cookbookUI.Finished();
                    break;
                }
                else
                {
                    _ui.WriteMessage("\nSorry there is no ingredient selected, you must choose at least one ingredient");
                }
            }
            else if (userAction == UserAction.AddIngredients)
            {
                _cookbookUI.SelectedIngredient();
                _ui.WriteMessage("\nChoose one of the ingredient by number (only input the number) : ");
                string inputPlayer = _ui.GetUserInput();
                if (_ui.TryRead(inputPlayer, out int id))
                {
                    Ingredient ingredient = _ingredientRepository.GetIngredientsList().ToList().Find(a => a.Id == id);
                    AddIngredients(ingredient, inputPlayer);
                }
            }
        }
        SavingRecipe(recipe);
        return CookbookErrorCode.NoError;
    }
    public void AddIngredients(Ingredient ingredient, string inputPlayer)
    {
        var input = _ui.TryReadInt(inputPlayer);
        var totalIngredient = _ingredientRepository.GetIngredientsList().ToList().Count;
        if (_ingredient != null && input <= totalIngredient && inputPlayer != "0")
        {
            _ingredient.Add(ingredient);
            _ui.WriteMessage($"{ingredient.Name} add to recipe");
        }
        else
        {
            _ui.WriteMessage("Please input the valid number. no ingredient was matched with id that you input");
        }
    }
    public void SavingRecipe(Recipe recipe)
    {
        if (_ingredient.Count > 0)
        {
            _ingredientRepository.GetSelectedIngredients(recipe);
            _recipeRepository.LoadFile();
            _recipeRepository.AddRecipe();
            _recipeRepository.SaveRecipes(recipe);
            _ui.WriteMessage($"____New recipe added_____");
        }
        else
        {
            _ui.WriteMessage("No ingredients selected. No recipe added.");
        }
    }
}
