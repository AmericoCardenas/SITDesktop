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
    
    public partial class Lineas
    {
        public int IdLinea { get; set; }
        public string Linea { get; set; }
        public string NumSim { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdEstatus { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
    
        public virtual Trabajadores Trabajadores { get; set; }
    }
}
