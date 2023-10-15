namespace AidUp.Models
{
    public class AidupDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string PersonaDatabase { get; set; } = null!;
        public string InstituicaoCollectionName { get; set; } = null!;
        public string UsuarioCollectionName { get; set; } = null!;  


        public string TopicoDatabase { get; set; } = null!;
        public string ProgramacaoCollectionName { get; set; } = null!;
        public string ArtigoCollectionName { get; set; } = null!;
        public string ComunicadoCollectionName { get; set; } = null!;
        public string DevocionalCollectionName { get; set; } = null!;
        public string EnqueteCollectionName { get; set; } = null!;
        public string EventoCollectionName { get; set; } = null!;
        public string LembreteCollectionName { get; set; } = null!;
        public string PostCollectionName { get; set; } = null!;
        public string TarefaCollectionName { get; set; } = null!;




    }
}
