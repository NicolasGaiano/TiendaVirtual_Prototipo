using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaOL
{
    [Serializable]
    internal class AdminTajetas
    {
        protected List<Tarjeta> listaTarjetas = new List<Tarjeta>();
        protected List<Beneficio> listaBeneficios = new List<Beneficio>();
        protected float totalTarjetas;

        public AdminTajetas()
        {

        }

        public float TotalTarjetas
        {
            get { return totalTarjetas; }
            set { totalTarjetas = value; }
        }
        public List<Tarjeta> ListaTarjetas
        {
            get { return listaTarjetas; }
            set { listaTarjetas = value; }
        }

        public List<Beneficio> ListaBeneficios
        {
            get { return listaBeneficios; }
            set { listaBeneficios = value; }
        }

        //***************************Alta baja Tajeta***************************//
        public void CargarTarjeta(Tarjeta NuevaTarjeta)
        {
            ListaTarjetas.Add(NuevaTarjeta);
        }

        public void QuitarTarjeta(int i)
        {

            if (listaTarjetas[i].Beneficio== false)
            {
                try { ListaTarjetas.RemoveAt(i); }
                catch (SystemException) { }
            }
            
        }

        //**********************************************************************//

        //***************************Alta baja Beneficio***********************//
        public void AgregarBeneficio(Beneficio NuevoBeneficio)
        {

            ListaBeneficios.Add(NuevoBeneficio);

            
            // la tarjeta con benefico se agrega a la lista total de tarjetas 
            // la ubicacion de la tajeta con beneficio sera en el mismo indice 
            // que en la listaBeneficios
            int tamLB = listaBeneficios.Count;
            int indLBadd = tamLB - 2;

            // el beneficio se asigna como una forma de pago a la tarjeta
            Tarjeta Tb = new Tarjeta
            {
                Nombre = NuevoBeneficio.TarjetaConBeneficio.Nombre + "[con Beneficio]",
                Banco = NuevoBeneficio.TarjetaConBeneficio.Banco,
                Total = 0,
                Beneficio = true,

            };
            
            Tb.ListaFormasDePago.Add(NuevoBeneficio.PBeneficio);
            
            

            if (tamLB == 1)
            {
               listaTarjetas.Insert(0, Tb);
               listaTarjetas.Reverse(0, 1);
            }
            else { listaTarjetas.Insert(indLBadd, Tb); }
            

        }

        public void QuitarBeneficio(int i)
        {

            // los indices coinciden an ambas listas.
            try { ListaBeneficios.RemoveAt(i); }
            catch (SystemException) { }

           try { listaTarjetas.RemoveAt(i); }
            catch (SystemException) { }


        }

        //**********************************************************************//

        //*********************************INFO********************************//

        //se retorna a la interfaz de usuario una copia de la lista que corresponda. 
        public List<Tarjeta> DarInfoTarjeta()
        {
            List<Tarjeta> listaTarjetasCopia = new List<Tarjeta>(ListaTarjetas);

            return listaTarjetasCopia;
        }
        public List<Beneficio> DarInfoBeneficio()
        {
            List<Beneficio> listaBeneficiosCopia = new List<Beneficio>(ListaBeneficios);

            return listaBeneficiosCopia;


        }

        //**********************************************************************//

        //*************************Total con tarjetas***************************//
        public float CalcularTotal()
        {
            totalTarjetas = 0;

            foreach (Tarjeta t in listaTarjetas )
            {
                totalTarjetas += t.Total;
            }

            return totalTarjetas;
        }
        //**********************************************************************//
    }


    [Serializable]
    internal class Tarjeta
    {
        protected string nombre;
        protected string banco;
        protected float total;
        protected bool beneficio = false;
        protected List<FormaDePago> listaFormasDePago = new List<FormaDePago>();

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        public List<FormaDePago> ListaFormasDePago
        {
            get { return listaFormasDePago; }
            set { listaFormasDePago = value; }
        }

        public bool Beneficio
        {
            get { return beneficio; }
            set { beneficio = value; }
        }
    }

    [Serializable]
    internal class FormaDePago
    {
        protected int numCuotas;
        protected int interesXcuota;

        public int NumCuotas
        {
            get { return numCuotas; }
            set { numCuotas = value; }
        }

        public int InteresXcuota
        {
            get { return interesXcuota; }
            set { interesXcuota = value; }
        }
    }

    [Serializable]
    internal class Beneficio
    {
        protected Tarjeta tarjetaConBeneficio;
        protected FormaDePago pBeneficio;

        public Tarjeta TarjetaConBeneficio
        {
            get { return tarjetaConBeneficio; }
            set { tarjetaConBeneficio = value; }
        }
        public FormaDePago PBeneficio
        {
            get { return pBeneficio; }
            set { pBeneficio = value; }
        }


        public Beneficio()
        {

        }

        public void Tarjeta(Tarjeta tarjetaConBeneficio)
        {
            this.tarjetaConBeneficio = tarjetaConBeneficio;
        }
        public void FP(FormaDePago pBeneficio)
        {
            this.pBeneficio = pBeneficio;
        }

    }
}
