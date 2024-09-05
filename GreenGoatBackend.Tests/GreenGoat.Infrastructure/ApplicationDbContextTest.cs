using Microsoft.EntityFrameworkCore;
using GreenGoat.Infrastructure.Data;

public class ApplicationDbContextTests
{
    [Fact]
    public void initializes_with_valid_options()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;

        var context = new ApplicationDbContext(options);

        Assert.NotNull(context);
        Assert.IsType<ApplicationDbContext>(context);
    }
}