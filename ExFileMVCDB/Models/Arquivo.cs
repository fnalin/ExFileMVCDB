
namespace ExFileMVCDB.Models
{
    public partial class Arquivo
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public byte[] AnexoBytes { get; set; }
        public string AnexoExtensao { get; set; }
        public string AnexoTipo { get; set; }
    }
}
