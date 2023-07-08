using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Progra6_PF_2023_Aplicacion.Attributes
{
    //esta clase ayuda a limitar la forma en que se puede consumir un recurso de controlador (un end point)
    //vamos a crear una decoracion personalizada que se inyecta cierta funcionalidad ya sea a todo
    //un controller o a un end point particular.

    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApikeyAttribute : Attribute, IAsyncActionFilter
    {
        //especificamos cual es el clave:valor dentro de appsettings que queremos usar como apikey
        private readonly string _apiKey = "Progra6Apikey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) 
        {
            //aqui se valida que el body del request vaya a la info de la apikey
            //si no va la info presentamos mensaje de error indicando que falta apikey y que no se puede consumir el recurso
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Llamada no contiene informacion de seguridad..."
                };
                return;
                //si no hay info de seguridad sale de la funcion y muestra este mensaje
            }
            //si tiene info de seguridad, falta validar que sea la correcta
            //para esto es extraer el valor de progra6apikey dentro de appsettings.json
            //para poder compara contra lop que viene en el request
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var ApikeyValue = appSettings.GetValue<string>(_apiKey);
            //queda comparar que las apikey sean iguales
            if (!ApikeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Apikey invalida..."
                };
                return;
            }
            await next();
        }
    }
}
