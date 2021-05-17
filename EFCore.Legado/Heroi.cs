using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Heroi
    {
        public Heroi()
        {
            Armas = new HashSet<Arma>();
            HeroisBatalhas = new HashSet<HeroisBatalha>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual IdentidadesSecreta IdentidadesSecreta { get; set; }
        public virtual ICollection<Arma> Armas { get; set; }
        public virtual ICollection<HeroisBatalha> HeroisBatalhas { get; set; }
    }
}
