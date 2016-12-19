using System;
using System.Collections.Generic;
using System.Web.Http;
using DAL.DataTransferObject;
using DAL.Repository;
using NLog;

namespace ToDoList.Controllers
{
    public class ToDoListController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IToDoFormRepository toDoFormRepository;

        public ToDoListController(IToDoFormRepository toDoFormRepository)
        {
            this.toDoFormRepository = toDoFormRepository;
        }

        [HttpGet]
        public IEnumerable<DalToDoForm> GetAll()
        {
            DalToDoForm toAdd = new DalToDoForm
            {
                Title = "Another task",
                Author = new DalAuthor { FirstName = "Fedorrrr", LastName = "Emelianenko" },
                CreationTime = DateTime.Now,
                Tasks = new List<DalTask>
                {
                    new DalTask { Content = "Morning Training", CreationTime = DateTime.Now},
                    new DalTask { Content = "Evening Training", CreationTime = DateTime.Now}
                }
            };
            //toDoFormRepository.Delete(2);
            /*toDoFormRepository.Delete(3);
            toDoFormRepository.Delete(4);
            toDoFormRepository.Delete(5);
            toDoFormRepository.Delete(6);*/
            //toDoFormRepository.Create(toAdd);
            //toDoFormRepository.Create(toAdd);
            return toDoFormRepository.GetAll();
        }

        [HttpGet]
        public DalToDoForm Get(int id)
        {
            return toDoFormRepository.Get(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            toDoFormRepository.Delete(id);
        }

        [HttpPut]
        public void Add(DalToDoForm form)
        {
            form.CreationTime = DateTime.UtcNow;
            foreach (DalTask dalTask in form.Tasks)
            {
                dalTask.CreationTime = DateTime.UtcNow;
            }
            toDoFormRepository.Create(form);
        }
    }
}
