namespace CheckInWpf.Service
{
    public interface IOrderNumberService
    {
        int GetOrderNumber();
        void SetOrderNumber(int orderNo);
    }
}