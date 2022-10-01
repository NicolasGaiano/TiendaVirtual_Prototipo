using System;

namespace TiendaOL
{
    class Program
    {
        static void Main(string[] args)
        {
            //************************************************************************************

            // True dentro del menu False salir del menu

            bool flagMenuTarjetas = false;
            AdminTajetas adminTajetas = new AdminTajetas();

            bool flagMenuCliente = false;
            AdminCliente adminCliente = new AdminCliente();

            bool flagMenuProductos = false;
            AdminProducto adminProducto = new AdminProducto();

            bool flagMenuCarro = false;
            Carrito carrito = new Carrito();

            bool flagMenuTotales = false;
            // el administrador de totales se declara luego de que se deserializan adminCliente y adminTarjeta


            //***********************************************************************

            bool menu = true; // flag de inicio
            int subMenu = 0; // selector de submenu
            int volver = 0;  // variable para volver atras

            bool falgInicio = true;
            bool modoCliente = false;
            bool modoAdmin = false;


            //***********************************************************************

            //Deserializar administradores

            adminTajetas = (SerializaClass.Deserializar(adminTajetas, "AdminTarjetas.bin") as AdminTajetas);

            adminCliente = (SerializaClass.Deserializar(adminCliente, "AdminCliete.bin") as AdminCliente);

            adminProducto = (SerializaClass.Deserializar(adminProducto, "AdminProducto.bin") as AdminProducto);

            

            AdminTotales totales = new AdminTotales(adminCliente, adminTajetas);

            totales = (SerializaClass.Deserializar(totales, "Totales.bin") as AdminTotales);

            //***********************************************************************


            while (menu == true) 
            {
                //********************[0]INICIO******************************************

                while (falgInicio == true)
                {
                    Inicio.MostrarOpciones();
                    try { (falgInicio, subMenu) = Inicio.EjecutarAccion(Convert.ToInt32(Console.ReadLine())); }
                    catch (System.FormatException)
                    {
                        (falgInicio, subMenu) = Inicio.EjecutarAccion(4);
                    }
                }

                //***********************************************************************

                //********************[1]Sub Menu de Clientes****************************
                while (flagMenuCliente == true)
                {
                    MenuClientes.MostrarOpciones();
                    try { flagMenuCliente = MenuClientes.EjecutarAccion(Convert.ToInt32(Console.ReadLine()), adminCliente); }
                    catch (System.FormatException)
                    {
                        flagMenuCliente = MenuClientes.EjecutarAccion(8, adminCliente);
                    }
                }

                //***********************************************************************


                //********************[2]Sub Menu de Tarjetas****************************
                while (flagMenuTarjetas == true)
                {
                    MenuTarjetas.MostrarOpciones();
                    try { flagMenuTarjetas = MenuTarjetas.EjecutarAccion(Convert.ToInt32(Console.ReadLine()), adminTajetas); }
                    catch (System.FormatException)
                    {
                        flagMenuTarjetas = MenuTarjetas.EjecutarAccion(8, adminTajetas);
                    }
                }

                //***********************************************************************


                //********************[3]Sub Menu de Productos***************************

                while (flagMenuProductos == true)
                {
                    MenuProducto.MostrarOpciones();
                    try { flagMenuProductos = MenuProducto.EjecutarAccion(Convert.ToInt32(Console.ReadLine()), adminProducto); }
                    catch (System.FormatException)
                    {
                        flagMenuProductos = MenuProducto.EjecutarAccion(8, adminProducto);
                    }
                }

                //***********************************************************************


                //********************[4]Sub Menu de Totales*****************************
                
                while (flagMenuTotales == true)
                {
                    SubMenuTotales.MostrarOpciones();
                    try { flagMenuTotales = SubMenuTotales.EjecutarAccion(Convert.ToInt32(Console.ReadLine()), adminTajetas,adminCliente,totales); }
                    catch (System.FormatException)
                    {
                        flagMenuTotales = SubMenuTotales.EjecutarAccion(7,adminTajetas,adminCliente,totales);
                    }
                }

                //***********************************************************************


                //********************[5]Sub Menu del Carrito****************************

                while (flagMenuCarro == true)
                {
                    MenuCarro.MostrarOpciones();
                    try { flagMenuCarro = MenuCarro.EjecutarAccion(Convert.ToInt32(Console.ReadLine()), carrito, adminProducto,adminCliente, adminTajetas,totales); }
                    catch (System.FormatException)
                    {
                        flagMenuCarro = MenuCarro.EjecutarAccion(6, carrito, adminProducto, adminCliente, adminTajetas,totales);
                    }
                }

                //***********************************************************************


                //********************[6]Modo Cliente************************************

                while (modoCliente == true)
                {
                    ModoCliente.MostrarOpciones();
                    try { (modoCliente, subMenu) = ModoCliente.EjecutarAccion(Convert.ToInt32(Console.ReadLine()),adminProducto); }
                    catch (System.FormatException)
                    {
                        (modoCliente, subMenu) = Inicio.EjecutarAccion(5);
                    }
                }

                //***********************************************************************


                //********************[7]Modo Administrador******************************

                while (modoAdmin == true)
                {
                    ModoAdmin.MostrarOpciones();
                    try { (modoAdmin, subMenu) = ModoAdmin.EjecutarAccion(Convert.ToInt32(Console.ReadLine())); }
                    catch (System.FormatException)
                    {
                        (modoAdmin, subMenu) = Inicio.EjecutarAccion(6);
                    }
                }

                //***********************************************************************


                //********************Seleccion de subMenu*******************************

                switch (subMenu)
                {
                    case 0://inicio*******************************************************

                   

                        falgInicio = true;

                        break;

                    case 1://Sub Menu de Clientes****************************************

                        subMenu = volver;

                        flagMenuCliente = true;

                        break;

                    case 2://Sub Menu de Tarjetas*****************************************

                        subMenu = volver;

                        flagMenuTarjetas = true;

                        break;

                    case 3://Sub Menu de Productos****************************************

                        subMenu = volver;

                        flagMenuProductos = true;

                        break;

                    case 4://Sub Menu de Totales******************************************

                        subMenu = volver;

                        flagMenuTotales = true;

                        break;

                    case 5://Sub Menu del Carrito*****************************************

                        subMenu = volver;

                        flagMenuCarro = true;

                        break;

                    case 6://Modo Cliente*************************************************

                        subMenu = volver;

                        volver = 6;

                        modoCliente = true;

                        break;

                    case 7://Modo Administrador*******************************************

                        subMenu = volver;

                        volver = 7;

                        modoAdmin = true;

                        break;

                    case 8://Salir del sistema

                        menu = false;

                        break;

                    default:
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                        break;
                }

                //***********************************************************************



            }

            //Serializar administradores

            SerializaClass.Serializar(adminTajetas, "AdminTarjetas.bin");

            SerializaClass.Serializar(adminCliente, "AdminCliete.bin");

            SerializaClass.Serializar(adminProducto, "AdminProducto.bin");

            SerializaClass.Serializar(totales, "Totales.bin");

        }
    }
}
