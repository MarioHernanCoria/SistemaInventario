﻿using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly SistemaInventarioContext _context;
        public IBodegaRepositorio Bodega {  get; private set; }
        public ICategoriaRepositorio Categoria { get; private set; }
        public IMarcaRepositorio Marca { get; private set; }


        public UnidadTrabajo(SistemaInventarioContext context)
        {
            _context = context;
            Bodega = new BodegaRepositorio(_context);
            Categoria = new CategoriaRepositorio(_context);
            Marca = new MarcaRepositorio(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Guardar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
