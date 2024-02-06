using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {
        private readonly SistemaInventarioContext _context;

        public BodegaRepositorio(SistemaInventarioContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Bodega bodega)
        {
            var bodegaBD = _context.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if(bodegaBD != null) 
            {
                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.Estado = bodega.Estado;

                _context.SaveChanges();
            }
        }
    }
}
