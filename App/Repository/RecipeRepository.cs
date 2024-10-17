namespace Cookbook.App.Repository;

public class RecipeRepository : IRecipeRepository
{
    private IStringRepoManager _stringRepoManager;
    public RecipeRepository(IStringRepoManager stringRepoManager)
    {
        _stringRepoManager = stringRepoManager;
    }
    public void SaveRecipes(Recipe recipe)
    {
        List<int> ingredientIds = recipe._ingredients
        .Select(i => i.Id)
        .Distinct()
        .ToList();
        string recipeLine = string.Join(",", ingredientIds);

        _stringRepoManager.SaveRecipes(recipe, recipeLine);
    }
    public List<string> ReadRecipes()
    {
        return _stringRepoManager.ReadRecipe();
    }
    public List<string> LoadFile(){
        return _stringRepoManager.LoadFile();
    }
    public List<string> AddRecipe(List<string> recipes, string recipeLine)
    {
        return recipes.Add(recipeLine);
    }
}

