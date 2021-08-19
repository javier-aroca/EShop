using EShop.CORE.Contracts;
using EShop.DAL;
using System.Linq;

namespace EShop.Application
{
    /// <summary>
    /// Clase genérica de Manager
    /// </summary>
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        /// <summary>
        /// contexto de datos del manager
        /// </summary>
        public IApplicationDbContext Context { get; private set; }

        /// <summary>
        /// constructor del manager
        /// </summary>
        /// <param name="context"> contexto de datos</param>
        public GenericManager(IApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// añade entidad al contexto de datos
        /// </summary>
        /// <param name="entity">entidad a añadir</param>
        /// <returns>entidad añadida</returns>
        public T Add(T entity)
        {
            try
            {
                return Context.Set<T>().Add(entity);
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error al generar el elemento " + typeof(T));
            }
        }

        /// <summary>
        /// elimna una entidad del contexto de datos
        /// </summary>
        /// <param name="entity">entidad a eliminar</param>
        /// <returns>entidad eliminada</returns>
        public T Remove(T entity)
        {
            try
            {
                return Context.Set<T>().Remove(entity);
            }
            catch(System.Exception e)
            {
                throw new System.Exception("Error al eliminar el elemento " + typeof(T));
            }
        }

        /// <summary>
        /// obtiene una entidad por su clave
        /// </summary>
        /// <param name="key">clave del objeto</param>
        /// <returns>entidad</returns>
        public T GetById(object[] key)
        {
            var result = Context.Set<T>().Find(key);
            if (result == null)
                throw new System.Exception("Error al obtener objeto " + typeof(T));

            return result;
        }

        /// <summary>
        /// obtiene una entidad por su clave int
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>entidad</returns>
        public T GetById(int id)
        {
            return GetById(new object[] { id });
        }

        /// <summary>
        /// Obtiene todas las entidades de un tipo específico
        /// </summary>
        /// <returns>Lista todas las incidencias</returns>
        public IQueryable<T> GetAll()
        {
            try
            {
                return Context.Set<T>();
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Error al listar " + typeof(T));
            }
        }
    }
}

