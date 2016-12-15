﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Linq;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using ORM;

namespace DAL.RepositoryImplementations
{
    public class ToDoFormRepository : IToDoFormRepository
    {
        private readonly DbContext context;

        public ToDoFormRepository(DbContext context)
        {
            this.context = context;
            MapperDomainConfiguration.Configure();
        }

        public IEnumerable<DalToDoForm> GetAll()
        {
            return context.Set<ToDoForm>().ToList().Select(form =>
            MapperDomainConfiguration.MapperInstance.Map<ToDoForm, DalToDoForm>(form)
            );
        }

        public DalToDoForm Get(int id)
        {
            var found = context.Set<ToDoForm>().FirstOrDefault(form => form.Id == id);

            return found == null ? null : MapperDomainConfiguration.MapperInstance.Map<ToDoForm, DalToDoForm>(found);
        }

        public void Create(DalToDoForm entity)
        {
            var form = MapperDomainConfiguration.MapperInstance.Map<DalToDoForm, ToDoForm>(entity);
            context.Set<ToDoForm>().Add(form);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<ToDoForm>().Where(form => form.Id == id).Delete();
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