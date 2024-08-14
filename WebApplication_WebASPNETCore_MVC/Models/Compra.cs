namespace WebApplication_WebASPNETCore_MVC.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
    }
}
