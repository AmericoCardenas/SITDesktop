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
    
    public partial class ProductosAlmacen
    {
        public int IdProducto { get; set; }
        public string CodProducto { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> Stock { get; set; }
        public Nullable<double> ExMin { get; set; }
        public Nullable<double> ExMax { get; set; }
        public Nullable<int> IdMedida { get; set; }
        public Nullable<int> IdZona { get; set; }
        public Nullable<int> IdEstatus { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<int> IdUsCreo { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public Nullable<int> IdUsMod { get; set; }
        public Nullable<System.DateTime> FechaCan { get; set; }
        public Nullable<int> IdUsCan { get; set; }
        public Nullable<int> Pasillo { get; set; }
        public string Anaquel { get; set; }
    }
}
