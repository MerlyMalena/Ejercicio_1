// Una aplicación que permita modelar figuras geometricas. Abstraiga cada figura y pongales las 
//características y los comportamientos que entienda.

// Permita que el usuario de la aplicación pueda crear las figuras que desee.

//El programa podrá manejar N cantidad de cada figura geométrica, exceptuando el triangulo, 
// de la cual solo podra manejar una.

//Para lograr esto último, aplique el patrón de diseño Singleton.

//El programa debe mostrar en pantalla el listado de todas las figuras geométricas creadas.

using System;
using System.Drawing;
using System.Collections.Generic;


class Program
{


    public class Figura
    {
        public String color { get; set; }
        public int lados { get; set; }

        public Figura()
        {
            color = "Blanco";
            lados = 0;
        }

        public virtual void Imprimir() {
        Console.WriteLine($"Figura de color {color}");
    }

        public virtual void calcularArea()
        {
            double area=0;
            System.Console.WriteLine($"El área de la figura es: {area}");
           
        }

    }

    public class Cuadrado : Figura
    {
        public int longitud { get; set; }
        public Cuadrado()
        {
            lados = 4;
            longitud = 0;
        }

        public override void Imprimir() {
        Console.WriteLine($"Cuadrado\n - Color: {color}\n, -Longitud: {longitud}");
    }
        public override void calcularArea()
        {
            double area=longitud*longitud;
            double areaRedondeada = Math.Round(area, 1);
            area=areaRedondeada;
            System.Console.WriteLine($"El área del cuadrado es: {area}");
        }


    }

    public class Rectangulo : Figura
    {
        public int largo { get; set; }
        public int ancho { get; set; }

        public Rectangulo()
        {
            lados = 4;
            largo = 0;
            ancho = 0;
        }

          public override void Imprimir() {
        Console.WriteLine($"Rectangulo\n - Color: {color}\n, Largo: {largo}\n, Ancho: {ancho}\n");
    }
         public override void calcularArea()
        {
            double area=largo*ancho;
            double areaRedondeada = Math.Round(area, 1);
            area=areaRedondeada;
            System.Console.WriteLine($"El área del rectángulo es: {area}");
        }
    }


    public class Triangulo : Figura
    {
        private static Triangulo? instancia;

        public int longitudLado1 { get; set; }

        public int longitudLado2 { get; set; }

        public int longitudLado3 { get; set; }


        private Triangulo()
        {
            lados = 3;
            longitudLado1 = 0;
            longitudLado2 = 0;
            longitudLado3 = 0;

        }

         public override void calcularArea()
        {
            
            double semiperimetro=(longitudLado1+longitudLado2+longitudLado3)/2.0;
            double area=Math.Sqrt(semiperimetro*(semiperimetro-longitudLado1)*(semiperimetro-longitudLado2)*(semiperimetro-longitudLado3));
            double areaRedondeada = Math.Round(area, 1);
            area=areaRedondeada;
           System.Console.WriteLine($"El área del triángulo es: {area} cm.");
        }

         public override void Imprimir() {
        Console.WriteLine($"Triangulo\n - Color: {color}\n, Lado 1: {longitudLado1}\n, Lado 2: {longitudLado2}\n, Lado 3:{longitudLado3}\n");
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
       List<Figura> figuras = new List<Figura>();
        int opcion=0;

        do
        {
        Console.Write("");
        Console.WriteLine("\tMenú");
        Console.WriteLine("\t1. Crear una nueva figura");
        Console.WriteLine("\t2. Ver las figuras creadas");
        Console.WriteLine("\t3. Salir");
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
                     Console.Write("\t --> ");

                    Cuadrado c1 = new Cuadrado();
                    c1.color = Console.ReadLine();

                    Console.WriteLine("\t ¿De qué longitud desea que sean los lados (cm)?");
                    Console.Write("\t --> ");

                    c1.longitud = int.Parse(Console.ReadLine());
                    if (c1.longitud <= 0)
                    {
                        do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                            c1.longitud = int.Parse(Console.ReadLine());
                        }
                        while(c1.longitud<=0);
                    }

                    Console.WriteLine("\tEl color de su cuadrado es: "+ c1.color);
                    Console.WriteLine("\tLa longitud de su cuadrado es: "+ c1.longitud);

                    figuras.Add(c1);

                    Console.WriteLine("\tPresione cualquier tecla para continuar");
                    Console.ReadKey();
                }

