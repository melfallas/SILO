using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Abstract.Generic
{
    public class GenericRepository<DataType, KeyType> where DataType : class where KeyType : class
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
            List<DataType> entityList = new List<DataType>();
            using (var context = new SILOEntities())
            {
                var allElementList = context.Set<DataType>();
                if (allElementList.Count() != 0)
                {
                    entityList = allElementList.ToList();
                }
            }
            return entityList;
        }

        // Save
        public DataType save(DataType pEntityInstance, KeyType pEntityId, Func<DataType, DataType, long> pCopyFuntion)
        {
            DataType findedEntity = null;
            using (var context = new SILOEntities())
            {
                if (pEntityId != default(KeyType))
                {
                    // Validar colecciones vacías y elementos no encontrados
                    var entityCollection = context.Set<DataType>();
                    findedEntity = entityCollection.Count() == 0 ? null : entityCollection.Find(pEntityId);
                    if (findedEntity == null)
                    {
                        // Si no existe la entidad, añadirla y guardar cambios
                        context.Set<DataType>().Add(pEntityInstance);
                        context.SaveChanges();
                        findedEntity = pEntityInstance;
                    }
                    else
                    {
                        long actualStatus = pCopyFuntion(findedEntity, pEntityInstance);
                        // Validar estado de la entidad para determinar si se actualiza
                        //if (actualStatus == SystemConstants.SYNC_STATUS_COMPLETED)
                        if (actualStatus != SystemConstants.SYNC_STATUS_PENDING_TO_SERVER)
                        {
                            // Update solamente si el estado es completamente sincronizado
                            context.SaveChanges();
                        }
                    }
                }
            }
            return findedEntity;
        }

        // Save
        public DataType saveWithStatus(DataType pEntityInstance, KeyType pEntityId, Func<DataType, DataType, long> pCopyFuntion)
        {
            DataType findedEntity = null;
            using (var context = new SILOEntities())
            {
                if (pEntityId != default(KeyType))
                {
                    // Validar colecciones vacías y elementos no encontrados
                    var entityCollection = context.Set<DataType>();
                    findedEntity = entityCollection.Count() == 0 ? null : entityCollection.Find(pEntityId);
                    if (findedEntity == null)
                    {
                        // Si no existe la entidad, añadirla y guardar cambios
                        context.Set<DataType>().Add(pEntityInstance);
                        context.SaveChanges();
                        findedEntity = pEntityInstance;
                    }
                    else
                    {
                        long actualStatus = pCopyFuntion(findedEntity, pEntityInstance);
                        context.SaveChanges();
                    }
                }
            }
            return findedEntity;
        }

    }
}
