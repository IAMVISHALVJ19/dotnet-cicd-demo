using Xunit;

public class CalculatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    public void Add_ReturnsSum(int a, int b, int expected)
        => Assert.Equal(expected, Calculator.Add(a, b));
}
