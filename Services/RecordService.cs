using EgyptExcavationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Services
{
    public class RecordService : IRecordService
    {
        private ExcavationProjectContext _context;
        public RecordService(ExcavationProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<Burial> GetAllBurials()
        {
            DateTime jan01 = new DateTime(2021, 01, 01);
            return _context.Burial.Where(b => b.DateFound > jan01 ).OrderBy(b => b.BurialId);
            //return _context.Burial.OrderBy(b => b.BurialId);
        }

        //FIXME: return type change to BurialModel
        public Burial GetRecord(Guid burialID)
        {
            Burial burial = _context.Burial.Where(b => b.BurialId == burialID).FirstOrDefault();
            burial.Location = _context.Location.Where(x => x.LocationId == burial.LocationId).FirstOrDefault();
            return burial;
        }

        public void AddBurial(Burial newBurial)
        {
            //try
            //{
                
            //}
            //catch
            //{
            //    throw new Exception("Error in adding new burial record");
            //}
            _context.Burial.Add(newBurial);
            _context.SaveChanges();

        }

        public void AddLocation(Location location)
        {
            try
            {
                _context.Location.Add(location);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error in adding new location record");
            }
        }

        public void UpdateRecord(Burial updatedBurial)
        {
            Burial burialToUpdate = _context.Burial.Where(b => b.BurialId == updatedBurial.BurialId).FirstOrDefault();
            
            if(updatedBurial.LocationId == null)
            {
                if(burialToUpdate.LocationId != null)
                {
                    updatedBurial.LocationId = burialToUpdate.LocationId;
                }
                else
                {
                    _context.Location.Add(updatedBurial.Location);
                    _context.SaveChanges();
                    updatedBurial.LocationId = updatedBurial.Location.LocationId;
                }
            }

            if(burialToUpdate != null)
            {
                _context.Entry(burialToUpdate).CurrentValues.SetValues(updatedBurial);
            }
            _context.SaveChanges();
        }

        public void DeleteRecord(Guid burialID)
        {
            _context.Remove(_context.Burial.Where(b => b.BurialId == burialID).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
