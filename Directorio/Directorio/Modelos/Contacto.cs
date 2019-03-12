using SQLite;

namespace Directorio.Modelos
{
    public class Contacto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(12)]
        public string Numero { get; set; }
    }
}
