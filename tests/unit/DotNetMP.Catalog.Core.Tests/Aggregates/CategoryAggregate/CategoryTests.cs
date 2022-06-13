using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;

namespace DotNetMP.Catalog.Core.Tests.Aggregates.CategoryAggregate;

public class CategoryTests
{

    [Fact]
    public void Constructor_NullNameIsSent_ArgumentNullExceptionThrown()
    {
        // Arrange
        string nullName = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new Category(nullName));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidNameSent_ArgumentExceptionThrown(string name)
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Category(name));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
    }

    [Fact]
    public void UpdateName_NullNameSent_ArgumentNullExceptionThrown()
    {
        // Arrange
        var previousName = "Electronics";
        var category = new Category(previousName);
        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => category.UpdateName(null));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
        Assert.Equal(previousName, category.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void UpdateName_InvalidNameSent_ArgumentExceptionThrown(string name)
    {
        // Arrange
        var previousName = "Electronics";
        var category = new Category(previousName);
        // Act
        var exception = Assert.Throws<ArgumentException>(() => category.UpdateName(name));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
        Assert.Equal(previousName, category.Name);
    }
}
