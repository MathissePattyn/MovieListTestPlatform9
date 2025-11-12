using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services.Interfaces
{
    public interface IDataPersistanceService
    {
        Task SaveDataAsync();
        Task LoadDataAsync();
    }
}