                else if (opcionFigura == 2)
                {
                    Console.WriteLine("\t -- Crear un rectangulo --");
                    Console.WriteLine("\t ¿De qué color desea que sea su rectángulo (cm)?");
                     Console.Write("\t --> ");

                    Rectangulo r1 = new Rectangulo();
                    r1.color = Console.ReadLine();

                    Console.WriteLine("\t ¿De qué longitud desea que sea el ancho (cm)?");
                    Console.Write("\t --> ");

                    r1.ancho = int.Parse(Console.ReadLine());
                    if (r1.ancho <= 0)
                    {
                        do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                            r1.ancho= int.Parse(Console.ReadLine());
                        }
                        while(r1.ancho<=0);
                    }
                    
                     Console.WriteLine("\t ¿De qué longitud desea que sea el ancho (cm)?");
                    Console.Write("\t --> ");

                    r1.largo = int.Parse(Console.ReadLine());
                    if (r1.largo <= 0)
                    {
                        do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                            r1.largo= int.Parse(Console.ReadLine());
                        }
                        while(r1.largo<=0);
                    }

                    Console.WriteLine("\tEl color de su rectangulo es: "+ r1.color);
                    Console.WriteLine("\tEl ancho de  de su rectangulo es: "+ r1.ancho);
                    Console.WriteLine("\tEl largo de  de su rectangulo es: "+ r1.largo);

                    figuras.Add(r1);

                    Console.WriteLine("\tPresione cualquier tecla para continuar");
                    Console.ReadKey();

                }

                 else if (opcionFigura == 3)
                {
                    var t1 = Triangulo.ObtenerInstancia();
                    if (figuras.Contains(t1))
                    {
                        Console.WriteLine("Ya se ha creado un triángulo. No puede crearse otro más.");
                    }
                    else {
                    Console.WriteLine("\t -- Crear un triangulo --");
                    Console.WriteLine("\t ¿De qué color desea que sea su triángulo?");
                    Console.Write("\t --> ");
                    
                    t1.color=Console.ReadLine();

                    Console.WriteLine("\t ¿De qué tamaño desea el primer lado de su triángulo (cm)?");
                    Console.Write("\t --> ");
                    t1.longitudLado1=int.Parse(Console.ReadLine());
                     if (t1.longitudLado1 <= 0){
                    do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                             t1.longitudLado1=int.Parse(Console.ReadLine());
                        }
                     while(t1.longitudLado1<=0);
                     }

                    Console.WriteLine("\t ¿De qué tamaño desea el segundo lado de su triángulo (cm)?");
                    Console.Write("\t --> ");
                    t1.longitudLado2=int.Parse(Console.ReadLine());

                     if (t1.longitudLado2 <= 0){
                    do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                             t1.longitudLado2=int.Parse(Console.ReadLine());
                        }
                     while(t1.longitudLado2<=0);
                     }

                    Console.WriteLine("\t ¿De qué tamaño desea el tercer lado de su triángulo (cm)?");
                    Console.Write("\t --> ");
                    t1.longitudLado3 = int.Parse(Console.ReadLine());
                     if (t1.longitudLado3 <= 0){
                    do
                        {
                            Console.WriteLine("\tEste valor no es válido. Debe de ser un número mayor a 0 ");
                            Console.Write("\t --> ");
                             t1.longitudLado3=int.Parse(Console.ReadLine());
                        }
                     while(t1.longitudLado3<=0);
                     }

                    Console.WriteLine("\tEl triangulo que ha creado tiene los siguientes lados: " + t1.longitudLado1 + ", " + t1.longitudLado2 + ", " + t1.longitudLado3);
                    Console.WriteLine("\tEl color de su triangulo es: " + t1.color);

                
                    figuras.Add(t1);
                    
                    }

                  

                    Console.WriteLine("\tPresione cualquier tecla para continuar");
                    Console.ReadKey();
                     Console.WriteLine("");
                }


            }

            else if (opcion == 2)
            {
                Console.WriteLine("\t -- Lista de figuras creadas --");
                Console.WriteLine("");

                if (figuras.Count == 0)
                {
                    Console.WriteLine("\tNo se ha creado ninguna figura todavía. Intente creando una primero.");
                }

                foreach (var item in figuras)
                {
                    item.Imprimir();
                    item.calcularArea();
                   
                }

                Console.WriteLine("\tPresione cualquier tecla para continuar");
                Console.ReadKey();
                Console.WriteLine("");
            }
        }
        while(opcion!=3);
    }
}