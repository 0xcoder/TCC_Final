using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador.Models
{
    public class Aluno
    {
      [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome da Disciplina")]

        public string Disciplina { get; set; }

        [Required(ErrorMessage ="Insira uma descrição")]

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Insira um Tema")]

        public string Tema { get; set; }

        [Required(ErrorMessage = "Insira os Integrantes")]
        
        public string Integrantes { get; set; }
        
        public string idUsuario { get; set; }
        public string tipoPasta { get; set; }


    }
}
