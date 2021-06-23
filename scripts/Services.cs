using PG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Services
{
    class IOService
    {
        public BindingList<Model> LoadData()
        {
            return null;
        /*
         Нужно загрузить данные и сконвертированные данные закинуть в список модели*/
        }
        public void SaveData(BindingList<Model> Data) // BindingList<Model> заменить на object
        {
            return;
        /*
         Нужно список модели переделать в строку и закинуть в бд
         */
        }
    }
}
