
public class BurgerService
{
    public List<Topping> lstTopping = new List<Topping>()
    {
        new Topping(){name ="salad", price=10,quantity=5 },
        new Topping(){name ="beef", price=30,quantity=1 },
        new Topping(){name ="cheese", price=20,quantity=1 },
    };


    public event Action OnChange;

    public void ChangeQuantity(string name, int quantity)
    {
        //Dựa vào name để lấy ra topping cần thay đổi
        Topping? topping = lstTopping.SingleOrDefault(item => item.name == name);
        if (topping != null)
        {
            topping.quantity += quantity;
            if (topping.quantity < 1)
            {
                topping.quantity += 1;
            }
        }
        //Cập nhật giao diện
        StateHasChange();
    }
    
        public void RemoveItem (string name)
    {
        //Dựa vào name để lấy ra topping cần thay đổi
        Topping? topping = lstTopping.SingleOrDefault(item => item.name == name);
        if (topping != null)
        {
            lstTopping.Remove(topping);
        }
        //Cập nhật giao diện
        StateHasChange();
    }

    public void StateHasChange()
    {
        this.OnChange?.Invoke();
    }
}