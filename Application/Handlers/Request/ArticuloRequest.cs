namespace Application.Request
{
    public class ArticuloRequest
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int TiendaId { get; set; }
    }
}
