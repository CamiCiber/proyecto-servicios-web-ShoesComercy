namespace AppCustomer.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? nombre { get; set; }
        public string? Apellido { get; set; }
        public int dni { get; set; }
        public string? direccion { get; set; }
        public int telefono { get; set; }

    }
}
