using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.Core.Aggregates.ItemAggregate;

namespace DotNetMP.Catalog.Core.Tests.Aggregates.ItemAggregate;

public class ItemTests
{
    [Fact]
    public void Constructor_NullCategoryIsSent_ArgumentNullExceptionThrown()
    {
        // Arrange
        Category nullCategory = null;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new Item(nullCategory, "name", 1, 1));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("category", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidNameIsSent_ArgumentExceptionThrown(string name)
    {
        // Arrange
        var category = new Category("category");

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Item(category, name, 1, 1));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-1000)]
    public void Constructor_InvalidPriceIsSent_ArgumentExceptionThrown(decimal price)
    {
        // Arrange
        var category = new Category("category");

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Item(category, "name", price, 1));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("price", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-1000)]
    public void Constructor_InvalidAmounIsSent_ArgumentExceptionThrown(int amount)
    {
        // Arrange
        var category = new Category("category");

        // Act
        var exception = Assert.Throws<ArgumentException>(() => new Item(category, "name", 1, amount));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("amount", exception.ParamName);
    }

    [Fact]
    public void UpdateName_NullNameIsSent_ArgumentNullExceptionThrown()
    {
        // Arrange
        var category = new Category("category");
        var initialName = "initialName";
        var item = new Item(category, initialName, 1, 1);

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => item.UpdateName(null));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
        Assert.Equal(initialName, item.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void UpdateName_InvalidNameIsSent_ArgumentExceptionThrown(string name)
    {
        // Arrange
        var category = new Category("category");
        var initialName = "initialName";
        var item = new Item(category, initialName, 1, 1);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => item.UpdateName(name));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("name", exception.ParamName);
        Assert.Equal(initialName, item.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-1000)]
    public void UpdatePrice_InvalidPriceIsSent_ArgumentExceptionThrown(decimal price)
    {
        // Arrange
        var category = new Category("category");
        decimal initialPrice = 10.5M;
        var item = new Item(category, "name", initialPrice, 1);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => item.UpdatePrice(price));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("price", exception.ParamName);
        Assert.Equal(initialPrice, item.Price);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-1000)]
    public void UpdateAmount_InvalidAmountIsSent_ArgumentExceptionThrown(int amount)
    {
        // Arrange
        var category = new Category("category");
        var initialAmount = 10;
        var item = new Item(category, "name", 1, initialAmount);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => item.UpdateAmount(amount));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("amount", exception.ParamName);
        Assert.Equal(initialAmount, item.Amount);
    }
}
