using CMD.DTO.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business.Appointments.Interfaces
{
    public interface IVitalService
    {
        ICollection<VitalDTO> GetAllVitalsDTO();
        VitalDTO GetVitalDTOByVitalId(int vital_id);
        VitalDTO UpdateVital(VitalDTO v);
    }
}
