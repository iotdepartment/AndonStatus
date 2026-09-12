namespace AndonStatus.ViewModels
{
    public class AndonViewModel
    {
        public int AndonId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public int EstadoId { get; set; }
    }
}
