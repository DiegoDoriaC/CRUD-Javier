using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JavierCRUD.Interfaces;
using JavierCRUD.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace JavierCRUD.DAO
{
    public class DAOUsuario : IUsuario, IConexionDB
    {

        string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        public List<Usuario> Usuarios()
        {
            List<Usuario> temporal = new List<Usuario>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listarClientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario u = new Usuario();
                u.ID = dr.GetInt32(0);
                u.Nombre = dr.GetString(1);
                u.Apellido = dr.GetString(2);
                u.DNI = dr.GetString(3);
                u.Telefono = dr.GetString(4);
                temporal.Add(u);
            }
            dr.Close();
            cn.Close();
            return temporal;
        }

        public void EliminarUsuario(Usuario u)
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_eliminarUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", u.ID);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void CrearUsuario(Usuario u)
        {
            string comando = "sp_crearUsuario";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand(comando, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@apellido", u.Apellido);
            cmd.Parameters.AddWithValue("@dni", u.DNI);
            cmd.Parameters.AddWithValue("@telefono", u.Telefono);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void ActualizarUsuario(int id, Usuario u)
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_actualizarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@apellido", u.Apellido);
            cmd.Parameters.AddWithValue("@dni", u.DNI);
            cmd.Parameters.AddWithValue("@telefono", u.Telefono);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}