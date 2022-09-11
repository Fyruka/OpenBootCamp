using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploFlujoAsync
{
    public static class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAniosVidaLaboral() // En este caso la funcion la declaramos asincrona, y vamos a devolver una Task o tarea, que se va a resolver en el futuro.  
        {
            Console.WriteLine("\nObteniendo años de vida laboral...");
            await Task.Delay(5000); // Esta es la tarea a realizar, por eso le decimos que await aqui. normalmente en un codigo de una API tendremos tareas como lecturas en bases de datos, y eso es lo que la funcion tiene que esperar a que termine para continuar.   
            return new Random().Next(1, 35); 
        }

        public static async Task<bool> EsTipoContratoIndefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es indefinido...");
            await Task.Delay(5000);
            return (new Random().Next(1, 10)) % 2 == 0; 
        }

        public static async Task<int> ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            await Task.Delay(5000);
            return new Random().Next(800, 6000);
        }

        public static async Task<int> ObtenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales...");
            await Task.Delay(10000);
            return new Random().Next(200, 1000);
        }

        public static bool AnalizarInformacionParaConcederHipoteca(
           int aniosVidaLaboral,
           bool tipoContratoEsIndefinido,
           int sueldoNeto,
           int gastosMensuales,
           int cantidadSolicitada,
           int aniosPagar)
        {
            Console.WriteLine("\nAnalizando informacion para conceder hipoteca...");

            if (aniosVidaLaboral < 2)
            {
                return false;
            }

            // Obtener la cuota mensual a pagar
            var cuota = (cantidadSolicitada / aniosPagar) / 12;

            if (cuota >= sueldoNeto || cuota > (sueldoNeto / 2))
            {
                return false;
            }

            var porcentajeGastosSobreSueldo = ((gastosMensuales * 100) / sueldoNeto);

            if (porcentajeGastosSobreSueldo > 30)
            {
                return false;
            }

            if ((cuota + gastosMensuales) >= sueldoNeto)
            {
                return false;
            }

            if (!tipoContratoEsIndefinido)
            {
                if ((cuota + gastosMensuales) > sueldoNeto / 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            // Si no entra en ninguna de las condiciones, sí que la concedemos
            return true;
        }
    }
}
