using System;
using System.Collections.Generic;
using System.Text;


namespace TiendaOL
{
    
    class Carrito
    {
        private float total;
        private int cantidad;
        private float totales_clientes;
        List<Producto> ListaProductosCarro = new List<Producto>();
        List<int> IndicesProductos = new List<int>();

        
        public float unTotal
        {
            get { return total; }
            set { total = value; }
        }

        public int unaCantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public float unTotalesCliente
        {
            get { return totales_clientes; }
            set { totales_clientes = value; }
        }

        public void AgregarAlCarro(Producto prod, int cantidad)
        {
            Producto prodEnCarro = new Producto();
            prodEnCarro.Tipo = prod.Tipo;
            prodEnCarro.Marca = prod.Marca;
            prodEnCarro.Talle = prod.Talle;
            prodEnCarro.Precio = prod.Precio;
            prodEnCarro.Descuento = prod.Descuento;
            prodEnCarro.Porcentaje = prod.Porcentaje;
            prodEnCarro.Cantidad = cantidad;
            //prodEnCarro= prod;
            //prodEnCarro.Cantidad=cantidad;
            ListaProductosCarro.Add(prodEnCarro);
        }
        public void QuitarDelCarro(int eleccion, int num)
        {
            if (num < ListaProductosCarro[eleccion].Cantidad)
            {
                ListaProductosCarro[eleccion].Cantidad = ListaProductosCarro[eleccion].Cantidad - num;
            }
            else
            {
                ListaProductosCarro.RemoveAt(eleccion);
            }
        }
        public void VaciarCarro()
        {
            ListaProductosCarro.Clear();
        }
        public List<Producto> ListarProductosCarro()
        {
            List<Producto> ListaCopia = new List<Producto>(ListaProductosCarro);
            return ListaCopia;
        }
        public float CalcularGastoTotal()
        {
            total = 0;
            for (int i = 0; i < ListaProductosCarro.Count; i++)
            {
                total = total + ListaProductosCarro[i].Precio * ListaProductosCarro[i].Cantidad;
            }
            return total;
        }
        public void FinalizarCompra()
        {
            ListaProductosCarro.Clear();
            IndicesProductos.Clear();
        }

        // metodo para guardar indices de los productos para luego eliminar del stock
        public void GuardarIndice(int x)
        {
            IndicesProductos.Add(x);
        }

        // metodo para pasar indices de los productos a eliminar
        public List<int> PasarIndices()
        {
            List<int>  ListaCopia= new List<int>(IndicesProductos);
            ListaCopia.Sort(); // ordena la lista de indices 
            return ListaCopia;
        }

        //Agregar gasto total de compra a tarjeta
        public void CargarGasto(float gasto , int indiceTarjeta, AdminTajetas admin, bool beneficio)
        {
           
                
                try { admin.ListaTarjetas[indiceTarjeta].Total+= gasto; }
                catch (SystemException) { } 
            
           

        }

    }
}
