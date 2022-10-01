using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOL
{


    [Serializable]
    class AdminCliente
    {
        List<Cliente> ListaCliente = new List<Cliente>();
        private float totalClientes;


        //Propiedad para totalesclientes

        public float unTotalesClientes
        {
            set { totalClientes = value; }
            get { return totalClientes; }
        }
        public int unaCantidadClientes
        {
            get { return ListaCliente.Count; }
        }
        //Metodo para cargar un cliente.

        public void CargarCliente(Cliente Cx)
        {
            ListaCliente.Add(Cx);
        }

        public List<Cliente> DarInfoListaClientes()
        {
            List<Cliente> ListaClienteCopia = new List<Cliente>(ListaCliente);
            return ListaClienteCopia;
        }

        public (string, bool, int) IdentificarCliente(int dni_cliente)
        {
            string info_cliente = "-->Cliente no registrado.\n-->Cargar cliente nuevo...";
            bool existe_cliente = false;
            int indiceCliente = -1;

            for (int i = 0; i < ListaCliente.Count; i++)
            {
                if (ListaCliente[i].unDNI == dni_cliente)
                {
                    info_cliente = ListaCliente[i].DarInfoCliente();
                    existe_cliente = true;
                    indiceCliente = i;
                }

            }
            return (info_cliente, existe_cliente, indiceCliente);

        }

        public (string, bool) EliminarCliente(int dni_cliente)
        {
            string info_cliente = "[X] NO SE ECONTRO CLIENTE ";
            bool cliente_eliminado = false;

            for (int i = 0; i < ListaCliente.Count; i++)
            {
                if (ListaCliente[i].unDNI == dni_cliente)
                {
                    info_cliente = "[X] SE ELIMINO: " + ListaCliente[i].DarInfoCliente();
                    ListaCliente.RemoveAt(i);
                    cliente_eliminado = true;

                }

            }
            return (info_cliente, cliente_eliminado);
        }

        public void CalcularTotalesClientes()
        {
            foreach (Cliente var in ListaCliente)
            {
                unTotalesClientes += var.unTotal;
            }
        }

        public void TotalCliente(int indiceCliente, float subtotal)
        {
            ListaCliente[indiceCliente].unTotal += subtotal;
        }
    }


    [Serializable]
    public class Cliente
    {

        private string nombre;
        private string apellido;
        private int DNI;
        private object tarjeta;
        private float total;
        private DateTime nacimiento;

        //Propiedades que permite cargar los datos.
        //Quien carga los datos es la clase AdminClientes.
        //Luego cada cliente queda en la lista, por lo tanto no es necasario
        //que se lean desde aqui.

        public string unNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public string unApellido
        {
            set { apellido = value; }
            get { return apellido; }
        }
        public int unDNI
        {
            set { DNI = value; }
            get { return DNI; }
        }

        public object unaTarjeta
        {
            set { tarjeta = value; }
            get { return tarjeta; }
        }

        public float unTotal
        {
            set { total = value; }
            get { return total; }
        }

        public DateTime unNacimiento
        {
            set { nacimiento = value; }
            get { return nacimiento; }

        }


        //Metodo para calcular el total

        public float CalcularTotales(float total_ultima_compra)
        {
            total += total_ultima_compra;
            return total;
        }

        public string DarInfoCliente()
        {
            return "Nombre: " + unNombre + ", Apellido: " + unApellido + ", DNI: " + unDNI + ", Total: $" + unTotal;
        }
    }


}

