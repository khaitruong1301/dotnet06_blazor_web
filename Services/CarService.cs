
namespace blazor_dotnet06.Services;

public class CarService
{
    public string color = "red";


    public event Action OnChange;

    public async Task ChangeColor(string colorParam)
    {
        color = colorParam;
        await StateHasChanged();
    }

    public async Task StateHasChanged()
    {
        OnChange?.Invoke();
    }

}



