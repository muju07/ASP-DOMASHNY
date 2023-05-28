using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Services.GetRequiredService<IWebHostEnvironment>();
//app.UseMiddleware<FileMiddleware>();
app.UseStaticFiles(); 
app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), @"img")),
                            RequestPath = new PathString("/img")
    });

// app.Run(async(context)=>{
//     if(app.Environment.IsDevelopment())
//     {
//         app.UseDeveloperExceptionPage();
//     }
//     //await context.Response.WriteAsync("Hello world");
//     int x = 0;
//     int z = 5;
//     int y = z / x;
//     await context.Response.WriteAsync(y.ToString());
// });

app.Run(async(context)=>{
    throw new Exception("error");
});

//app.MapGet("/", () => "Hello World!");

app.Run();
    
