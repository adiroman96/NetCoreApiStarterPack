using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMedicalInformationService : IBaseService<MedicalInformation>
    {
        /// <summary>
        /// Some method specific to MedicalInformationService
        /// </summary>
        /// <returns></returns>
        public int GetSomePersonalizedResult();
    }


    public class MedicalInformationService : BaseService<MedicalInformation>, IMedicalInformationService
    {
        public MedicalInformationService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MedicalInformation> AddAsync(MedicalInformation obj)
        {
            // adauga medical information
            var x = await _dataContext.AddAsync(obj);
            /*
             * Example of addin Parent + child table
             * 
             *   var acc = await _acountService.AddAsync(new Account() { Username = "asd" });
             *   acc.MedicalInformations.Add(med);
             * 
             */

            // adauge fisierele
            // ....

            // salveaza toate operatiunile (Unit Of Work)
            var result = await _dataContext.SaveChangesAsync();
            if (result < 0)
            {
                return null; // daca result e <0, au aparut probleme si nu s-a salvat.
            }

            return x.Entity;
        }


        public int GetSomePersonalizedResult()
        {
            return 101;
        }
    }
}
