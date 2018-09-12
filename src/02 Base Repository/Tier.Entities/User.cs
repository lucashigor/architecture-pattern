using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityPhoto
{
    /// <summary>
    /// Classe que representa um usuario no sistema
    /// </summary>
    public class User
    {
        /// <summary>
        /// Cd é o Login do user, o que ele usa para se logar
        /// VARCHAR(50)
        /// </summary>
        public string Cd_usuario { get; set; }

        /// <summary>
        /// Mostra se está ativo ou não o user
        /// bolean
        /// </summary>
        public Boolean Dv_status { get; set; }

        /// <summary>
        /// Qual o nome do User
        /// VARCHAR(100)
        /// </summary>
        public string Nm_usuario { get; set; }

        /// <summary>
        /// Senha em MD5
        /// CHAR(30)
        /// </summary>
        public string Tx_senha { get; set; }

        [Key]
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        
        public int? Type_Id { get; set; }

        [ForeignKey("Type_Id")]
        [InverseProperty("Users")]
        public virtual UserType Type { get; set; }
    }
}
