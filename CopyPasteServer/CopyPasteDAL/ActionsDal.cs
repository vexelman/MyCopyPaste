using CopyPasteDAL.Models;
using System;
using System.Linq;

namespace CopyPasteDAL
{
    public class ActionsDal : IActionsDal
    {
        CopyPasteDataContext DB;
        public ActionsDal(CopyPasteDataContext _DB)
        {
            this.DB = _DB;
        }
        //function that adds a newItem to the dataBase
        public bool AddItem(Data item)
        {
            //if the action succeeds returns true
            try
            {       
                DB.Data.Add(item);
                DB.SaveChanges();
                return true;
            }
            //if the action faild returns false
            catch (Exception e)
            {
               
                return false;
            }
     
        }


        //function that gets the data by url
        public Data GetByUrl(string url)
        {
            try
            {
               return DB.Data.FirstOrDefault(x => x.Url == url);
            }
            catch(Exception)
            {
                return null;
            }
        }

        //function that checks if the url exists in the data base
        public bool IsExistUrl(string url)
        {
            try
            {
              var u = DB.Data.FirstOrDefault(x => x.Url == url);
              if (u == null)
                   return true;
              return false;
            }
            catch{
                return true;
            }



        }
    }
}
