namespace NetCorePortfolio.Repositories
{
    public interface IResumeRepository
    {
        byte[] TryGetLastestResume();
    }
}