using NUnit.Framework;

namespace StackCalculator.Solution.Tests;

[TestFixture]
public class Tests
{
    private StackCalculator _calculator = new StackCalculator();

    [SetUp]
    public void Setup()
    {
        _calculator = new StackCalculator();
    }
}