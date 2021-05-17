using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int HeroiId { get; set; }

        public virtual Heroi Heroi { get; set; }
    }
}
