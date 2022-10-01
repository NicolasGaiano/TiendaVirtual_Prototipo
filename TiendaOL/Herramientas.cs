using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace TiendaOL
{

    //************************Menu Generico*********************************************
    class Menu
    {
        protected string titulo;
        protected List<string> opciones;

        public Menu(string titulo, List<string> opciones)
        {
            this.titulo = titulo;
            this.opciones = opciones;

            Console.WriteLine("********************************************");
            Console.WriteLine("        " + titulo);
            Console.WriteLine("********************************************");

        }

        public void MostrarOpciones()
        {
            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion);
            }

            Console.WriteLine("********************************************");
            Console.WriteLine("");
        }



    }

    //**********************************************************************************

    //*************Inicio***************************************************************
    class Inicio
    {


        Inicio()
        {



        }

        public static void MostrarOpciones()
        {
            Console.Clear();

            List<string> inicio = new List<string> {
            "[1] Modo Cliente",
            "[2] Modo Administrador",
            "[3] Salir del Sistema"
        };


            Menu MenuTa = new Menu("      Sports X", inicio);
            MenuTa.MostrarOpciones();
        }

        public static (bool, int) EjecutarAccion(int accion)
        {
            switch (accion)
            {
                case 1://Modo Ciente************************************************************************************************

                    return (false,6);

                case 2://Modo Administrador*****************************************************************************************

                    return (false,7);

                case 3://Salir del Sistema*******************************************************************************************

                    return (false,8);



                default://************************************************************************************************************
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return (true, 0);


            }


        }
    }

    //**********************************************************************************

    //*************Modo Administrador****************************************************

    class ModoAdmin
    {


        ModoAdmin()
        {



        }

        public static void MostrarOpciones()
        {
            Console.Clear();

            List<string> modoAdmin = new List<string> {
            "[1] Administrador De Productos",
            "[2] Administrador De Tarjetas",
            "[3] Administrador De Clientes",
            "[4] Administrador De Totales",
            "[5] Volver"
        };


            Menu MenuTa = new Menu("Modo Administrador", modoAdmin);
            MenuTa.MostrarOpciones();
        }

        public static (bool, int) EjecutarAccion(int accion)
        {
            switch (accion)
            {
                case 1://Administrador De Productos**********************************************************************************

                    return (false, 3);

                case 2://Administrador De Tarjetas************************************************************************************

                    return (false, 2);

                case 3://Administrador De Clientes************************************************************************************

                    return (false, 1);

                case 4://Administrador De Totales*************************************************************************************

                    return (false, 4);

                case 5://Volver*******************************************************************************************************

                    return (false, 0);



                default://************************************************************************************************************
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return (true, 7);


            }


        }
    }

    //**********************************************************************************


    //*************Modo Cliente*********************************************************
    class ModoCliente
    {


        ModoCliente()
        {



        }

        public static void MostrarOpciones()
        {
            Console.Clear();

            List<string> modoCliente = new List<string> {
            "[1] Mi Carrito",
            "[2] Catalogo",
            "[3] Promociones",
            "[4] Volver"
        };


            Menu MenuTa = new Menu("Modo Cliente", modoCliente);
            MenuTa.MostrarOpciones();
        }

        public static (bool, int) EjecutarAccion(int accion, AdminProducto adminProducto)
        {
            switch (accion)
            {
                case 1://Mi Carrito***************************************************************************************************

                    return (false, 5);

                case 2://Catalogo*****************************************************************************************************


                    MenuProducto.ImprimirListaCopia((adminProducto.DarInfoProductos()));

                    return (true, 0);

                case 3://Promociones**************************************************************************************************

                    MenuProducto.ImprimirListaCopiaEnPromo((adminProducto.DarInfoProductos()));

                    return (true, 0);

              

                case 4://Volver*******************************************************************************************************

                    return (false, 0);



                default://************************************************************************************************************
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return (true, 7);


            }


        }
    }

    //**********************************************************************************


    //*************Sub Menu Tarjetas****************************************************
    class MenuTarjetas
    {


        MenuTarjetas()
        {



        }

        public static void MostrarOpciones()
        {
            Console.Clear();

            List<string> opcionesTarjetas = new List<string> {
            "[1] Agregar Tarjeta",
            "[2] Quitar  Tarjeta",
            "[3] Agregar Beneficio",
            "[4] Quitar  Beneficio",
            "[5] Listar  Tarjetas",
            "[6] Listar  Tarjetas con Beneficios",
            "[7] Volver"
        };


            Menu MenuTa = new Menu("Administrador de Tarjetas", opcionesTarjetas);
            MenuTa.MostrarOpciones();
        }

        public static bool EjecutarAccion(int accion, AdminTajetas adminTajetas)
        {
            switch (accion)
            {
                case 1://Agregar Tarjeta****************************************************************
                    bool flagFP = true;
                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Agregar Tarjeta");
                    Console.WriteLine("********************************************");

                    List<FormaDePago> formaDePagos = new List<FormaDePago>();

                    Tarjeta tarjetaNueva = new Tarjeta();

                    Console.WriteLine("[+]Ingrese el Nombre de la Tarjeta");
                    tarjetaNueva.Nombre = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("[+]Ingrese el Banco");
                    tarjetaNueva.Banco = Convert.ToString(Console.ReadLine());


                    while (flagFP == true)
                    {
                        FormaDePago formaDePago = new FormaDePago();

                        Console.WriteLine("[+]Ingrese Forma de Pago");
                        Console.WriteLine(" ->Numero de Cuotas:");

                        try { formaDePago.NumCuotas = Convert.ToInt32(Console.ReadLine()); }
                        catch (System.FormatException) { formaDePago.NumCuotas = -1; }
                        Console.WriteLine(" ->Interes por cuota");

                        try { formaDePago.InteresXcuota = Convert.ToInt32(Console.ReadLine()); }
                        catch (System.FormatException) { formaDePago.InteresXcuota = -1; }

                        if ((formaDePago.NumCuotas >= 0) && (formaDePago.InteresXcuota >= 0))
                        {
                            formaDePagos.Add(formaDePago);
                        }

                        Console.WriteLine(" ->Ingresar otra forma de pago? [ si / no ]");

                        if (Convert.ToString(Console.ReadLine()) == "no")
                        {
                            flagFP = false;
                        }

                    }

                    tarjetaNueva.ListaFormasDePago = formaDePagos;
                    tarjetaNueva.Total = 0;

                    adminTajetas.CargarTarjeta(tarjetaNueva);
                    return true;

                case 2://Quitar  Tarjeta**************************************************************************************

                    List<Tarjeta> listaDeTarjetasQ = adminTajetas.DarInfoTarjeta();
                    int i = 0;
                    int selecion;

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Quitar Tarjeta");
                    Console.WriteLine("********************************************");

                    foreach (Tarjeta tarjeta in listaDeTarjetasQ)
                    {

                        Console.WriteLine("[{0}] Tarjeta: " + tarjeta.Nombre + "  Banco: " + tarjeta.Banco, i);
                        i++;
                    }

                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->Seleccione la Tarjeta a Borrar");

                    try { selecion = Convert.ToInt32(Console.ReadLine()); }
                    catch (System.FormatException)
                    {
                        selecion = -1;
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }

                    try
                    {
                        if (selecion >= 0)
                        {

                            if (listaDeTarjetasQ[selecion].Beneficio == false)
                            {
                                adminTajetas.QuitarTarjeta(selecion);
                                Console.WriteLine("Tarjeta Borrada! \n ->presione una tecla para continuar...");

                            }
                            else
                            {
                                Console.WriteLine("La tarjeta seleccionada tiene Beneficio \n" +
                                                  "seleccione la opcion [4] Quitar Beneficio  \n " +
                                                  "->presione una tecla para continuar...");
                            }
                            Console.ReadLine();
                        }
                    }catch(System.FormatException) 
                    {

                        selecion = -1;
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }


                    return true;

                case 3://Agregar Beneficio*************************************************************************************

                    List<Tarjeta> listaDeTarjetasAB = adminTajetas.DarInfoTarjeta();
                    FormaDePago fPBeneficio = new FormaDePago();
                    Beneficio NuevoBeneficio = new Beneficio();
                    int k = 0;
                    int seleccionAB;



                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Agregar Beneficio");
                    Console.WriteLine("********************************************");

                    foreach (Tarjeta tarjeta in listaDeTarjetasAB)
                    {
                        Console.WriteLine("[{0}] Tarjeta: " + tarjeta.Nombre + "  Banco: " + tarjeta.Banco, k);
                        k++;
                    }

                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->Seleccione Tarjeta para Agregar Beneficio");

                    try { seleccionAB = Convert.ToInt32(Console.ReadLine()); }
                    catch (System.FormatException)
                    {
                        seleccionAB = -1;
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }


                    if (seleccionAB >= 0)
                    {

                        Console.WriteLine("[+]Ingrese Forma de Pago con Beneficio");
                        Console.WriteLine(" ->Numero de Cuotas:");

                        try { fPBeneficio.NumCuotas = Convert.ToInt32(Console.ReadLine()); }
                        catch (System.FormatException) { fPBeneficio.NumCuotas = -1; }

                        Console.WriteLine(" ->Interes por cuota");

                        try { fPBeneficio.InteresXcuota = Convert.ToInt32(Console.ReadLine()); }
                        catch (System.FormatException) { fPBeneficio.InteresXcuota = -1; }

                        if ((fPBeneficio.NumCuotas >= 0) && (fPBeneficio.InteresXcuota >= 0))
                        {
                            NuevoBeneficio.Tarjeta(listaDeTarjetasAB[seleccionAB]);
                            NuevoBeneficio.FP(fPBeneficio);

                            adminTajetas.AgregarBeneficio(NuevoBeneficio);

                            Console.WriteLine("Se Agrego el Beneficio! \n ->presione una tecla para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                            Console.ReadLine();
                        }

                    }


                    return true;

                case 4://Quitar  Beneficio*************************************************************************************

                    List<Beneficio> listaDeTarjetasBeneQ = adminTajetas.DarInfoBeneficio();
                    int j = 0;
                    int seleccionTB;

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Quitar Tarjeta con Beneficios");
                    Console.WriteLine("********************************************");

                    foreach (Beneficio tarjeta in listaDeTarjetasBeneQ)
                    {
                        Console.WriteLine("********************************************");
                        Console.WriteLine("[{0}] Tarjeta: " + tarjeta.TarjetaConBeneficio.Nombre +
                                                 " Banco: " + tarjeta.TarjetaConBeneficio.Banco, j);
                        Console.WriteLine("  ->Beneficio: " + tarjeta.PBeneficio.NumCuotas + " Cuotas con "
                                            + tarjeta.PBeneficio.InteresXcuota + "% de interes");
                        j++;
                    }

                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->Seleccione la Tarjeta con Beneficio a Borrar");

                    try { seleccionTB = Convert.ToInt32(Console.ReadLine()); }
                    catch (System.FormatException)
                    {
                        seleccionTB = -1;
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }


                    if (seleccionTB >= 0)
                    {
                        adminTajetas.QuitarBeneficio(seleccionTB);
                        Console.WriteLine("Tarjeta Borrada! \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }


                    return true;

                case 5://Listar  Tarjetas***************************************************************************************

                    List<Tarjeta> listaDeTarjetas = adminTajetas.DarInfoTarjeta();

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Lista de Tarjetas");
                    Console.WriteLine("********************************************");

                    foreach (Tarjeta tarjeta in listaDeTarjetas)
                    {
                        Console.WriteLine("********************************************");
                        Console.WriteLine("[+]Tarjeta: " + tarjeta.Nombre);
                        Console.WriteLine("[+]Banco: " + tarjeta.Banco);

                        Console.WriteLine("[+]Formas de pago:");
                        foreach (FormaDePago fp in tarjeta.ListaFormasDePago)
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("  -> Numero de Cuotas: " + fp.NumCuotas);
                            Console.WriteLine("  -> Interes por Cuota: " + fp.InteresXcuota);

                        }
                        Console.WriteLine("-------------------------------------");

                        Console.WriteLine("[+]Total: " + tarjeta.Total);

                    }

                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->presione una tecla para continuar...");
                    Console.ReadLine();

                    return true;

                case 6://Listar  Tarjetas con Beneficios****************************************************************************

                    List<Beneficio> listaDeTarjetasBene = adminTajetas.DarInfoBeneficio();

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Lista de Tarjetas con Beneficios");
                    Console.WriteLine("********************************************");

                    foreach (Beneficio tarjeta in listaDeTarjetasBene)
                    {
                        Console.WriteLine("********************************************");
                        Console.WriteLine("[+]Tarjeta: " + tarjeta.TarjetaConBeneficio.Nombre);
                        Console.WriteLine("[+]Banco: " + tarjeta.TarjetaConBeneficio.Banco);
                        Console.WriteLine("[+]Beneficio: " + tarjeta.PBeneficio.NumCuotas + " Cuotas con "
                                            + tarjeta.PBeneficio.InteresXcuota + "% de interes");
                    }

                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->presione una tecla para continuar...");
                    Console.ReadLine();

                    return true;

                case 7://salir y guardar*********************************************************************************************
                    // aca hay que serializar el admin tarjetas 
                    return false;



                default://************************************************************************************************************
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;


            }


        }
    }

    //**********************************************************************************


    //*************Sub Menu Clientes****************************************************
    class MenuClientes
    {


        MenuClientes()
        {



        }

        public static void MostrarOpciones()
        {
            Console.Clear();

            List<string> opcionesClientes = new List<string> {
            "[1] Agregar Cliente",
            "[2] Quitar  Cliente",
            "[3] Identificar Cliente",
            "[4] Lista Cliente",
            "[5] Volver"
        };


            Menu MenuCli = new Menu("Administrador de Clientes", opcionesClientes);
            MenuCli.MostrarOpciones();
        }

        public static bool EjecutarAccion(int accion, AdminCliente admincliente)
        {
            switch (accion)
            {
                case 1://Agregar Clientes****************************************************************
                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Agregar Cliente");
                    Console.WriteLine("********************************************");

                    Cliente ClienteNuevo = new Cliente();
                    bool cargar = true;

                    try
                    {
                        (cargar, ClienteNuevo) = SubMenuCargar();

                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        cargar = false;

                        Console.WriteLine("[X] Fecha no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }
                    catch (System.FormatException)
                    {
                        cargar = false;
                        Console.WriteLine("[X] No se registro un numero, revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();


                    }
                    catch (Exception e)
                    {
                        cargar = false;
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();


                    }


                    if (cargar)
                        admincliente.CargarCliente(ClienteNuevo);

                    return true;

                case 2://Quitar  Cliente**************************************************************************************

                    List<Cliente> listaDeCLientes_x_quitar = admincliente.DarInfoListaClientes();

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Quitar Cliente");
                    Console.WriteLine("********************************************");
                    try
                    {
                        for (int i = 0; i < listaDeCLientes_x_quitar.Count; i++)
                        {
                            Console.WriteLine(listaDeCLientes_x_quitar[i].DarInfoCliente());
                        }


                        Console.WriteLine("\n\n[+] Ingrese DNI del cliente a eliminar:\n");
                        var (retorno, retorno_bool) = admincliente.EliminarCliente(Int32.Parse(Console.ReadLine()));
                        Console.WriteLine(retorno);
                        Console.WriteLine("->presione una tecla para continuar...");
                        Console.ReadLine();
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();

                    }

                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("[X] Error al imprimir");
                        Console.WriteLine("->presione una tecla para continuar...");
                        Console.ReadLine();

                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("[X] Error al imprimir");
                        Console.WriteLine("->presione una tecla para continuar...");
                        Console.ReadLine();
                    }


                    return true;

                case 3://Identificar Cliente *************************************************************************************

                    List<Cliente> listaDeCLientes_x_identificar = admincliente.DarInfoListaClientes();

                    Console.Clear();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Identificar Cliente");
                    Console.WriteLine("********************************************");

                  
                    try
                    {
                        Console.WriteLine("[+] Ingrese DNI: ");
                        var (salida, existe_cliente,indiceCliente) = admincliente.IdentificarCliente(Int32.Parse(Console.ReadLine()));
                        /*--El metodo IdentificarCliente retorna un bool que será FALSE si no existe--*/
                        /*--En ese caso de permite registrar el nuevo cliente*/

                        if (!existe_cliente)
                        {
                            Console.WriteLine("\n********************************************");
                            Console.WriteLine("El cliente no se encuentra en el sistema");
                            Console.WriteLine("->presione una tecla para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\n********************************************");
                            Console.WriteLine(salida);
                            Console.WriteLine("->presione una tecla para continuar...");
                            Console.ReadLine();
                        }
                    }
                    catch (System.FormatException)
                    {
       
                        Console.WriteLine("[X] No se registro un numero, revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();


                    }
                    catch (Exception e)
                    {
   
                        Console.WriteLine(e.Message);
                        Console.WriteLine("[X] Revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();


                    }

                    return true;

                case 4://Listar Clientes*************************************************************************************


                    List<Cliente> listaDeCLientes_x_imprimir = admincliente.DarInfoListaClientes();

                    try
                    {
                        for (int i = 0; i < listaDeCLientes_x_imprimir.Count; i++)
                            Console.WriteLine(listaDeCLientes_x_imprimir[i].DarInfoCliente());



                        Console.WriteLine("********************************************");
                        Console.WriteLine("\n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();

                    }

                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("[X] Error al imprimir");
                        Console.WriteLine("->presione una tecla para continuar...");
                        Console.ReadLine();

                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("[X] Error al imprimir");
                        Console.WriteLine("->presione una tecla para continuar...");
                        Console.ReadLine();
                    }

                    return true;


                case 5://salir y guardar**********************************************************************************************
                    
                    return false;

                



                default://************************************************************************************************************
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;


            }


        }

        public static (bool, Cliente) SubMenuCargar()
        {
            Cliente ClienteNuevo = new Cliente();
            int año, mes, dia;
            bool cargar = true, es_nombre = true, es_apellido = true;
            Console.WriteLine("[+] Ingrese nombre:");
            ClienteNuevo.unNombre = (Console.ReadLine().ToUpper());
            es_nombre = Regex.IsMatch(ClienteNuevo.unNombre, @"^[a-zA-Z]+$");

            if (!es_nombre)
                throw new Exception("[X] El nómbre debe contener solo letras.");

            Console.WriteLine("[+]Ingrese apellido:");
            ClienteNuevo.unApellido = (Console.ReadLine().ToUpper());
            es_apellido = Regex.IsMatch(ClienteNuevo.unApellido, @"^[a-zA-Z]+$");

            if (!es_apellido)
                throw new Exception("[X] El apellido debe contener solo letras.");

            Console.WriteLine("[+] Ingrese DNI:");
            ClienteNuevo.unDNI = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] Ingrese Fecha de nacimiento:");
            Console.WriteLine("[+]--->AÑO:");
            año = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] --->MES:");
            mes = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] --->DÍA:");
            dia = (Int32.Parse(Console.ReadLine()));
            ClienteNuevo.unNacimiento = new DateTime(año, mes, dia);

            return (cargar, ClienteNuevo);
        }

    }

    //**********************************************************************************


    //*************Sub Menu Productos ****************************************************
    class MenuProducto
    {
        public static void MostrarOpciones()
        {
            Console.Clear();
            List<string> opcionesProductos = new List<string>{
            "[1] Dar alta producto",
            "[2] Dar alta promociones",
            "[3] Listar productos",
            "[4] Listar promociones",
            "[5] Quitar Producto",
            "[6] Volver"
        };
            Menu MenuProd = new Menu("Administrador de Productos", opcionesProductos);
            MenuProd.MostrarOpciones();
        }
        public static bool EjecutarAccion(int accion, AdminProducto adminprod)
        {

            switch (accion)
            {


                case 1: // Dar alta producto
                    Producto NuevoProd = new Producto();
                    Console.WriteLine("[+] Ingrese tipo de producto");
                    NuevoProd.Tipo = Console.ReadLine();
                    Console.WriteLine("[+] Ingrese marca de producto");
                    NuevoProd.Marca = Console.ReadLine();
                    Console.WriteLine("[+] Ingrese talle de producto");
                    NuevoProd.Talle = Console.ReadLine();
                    Console.WriteLine("[+] Ingrese precio del producto");
                    try
                    {
                        NuevoProd.Precio = float.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        NuevoProd.Precio = -1;
                    }
                    Console.WriteLine("[+] ingrese cantidad del producto");
                    try
                    {
                        NuevoProd.Cantidad = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        NuevoProd.Cantidad = -1;
                    }
                    if ((NuevoProd.Precio >= 0) && (NuevoProd.Cantidad >= 0))
                    {
                        adminprod.CargarProducto(NuevoProd);
                    }
                    else
                    {
                        Console.WriteLine("Dato ingresado erroneo, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    return true;


                case 2: // Dar alta promociones
                    ImprimirListaCopia(adminprod.DarInfoProductos());
                    Console.WriteLine("[+] ELIJA UN PRODUCTO PARA PONER EN PROMOCION");
                    int eleccionpromo;
                    int porcentaje;
                    try
                    {
                        eleccionpromo = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        eleccionpromo = -1;
                    }
                    Console.WriteLine("[+] INDIQUE PORCENTAJE DE DESCUENTO");
                    try
                    {
                        porcentaje = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        porcentaje = -1;
                    }
                    if ((eleccionpromo >= 0) && (porcentaje >= 0))
                    {
                        try
                        {
                            adminprod.CargarPromo(eleccionpromo, porcentaje);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Error al ingresar indice, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dato ingresado erroneo, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    return true;


                case 3: // Listar productos
                    ImprimirListaCopia(adminprod.DarInfoProductos());
                    return true;


                case 4: // Listar productos en promo
                    ImprimirListaCopiaEnPromo(adminprod.DarInfoProductos());
                    return true;


                case 5: // Quitar Producto
                    ImprimirListaCopia(adminprod.DarInfoProductos());
                    int eleccionquitar;
                    int num;
                    Console.WriteLine("[+] ELIJA UN PRODUCTO PARA QUITAR");
                    try
                    {
                        eleccionquitar = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        eleccionquitar = -1;
                    }
                    Console.WriteLine("[+] INDIQUE LA CANTIDAD");
                    try
                    {
                        num = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        num = -1;
                    }
                    if ((eleccionquitar >= 0) && (num > 0))
                    {
                        try
                        {
                            adminprod.QuitarProducto(eleccionquitar, num);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Error al ingresar indice, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dato ingresado erroneo, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    return true;


                case 6: // Volver
                    return false;


                default:
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;
            }
        }
        public static void ImprimirListaCopia(List<Producto> lista)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("      Lista de productos disponibles");
            Console.WriteLine("********************************************");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write("[{0}]", i);
                Console.WriteLine(lista[i].DarInfoProducto());
            }
            Console.WriteLine("->presione una tecla para continuar...");
            Console.ReadKey();
        }
        public static void ImprimirListaCopiaEnPromo(List<Producto> lista)
        {
            int j = 0;
            Console.WriteLine("********************************************");
            Console.WriteLine("Lista de productos en promocion disponibles");
            Console.WriteLine("********************************************");
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Descuento)
                {
                    Console.Write("[{0}][PROMOCION] ", j);
                    Console.WriteLine(lista[i].DarInfoPromo());
                    j++;
                }
            }
            Console.WriteLine("->presione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    //**********************************************************************************


    //*************Sub Menu Carrito**************************************************** 
    class MenuCarro
    {
        public static void MostrarOpciones()
        {
            Console.Clear();
            List<string> opcionesCarrito = new List<string>{
            "[1] Agregar productos al carro",
            "[2] Quitar producto del carro",
            "[3] Listar productos en carro",
            "[4] Realizar compra",
            "[5] Volver"
        };
            Menu MenuCrr = new Menu("Carrito", opcionesCarrito);
            MenuCrr.MostrarOpciones();
        }
        public static bool EjecutarAccion(int accion, Carrito carro, AdminProducto adminprod,AdminCliente admincliente, AdminTajetas adminTajetas,AdminTotales totales)
        {

            switch (accion)
            {

                case 1: // Agregar al carro
                    ImprimirListaCopiaTienda(adminprod.DarInfoProductos());
                    int eleccionagregar;
                    int cantidad;
                    Console.WriteLine("\n[+] ELIJA UN PRODUCTO PARA AGREGAR AL CARRO");
                    try{ eleccionagregar = Convert.ToInt32(Console.ReadLine());}
                    catch (System.FormatException) {eleccionagregar = -1;}
                    Console.WriteLine("[+] INDIQUE LA CANTIDAD A COMPRAR");
                    try { cantidad = Convert.ToInt32(Console.ReadLine()); }
                    catch (System.FormatException) { cantidad = -1; }
                    
                    
                  
                    if ((eleccionagregar >= 0) && (cantidad > 0))
                    {
                        try
                        {
                            carro.AgregarAlCarro(adminprod.DarInfoProducto(eleccionagregar), cantidad);
                            carro.GuardarIndice(eleccionagregar);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Error al ingresar indice, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dato ingresado erroneo, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    return true;


                case 2: // quitar del carro
                    ImprimirListaCopiaCarro(carro.ListarProductosCarro());
                    int eleccionquitar;
                    Console.WriteLine("[+] ELIJA UN PRODUCTO PARA QUITAR DEL CARRO");
                    try
                    {
                        eleccionquitar = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        eleccionquitar = -1;
                    }
                    Console.WriteLine("[+] INDIQUE LA CANTIDAD QUE DESEA QUITAR");
                    try
                    {
                        cantidad = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        cantidad = -1;
                    }
                    if ((eleccionquitar >= 0) && (cantidad > 0))
                    {
                        try
                        {
                            carro.QuitarDelCarro(eleccionquitar, cantidad);
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Error al ingresar indice, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dato ingresado erroneo, no se pudo realizar la operacion. \n ->presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    return true;


                case 3: // Listar productos carro
                    Console.WriteLine("TOTAL DE COMPRA: $" + carro.CalcularGastoTotal());
                    ImprimirListaCopiaCarro(carro.ListarProductosCarro());
                    return true;


                case 4: // Realizar compra

                    List<Tarjeta> listaDeTarjetas = adminTajetas.DarInfoTarjeta();
                    Cliente ClienteNuevo = new Cliente();
                    bool cargar = true;
                    int cantidad_tarj = 0;
                    int cantidad_cuotas = 0;
                    int elecciontarjeta, eleccioncuotas;
                    int indiceCliente = -1;


                    try
                    {
                        Console.WriteLine("[+] Ingrese DNI: ");
                        var (salida, existe_cliente, indice) = admincliente.IdentificarCliente(Int32.Parse(Console.ReadLine()));
                        indiceCliente = indice;

                        /*--El metodo IdentificarCliente retorna un bool que será FALSE si no existe--*/
                        /*--En ese caso de permite registrar el nuevo cliente*/

                        Console.WriteLine(salida);
                        if (!existe_cliente)
                        {

                            (cargar, ClienteNuevo) = SubMenuCargar();
                            if (cargar)
                            {
                                admincliente.CargarCliente(ClienteNuevo);
                                indiceCliente = admincliente.unaCantidadClientes - 1;

                            }
                        }

                        Console.WriteLine("********************************************");
                        Console.WriteLine("\n ->presione una tecla para las tarjetas disponibles...");
                        Console.ReadLine();


                        if (existe_cliente || cargar)
                        {
                            /*Si estoy aca es porque existe el cliente*/
                            Console.WriteLine("***********TARJETAS DISPONIBLES***********\n");
                            foreach (Tarjeta tarjeta in listaDeTarjetas)
                            {
                                cantidad_tarj++;
                                Console.WriteLine("*********OPCIÓN " + cantidad_tarj + "***********\n");
                                Console.WriteLine("[+]Tarjeta: " + tarjeta.Nombre);
                                Console.WriteLine("[+]Banco: " + tarjeta.Banco);
                            }

                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        cargar = false;

                        Console.WriteLine("[X] Fecha no valida \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                        return true;
                    }
                    catch (System.FormatException)
                    {
                        cargar = false;
                        Console.WriteLine("[X] No se registro un numero, revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                        return true;


                    }
                    catch (Exception e)
                    {
                        cargar = false;
                        Console.WriteLine(e.Message);
                        Console.WriteLine("revise los datos ingresados \n ->presione una tecla para continuar...");
                        Console.ReadLine();
                        return true;


                    }


                    Console.WriteLine("********************************************");
                    Console.WriteLine("\n ->Estas son todas las tarjetas disponibles...\n");
                    Console.WriteLine("[+] INDIQUE TARJETA PARA REALIZAR LA COMPRAR");
                    try
                    {
                        elecciontarjeta = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        elecciontarjeta = -1;
                    }

                    /*Verificacion de datos de la tarjeta*/
                    bool existe_cuota = false;

                    if (elecciontarjeta <= cantidad_tarj && elecciontarjeta >= 1)
                    {

                        Console.WriteLine("[+]Formas de pago:");


                      
                            foreach (FormaDePago fp in listaDeTarjetas[elecciontarjeta - 1].ListaFormasDePago)
                            {
                                cantidad_cuotas++;
                                Console.WriteLine("\n*********OPCIÓN " + cantidad_cuotas + "***********\n");
                                Console.WriteLine("  -> Numero de Cuotas: " + fp.NumCuotas);
                                Console.WriteLine("  -> Interes por Cuota: " + fp.InteresXcuota);

                            }
                            Console.WriteLine("********************************************");
                        

                        



                        
                        Console.WriteLine("[+] INDIQUE LA FORMA DE PAGO");
                        try
                        {
                            eleccioncuotas = int.Parse(Console.ReadLine());
                        }
                        catch (System.FormatException)
                        {
                            eleccioncuotas = -1;
                        }

                        foreach (FormaDePago fp in listaDeTarjetas[elecciontarjeta - 1].ListaFormasDePago)
                        {
                            if (eleccioncuotas<= cantidad_cuotas && eleccioncuotas>=1)
                            {
                                Console.WriteLine("Tarjeta y cuotas validas");
                                existe_cuota = true;
                                Console.WriteLine("En el carro hay un total de : ${0:#.##}",carro.CalcularGastoTotal());
                                float intereses = listaDeTarjetas[elecciontarjeta-1].ListaFormasDePago[eleccioncuotas-1].InteresXcuota;
                                int cuotas = listaDeTarjetas[elecciontarjeta-1].ListaFormasDePago[eleccioncuotas-1].NumCuotas;
                                float precio_con_interes = carro.CalcularGastoTotal() * (1 + intereses / 100);
                                Console.WriteLine("El precio total financiado: ${0:#.##} , en "+cuotas+ " cuotas de ${1:#.##} (interes del "+intereses+" %)", precio_con_interes, precio_con_interes / cuotas);
                                
                                Console.WriteLine("Confirma compra ? (S/N)");

                                
                                if (Console.ReadLine().ToUpper() == "S")
                                {
                                    Console.WriteLine("Felicidades por su compra, carro vacio\n ->presione una tecla para continuar...");


                                    // descontar productos de atras para adelante
                                    // la lista de indices esta ordenada de menor a mayor

                                    int y = (carro.PasarIndices().Count);
                                    int a;

                                    int z;
                                    for (z = 1; z <= y; z++)
                                    {
                                        a = y - z;
                                        if (a >= 0) { adminprod.QuitarProducto(carro.PasarIndices()[a], carro.ListarProductosCarro()[a].Cantidad); }
                                    }

        

                                    Console.ReadKey();

                                    //Se agrega  el gasto al cliente.
                                    if (indiceCliente > 0)
                                        admincliente.TotalCliente(indiceCliente, precio_con_interes);

                                    carro.FinalizarCompra();

                                    // se agrega el gasto a la tarjeta 
                                    int indiceTarjeta = elecciontarjeta - 1;
                                    carro.CargarGasto(precio_con_interes, indiceTarjeta, adminTajetas, listaDeTarjetas[indiceTarjeta].Beneficio);


                                    // se suma el gasto al total de la tienda

                                    totales.CalcularTotaltienda(precio_con_interes);
                                    
                                    return false;
                                }
                                else
                                {
                                    Console.WriteLine("Compra cancelada\n ->presione una tecla para continuar...");
                                    Console.ReadKey();
                                    return true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("[x] La opcion de cuota no valida, no se pudo realizar la operacion\n->presione una tecla para continuar...");
                                Console.ReadLine();
                                return true;
                            }

                        }
                        
       

                    }
                    else
                    {
                        Console.WriteLine("[x] Opcion de tarjeta no valida, no se pudo realizar la operacion\n ->presione una tecla para continuar...");
                        Console.ReadLine();
                    }
                    return true;


                case 5: // Volver
                    return false;

                default:
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;

            }
        }
        static void ImprimirListaCopiaTienda(List<Producto> lista)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("      Lista de productos disponibles");
            Console.WriteLine("********************************************");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write("[{0}]", i);
                Console.WriteLine(lista[i].DarInfoProducto());
            }
            Console.WriteLine("->presione una tecla para continuar...");
            Console.ReadKey();
        }
        static void ImprimirListaCopiaCarro(List<Producto> lista)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("           Productos en carro");
            Console.WriteLine("********************************************");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write("[{0}]", i);
                Console.WriteLine(lista[i].DarInfoProducto());
            }
            Console.WriteLine("->presione una tecla para continuar...");
            Console.ReadKey();
        }
        static (bool, Cliente) SubMenuCargar()
        {
            Cliente ClienteNuevo = new Cliente();
            int año, mes, dia;
            bool cargar = true, es_nombre = true, es_apellido = true;
            Console.WriteLine("[+] Ingrese nombre:");
            ClienteNuevo.unNombre = (Console.ReadLine().ToUpper());
            es_nombre = Regex.IsMatch(ClienteNuevo.unNombre, @"^[a-zA-Z]+$");

            if (!es_nombre)
                throw new Exception("[X] El nómbre debe contener solo letras.");

            Console.WriteLine("[+]Ingrese apellido:");
            ClienteNuevo.unApellido = (Console.ReadLine().ToUpper());
            es_apellido = Regex.IsMatch(ClienteNuevo.unApellido, @"^[a-zA-Z]+$");

            if (!es_apellido)
                throw new Exception("[X] El apellido debe contener solo letras.");

            Console.WriteLine("[+] Ingrese DNI:");
            ClienteNuevo.unDNI = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] Ingrese Fecha de nacimiento:");
            Console.WriteLine("[+]--->AÑO:");
            año = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] --->MES:");
            mes = (Int32.Parse(Console.ReadLine()));
            Console.WriteLine("[+] --->DÍA:");
            dia = (Int32.Parse(Console.ReadLine()));
            ClienteNuevo.unNacimiento = new DateTime(año, mes, dia);

            return (cargar, ClienteNuevo);
        }

    }

    //*************Sub Menu Totales**************************************************** 

    class SubMenuTotales 
    {
        public static void MostrarOpciones()
        {
            Console.Clear();
            List<string> opcionesTotales = new List<string>{ 
            "[1] Total Vendido en SportsX ",
            "[2] Total Vendido por Cliente",
            "[3] Total Vendido por Tarjeta",
            "[4] Volver"
        };
            Menu MenuProd = new Menu("Administrador de Totales", opcionesTotales);
            MenuProd.MostrarOpciones();
        }
        public static bool EjecutarAccion(int accion, AdminTajetas admintarjetas, AdminCliente admincliente, AdminTotales totales)
        {

            switch (accion)
            {


                case 1: //Total Vendido en SportsX********************************************************************************************************
                    AdminTotales admintotales = new AdminTotales(admincliente, admintarjetas);
                    Console.WriteLine("el Total Vendido en SportsX es: $ {0}", totales.unTotalTienda);
                    Console.WriteLine("\n ->presione una tecla para continuar...");
                    Console.ReadLine();

                    return true;


                case 2: //Total Vendido por Cliente******************************************************************************************************
         
                    int j = 1;
                    admintotales = new AdminTotales(admincliente,admintarjetas);
                    
                    List<Cliente> LC = admintotales.DarInfoTotalesClientes();
                    

                    foreach (Cliente cliente in LC)
                    {
                        Console.WriteLine("[{0}] Cliente Nombre: " + cliente.unNombre + ",  Apellido: " + cliente.unApellido + ", DNI:"+ cliente.unDNI +
                            ", Fecha de Nacimiento:" + cliente.unNacimiento.ToString("d") + ", Gasto Total: $" + cliente.unTotal , j);

                 
                        j++;
                    }

                    Console.WriteLine(" \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;


                case 3: //Total Vendido por Tarjeta*******************************************************************************************************

                    admintotales = new AdminTotales(admincliente, admintarjetas);

                    int i = 1;

                    List<Tarjeta> LT = admintotales.DarInfoTotalesTarjetas();

                    foreach (Tarjeta tarjeta in LT)
                    {
                        Console.WriteLine("[{0}] Tarjeta: " + tarjeta.Nombre + ",  Banco: " + tarjeta.Banco + ", Gasto Total: $"+ tarjeta.Total, i);
                        i++;  
                    }

                    Console.WriteLine(" \n ->presione una tecla para continuar...");
                    Console.ReadLine();

                    return true;

                
                case 4: // Volver*****************************************************************************************************************************
                    return false;


                default:
                    Console.WriteLine("Opcion no valida \n ->presione una tecla para continuar...");
                    Console.ReadLine();
                    return true;
            }
        }
       
       
    }

    //**********************************************************************************

    //**************Serializador / Deserializador***************************************
    class SerializaClass
    {



        public static void Serializar(object SerializarObjeto, string name)
        {
            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();
                Stream Escritor = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None);
                Formateador.Serialize(Escritor, SerializarObjeto);
                Escritor.Close();
            }
            
            catch (SystemException)
            {
               

            }
        }

        public static object Deserializar(object DSerializarObjeto, string name)
        {

            try
            {
                Object DeserializarObjeto = new object();
                BinaryFormatter Formateador = new BinaryFormatter();
                Stream Lector = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.None);
                DeserializarObjeto = Formateador.Deserialize(Lector);
                Lector.Close();
                return (DeserializarObjeto);
            }
            catch (System.IO.FileNotFoundException)
            {

                BinaryFormatter Formateador = new BinaryFormatter();
                Stream Escritor = new FileStream(name, FileMode.Create);
                Escritor.Close();
                return (DSerializarObjeto);

            }
            catch (SystemException) { return (DSerializarObjeto); }
           


        }
    }

    //**********************************************************************************

}
