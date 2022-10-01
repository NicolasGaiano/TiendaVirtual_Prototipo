using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOL
{
    [Serializable]
    class AdminProducto
    {

        List<Producto> productos = new List<Producto>();
        public void CargarProducto(Producto prod)
        {
            productos.Add(prod);
        }
        public void CargarPromo(int eleccion, int porcentaje)
        {
            productos[eleccion].EnPromo(porcentaje);
            productos[eleccion].CalcularPrecio(porcentaje);
        }
        public void QuitarProducto(int eleccion, int num)
        {
            if (num < productos[eleccion].Cantidad)
            {
                productos[eleccion].Cantidad = productos[eleccion].Cantidad - num;
            }
            else
            {
                productos.RemoveAt(eleccion);
            }
        }

        // metodo para mostrar lista de productos
        public List<Producto> DarInfoProductos()
        {
            List<Producto> ListaCopia = new List<Producto>(productos);
            return ListaCopia;

        }

        // metodo para agregar producto al carro
        public Producto DarInfoProducto(int seleccion)
        {
            return productos[seleccion];
        }
    }

    [Serializable]
    class Producto
    {
        private string tipo;
        private string marca;
        private string talle;
        private float precio;
        private bool descuento = false;
        private int porcentaje = 0;
        private int cantidad;

        //---------------------------- Propiedades ----------------------------//
        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
            }
        }
        public string Talle
        {
            get
            {
                return talle;
            }
            set
            {
                talle = value;
            }
        }
        public float Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }
        public bool Descuento
        {
            get
            {
                return descuento;
            }
            set
            {
                descuento = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public int Porcentaje
        {
            get
            {
                return porcentaje;
            }
            set
            {
                porcentaje = value;
            }
        }

        //---------------------------- Metodos ----------------------------//

        public string DarInfoProducto()
        {
            return "[PRODUCTO] Tipo: " + Tipo + ", Marca: " + Marca + ", Talle: " + Talle + ", Precio: $ " + Precio + ", Descuento: " + porcentaje + "%" + ", Cantidad Disponible: " + Cantidad;
        }
        public string DarInfoPromo()
        {
            if (descuento == true)
            {
                return "[PRODUCTO] Tipo: " + Tipo + ", Marca: " + Marca + ", Talle: " + Talle + ", Precio: $ " + Precio + ", Descuento: " + porcentaje + "%" + ", Cantidad Disponible: " + Cantidad;
            }
            else
            {
                return null;
            }
        }
        public void EnPromo(int porcentaje)
        {
            descuento = true;
            this.porcentaje = porcentaje;
        }
        public void CalcularPrecio(int x)
        {
            precio = precio * (1 - (float)x / 100);
        }
    }

}
