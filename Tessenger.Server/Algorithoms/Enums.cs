namespace Tessenger.Server.Algorithoms
{
   public enum RequestType
    {
        Send,
        Receive,
        None
    }
    public enum RequestStatus
    {
        Pending,
        Accepted,
        Rejected,
        Blocked,
        None
    }
}
