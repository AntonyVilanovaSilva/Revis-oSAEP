//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBTarefaAnderline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tarefa
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public int IDPrioridade { get; set; }
        public int IDStatus { get; set; }
        public string Descricao { get; set; }
        public System.DateTime DataCriacao { get; set; }
    
        public virtual Prioridades Prioridades { get; set; }
        public virtual StatusTarefa StatusTarefa { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}