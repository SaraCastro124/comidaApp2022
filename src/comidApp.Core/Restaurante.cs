namespace comidApp.Core
{
    public class Restaurante : CosaPedido
    {
        public ushort idRestaurante { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Clave { get; set; }
        
        public Restaurante(ushort idRestaurante, string email, string nombre, string domicilio, string clave)
            : base()
        {
            this.idRestaurante = idRestaurante;
            this.Email = email;
            this.Nombre = nombre;
            this.Domicilio = domicilio;
            this.Clave = clave;
        }

        public Restaurante()
        {
            
        }
    }
}