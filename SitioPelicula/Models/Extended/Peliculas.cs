using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioPelicula.Models
{
    [MetadataType(typeof(PeliculasMetadata))]
    public partial class Pelicula
    {

    }

    public class PeliculasMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el Nombre de la Pelicula")]
        public string NombrePelicula { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el Genero de la Pelicula")]
        public string GeneroPelicula { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el año de la Pelicula")]
        public int AñoPelicula { get; set; }


        //[Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el Pais de la Pelicula")]
        public string PaisPelicula { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el nombre del Director de la Pelicula")]
        public string DirectorPelicula { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el nombre del Actor principal de la Pelicula")]
        public string ActorPelicula1 { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Favor agregar el nombre del Actor Secundario de la Pelicula")]
        public string ActorPelicula2 { get; set; }


        public string ActorPelicula3 { get; set; }


        public string ActorPelicula4 { get; set; }
    }
}