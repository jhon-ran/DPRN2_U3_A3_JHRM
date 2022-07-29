using System;
using System.IO;

namespace DPRN2_U3_A3_JHRM
{
    class Program
    {
        static void Main(string[] args)
        {

            //Arreglo para almacenar datos de películas
            String[,] peliculas = new string[4, 4];

            // Atributos de película 1
            Boleto bol1 = new Boleto();
            peliculas[0, 0] = bol1.Peli = "1";
            peliculas[0, 1] = bol1.Clasificacion = "A";
            peliculas[0, 2] = bol1.Apto = "Para todo público";
            peliculas[0, 3] = bol1.Sala = "1";

            // Atributos de película 2
            Boleto bol2 = new Boleto();
            peliculas[1, 0] = bol2.Peli = "2";
            peliculas[1, 1] = bol2.Clasificacion = "B";
            peliculas[1, 2] = bol2.Apto = "Mayores de 15 años";
            peliculas[1, 3] = bol2.Sala = "2";
            
            // Atributos de película 3
            Boleto bol3 = new Boleto();
            peliculas[2, 0] = bol3.Peli = "3";
            peliculas[2, 1] = bol3.Clasificacion = "C";
            peliculas[2, 2] = bol3.Apto = "Mayores de 18 años";
            peliculas[2, 3] = bol3.Sala = "3";

            // Atributos de película 4
            Boleto bol4 = new Boleto();
            peliculas[3, 0] = bol4.Peli = "4";
            peliculas[3, 1] = bol4.Clasificacion = "D";
            peliculas[3, 2] = bol4.Apto = "Mayores de 21 años";
            peliculas[3, 3] = bol4.Sala = "4";


            //Ver lista completa de películas
            System.Console.WriteLine("Película Clasificación Rango de edades Sala");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    System.Console.Write("{0} \t", peliculas[i, j]);
                }
                Console.WriteLine("\n");
            }




            //variable para calcular el costo total de compra, todos los boletos cuestan lo mismo
            int costoBoleto = 40;

            //Variable para almacenar # de peli escogida y # de boletos
            int peliEscogida, boletos;

            bol4.verificarEdad(peliEscogida = bol4.seleccionar(), boletos = bol4.numBoletos());

            //variable para almacenar total de compra
            int total, boletos2;
            //Se copia el # de boletos en otra variable para calcular total de compra
            boletos2 = boletos;

