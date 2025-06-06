using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Alunos.Domain.Entities
{
    public class Certificado : Entity
    {
        public Guid CursoId { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public string? Url { get; private set; }

        protected Certificado() { }

        public static Certificado Create(Guid id, Guid cursoId, DateTime dataConclusao, string? url)
        {
            return new Certificado
            {
                Id = id,
                CursoId = cursoId,
                DataConclusao = dataConclusao,
                Url = url,
            };
        }
    }
}
