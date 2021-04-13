using EgyptExcavationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Service to handle the bulk of the logic neccessary for the controller in adding records to the database, editing, and deleting
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
            //DateTime jan01 = new DateTime(2021, 01, 01);
            //return _context.Burial.Where(b => b.DateFound > jan01 ).OrderBy(b => b.BurialId);
            return _context.Burial.OrderBy(b => b.BurialId);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Location.OrderBy(l => l.LocationId);
        }

        //FIXME: return type change to BurialModel
        public Burial GetRecord(Guid burialID)
        {
            Burial burial = _context.Burial.Where(b => b.BurialId == burialID).FirstOrDefault();
            burial.Location = _context.Location.Where(x => x.LocationId == burial.LocationId).FirstOrDefault();
            return burial;
        }

        //Function used to calculate the length of the remains based on the coordinates of the head and feet from the south and west border
        public double CalculateLength(double SouthToHead, double WestToHead, double SouthToFeet, double WestToFeet)
        {
            var xpair = Math.Pow(SouthToHead - SouthToFeet, 2);
            var ypair = Math.Pow(WestToHead - WestToFeet, 2);
            var results = Math.Sqrt(xpair + ypair);
            results = Math.Round(results, 2);

            return results;
        }

        //Adds burial to database. Takes all the data from the new burial from the input form, adds the calculated length, and adds to burial context
        public void AddBurial(Burial newBurial)
        {
            try
            {

                newBurial.CalculatedLengthOfRemains = CalculateLength(newBurial.SouthToHead.Value, newBurial.WestToHead.Value,
                                                                      newBurial.SouthToFeet.Value, newBurial.WestToFeet.Value);
                
                _context.Burial.Add(newBurial);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error in adding new burial record");
            }

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

        public void DeleteLocation(Guid locationID)
        {
            _context.Remove(_context.Location.Where(l => l.LocationId == locationID).FirstOrDefault());
            _context.SaveChanges();
        }


        public void SavePhotoUrl(Guid burialID, string url)
        {
            if(url != "" && url != null)
            {
                Burial burial = new Burial { BurialId = burialID, Photo = url };

                _context.Burial.Attach(burial).Property(p => p.Photo).IsModified = true;
                _context.SaveChanges();
            }
        }
    }
}
