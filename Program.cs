using System.Resources;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Items.DatabaseContext;
using RestAPI_Items.Models;
using Microsoft.EntityFrameworkCore.Design;


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
                    while (itemData.Count<7)
                    {
                        itemData.Add(string.Empty);
                    }
                    var newItem = new ItemModel()
                    {
                        ItemName = itemData[1],
                        ItemPrice = double.Parse(itemData[2]),
                        ItemCount = int.Parse(itemData[3]),
                        ItemFabric = char.Parse(itemData[4]),
                        ItemWillRestock = bool.Parse(itemData[5])
                    };
                    context.Items.Add(newItem);
                }
                context.SaveChanges();
            }
        }

        app.Run();
    }
}
