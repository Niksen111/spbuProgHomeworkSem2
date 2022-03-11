namespace StackCalculator.Solution;


internal class Program
{
    public static void Main(string[] args)
    {
        var x = new StackCalculator();
        x.ChangeStack(StackCalculator.TypesOfStacks.ListStack);
    }
}

