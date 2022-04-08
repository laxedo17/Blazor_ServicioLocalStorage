using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor_ServicioLocalStorage.Services
{

    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime js;

        public LocalStorageService(IJSRuntime JsRuntime)
        {
            js = JsRuntime;
        }

        /// <summary>
        /// Chama a funcion de Javascript blazorwebassemblyInterop.setLocalStorage cunha key. Se blazorwebassemblyInterop.setLocalStorage devolve un valor, ese valor deserializase e devolvese. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await js.InvokeAsync<string>(
                "blazorwebassemblyInterop.getLocalStorage", key
            );

            return string.IsNullOrEmpty(json)
                    ? default
                    : JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Chama a funcion de Javascript blazorwebassemblyInterop.setLocalStorage cunha key e unha version serializada do elemento a gardar en localStorage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task SetItemAsync<T>(string key, T item)
        {
            await js.InvokeVoidAsync(
                "blazorwebassemblyInterop.setLocalStorage", key, JsonSerializer.Serialize(item));
        }
    }
}
