using Microsoft.EntityFrameworkCore;
using ProCookBook.Data;
using ProCookBook.Components;
using ProCookBook.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=recipes.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if (!db.Recipes.Any())
    {
        db.Recipes.AddRange(
            new Recipe
            {
                Title = "Grilled Chicken",
                Category = "Dinner",
                Ingredients = "Chicken, Salt, Pepper, Garlic",
                Instructions = "Season chicken and grill for 25 minutes.",
                CookingTime = 30,
                ImageUrl = "https://images.unsplash.com/photo-1600891964599-f61ba0e24092?q=80&w=1200&auto=format&fit=crop"
            },
            new Recipe
            {
                Title = "Pancakes",
                Category = "Breakfast",
                Ingredients = "Flour, Milk, Eggs, Sugar",
                Instructions = "Mix ingredients and cook 2 minutes per side.",
                CookingTime = 15,
               ImageUrl = "https://images.unsplash.com/photo-1504754524776-8f4f37790ca0?q=80&w=1200&auto=format&fit=crop"

            },
            new Recipe
            {
                Title = "Spaghetti Bolognese",
                Category = "Lunch",
                Ingredients = "Spaghetti, Beef, Tomato Sauce, Onion, Garlic",
                Instructions = "Cook pasta. Prepare sauce. Combine and simmer.",
                CookingTime = 40,
                ImageUrl = "https://images.unsplash.com/photo-1589302168068-964664d93dc0?q=80&w=1200&auto=format&fit=crop"
            }
        );

        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
