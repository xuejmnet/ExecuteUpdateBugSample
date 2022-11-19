// See https://aka.ms/new-console-template for more information

using ExcuteUpdateBugSample;
using Microsoft.EntityFrameworkCore;

var dbContextOptionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>();
dbContextOptionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=testdb1;userid=root;password=root;",
    new MySqlServerVersion(new Version()));
var dbContextOptions = dbContextOptionsBuilder.Options;
var defaultDbContext = new DefaultDbContext(dbContextOptions);
defaultDbContext.Database.EnsureCreated();
defaultDbContext.Set<LogicDatabaseEntity>().Where(o => o.Id == "123")
    .ExecuteUpdate(o => o.SetProperty(x => x.IsDelete, x => true));
Console.WriteLine("direct invoke success");

try
{
    defaultDbContext.Set<LogicDatabaseEntity>().Where(o => o.Id == "123")
        .LogicDelete();
    Console.WriteLine("extension invoke success");
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.WriteLine("extension invoke fail");
}

Console.WriteLine("ok");