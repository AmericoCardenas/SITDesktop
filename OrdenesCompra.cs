//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIT
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdenesCompra
    {
        public int IdOCompra { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdEstatus { get; set; }
        public Nullable<System.DateTime> FCreo { get; set; }
        public Nullable<int> IdUsCreo { get; set; }
        public Nullable<System.DateTime> FMod { get; set; }
        public Nullable<int> IdUsMod { get; set; }
        public Nullable<System.DateTime> FCan { get; set; }
        public Nullable<int> IdUsCan { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public Nullable<double> Iva { get; set; }
        public Nullable<double> Total { get; set; }
        public string ImporteLetra { get; set; }
    }
}
