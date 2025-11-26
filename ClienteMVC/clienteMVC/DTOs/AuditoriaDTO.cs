namespace clienteMVC.DTOs
{
    public class AuditoriaDTO
    {
        public int Id { get; set; }

        public int TipoDeGastoId { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        //public string? NombreUsuario { get; set; }

        public AuditoriaDTO() { }
    }
}
