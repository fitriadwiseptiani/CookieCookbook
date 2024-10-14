using Cookbook.App.Repository;
using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App.UI;

public class CookbookInteraction : ICookbookInteraction
{
    private IngredientRepository _ingredientRepository;
    public CookbookInteraction()
    {
        _ingredientRepository = new();
    }
    public void ChooseAction(out int action)
    {
        action = 0;
        bool validInput = false;
        while (!validInput)
        {
            WriteMessage("\nPlease choose one of this following action ");
            WriteMessage("1. Add Ingredient");
            WriteMessage("2. End Session");
            WriteMessage("");
            WriteMessage("Your Input : ");
            bool status = TryRead(GetUserInput(), out int input);
            if (status && input >= 1 && input <= 2)
            {
                action = input;
                validInput = true;
            }
            else
            {
                WriteMessage("Please input valid number (1-2)");
                Thread.Sleep(1000);
            }
        }
    }
    public void SelectedIngredient()
    {
        WriteMessage("\nChoose one of the ingredient below : ");
        DisplayAvailableIngredient();
    }
    public void DisplayAvailableIngredient()
    {
        WriteMessage("\n Available Ingredient : ");
        var ingredients = _ingredientRepository.GetIngredientsList();
        foreach (var ingredient in ingredients)
        {
            WriteMessage($"{ingredient.Id} - {ingredient.Name}");
        }
    }
    public void Finished()
    {
        WriteMessage("The session has been finished. Thank you for your contribution to adding new recipe");
    }
    public void RecipeStatus(CookbookErrorCode result)
    {
        if (result == CookbookErrorCode.NoError)
        {
            WriteMessage("Recipe created successfully.");
        }
        else
        {
            WriteMessage($"An error occurred: {result}");
        }
    }
    
    public string FormatSingleRecipe(List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();
        foreach (int id in ingredientIds)
        {
            Ingredient ingredient = _ingredientRepository.GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                WriteMessage($"{ingredient.Name}. {string.Join(". ", ingredient.InstructionPreparation)}");
            }
            else
            {
                WriteMessage($"Ingredient with ID {id} not found in recipe.");
            }
        }
        return string.Join("\n", ingredientDetails);
    }
    public void DisplayRecipe(List<string> recipe)
    {
        WriteMessage("\nAvailable Recipe : ");
        recipe.Select((recipeData, index) => new { recipeData, index })
           .ToList()
           .ForEach(r =>
           {
               List<int> ingredientIds = r.recipeData.Split(',').Select(int.Parse).ToList();
               WriteMessage($"***** Recipe {r.index + 1} *****");
               WriteMessage(FormatSingleRecipe(ingredientIds));
           });
    }

    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }

    public bool TryRead(string inputPlayer, out int id)
    {
        return Int32.TryParse(inputPlayer, out id);
    }
    public string GetUserInput(){
        return Console.ReadLine();
    }

    public int TryReadInt(string inputPlayer)
    {
        return Int32.Parse(inputPlayer);
    }

}
