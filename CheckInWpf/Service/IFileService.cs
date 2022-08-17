namespace CheckInWpf.Service
{
    internal interface IFileService
    {
        void InitializeFiles();
        T Read<T>();
        void Write<T>(T toBeSerialized);
    }
}