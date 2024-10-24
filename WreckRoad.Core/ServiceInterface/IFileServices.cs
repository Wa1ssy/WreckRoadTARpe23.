using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;

namespace WreckRoad.Core.Serviceinterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);
    }
}
