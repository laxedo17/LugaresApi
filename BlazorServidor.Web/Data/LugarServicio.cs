using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorServidor.Web.Data
{
    public class LugarServicio
    {
        private readonly HttpClient _httpClient;
        private HubConnection _hubConnection;

        public LugarServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string NovoNomeLugar { get; set; }
        public int NovaIdLugar { get; set; }
        public event Action OnChange;

        public async Task InicializaSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
               .WithUrl($"{_httpClient.BaseAddress.AbsoluteUri}LugaresApiHub")
               .Build();

            _hubConnection.On<int, string>("NotifyNewLugarAdded", (lugarId, lugarNome) =>
            {
                ActualizarUIState(lugarId, lugarNome);
            });

            await _hubConnection.StartAsync();
        }

        private void ActualizarUIState(int lugarId, string lugarNome)
        {
            NovaIdLugar = lugarId;
            NovoNomeLugar = lugarNome;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task<IEnumerable<Lugar>> GetLugaresAsync()
        {
            var resposta = await _httpClient.GetAsync("/api/lugares");

            resposta.EnsureSuccessStatusCode();

            var json = await resposta.Content.ReadAsStringAsync();

            var jsonOpcion = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var datos = JsonSerializer.Deserialize<IEnumerable<Lugar>>(json, jsonOpcion);

            return datos;
        }

        public async Task ActualizarLugarAsync(Lugar lugar)
        {
            var resposta = await _httpClient.PutAsJsonAsync("/api/lugares", lugar);
            resposta.EnsureSuccessStatusCode();
        }
    }


}
