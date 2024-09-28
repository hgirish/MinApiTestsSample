using Microsoft.EntityFrameworkCore;
using MinApiTestsSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers;
public class MockDb : IDbContextFactory<TodoGroupDbContext>
{
    public TodoGroupDbContext CreateDbContext()
    {
var options = new DbContextOptionsBuilder<TodoGroupDbContext>()
            .UseInMemoryDatabase(
    $"InMemoryTestDb={DateTime.Now.ToFileTimeUtc()}")
            .Options;
        return new TodoGroupDbContext( options );   
    }
}
