using FluentAssertions;

namespace StringCalculator.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData("",0)]
    [InlineData("1",1)]
    [InlineData("1,3",4)]
    public void Add_AddUpToTwoNumbers_WhenStringIsValid(string calculation, int expected)
    {
        //arrange
        var sut = new Calculator();


        //act
        var result = sut.Add(calculation);


        //assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("1,2,3",6)]
    [InlineData("10,90,10,20",130)]
    
    public void Add_AddUpToAnyNumber_WhenStringIsValid(string calculation, int expected)
    {
        //arrange
        var sut = new Calculator();


        //act
        var result = sut.AddUpToAnyNumber_(calculation);


        //assert
        result.Should().Be(expected);
    }
    
    
    
    [Theory]
    [InlineData("1,\n2,3",6)]
    [InlineData("10,\n90,10,\n20",130)]
    
    public void Add_AddsNumbersUsingNewLineDelimiter_WhenStringIsValid(string calculation, int expected)
    {
        //arrange
        var sut = new Calculator();


        //act
        var result = sut.AddsNumbersUsingNewLineDelimiter(calculation);


        //assert
        result.Should().Be(expected);
    }
    
    
    
    [Theory]
    [InlineData("//;\n1;2",3)]
    [InlineData("//;\n1;2;4",7)]
    
    public void Add_AddsNumbersUsingCustomDelimiter_WhenStringIsValid(string calculation, int expected)
    {
        //arrange
        var sut = new Calculator();


        //act
        var result = sut.AddsNumbersUsingCustomDelimiter(calculation);


        //assert
        result.Should().Be(expected);
    }
    
    
        
    
    [Theory]
    [InlineData("1,2,-1","-1")]
    [InlineData("//;\n1;-2;-4","-2,-4")]
    
    public void Add_ShouldThrowAnException_WhenNegitiveNumbersAreUsed(string calculation, string negativeNumbers)
    {
        //arrange
        var sut = new Calculator();


        //act
        Action action = () => sut.Add_ShouldThrowAnException(calculation);


        //assert
        action.Should().Throw<Exception>().WithMessage("Negatives are not allowed" + negativeNumbers);
    }
}