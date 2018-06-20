using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MulhouseHabitat.Models;
using System.ComponentModel.DataAnnotations;


namespace MulhouseHabitat.Models
{
    public class Dal : IDisposable
    {
        public BddContext dbContext;

        public Dal()
        {
            dbContext = new BddContext();
        }

        public void Dispose()
        {
            dbContext.Dispose();

        }
        #region CRU
        public void GetLogement(int _id)
        {
            dbContext.Logements.FirstOrDefault(x => (x.Id == _id));
        }

        public void AddLogement(MHLogements _logement)
        {
            dbContext.Logements.Add(_logement);

            dbContext.SaveChanges();
        }

        public void UpdateLogement(MHLogements _logement)
        {

            MHLogements exist = dbContext.Logements.FirstOrDefault(x => (x.Id == _logement.Id));

            if (exist != default(MHLogements))
            {
                exist.Id = _logement.Id;
                exist.Type = _logement.Type;
                exist.StreetNumber = _logement.StreetNumber;
                exist.StreetName = _logement.StreetName;
                exist.PostalCode = _logement.PostalCode;
                exist.City = _logement.City;
                exist.NumberOfPieces = _logement.NumberOfPieces;
                exist.Size = _logement.Size;
                exist.Rented = _logement.Rented;

                dbContext.SaveChanges();
            }

           

            

        }

        internal MHLogements GetLogement(MHLogements id)
        {
            throw new NotImplementedException();
        }

        public List<MHLogements> GetLogements()
        {
            return dbContext.Logements.ToList();
        }


        #endregion 


    }
}