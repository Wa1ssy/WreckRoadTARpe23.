using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_Road.Core.Domain;
using Wreck_Road.Core.Domain.Serviceinterface;
using Wreck_RoadContext.Core.Domain;
using Wreck_RoadContext.Core.Domain.Dto;
using Wreck_RoadContext.Data;

namespace Wreck_Road.ApplicationServices.Services
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
