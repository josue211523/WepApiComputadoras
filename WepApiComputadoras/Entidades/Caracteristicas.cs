namespace WepApiComputadoras.Entidades
{
    public class Caracteristicas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int ComputadoraId { get; set; }
        public Computadora Computadora { get; set; }

    }
}
