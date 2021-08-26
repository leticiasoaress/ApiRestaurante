using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiRestaurante.Base
{
    public class BaseRepositorio<T> where T : BaseModel
    {
        private readonly Contexto _contexto;

        public BaseRepositorio()
        {
            this._contexto = new Contexto();
        }

        virtual public void Create(T objeto)
        {
            objeto.DT_CREATE = DateTime.Now;
            try
            {
                _contexto.Set<T>().Add(objeto);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        virtual public void Update(T objeto)
        {        
            try
            {
                var objAlter = new Contexto().Set<T>().FirstOrDefault(m => m.ID == objeto.ID);
                if(objAlter != null)
                {
                    objeto.DT_CREATE = objAlter.DT_CREATE;
                    var _ctx = new Contexto();
                    _ctx.Entry(objeto).State = EntityState.Modified;
                    _ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        virtual public void Delete(T objeto)
        {
            try
            {
                var _ctx = new Contexto();
                _ctx.Entry(objeto).State = EntityState.Deleted;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        virtual public IEnumerable<T> GetAll()
        {
            return _contexto.Set<T>().ToList();
        }

        virtual public T GetById(int Id)
        {
            return _contexto.Set<T>().AsNoTracking().FirstOrDefault(m => m.ID == Id);
        }

        virtual public int VerifyId(int Id)
        {
            return _contexto.Set<T>().Count(m => m.ID == Id);
        }
    }
}