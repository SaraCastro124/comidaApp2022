namespace comidApp.Core;

    public class Cliente : CosaPedido
    {
        public ushort IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public Cliente(ushort IdCliente, string nombre, string apellido, string email, string clave)
            : base()
        {
            this.IdCliente = IdCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Clave = clave;
        }

        public Cliente()
        {
            
        }
    }
