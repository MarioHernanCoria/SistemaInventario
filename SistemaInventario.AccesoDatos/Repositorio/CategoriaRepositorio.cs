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
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly SistemaInventarioContext _context;

        public CategoriaRepositorio(SistemaInventarioContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Categoria categoria)
        {
            var categoriaBD = _context.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
            if(categoriaBD != null) 
            {
                categoriaBD.Nombre = categoria.Nombre;
                categoriaBD.Descripcion = categoria.Descripcion;
                categoriaBD.Estado = categoria.Estado;

                _context.SaveChanges();
            }
        }
    }
}
