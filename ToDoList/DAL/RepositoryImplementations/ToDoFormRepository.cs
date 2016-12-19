using System;
using System.Collections.Generic;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Linq;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using NLog;
using ORM;

namespace DAL.RepositoryImplementations
{
    public class ToDoFormRepository : IToDoFormRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly DbContext context;

        public ToDoFormRepository(DbContext context)
        {
            this.context = context;
            MapperDomainConfiguration.Configure();
        }

        public IEnumerable<DalToDoForm> GetAll()
        {
            IEnumerable<DalToDoForm> list = context.Set<ToDoForm>().ToList().Select(form =>
                MapperDomainConfiguration.MapperInstance.Map<ToDoForm, DalToDoForm>(form)
                );

            return list;
        }

        public DalToDoForm Get(int id)
        {
            ToDoForm found = context.Set<ToDoForm>().FirstOrDefault(form => form.Id == id);

            return found == null ? null : MapperDomainConfiguration.MapperInstance.Map<ToDoForm, DalToDoForm>(found);
        }

        public void Create(DalToDoForm entity)
        {
            try
            {
                ToDoForm form = MapperDomainConfiguration.MapperInstance.Map<DalToDoForm, ToDoForm>(entity);
                context.Set<ToDoForm>().Add(form);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public void Delete(int id)
        {
            //context.Set<ToDoForm>().Include(t => t.Tasks).SingleOrDefault(t => t.)
            //context.Set<ToDoForm>().Include(t => t.Tasks).Where(form => form.Id == id).Delete();

            ToDoForm form = new ToDoForm { Id = id };
            context.Set<ToDoForm>().Attach(form);
            context.Set<ToDoForm>().Remove(form);
            context.SaveChanges();
        }

        public void Update(DalToDoForm entity)
        {
            ToDoForm toDoForm = MapperDomainConfiguration.MapperInstance.Map<DalToDoForm, ToDoForm>(entity);

            context.Set<ToDoForm>()
                .Where(form => form.Id == toDoForm.Id)
                .Update(updated => toDoForm);
        }
    }
}
