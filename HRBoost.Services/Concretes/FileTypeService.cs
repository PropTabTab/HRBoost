using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class FileTypeService :BaseServices<FileType>,IFileTypeService
    {
        public FileTypeService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
    }
}
