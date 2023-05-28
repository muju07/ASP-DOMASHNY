using System.Diagnostics;
using System.Linq;
using System.Text;

public class FileMiddleware
{

    private readonly IWebHostEnvironment env;
    private RequestDelegate del;
    public FileMiddleware(RequestDelegate _del, IWebHostEnvironment _env) 
    {
        this.del = _del;
        this.env = _env;
    } 
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var path = httpContext.Request.Path.Value;
        byte[]bytes = Encoding.UTF8.GetBytes(path);
        //string pathFile = "/home/kat/Desktop";
        var temp = env.ContentRootPath;
        string pathFile = Path.Combine(temp, "File");
        using(FileStream fs = new FileStream(pathFile, FileMode.OpenOrCreate))
        {
            await fs.WriteAsync(bytes, 0, bytes.Length);
        }
        await del.Invoke(httpContext);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message + " + " + ex.InnerException);
        }
        
    }
   
}