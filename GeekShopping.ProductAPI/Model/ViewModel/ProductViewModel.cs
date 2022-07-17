namespace GeekShopping.ProductAPI.Model.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
