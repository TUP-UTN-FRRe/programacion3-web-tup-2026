var app = WebApplication.Create(args);


app.MapGet("/home", () => Results.Content("""
    <h1>Programacion III</h1>
    <p>Servidor mínimo funcionando.</p>
    """, "application/json"));



app.Run();