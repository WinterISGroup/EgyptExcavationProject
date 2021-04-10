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
            return _context.Burial.OrderBy(b => b.BurialId);
        }

        //FIXME: return type change to BurialModel
        public Burial GetRecord(Guid burialID)
        {
            return _context.Burial.Where(b => b.BurialId == burialID).FirstOrDefault();
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
            _context.Burial.Update(updatedBurial);
            _context.SaveChanges();
        }

        public void DeleteRecord(Guid burialID)
        {
            _context.Remove(_context.Burial.Where(b => b.BurialId == burialID).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
