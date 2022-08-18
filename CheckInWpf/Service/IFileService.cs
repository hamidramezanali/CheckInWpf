using CheckInWpf.ViewModel;
using System.Collections.Generic;

namespace CheckInWpf.Service
{
    public interface IFileService
    {
        void InitializeFiles();
        T Read<T>();
        void Write<T>(T toBeSerialized);

        bool SaveProjectAsEXCEL(IEnumerable<CheckInWrapper> checkInWrappers);
    }
}