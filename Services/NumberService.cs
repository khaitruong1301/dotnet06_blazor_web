
namespace blazor_dotnet06.Services;


public class NumberService
{
    public int number { get; set; } = 10;
    public NumberService()
    {

    }

    public async Task changeNumber(int quantity)
    {
        number += quantity;
        //Cập nhật lại giao diện
       await StateHasChange();
    }

    public event Action OnChange; //Kết nối với giao diện để chủ động gọi component render lại 


    public async Task StateHasChange()
    {
        OnChange?.Invoke(); //Gọi giao diện component đang kết nối với service chủ động render lại

    }


}