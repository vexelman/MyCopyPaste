using CopyPasteDAL.Models;
using System;
using CopyPasteDAL;
namespace CopyPasteBLL
{
    public class ActionsBLL : IActionsBLL
    {
        IActionsDal ActionsDal;
        //use dependency injection
        public ActionsBLL(IActionsDal _ActionsDal)
        {
            this.ActionsDal = _ActionsDal;
        }

        //function that sends the item to the DAL AddItem function to add the item to the DB
        public bool AddItem(Data item)
        {
            return ActionsDal.AddItem(item);
        }
    
        //function that sends the url to the DAL GetByUrl function to find the data in the DB
        public Data GetByUrl(string url)
        {
            return ActionsDal.GetByUrl(url);
        }
     
        //function that sends the url to the DAL IsExistUrl function to check if it exists in the DB
        public bool IsExistUrl(string url)
        {
            return ActionsDal.IsExistUrl(url);
        }

    }
}
