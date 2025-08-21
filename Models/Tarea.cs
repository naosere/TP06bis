using Newtonsoft.Json;
namespace TP06Bis_SV.Models;

public class Tarea
{
        [JsonProperty]
    public int IDTarea{ get; private set; }
        [JsonProperty]
    public string titulo { get; private set; }
        [JsonProperty]
    public string descripcion{ get; private set; }
        [JsonProperty]
    public DateTime fecha{ get; private set; }
        [JsonProperty]
    public bool finalizada{ get; private set; }
        [JsonProperty]
    public int IDUsuario{ get; private set; }


    

}