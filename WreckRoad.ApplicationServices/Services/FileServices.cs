using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;
using WreckRoad.Core.Serviceinterface;
using WreckRoad.Data;


namespace WreckRoad.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly WreckRoadContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                WreckRoadContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(CarDto dto, Car domain)
        {
            if ( dto.Files != null && dto.Files.Count > 0) 
            { 
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            CarID = domain.ID,
                        };

                        image.CopyTo( target );
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add( files );
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImageFromDatabase(FilesToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
