using HRBoost.ContextDb.Abstract;
using HRBoost.Entity;
using HRBoost.Services.Abstracts;
using HRBoost.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Concretes
{
    public class DocumentService : BaseServices<Document>, IDocumentService
    {
        public DocumentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
