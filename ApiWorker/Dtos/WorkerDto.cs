namespace ApiWorker.Dtos
{
    public class WorkerDto
    {
        public int WorkerId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Dni { get; set; }
        public int Numero { get; set; }

        public string? Direccion { get; set; }

        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
    }
}
