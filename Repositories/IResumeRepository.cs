namespace NetCorePortfolio.Repositories
{
    public interface IResumeRepository
    {
        byte[] TryGetLatestResume();
    }
}