            //Try & catch para capturar error de escritura de archivo
            try
            {
                //Creación de archivo txt
                String archivo = "c:\\U3_A3\\temp.txt";
                FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                do
                {


                    if (peliEscogida == 1)
                    {


                        sw.WriteLine("\n-------------------------");
                        sw.WriteLine("Película: " + bol1.Peli);
                        sw.WriteLine("Boleto: " + boletos);
                        sw.WriteLine("Clasificación: " + bol1.Clasificacion);
                        sw.WriteLine("Sala: " + bol1.Sala);
                        sw.WriteLine("Precio: " + costoBoleto);
                        

                    }

                    else if (peliEscogida == 2)
                    {
                        sw.WriteLine("\n-------------------------");
                        sw.WriteLine("Película: " + bol2.Peli);
                        sw.WriteLine("Boleto: " + boletos);
                        sw.WriteLine("Clasificación: " + bol2.Clasificacion);
                        sw.WriteLine("Sala: " + bol2.Sala);
                        sw.WriteLine("Precio: " + costoBoleto);
                    }

                    else if (peliEscogida == 3)
                    {
                        sw.WriteLine("\n-------------------------");
                        sw.WriteLine("Película: " + bol3.Peli);
                        sw.WriteLine("Boleto: " + boletos);
                        sw.WriteLine("Clasificación: " + bol3.Clasificacion);
                        sw.WriteLine("Sala: " + bol3.Sala);
                        sw.WriteLine("Precio: " + costoBoleto);
                    }

                    else if (peliEscogida == 4)
                    {
                        sw.WriteLine("\n-------------------------");
                        sw.WriteLine("Película: " + bol4.Peli);
                        sw.WriteLine("Boleto: " + boletos);
                        sw.WriteLine("Clasificación: " + bol4.Clasificacion);
                        sw.WriteLine("Sala: " + bol4.Sala);
                        sw.WriteLine("Precio: " + costoBoleto);
                    }

                    boletos--;

                } while (boletos > 0);

                total = boletos2 * costoBoleto;
                sw.WriteLine("\n----------------");
                sw.WriteLine("Total de compra: " + total);
                sw.Close();

            }
            catch (DirectoryNotFoundException dne)
            {
                System.Console.WriteLine("Error: Se debe crear primero el directorio");
                System.Console.WriteLine(dne.ToString());
            }
            catch (IOException ioe)
            {
                System.Console.WriteLine(ioe.ToString());
            }

        }


    }

    abstract class Pelicula
    {
        //gets & sets para ingresar params
        protected String peli;
        public String Peli
        {
            set { this.peli = value; }
            get { return this.peli; }
        }

        protected String clasificacion;
        public String Clasificacion
        {
            set { this.clasificacion = value; }
            get { return this.clasificacion; }
        }

        protected String apto;
        public String Apto
        {
            set { this.apto = value; }
            get { return this.apto; }
        }

        protected String sala;
        public string Sala
        {
            set { this.sala = value; }
            get { return this.sala; }
        }


    }

    class Boleto : Pelicula
    {


          //Método para seleccionar peli
        String tmp;
        int op;
        public int seleccionar()
        {
            Console.WriteLine("Ingrese el número de la película que quiere ver: 1, 2, 3, 4");
            tmp = System.Console.ReadLine();
            try
            {
                op = System.Convert.ToInt16(tmp);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Formato ingresado no válido, debe ser un número");
                Console.WriteLine(fe.ToString());
            }

            return op;
        }

        //Método para seleccionar # de boletos deseados
        String tmp2;
        int nBoletos;
        public int numBoletos()
        {
            Console.WriteLine("¿Cuántos boletos desea comprar?");
            tmp2 = System.Console.ReadLine();
            nBoletos = System.Convert.ToInt16(tmp2);
            return nBoletos;
        }

        //Método para verificar edad 
        int contador2;

        public void verificarEdad(int op, int nBoletos)
        {
            //Arreglo para almacenar fechas de nacimiento
            DateTime[] nacimiento = new DateTime[nBoletos];
            //Arreglo para almacenar edad calculada con base a fecha de nacimiento
            int[] edadCalculada = new int[nBoletos];

            contador2 = 1;

            for (int i = 0; i < nBoletos; i++)
            {

                System.Console.WriteLine("Ingrese fecha de nacimiento de persona {0} en formato AAAA-MM-DD", contador2);

                try
                {

                    nacimiento[i] = Convert.ToDateTime(Console.ReadLine());
                    edadCalculada[i] = System.Convert.ToInt16(2021 - nacimiento[i].Year);
                }

        
                catch (FormatException fe)
                {
                    Console.WriteLine("Formato ingresado no válido, debe ser una fecha válida");
                    Console.WriteLine(fe.ToString());
                }

                // Se evalua si la edad es apropiada a la peli   
                finally
                {
                    if (edadCalculada[i] < 15 & op == 2)
                    {
                        throw new EdadFueraDeRangoException();
                    }

                    else if (op == 3 & edadCalculada[i] < 18)
                    {
                        throw new EdadFueraDeRangoException();
                    }
                    else if (op == 4 & edadCalculada[i] < 21)
                    {
                        throw new EdadFueraDeRangoException();
                    }

                }
                contador2++;
                
               

            }


            //Ver la información de las personas que compraron boletos
            System.Console.WriteLine("Persona Nacimiento Edad");
            int contador3 = 1;
            for (int i = 0; i < nBoletos; i++)
            {
                System.Console.Write(contador3 + "\t");
                System.Console.Write("{0} \t", nacimiento[i].Year);
                System.Console.WriteLine("{0} \t", edadCalculada[i]);
                contador3++;
            }


        }

 


        //Excepciones personalizadas
        class EdadFueraDeRangoException : ApplicationException
        {
            public EdadFueraDeRangoException()
                : base("Edad de asistente no permitida para la clasificación de la película")
            { }

            public EdadFueraDeRangoException(String mensaje)
                : base(mensaje)
            { }

            public EdadFueraDeRangoException(String mensaje, Exception anidada)
                : base(mensaje, anidada)
            { }
        }

    }
}