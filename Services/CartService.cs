

public class CartService
{
    //Giã sử giỏ hàng có 1 sản phẩm
    public List<ProductCartViewModel> lstProd { get; set; } = new List<ProductCartViewModel>();
  

    public async Task AddItem(ProductCartViewModel itemClick)
    {
        //Kiểm tra giỏ hàng có item đó chưa nếu có thì tăng số lượng nếu chưa có thì thêm vào lstProd
        ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == itemClick.Id);
        if (itemCart != null)
        {
            itemCart.quantity += 1;
        }
        else
        {
            //Tạo mới sản phẩm click
            ProductCartViewModel newProduct = new ProductCartViewModel()
            {
                Id = itemClick.Id,
                name = itemClick.name,
                price = itemClick.price,
                image = itemClick.image,
                quantity = 1,

            };

            lstProd.Add(newProduct);
        }

        //Cập nhật lại giao diện 
        await StateHasChange();
    }

    public async Task ChangeQuantity(int idClick, int quantity)
    {
        //Tìm ra sản phẩm trong giỏ hàng có id = với id được click
        ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == idClick);
        if (itemCart != null)
        {
            itemCart.quantity += quantity;
            if (itemCart.quantity == 0)
            {
                itemCart.quantity += 1;
            }
        }
        //Cập nhật lại giao diện
        await StateHasChange();
    }

    public async Task RemoveItem(int id)
    {
        ProductCartViewModel? itemCart = lstProd.SingleOrDefault(item => item.Id == id);
        if (itemCart != null)
        {
            lstProd.Remove(itemCart);
        }
        //Cập nhật lại giao diện
        StateHasChange();
    }


    public event Action OnChange;

    public async Task StateHasChange()
    {
        this.OnChange?.Invoke();
    }
}