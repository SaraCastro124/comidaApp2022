using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;
public class MapCliente: Mapeador<Cliente>
    {
    protected MapCliente(AdoAGBD ado) : base(ado)
        => Tabla = "Cliente";
    public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente(
                IdCliente : Convert.ToByte(fila["idCliente"]),
                nombre  : fila["nombre"].ToString(),
                apellido : fila["apellido"].ToString(),
                email : fila["email"].ToString(),
                clave : fila["clave"].ToString()
            );
    public List<Pedido> ObtenerPedidos() => ColeccionDesdeTabla();
    public List<Pedido> ObtenerPedidos(Pedido pedido)
    {
        
    }
    }


