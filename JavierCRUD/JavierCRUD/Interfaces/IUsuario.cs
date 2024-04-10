using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavierCRUD.Models;

namespace JavierCRUD.Interfaces
{
    public interface IUsuario
    {
        List<Usuario> Usuarios();
        void EliminarUsuario(Usuario u);
        void CrearUsuario(Usuario u);
        void ActualizarUsuario(int id, Usuario u);
    }
}
