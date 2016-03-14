using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunoCimatec.Model
{
    public class Curso
    {
        public String Nome { get; set; }

        public List<Disciplinas> Disciplinas { get; set; }

        public String InicialCurso
        {
            get
            {
                return  this.Nome.Substring(this.Nome.Length - 1, 1);
            }
            set
            {
                this.InicialCurso = value;
            }
        }

        //public String getInicalCurso()
        //{
        //    return this.Nome.Substring(1, this.Nome.Length);
        //}
    }
}
