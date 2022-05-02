using CopyPasteDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPasteDAL
{
   public interface IActionsDal
    {
        public bool AddItem(Data item);
        public Data GetByUrl(string url);
        public bool IsExistUrl(string url);

    }
}
