using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.ExportarExcel
{
    public class ExpExcel
    {
       
        SITEntities db = new SITEntities();
        public void ExportarExcel(string frmname)
        {
            try
            {
                DataGridView dgexcel = new DataGridView();
                SLDocument sl = new SLDocument();
                SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
                string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                downloadPath = System.IO.Path.Combine(downloadPath, "Documents");
                db = new SITEntities();


                switch (frmname)
                {
                    case "VProductosAlmacen":
                        
                        var tb = from p in db.ProductosAlmacen
                                 join m in db.Medidas on p.IdMedida equals m.IdMedida
                                 join z in db.ZonasAlmacen on p.IdZona equals z.IdZona
                                 where p.IdEstatus==1 && p.Stock>0
                                 select new
                                 {
                                     p.IdProducto,
                                     p.CodProducto,
                                     Producto= p.Nombre,
                                     p.Stock,
                                     m.Medida,
                                     z.Zona,
                                     p.Pasillo,
                                     p.Anaquel
                                 };

                        dgexcel.Columns.Add("IDPRODUCTO", "IDPRODUCTO");
                        dgexcel.Columns.Add("CODPRODUCTO", "CODPRODUCTO");
                        dgexcel.Columns.Add("PRODUCTO", "PRODUCTO");
                        dgexcel.Columns.Add("STOCK", "STOCK");
                        dgexcel.Columns.Add("MEDIDA", "MEDIDA");
                        dgexcel.Columns.Add("ZONA", "ZONA");
                        dgexcel.Columns.Add("PASILLO", "PASILLO");
                        dgexcel.Columns.Add("ANAQUEL", "ANAQUEL");


                        foreach (var item in tb)
                        {
                            dgexcel.Rows.Add(item.IdProducto, item.CodProducto, 
                                item.Producto, item.Stock, item.Medida, item.Zona,
                                item.Pasillo, item.Anaquel);
                        }

                        for (int i = 0; i < dgexcel.Columns.Count; i++)
                        {
                            sl.SetCellValue(1, i + 1, dgexcel.Columns[i].Name);
                        }

                        for (int i = 0; i < dgexcel.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgexcel.Columns.Count; j++)
                            {
                                DataGridViewCell cell = dgexcel.Rows[i].Cells[j];
                                if (cell.Value != null)
                                {
                                    sl.SetCellValue(i + 2, j + 1, dgexcel.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                        }



                        sl.AutoFitColumn(1, stats.EndColumnIndex);

                        // Save the Excel file
                        sl.SaveAs(downloadPath + "\\ProdsAlmacen" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                        MessageBox.Show("Archivo exportado en " + downloadPath);


                        break;

                    case "VOrdenesTrabajo":

                        var tbot = from aot in db.ActividadesOT
                                   join o in db.OrdenesTrabajoTaller on aot.IdOT equals o.IdOrdenTrabajo
                                   join u in db.Unidades on o.IdUnidad equals u.IdUnidad
                                   join op in db.Trabajadores on o.IdEmpleado equals op.IdEmpleado
                                   join m in db.MantenimientosTaller on aot.IdMtto equals m.IdMantenimiento
                                   join att in db.ActividadesTaller on aot.IdActTaller equals att.IdAct
                                   join gpo in db.GruposActTaller on att.IdGrupo equals gpo.IdGrupo
                                   join e in db.EstatusActTaller on aot.IdEstatus equals e.IdEstatus
                                   join mec in db.Trabajadores on aot.IdEmpleado equals mec.IdEmpleado
                                   where aot.IdEstatus != 2 && o.IdUnidad != 0
                                
                                 select new
                                 {
                                     aot.IdOT,
                                     Fecha=aot.FI,
                                     Unidad=u.Economico,
                                     Operador= op.NombreCompleto,
                                     Tecnico = mec.NombreCompleto,
                                     m.Mantenimiento,
                                     att.Actividad,
                                     gpo.Grupo,
                                     aot.Observaciones,
                                     OTObs=o.Observaciones,
                                     e.Estatus
                               
                                 };

                        dgexcel.Columns.Add("IDOT", "IDOT");
                        dgexcel.Columns.Add("FECHA", "FECHA");
                        dgexcel.Columns.Add("UNIDAD", "UNIDAD");
                        dgexcel.Columns.Add("OPERADOR", "OPERADOR");
                        dgexcel.Columns.Add("TECNICO", "TECNICO");
                        dgexcel.Columns.Add("T.MANTENIMIENTO", "T.MANTENIMIENTO");
                        dgexcel.Columns.Add("ACTIVIDAD", "ACTIVIDAD");
                        dgexcel.Columns.Add("GRUPO", "GRUPO");
                        dgexcel.Columns.Add("OBSACT", "OBSACT");
                        dgexcel.Columns.Add("OBSGENERAL", "OBSGENERAL");
                        dgexcel.Columns.Add("ESTATUS", "ESTATUS");





                        foreach (var item in tbot)
                        {
                            dgexcel.Rows.Add(item.IdOT, item.Fecha,
                                item.Unidad, item.Operador, item.Tecnico, item.Mantenimiento,
                                item.Actividad, item.Grupo,item.Observaciones,item.OTObs,item.Estatus);
                        }

                        for (int i = 0; i < dgexcel.Columns.Count; i++)
                        {
                            sl.SetCellValue(1, i + 1, dgexcel.Columns[i].Name);
                        }

                        for (int i = 0; i < dgexcel.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgexcel.Columns.Count; j++)
                            {
                                DataGridViewCell cell = dgexcel.Rows[i].Cells[j];
                                if (cell.Value != null)
                                {
                                    sl.SetCellValue(i + 2, j + 1, dgexcel.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                        }



                        sl.AutoFitColumn(1, stats.EndColumnIndex);

                        // Save the Excel file
                        sl.SaveAs(downloadPath + "\\ActividadesTaller" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                        MessageBox.Show("Archivo exportado en " + downloadPath);


                        break;

                }
            }
            catch(Exception ex) { 
            }
        }
    }
}
