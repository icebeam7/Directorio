using Directorio.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directorio.Servicios
{
    public static class ServicioBD
    {
        public static bool Guardar(Contacto contacto)
        {
            int insert = 0;

            using (SQLiteConnection conexion = new SQLiteConnection(App.RutaBD))
            {
                conexion.CreateTable<Contacto>();
                insert = conexion.Insert(contacto);
            }

            return (insert > 0);
        }

        public static List<Contacto> ObtenerContactos()
        {
            var contactos = new List<Contacto>();

            using (SQLiteConnection conexion = new SQLiteConnection(App.RutaBD))
            {
                conexion.CreateTable<Contacto>();
                contactos = conexion.Table<Contacto>().ToList();
            }

            return contactos;
        }
    }
}
