namespace Cookbook.Model;

public class WheatFlour : Ingredient
{
    public override int Id => 1;
    public override string Name => "Wheat Flour";
    public override string InstructionPreparation => $"Sieve. {base.InstructionPreparation}";

}
