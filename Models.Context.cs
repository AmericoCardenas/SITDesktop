﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SITEntities : DbContext
    {
        public SITEntities()
            : base("name=SITEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<DomiciliosClientes> DomiciliosClientes { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstatusRutas> EstatusRutas { get; set; }
        public virtual DbSet<EstatusUsuarios> EstatusUsuarios { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<TiposRutas> TiposRutas { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<DatosNominaEmpleados> DatosNominaEmpleados { get; set; }
        public virtual DbSet<DomicilioEmpleados> DomicilioEmpleados { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Rutas> Rutas { get; set; }
        public virtual DbSet<EstatusLineas> EstatusLineas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Lineas> Lineas { get; set; }
        public virtual DbSet<EquiposComputo> EquiposComputo { get; set; }
        public virtual DbSet<EquiposMovil> EquiposMovil { get; set; }
        public virtual DbSet<Trabajadores> Trabajadores { get; set; }
        public virtual DbSet<EstatusEquipos> EstatusEquipos { get; set; }
        public virtual DbSet<UsuariosSitios> UsuariosSitios { get; set; }
        public virtual DbSet<ConceptosFlujos> ConceptosFlujos { get; set; }
        public virtual DbSet<Flujos> Flujos { get; set; }
        public virtual DbSet<MetodosFlujos> MetodosFlujos { get; set; }
        public virtual DbSet<RubrosFlujos> RubrosFlujos { get; set; }
        public virtual DbSet<TiposFlujos> TiposFlujos { get; set; }
        public virtual DbSet<TiposCostos> TiposCostos { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<EstatusVE> EstatusVE { get; set; }
        public virtual DbSet<ViajesEspeciales> ViajesEspeciales { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<BitacoraBitad> BitacoraBitad { get; set; }
        public virtual DbSet<BitacoraRol> BitacoraRol { get; set; }
        public virtual DbSet<Regimenes> Regimenes { get; set; }
        public virtual DbSet<Herramientas> Herramientas { get; set; }
        public virtual DbSet<EstatusPHerramientas> EstatusPHerramientas { get; set; }
        public virtual DbSet<PrestamoHerramientas> PrestamoHerramientas { get; set; }
        public virtual DbSet<Medidas> Medidas { get; set; }
        public virtual DbSet<ProductosSnack> ProductosSnack { get; set; }
        public virtual DbSet<EstatusPSnack> EstatusPSnack { get; set; }
        public virtual DbSet<EstatusSnack> EstatusSnack { get; set; }
        public virtual DbSet<Snack> Snack { get; set; }
        public virtual DbSet<TipoPagoSnack> TipoPagoSnack { get; set; }
        public virtual DbSet<DeduccionesCheckin> DeduccionesCheckin { get; set; }
        public virtual DbSet<NomGenCheckin> NomGenCheckin { get; set; }
        public virtual DbSet<ServiciosCheckin> ServiciosCheckin { get; set; }
        public virtual DbSet<TicketsCheckin> TicketsCheckin { get; set; }
        public virtual DbSet<BonosCheckin> BonosCheckin { get; set; }
        public virtual DbSet<TipoUnidades> TipoUnidades { get; set; }
        public virtual DbSet<EstatusUnidades> EstatusUnidades { get; set; }
        public virtual DbSet<MotoresUnidades> MotoresUnidades { get; set; }
        public virtual DbSet<PolizasUnidades> PolizasUnidades { get; set; }
        public virtual DbSet<ModelosUnidades> ModelosUnidades { get; set; }
        public virtual DbSet<Unidades> Unidades { get; set; }
        public virtual DbSet<Combustibles> Combustibles { get; set; }
        public virtual DbSet<CorteDiarioBomba> CorteDiarioBomba { get; set; }
        public virtual DbSet<EstacionesCombustible> EstacionesCombustible { get; set; }
        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<CuentasBancos> CuentasBancos { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<NotasMovimientos> NotasMovimientos { get; set; }
        public virtual DbSet<Almacenes> Almacenes { get; set; }
        public virtual DbSet<ZonasAlmacen> ZonasAlmacen { get; set; }
        public virtual DbSet<ProductosAlmacen> ProductosAlmacen { get; set; }
        public virtual DbSet<DetalleRequisiciones> DetalleRequisiciones { get; set; }
        public virtual DbSet<Requisiciones> Requisiciones { get; set; }
        public virtual DbSet<CotizacionesRequisiciones> CotizacionesRequisiciones { get; set; }
        public virtual DbSet<EstatusCotizaciones> EstatusCotizaciones { get; set; }
        public virtual DbSet<OrdenesCompra> OrdenesCompra { get; set; }
        public virtual DbSet<DomiciliosProveedores> DomiciliosProveedores { get; set; }
        public virtual DbSet<EstatusOrdenCompra> EstatusOrdenCompra { get; set; }
        public virtual DbSet<DetalleSalidasAlmacen> DetalleSalidasAlmacen { get; set; }
        public virtual DbSet<SalidasAlmacen> SalidasAlmacen { get; set; }
        public virtual DbSet<EstatusSalidas> EstatusSalidas { get; set; }
        public virtual DbSet<FacturasOC> FacturasOC { get; set; }
        public virtual DbSet<FallasTaller> FallasTaller { get; set; }
        public virtual DbSet<GruposActTaller> GruposActTaller { get; set; }
        public virtual DbSet<OrdenesTrabajoTaller> OrdenesTrabajoTaller { get; set; }
        public virtual DbSet<UbicacionesOT> UbicacionesOT { get; set; }
        public virtual DbSet<ActividadesTaller> ActividadesTaller { get; set; }
        public virtual DbSet<MantenimientosTaller> MantenimientosTaller { get; set; }
        public virtual DbSet<EstatusActTaller> EstatusActTaller { get; set; }
        public virtual DbSet<ActividadesOT> ActividadesOT { get; set; }
        public virtual DbSet<CatIncidencias> CatIncidencias { get; set; }
        public virtual DbSet<IncidenciasOperaciones> IncidenciasOperaciones { get; set; }
        public virtual DbSet<VacacionesEmp> VacacionesEmp { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<VacDiasEmpPeriodo> VacDiasEmpPeriodo { get; set; }
        public virtual DbSet<ActividadesMOT> ActividadesMOT { get; set; }
        public virtual DbSet<CatDocsEmp> CatDocsEmp { get; set; }
        public virtual DbSet<DocsEmpleado> DocsEmpleado { get; set; }
        public virtual DbSet<CatArticulosRh> CatArticulosRh { get; set; }
        public virtual DbSet<ArticulosEmp> ArticulosEmp { get; set; }
        public virtual DbSet<HistBajasEmp> HistBajasEmp { get; set; }
    }
}
