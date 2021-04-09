using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Services
{
    public class RecordService : IRecordService
    {
        public RecordService(/*bring in DB Context*/)
        {
            //bring in DB Context
        }

        //FIXME: return type change to BurialModel
        public void GetRecord(/*int burialID*/)
        {
            //return DBContext.Burials.Where(b => b.burialID == burialID).FirstOrDefault();
        }

        public void AddRecord(/*BurialModel newBurial*/)
        {
            //DBContext.Add(newBurial)
            //DBContext.SaveChanges()
        }

        public void UpdateRecord(/*BurialModel updatedBurial*/)
        {
            //DBContext.Update(updatedBurial)
            //DBContext.SaveChanges()
        }

        public void DeleteRecord(/*int burialID*/)
        {
            //DBContext.Remove(DBContext.Burials.Where(x => x.burialID == burialID).FirstOrDefault())
            //DBContext.SaveChanges();
        }
    }
}
