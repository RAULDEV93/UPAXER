using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.

      
    public class Service1 : IService1
    {
         public Respuesta buscarUsuarioExistente(Usuarios usuario)
        {
            Respuesta resp = new Respuesta();
            if (!string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Pass))
            {
                ADNEntityes bd = new ADNEntityes();
                var lista = bd.Usuarios.Where(p => p.Nombre == usuario.Nombre && p.Pass == usuario.Pass)
                     .OrderByDescending(p => p.ID)
                     .Select(p => new { p.ID }).ToList();

                if (lista.Count() > 0)
                {
                    resp.Codigo = "C00000";
                    resp.StatusOperacion = true;
                    resp.Mensaje = "El Usuario Existe";

                }
                else
                    resp.StatusOperacion = false;

            }
            else
            {
                resp.Codigo = "F6500";
                resp.StatusOperacion = false;
                resp.Mensaje = "No se encuentra usuario";
            }

            return resp;
        }

        public Respuesta RegistrarUsuario(Usuarios usuario)
        {
            Respuesta resp = new Respuesta();

            if (!string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Pass) && !string.IsNullOrEmpty(usuario.CorreoElectronico))
            {
                 if (!buscarUsuarioExistente(usuario).StatusOperacion)
                    {
                    ADNEntityes bd = new ADNEntityes();
                    bd.Usuarios.Add(usuario);
                    bd.SaveChanges();


                    resp.Codigo = "C00000";
                    resp.StatusOperacion = true;
                    resp.Mensaje = "El Usuario se registro con Exito";

                }
                else
                {
                    resp.Codigo = "F6500";
                    resp.StatusOperacion = false;
                    resp.Mensaje = "El Usuario  ya Existe";

                }
            }

                return resp;
        }



    }
}
