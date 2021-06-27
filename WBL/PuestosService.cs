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
    public interface IPuestosService
    {
        Task<DBEntity> Create(PuestosEntity entity);
        Task<DBEntity> Delete(PuestosEntity entity);
        Task<IEnumerable<PuestosEntity>> Get();
        Task<PuestosEntity> GetById(PuestosEntity entity);
        Task<DBEntity> Update(PuestosEntity entity);
    }

    public class PuestosService : IPuestosService
    {
        private readonly IDataAccess sql;

        public PuestosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<PuestosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PuestosEntity>(sp: "PuestosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<PuestosEntity> GetById(PuestosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestosEntity>(sp: "PuestosObtener", Param: new { entity.Id_Puesto });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestosInsertar", Param: new { entity.Nombre, entity.Salario, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Update(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestosActualizar", Param: new { entity.Id_Puesto, entity.Nombre, entity.Salario, entity.Estado });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Delete(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestosEliminar", Param: new { entity.Id_Puesto });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
