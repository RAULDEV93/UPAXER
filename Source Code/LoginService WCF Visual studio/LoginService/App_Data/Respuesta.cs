using System.Runtime.Serialization;

[DataContract]
public class Respuesta
{
    private bool statusOperacion;
    private string mensaje;
    private string codigo;


    [DataMember]
    public bool StatusOperacion { get => statusOperacion; set => statusOperacion = value; }
    [DataMember]
    public string Mensaje { get => mensaje; set => mensaje = value; }

    [DataMember]
    public string Codigo { get => codigo; set => codigo = value; }
}