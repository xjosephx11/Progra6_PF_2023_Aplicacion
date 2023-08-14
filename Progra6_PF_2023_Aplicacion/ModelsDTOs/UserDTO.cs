namespace Progra6_PF_2023_Aplicacion.ModelsDTOs
{
    public class UserDTO
    {
        public int IDUsuariodto { get; set; }
        public string Correodto { get; set; } = null!;
        public string Contraseniadto { get; set; } = null!;
        public string Nombredto { get; set; } = null!;
        public string correoRespaldodto { get; set; } = null!;
        public string Telefonodto { get; set; } = null!;
        public bool? Avtivodto { get; set; }
        public string? direcciondto { get; set; }
        public int idroldto { get; set; }
        public bool estaBloqueadodto { get; set; }
        public string descripcionRoldto { get; set; } = null!;

        
    }
}
