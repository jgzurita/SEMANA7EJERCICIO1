/////// UEA
/// JUAN GABRIEL ZURITA MANOBANDA
/// SEMANA 7 EJERCICIO 1

using System;

class Programa   //// DECLARAMOS LA CLASE PROGRAMA 
{
    static void Main()
    {
        string expr = "{4 + (9 / 3) - [(9) + (4 * 1)]}"; //// INGRESAMOS LA EXPRECIÓN A EVALUAR
        Stack<char> pila = new Stack<char>();/// SE CREA UNA PILA PARA EVALUAR LOS SIMBOLOS DE LA EXPRECIÓN A REALIZAR 

        foreach (char c in expr)  // SE RECORRE LOS CARACTERES
        {
            if ("({[".Contains(c)) pila.Push(c); //// ESPECIFICAMOS APERTURA  Y CIERRE 
            else if (")}]".Contains(c))
            {
                if (pila.Count == 0 || //// SI LA PILA ESTA VACIA O NO RESPETA EL ORDEN SE ELIMINA 
                   (c == ')' && pila.Peek() != '(') ||
                   (c == ']' && pila.Peek() != '[') ||
                   (c == '}' && pila.Peek() != '{'))
                {
                    Console.WriteLine("Fórmula no balanceada.");
                    return; /// RETORNA COMO NO BALANCEADA
                }
                pila.Pop();
            }
        }

        Console.WriteLine(pila.Count == 0 ? "Fórmula balanceada." : "Fórmula no balanceada.");
    }
}
