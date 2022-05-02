using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopyPasteDAL;
using CopyPasteDAL.Models;


namespace CopyPasteBLL
{
    public interface IActionsBLL
    {
        public bool AddItem(Data item);
        public Data GetByUrl(string url);
        public bool IsExistUrl(string url);

    }
}
