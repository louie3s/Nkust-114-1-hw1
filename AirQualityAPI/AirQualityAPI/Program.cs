using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// ===============================
/// 1️⃣ 註冊服務（DI Container）
/// ===============================

/// 設定 Entity Framework Core + SQLite
/// 使用 air.db 作為資料庫檔案
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=air.db"));

/// 註冊 Controller（Web API）
builder.Services.AddControllers();

/// Swagger 相關服務（API 文件）
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// 設定 CORS（允許前端呼叫 API）
/// 目前設定為 AllowAll，專題階段最方便
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

/// =======================================
/// 2️⃣ 啟動時執行：匯入 JSON 到資料庫
/// =======================================
/// 這段會在專案啟動時執行一次
/// 若資料已存在，你的 Import 方法內應該有避免重複寫入
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataImport.Import(db);
}

/// =======================================
/// 3️⃣ HTTP Request Pipeline（中介軟體）
/// =======================================

/// Swagger 只在 Development 環境啟用
/// 並指定路徑為 /swagger（不佔用首頁）
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger"; // Swagger 路徑
    });
}

/// 重新導向 HTTPS
app.UseHttpsRedirection();

/// 啟用靜態檔案（wwwroot）
/// 讓 index.html、app.js 可以被存取
app.UseStaticFiles();

/// 啟用 CORS
app.UseCors("AllowAll");

/// 啟用授權（目前沒有登入，但保留）
app.UseAuthorization();

/// 啟用 Web API Controller 路由
app.MapControllers();

/// 🔥 關鍵：
/// 當找不到 API 路由時，自動回傳 index.html
/// 這會讓 `/` 顯示前端頁面，而不是 Swagger
app.MapFallbackToFile("index.html");

/// 啟動應用程式
app.Run();
