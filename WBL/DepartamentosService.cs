using BD;
using Entity;
using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IDepartamentosService
    {
        Task<DBEntity> Create(DepartamentosEntity entity);
        Task<DBEntity> Delete(DepartamentosEntity entity);
        Task<IEnumerable<DepartamentosEntity>> Get();
        Task<DepartamentosEntity> GetById(DepartamentosEntity entity);
        Task<DBEntity> Update(DepartamentosEntity entity);
    }

    public class DepartamentosService : IDepartamentosService
    {
        private readonly IDataAccess sql;

        public DepartamentosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<DepartamentosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<DepartamentosEntity>(sp: "DepartamentosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DepartamentosEntity> GetById(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<DepartamentosEntity>(sp: "DepartamentosObtener", Param: new { entity.Id_Departamento });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentosInsertar", Param: new { entity.Descripcion, entity.Ubicacion, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Update(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentosActualizar", Param: new { entity.Id_Departamento, entity.Descripcion, entity.Ubicacion, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Delete(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentosEliminar", Param: new { entity.Id_Departamento });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
