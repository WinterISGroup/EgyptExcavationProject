using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgyptExcavationProject.Models;

namespace EgyptExcavationProject.Services
{
    public interface IRecordService
    {
        Burial GetRecord(Guid burialID);
        void AddRecord(Burial newBurial);
        void UpdateRecord(Burial updatedBurial);
        void DeleteRecord(Guid burialID);
    }
}
