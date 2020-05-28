using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]


            [WebInvoke(UriTemplate = "/BuscarUsuario",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Respuesta  buscarUsuarioExistente(Usuarios usuario);



        [WebInvoke(UriTemplate = "/RegistrarUsuario",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Respuesta RegistrarUsuario(Usuarios usuario);



        // TODO: agregue aquí sus operaciones de servicio
    }

}
