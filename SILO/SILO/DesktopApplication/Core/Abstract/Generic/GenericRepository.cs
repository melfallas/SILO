using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Abstract.Generic
{
    class GenericRepository<DataType, KeyType> where DataType : class where KeyType : class
    {
        // Obtiene la entidad con base en su Id
        public DataType getById(KeyType pEntityId)
        {
            DataType findedEntity = default(DataType);
            using (var context = new SILOEntities())
            {
                if (pEntityId != default(KeyType))
                {
                    findedEntity = context.Set<DataType>().Find(pEntityId);
                }
            }
            return findedEntity;
        }

        // Obtiene una lista de todos los registros de la entidad
        public List<DataType> getAll()
        {
            List<DataType> entityList = null;
            using (var context = new SILOEntities())
            {
                entityList = context.Set<DataType>().ToList();
            }
            return entityList;
        }

        // Save
        public DataType save(DataType pEntityInstance, KeyType pEntityId, Func<DataType, DataType, DataType> pCopyFuntion)
        {
            DataType findedEntity = null;
            using (var context = new SILOEntities())
            {
                if (pEntityId != default(KeyType))
                {
                    findedEntity = context.Set<DataType>().Find(pEntityId);
                    if (findedEntity == null)
                    {
                        findedEntity = pEntityInstance;
                        context.Set<DataType>().Add(pEntityInstance);
                    }
                    else
                    {
                        findedEntity = pCopyFuntion(findedEntity, pEntityInstance);
                    }
                    context.SaveChanges();
                }
            }
            return findedEntity;
        }

    }
}
