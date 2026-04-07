var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
var demo1 = @"Aqui me pongo a cantar"
            + "Al compas de la vigüela"
            + "Que al hombre que lo desvela"
            + "Una pena extraordinaria";
*/

//https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/tokens/verbatim
const string HTML_INDEX_CONTENT = @"<html>
    <body>
        <h1>Programacion III</h1>
        <p>Bienvenido a la pagina de demostracion!</p>
    </body>
</html>";

app.MapGet("/", () => "Hello World! GET");

// Sirve el contenido HTML cuando se accede a /index.html con content-type text/html
//app.MapGet("/index.html", () => HTML_CONTENT)
app.MapGet("/index.html", () => Results.Content(HTML_INDEX_CONTENT, "text/html"));


app.MapPost("/", () => "Hello World! POST");

app.MapDelete("/", () => "Hello World! DELETE");

app.Run();
