﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bastis.Models.Entities
{
    public class Agency
    {
        //public Order()
        //{
        //    Items = new HashSet<Item>();
        //}

        public int AgencyID { get; set; }

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


        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<Property> Properties { get; set; }


        //        Nombre
        //Direccion
        //Phone:
        //Mobile:
        //Imagen
        //License:
        //Website:
        //redes sociales
        //Descripcion

        //https://www.pluralsight.com/guides/asp-net-mvc-getting-default-data-binding-right-for-hierarchical-views
    }
}