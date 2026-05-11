var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();

// Добавляем CORS (чтобы можно было вызывать API из браузера)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Настройка статических файлов (для index.html и gl-matrix)
app.UseDefaultFiles();     // Ищет index.html в wwwroot
app.UseStaticFiles();      // Отдает файлы из wwwroot

// CORS (если нужно)
app.UseCors("AllowAll");

// HTTPS редирект (опционально)
app.UseHttpsRedirection();

// Авторизация (если есть)
app.UseAuthorization();

// API контроллеры
app.MapControllers();

app.Run();
