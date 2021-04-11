using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgyptExcavationProject.Models;

namespace EgyptExcavationProject.Services
{
    public interface IRecordService
    {
        IEnumerable<Burial> GetAllBurials();
        Burial GetRecord(Guid burialID);
        void AddBurial(Burial newBurial);
        void AddLocation(Location location);
        void UpdateRecord(Burial updatedBurial);
        void DeleteRecord(Guid burialID);
        void DeleteLocation(Guid locationID);
    }
}
