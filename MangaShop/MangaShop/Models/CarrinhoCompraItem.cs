namespace MangaShop.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }

        public ProductModel ProductModel { get; set; }
        public string CarrinhoCompraId { get; set; }
    }
}
