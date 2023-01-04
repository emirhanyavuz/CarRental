using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {



        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderil mi gönderilmemiş diye test işlemi yapıldı.
            {
                if (!Directory.Exists(root)) //Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
                {                            //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                                             // O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists*ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur


                    Directory.CreateDirectory(root);
                }
                string extenison = Path.GetExtension(file.FileName);  //Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extenison;
                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;

                }

            }
            return null;

        }
    }
}

