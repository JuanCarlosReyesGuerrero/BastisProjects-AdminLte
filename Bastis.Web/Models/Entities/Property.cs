using System;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public class Property
    {
        public int ID { get; set; }

        [Display(Name = "Propiedad título")]
        [Required(ErrorMessage = "Digite el código de la EPS")]
        public string Title { get; set; }

        [Display(Name = "Descripción de la propiedad")]
        [Required(ErrorMessage = "Digite el código de la EPS")]
        public string Description { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Digite el Tipo")]
        public string TypeID { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Digite el Estado")]
        public string StatusID { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "Digite el Ubicación")]
        public string Location { get; set; }

        [Display(Name = "Dormitorios")]
        [Required(ErrorMessage = "Digite el Dormitorios")]
        public string Bedrooms { get; set; }

        [Display(Name = "Baños")]
        [Required(ErrorMessage = "Digite el Baños")]
        [Range(0, 99)]
        public string Bathrooms { get; set; }

        [Display(Name = "Pisos")]
        [Required(ErrorMessage = "Digite el pisos")]
        public string Floors { get; set; }

        [Display(Name = "Garajes")]
        [Required(ErrorMessage = "Digite el Garajes")]
        public string Garages { get; set; }

        [Display(Name = "Zona")]
        [Required(ErrorMessage = "Digite el Zona")]
        public string Area { get; set; }

        [Display(Name = "Tamaño")]
        [Required(ErrorMessage = "Digite el Tamaño")]
        public string Size { get; set; }

        [Display(Name = "Precio de venta o renta *")]
        [Required(ErrorMessage = "Digite el Precio de venta o renta")]
        public string SaleRentPrice { get; set; }

        [Display(Name = "Antes de la etiqueta de precio")]
        [Required(ErrorMessage = "Digite el Antes de la etiqueta de precio")]
        public string BeforePriceLabel { get; set; }

        [Display(Name = "Después de la etiqueta de precio")]
        [Required(ErrorMessage = "Digite el Después de la etiqueta de precio")]
        public string AfterPriceLabel { get; set; }

        [Display(Name = "URL del vídeo")]
        [Required(ErrorMessage = "Digite el URL del vídeo")]
        public string VideoURL { get; set; }

        [Display(Name = "Caracteristicas de la propiedad")]
        [Required(ErrorMessage = "Digite el Caracteristicas de la propiedad")]
        public string PropertyFeatures { get; set; }

        [Display(Name = "Galería de propiedades")]
        [Required(ErrorMessage = "Digite el Galería de propiedades")]
        public string PropertyGallery { get; set; }

        [Display(Name = "Dirección*")]
        [Required(ErrorMessage = "Digite el Dirección*")]
        public string Address { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "Digite el País")]
        public string CountryID { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Digite el Ciudad")]
        public string CityID { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Digite el departamento")]
        public string StateID { get; set; }

        [Display(Name = "Código Postal / Postal")]
        [Required(ErrorMessage = "Digite el Código Postal / Postal")]
        public string ZipPostalCode { get; set; }

        [Display(Name = "Barrio")]
        [Required(ErrorMessage = "Digite el Barrio")]
        public string Neighborhood { get; set; }


        //Descripción de propiedad
        // Tipo (tabla)
        // Estado (tabla)
        // Ubicación (geo)
        // Dormitorios
        // Baños
        // pisos
        // Garajes
        //Zona
        //Tamaño
        // Precio de venta o renta *
        // Antes de la etiqueta de precio
        // Después de la etiqueta de precio
        // ID de la propiedad *
        //URL del vídeo
        //Caracteristicas de la propiedad
        // Galería de propiedades
        // Ubicación de la Propiedad -----------------------
        //Dirección*
        //País
        //Ciudad
        //Estado
        // Código Postal / Postal
        //Barrio





        public int PropertyID { get; set; }
        public int DepartamentID { get; set; }

        // Inicio Auditoria de la tabla ---------------------------------------------------
        public Guid? UserRegisters { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRegister { get; set; }

        public Guid? UserModifies { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateModified { get; set; }
        // Fin Auditoria de la tabla ---------------------------------------------------

        public virtual Agency Agency { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual State State { get; set; }
        //city
    }
}