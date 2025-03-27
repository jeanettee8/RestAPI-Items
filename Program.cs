using Microsoft.AspNetCore.Mvc;
using RestAPI_Items.DatabaseController;
using RestAPI_Items.ItemDatabaseContext;
using RestAPI_Items.Models;


namespace RestAPI_Items;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ItemDatabaseContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        using(var context = new ItemDatabaseContext()){
            if (!context.Items.Any())
            {
                var items = File.ReadAllLines("items.csv");
                foreach (var item in items.Skip(1))
                {
                    var itemData = item.Split(',',StringSplitOptions.None).ToList();
                    while (itemData.Count<10)
                    {
                        itemData.Add(string.Empty);
                    }
                    var newItem = new ItemModel()
                    {
                        ItemName = itemData[0],
                        ItemPrice = itemData[1],
                        ItemCount = itemData[2],
                        ItemFabric = itemData[3],
                        ItemWillRestock = itemData[4]
                    };
                }
            }
        }

        app.Run();
    }
}
