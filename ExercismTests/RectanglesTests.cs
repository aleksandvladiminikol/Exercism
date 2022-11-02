using System;
using Xunit;
public class RectanglesTests
{
    [Fact]
    public void No_rows()
    {
        var strings = Array.Empty<string>();
        Assert.Equal(0, Rectangles.Count(strings));
    }
   [Fact]
    public void No_columns()
    {
        var strings = new[]
        {
            ""
        };
        Assert.Equal(0, Rectangles.Count(strings));
    }
   [Fact]
    public void No_rectangles()
    {
        var strings = new[]
        {
            " "
        };
        Assert.Equal(0, Rectangles.Count(strings));
    }
   [Fact]
    public void One_rectangle()
    {
        var strings = new[]
        {
            "+-+",
            "| |",
            "+-+"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }
}
