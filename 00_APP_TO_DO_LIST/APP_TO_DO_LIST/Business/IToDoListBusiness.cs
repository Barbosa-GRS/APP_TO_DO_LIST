using APP_TO_DO_LIST.Model;
using static APP_TO_DO_LIST.Model.ToDoList;

namespace APP_TO_DO_LIST.Business;

public interface IToDoListBusiness :IBaseBusiness<ToDoList>
{
   
    void DeleteCompleteToDoList();

}
