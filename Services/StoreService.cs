
using System.Text.Json;
using Microsoft.AspNetCore.Components;

public class StoreService
{
    //state này là list các store của trang getAll
    public List<StoreViewModel> lstStore = new List<StoreViewModel>();
    //state này của trang edit store
    public StoreViewModel storeDetail = new StoreViewModel();

    public StoreViewModel storeCreate = new StoreViewModel();

    private readonly HttpClient _http;
    private readonly NavigationManager _navigate;

    public StoreService(HttpClient http, NavigationManager navigate)
    {
        _http = http;
        _navigate = navigate;
    }

    public async Task GetStoreById(string id)
    {
        ResponseType<StoreViewModel>? res = await _http.GetFromJsonAsync<ResponseType<StoreViewModel>>(@$"https://apistore.cybersoft.edu.vn/api/Store/getbyid?id={id}");

        if (res != null)
        {
            storeDetail = res.content;
        }
        StateHasChanged();
    }

    public async Task UpdateStore()
    {
        //Gọi api put cập nhật dữ liệu của store
        HttpResponseMessage? response = await _http.PutAsJsonAsync("https://apistore.cybersoft.edu.vn/api/Store", storeDetail);

        Console.WriteLine($@"{JsonSerializer.Serialize(storeDetail)}");
        response.EnsureSuccessStatusCode();
        //Chuyển hướng về trang /crud-store
        _navigate.NavigateTo("/crud-store");
    }

   public async Task CreateStore()
    {
        //Gọi api put cập nhật dữ liệu của store
        HttpResponseMessage? response = await _http.PostAsJsonAsync("https://apistore.cybersoft.edu.vn/api/Store", storeCreate);

        response.EnsureSuccessStatusCode();
        //Chuyển hướng về trang /crud-store
        _navigate.NavigateTo("/crud-store");
    }
    public async Task getAllStore(string keyword = "")
    {
        string url = "https://apistore.cybersoft.edu.vn/api/Store/getAll";
        if (!string.IsNullOrEmpty(keyword))
        {
            url = @$"https://apistore.cybersoft.edu.vn/api/Store/getAll?keyword={keyword}";
        }

        //Dùng http client để gọi api từ server backend apistore.cybersoft.edu.vn
        ResponseType<List<StoreViewModel>>? res = await _http.GetFromJsonAsync<ResponseType<List<StoreViewModel>>>(url);
        if (res != null)
        {
            lstStore = res.content;
        }
        StateHasChanged();

    }

    public async Task DeleteStore(int id)
    {
        var res = await _http.DeleteAsync(@$"https://apistore.cybersoft.edu.vn/api/Store/{id}");

        //Call lại api getall 
        await getAllStore();

    }


    public event Action OnChange;

    public void StateHasChanged()
    {
        OnChange?.Invoke();
    }



}