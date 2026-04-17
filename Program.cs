var builder = WebApplication.CreateBuilder(args);

//DI các thư viện cho ứng dụng


//setup server blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); 

builder.Services.AddHttpClient(); //Thư viện dùng để call api từ server khác

//Trước app là DI (tiêm các service vào ứng dụng)
//Sử dụng các hàm từ service
builder.Services.AddSignalR();

var app = builder.Build();




app.UseRouting();
app.MapBlazorHub(); //kích hoạt server socket của blazor web
app.MapFallbackToPage("/_Host");

app.UseStaticFiles(); // middleware để sử dụng file tĩnh như css, js, img



app.Run();

