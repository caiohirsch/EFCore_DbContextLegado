using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Batalha
    {
        public Batalha()
        {
            HeroisBatalhas = new HashSet<HeroisBatalha>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }

        public virtual ICollection<HeroisBatalha> HeroisBatalhas { get; set; }
    }
}
