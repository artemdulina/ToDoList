using System.Collections.Generic;
using System.Web.Http;
using DAL.DataTransferObject;
using DAL.Repository;

namespace ToDoList.Controllers
{
    public class ToDoListController : ApiController
    {
        private readonly IToDoFormRepository toDoFormRepository;

        public ToDoListController(IToDoFormRepository toDoFormRepository)
        {
            this.toDoFormRepository = toDoFormRepository;
        }

        public IEnumerable<DalToDoForm> GetAll()
        {
            return toDoFormRepository.GetAll();
        }
    }
}
