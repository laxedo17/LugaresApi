using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServidor.Web.Data
{
    public class AppState
    {
        public Lugar Lugar { get; private set; }
        public event Action OnChange;

        public void SetAppState(Lugar lugar)
        {
            Lugar = lugar;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
