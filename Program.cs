// Una aplicación que permita modelar figuras geometricas. Abstraiga cada figura y pongales las 
//características y los comportamientos que entienda.

// Permita que el usuario de la aplicación pueda crear las figuras que desee.

//El programa podrá manejar N cantidad de cada figura geométrica, exceptuando el triangulo, 
// de la cual solo podra manejar una.

//Para lograr esto último, aplique el patrón de diseño Singleton.

//El programa debe mostrar en pantalla el listado de todas las figuras geométricas creadas.

using System;
using System.Drawing;
using System.Collections;
using System.Runtime.CompilerServices;

class Program
{
   
    
    public class Figura
    {
        public String color {get;set;}
        
        public int lados;
        public virtual void cambiarColor()
        {
            Console.WriteLine("Color cambiado");
        }

    }

    public class Cuadrado : Figura
    {
        public int longitud;
        public Cuadrado()
        {
            color= "Blanco";
            lados=4;
            longitud=0;
        }

       
    }

    public class Rectangulo : Figura
    {
        int lados=4;
        int ladosCortos;
        int ladosLargos;
    }

    public class Triangulo:Figura
    {


        private static Triangulo? instancia;

        int lados {get;set;}

        int color {get;set;}
        public int longitudLado1 {get;set;}

        public int longitudLado2 {get;set;}

        public int longitudLado3 {get;set;}


        private Triangulo(){
        lados=3;
        longitudLado1=0;
        longitudLado2=0;
        longitudLado3=0;
  
        }

        public  static Triangulo ObtenerInstancia(){
        if (instancia==null){
            instancia= new Triangulo();
        }
        return instancia;

        }
    



    }
    static void Main(string[] args)
    {
        ArrayList figuras = new ArrayList();
        int opcion=0;


        do
        {

              Console.WriteLine("Menú");
        Console.WriteLine("1. Crear una nueva figura");
        Console.WriteLine("2. Ver las figuras creadas");
        Console.WriteLine("3. Salir");
        Console.WriteLine("");
        Console.Write("\t --> ");
        opcion= int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.Clear();
                Console.WriteLine("\t -- Crear figuras --");
                Console.WriteLine("");
                Console.WriteLine("\t -- 1. Cuadrado --");
                Console.WriteLine("\t -- 2. Rectangulo --");
                Console.WriteLine("\t -- 3. Triangulo --");
                Console.WriteLine("");
                Console.Write("\t --> ");
                int opcionFigura = int.Parse(Console.ReadLine());

                    if (opcionFigura == 1)
                {
                     Console.WriteLine("\t -- Crear un cuadrado --");
                     Console.WriteLine("\t ¿De qué color desea que sea su cuadrado?");

                    Cuadrado c1 = new Cuadrado();
                    c1.color = Console.ReadLine();

                    Console.WriteLine("\t ¿De qué longitud desea que sean los lados?");
                   
                    c1.longitud = int.Parse(Console.ReadLine());

                    Console.WriteLine("El color de su cuadrado es: "+ c1.color);
                    Console.WriteLine("La longitud de su cuadrado es: "+ c1.longitud);

                    figuras.Add(c1);

                    foreach (object item in figuras)
                    {
                        if (item is Cuadrado cuad)
                        Console.WriteLine("Cuadrado. Color:"+cuad.color+ "\nLongitud:"+cuad.longitud);
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                }

                else if (opcionFigura == 2)
                {
                    Console.WriteLine("\t -- Crear un rectangulo --");
                }

                 else if (opcionFigura == 3)
                {
                    Console.WriteLine("\t -- Crear un triangulo --");
                    Console.WriteLine("\t ¿De qué color desea que sea su triángulo?");
                    var t1 = Triangulo.ObtenerInstancia();
                    t1.color=Console.ReadLine();

                    Console.WriteLine("\t ¿De qué tamaño desea el primer lado de su triángulo?");
                    t1.longitudLado1=int.Parse(Console.ReadLine());

                    Console.WriteLine("\t ¿De qué tamaño desea el segundo lado de su triángulo?");
                    t1.longitudLado2=int.Parse(Console.ReadLine());

                    Console.WriteLine("\t ¿De qué tamaño desea el tercer lado de su triángulo?");
                    t1.longitudLado3=int.Parse(Console.ReadLine());

                    Console.WriteLine("El triangulo tiene los siguientes lados: "+t1.longitudLado1+", "+t1.longitudLado2+", "+t1.longitudLado3);
                    Console.WriteLine("El color de su triangulo es: "+ t1.color);

                     figuras.Add(t1);

                    foreach (object item in figuras)
                    {
                        if (item is Triangulo tr)
                        Console.WriteLine("Triangulo. Color:"+tr.color+ "\nLongitud:"+tr.longitudLado1+", "+t1.longitudLado2+", "+t1.longitudLado3);
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                }


            }

            else if (opcion == 2)
            {
                  Console.WriteLine("\t -- Lista de figuras creadas --");
                  Console.WriteLine("\t -- Triangulos--");

                foreach (object item in figuras)
                {
                    if (item is Triangulo tr)
                    {
                        Console.WriteLine("\tTriangulo. Color:" + tr.color + "\nLongitud:" + tr.longitudLado1 + ", " + tr.longitudLado2 + ", " + tr.longitudLado3);
                    }
                    else
                    {
                    Console.WriteLine("No se han creado triángulos");
                    }
                }

                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
        while(opcion!=3);
    }
}