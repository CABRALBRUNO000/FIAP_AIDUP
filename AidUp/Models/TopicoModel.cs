namespace AidUp.Models
{
    public class TopicoModel
    {
        public string Titulo { get; set; }
        public string IdAutor { get; set; }
        public string IdInstituicao { get; set; }

        public DateTime DataPublicacao { get; set; }
        public string Conteudo { get; set; }
        public string[] Tags { get; set; }
        public StatusTopico Status { get; set; }

        public DateTime Validade { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Descricao { get; set; }

        public string UrlMidia { get; set; }


    }

    public enum StatusTopico
    {
        Ativo,
        Inativo,
        Visualizado,
        NaoVisualizado
    }
}
