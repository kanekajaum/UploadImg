//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImagensAleatorias
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Postagem
    {
        public int id { get; set; }
        [Display(Name = "URL: ")]
        public string url { get; set; }
        [Display(Name = "Titulo: ")]
        public string titulo { get; set; }
        [Display(Name = "Descri��o: ")]
        public string descricao { get; set; }
        public int idUsuario { get; set; }

        public HttpPostedFileBase imagemUpload { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}