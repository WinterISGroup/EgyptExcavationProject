using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Services
{
    public interface IRecordService
    {
        void GetRecord(/*int burialID*/);
        void AddRecord(/*BurialModel newBurial*/);
        void UpdateRecord(/*BurialModel updatedBurial*/);
        void DeleteRecord(/*int burialID*/);
    }
}
