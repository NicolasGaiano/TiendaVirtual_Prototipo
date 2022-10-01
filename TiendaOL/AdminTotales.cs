using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOL
{
    [Serializable]
    class AdminTotales
    {


        protected float totaltienda;
        protected List<Cliente> TotalesDeClientes = new List<Cliente>();
        protected List<Tarjeta> TotalesDeTarjetas = new List<Tarjeta>();


        public AdminTotales(AdminCliente adminCliente,AdminTajetas adminTajetas)
        {
            TotalesDeClientes = adminCliente.DarInfoListaClientes();

            TotalesDeTarjetas = adminTajetas.DarInfoTarjeta();

        }


        /***Propiedad para acceder al total***/

        public float unTotalTienda
        {
            get { return totaltienda; }
            set { totaltienda = value; }
        }

        /***Metodos que devuelven los totales***/


        public List<Cliente> DarInfoTotalesClientes()
        {
            List<Cliente> TotalesDeClientesCopia = new List<Cliente>(TotalesDeClientes);
            return TotalesDeClientesCopia;
        }

        public List<Tarjeta> DarInfoTotalesTarjetas()
        {
            List<Tarjeta> TotalesDeTarjetasCopia = new List<Tarjeta>(TotalesDeTarjetas);
            return TotalesDeTarjetasCopia;
        }

        /**************Metodo para calcular totales de la tienda***************/
        /***Este metodo recibe un subtotal cada vez que finaliza una compra***/

        public void CalcularTotaltienda(float subtotal)
        {
            unTotalTienda += subtotal;

        }



    }
}


