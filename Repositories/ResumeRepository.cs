using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace NetCorePortfolio.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResumeRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] TryGetLatestResume()
        {
            var resumeDirectoryInfo = new DirectoryInfo(Path.Combine(_webHostEnvironment.WebRootPath, "assets/resumes"));
            var lastWrittenPdfPath = resumeDirectoryInfo.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .FirstOrDefault()?.FullName;

            if (!string.IsNullOrWhiteSpace(lastWrittenPdfPath))
            {
                return File.ReadAllBytes(lastWrittenPdfPath);
            }

            return null;
        }
    }
}
