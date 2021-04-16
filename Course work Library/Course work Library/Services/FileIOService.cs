using Course_work_Library.BookModel;
using Course_work_Library.CategoriesModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Course_work_Library.Services
{
    static class FileIOService
    {
        static public BindingList<CategoriesBooks> LoadDataCategories(string PATH)
        {
            var fileExist = File.Exists(PATH);
            if(!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<CategoriesBooks>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<CategoriesBooks>>(fileText);
            }
        }
        static public BindingList<Book> LoadDataCategoriesBooks(string PATH)
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Book>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Book>>(fileText);
            }
        }
        static public void SaveData(object todoDataList,string PATH)
        {
            using (StreamWriter writer = File.CreateText(PATH)) {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
