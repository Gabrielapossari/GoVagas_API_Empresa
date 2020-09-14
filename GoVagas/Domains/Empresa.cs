using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoVagas.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Documentacao = new HashSet<Documentacao>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public byte[] AnexarLogo { get; set; }
        public string CargoArea { get; set; }
        public string WebSite { get; set; }

        // Define que o nome da empresa é obrigatória
        [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
  
        public string NomeEmpresa { get; set; }
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O cnpj da empresa é obrigatório!")]
        
        public string Cnpj { get; set; }
        // Define que o ramo da emrpesa é obrigatória
        [Required(ErrorMessage = "O ramo da empresa é obrigatório!")]
      
        public string RamoEmpresa { get; set; }
        // Define que a descricao da empresa é obrigatória
        [Required(ErrorMessage = "O descrição da empresa é obrigatória!")]
        
        public string DescricaoEmpresa { get; set; }
        // Define que a localziacão é obrigatória
        [Required(ErrorMessage = "A localização da empresa é obrigatória!")]
      
        public string LocalizacaoEmpresa { get; set; }
        // Define que onde voce encontrou a empresa  é obrigatória
        [Required(ErrorMessage = "Onde voce encontrou a empresa é obrigatório!")]
      
        public string EncontrouSenai { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Documentacao> Documentacao { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
