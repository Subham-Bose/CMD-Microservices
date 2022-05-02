using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.CustomException.Appointments
{
    public class AppointmentDatetimeException : ApplicationException
    {
        public AppointmentDatetimeException(string msg= "Cannot book appointment on previous date and time"): base(msg) { }
    }
}
