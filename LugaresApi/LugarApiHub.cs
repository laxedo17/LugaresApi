using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LugaresApi
{
    /// <summary>
    /// Clase que hereda de Hub, relacionado con Signal R.
    /// Deixamola vacia porque non invocamos ningun metodo do cliente.
    /// En cambio enviaremos eventos sobre o hub
    /// </summary>
    public class LugarApiHub : Hub
    {
    }
}
