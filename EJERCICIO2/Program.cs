//////////UEA   
/// JUAN GABRIEL ZURITA MANOBANDA 
/// EJERCICIO 2 SEMANA 7 
/// 

class Hamoi       /////// CREAMOS LA CLASE HAMOI  QUE CONSTARA DE 3 TORRES DONDE 
{                 ///// MOVEREMOS 3 PIESAS 
    static Stack<string> t1 = new Stack<string>();
    static Stack<string> t2 = new Stack<string>();
    static Stack<string> t3 = new Stack<string>();

    static void Main()
    {
        // INICIAMOS CON LA TORRE 5 Y COMENZAMOS CON LA PIEZA  P3 ABAJO A P1 ARRIBA 
        t1.Push("p3");
        t1.Push("p2");
        t1.Push("p1");

        Console.WriteLine("Estado inicial:");
        MostrarTorres();

        // MOVEMOS LOS 3 DISCOS A DE LA TORRE 1 A LA 3
        MoverDiscos(3, t1, t3, t2, "t1", "t3", "t2");

        Console.WriteLine("Estado final:");
        MostrarTorres();
    }
             ///MOVER DISCOS DE UNA TORRE A OTRA USANDO UNA TORRE AUXILIAR
    static void MoverDiscos(int n, Stack<string> origen, Stack<string> destino, Stack<string> auxiliar,
                            string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            // MOVER UN SOLO DISCO para SACAR DE LA PILA ORIGEN Y PONER EN DESTINO FINAL 
            string disco = origen.Pop();      /// QUITA EL DISCO DEL TOPE DE LA PILA ORIGEN
            destino.Push(disco);              //// AGREGA EL DISCO AL TOPE DE LA PILA DESTINO

            Console.WriteLine($"Mover {disco} de {nombreOrigen} a {nombreDestino}");
            MostrarTorres(); // ///MOSTRAR EL ESTADO DE LAS TORRES DESPUÉS DEL MOVIMIENTO
        }
        else
        {
            //MOVEMOS LOS DISCOS A LA TORRE AUXILIAR
            MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            /// MOVEMOS EL DISCO RESTANTE A LA TORRE DESTINO 
            MoverDiscos(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);

            // MOVEMOS  DISCOS DE LA AUXILIAR A DESTINO
            MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    // ///// MOSTRAMOS EL ESTAOD DE LAS TORRES 
    static void MostrarTorres()
    {
        Console.WriteLine("\nESTADO DE LAS TORRES:");
        MostrarTorre(t1, "t1");
        MostrarTorre(t2, "t2");
        MostrarTorre(t3, "t3");
        Console.WriteLine("-----------------------\n");
    }

    // MOSTRAMOS  EL CONTENIDO DE UNA TORRE USANDO PILA INVERTIDA PARA RESOLVER EL PROBLEMA
    static void MostrarTorre(Stack<string> torre, string nombre)
    {
        Console.Write($"{nombre}: ");
        string[] discos = torre.ToArray(); // CONVERTIMOS LA PILA A UN ARRAY PARA MOSTRAR DESDE EL FONDO 

        for (int i = discos.Length - 1; i >= 0; i--)
        {
            Console.Write($"{discos[i]} ");
        }
        Console.WriteLine();
    }
}