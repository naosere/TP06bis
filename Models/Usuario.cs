using Newtonsoft.Json;
namespace TP06Bis_SV.Models;

public class Usuario
{
        [JsonProperty]
    public int IDUsuario{ get; private set; }
        [JsonProperty]
    public string nombre { get; private set; }
        [JsonProperty]
    public string apellido{ get; private set; }
        [JsonProperty]
    public string usuario{ get; private set; }
        [JsonProperty]
    public string contraseña{ get; private set; }
        [JsonProperty]
    public string foto{ get; private set; }
        [JsonProperty]
    public DateTime ultLogin{ get; private set; }


}