using EjemploFlujoAsync;
using System.Diagnostics; // Con este modulo podemos ver, analizar y calcular los tiempos de ejecucion de nuestras aplicaciones. 


// Iniciamos un contrador de tiempo - SINCRONA
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
Console.WriteLine("\n**************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Sincrona");
Console.WriteLine("\n**************************************************");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo netro obtenido: {sueldoNeto}€");

var gastosMenusales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMenusales}€");

var hipotecaConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMenusales, cantidadSolicitada: 5000, aniosPagar: 30);

var resultado = hipotecaConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis finalizado. Su solicitud de hipoteca ha sido: {resultado}");

// Paramos el contador
stopwatch.Stop();

Console.WriteLine($"\n La operacion ha durado: {stopwatch.Elapsed}");



// REIniciamos un contrador de tiempo - ASINCRONA

stopwatch.Restart();
Console.WriteLine("\n****************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Asincrona");
Console.WriteLine("\n****************************************************");

Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboral();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
Task<int> gastosMenusalesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var analisisHipotecaTasks = new List<Task>
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMenusalesTask
};

while (analisisHipotecaTasks.Any()) // Si cualquiera de estas Task de la lista ha terminado...
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks); // Esperamos de forma activa a que cualquiera de las tareas termine y nos diga cual es. Vamos obtreniendo las tareas a medida que se completen. 

    if (tareaFinalizada == aniosVidaLaboralTask)
    {
        Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboralTask.Result}"); // Con result accedemos al resultado de la tarea. 
    }
    else if(tareaFinalizada == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if (tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo netro obtenido: {sueldoNetoTask.Result}€");
    }
    else if (tareaFinalizada == gastosMenusalesTask)
    {
        Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMenusalesTask.Result}€");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada); // Eliminamos de la lista de tareas para vaciar la lista y salir del while
}


var hipotecaAsyncConcedida = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMenusalesTask.Result, cantidadSolicitada: 5000, aniosPagar: 30);

var resultadoAsync = hipotecaAsyncConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnalisis finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");

// Paramos el contador
stopwatch.Stop();

Console.WriteLine($"\n La operacion asincrona ha durado: {stopwatch.Elapsed}");

Console.Read();