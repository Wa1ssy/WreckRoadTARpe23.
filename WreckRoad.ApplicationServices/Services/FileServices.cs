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
    }
}
