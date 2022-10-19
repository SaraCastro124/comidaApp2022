namespace comidApp.Core
{
    public class cliente
    {
        public ushort Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

        public cliente(ushort id, string nombre, string apellido, string email, string clave)
        {
            this.Id = Id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Clave = clave;
        }
    }
}