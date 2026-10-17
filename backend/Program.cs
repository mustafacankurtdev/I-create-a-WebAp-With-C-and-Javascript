var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(op =>
{
    op.AddPolicy("AllowJs", policy =>
    {
        policy.WithOrigins()
        .AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseCors("AllowJs");

app.MapGet("/", () => "API");

app.MapGet("/ogrenciler", () =>
{
    var OgrenciListesi = new[]
    {
        new{Id = 1, Name = "Mustafa"},
        new{Id = 2, Name = "Mehmet"}
    };

    return Results.Ok(OgrenciListesi);
});

app.MapGet("/Urunler", () =>
{
    var Urunler = new[]
    {
        new {Id = 1, Name = "Laptop"},
        new {Id = 2, Name = "Iphone" },
        new {Id = 3, Name = "Pc"},
        new {Id = 4, Name = "Klavye"},
    };

    return Results.Ok(Urunler);
});


//app.MapGet("/Tshirtler", () =>
//{
//    var tsh = new[]
//    {
//        new {id = 1, Name = "Not Found"},
//        new {id = 2, Name = "Not Found"}
//    }
//});


app.MapGet("/Urunler/{Name}", (string Name) =>
{
    var UrunlerListesi = new[]
    {
        new {Id = 1, Name = "Laptop"},
        new {Id = 2, Name = "Iphone" },
        new {Id = 3, Name = "Pc"},
        new {Id = 4, Name = "Klavye"},
        new {Id = 5, Name = "Stokta Yok"}
    };

    var filterUrunler = UrunlerListesi.FirstOrDefault(n => n.Name == Name);

    if(filterUrunler == null)
    {
        return Results.NotFound("Ürün Bulunamadı!");
    }
    else
    {
        return Results.Ok(filterUrunler);
    }

});


app.MapGet("/ogrenciler/{id}", (int id) =>
{
    var OgrenciListesi = new[]
    {
        new {Id = 1, Name = "Mustafa"},
        new {Id = 2, Name = "Mehmet"}
    };

    var bulunanOgrenci = OgrenciListesi.FirstOrDefault(o => o.Id == id);

    if(bulunanOgrenci == null)
    {
        return Results.NotFound("Böyle Birisi Yok");
    }
    else
    {
        return Results.Ok(bulunanOgrenci);
    }
});

app.Run();

