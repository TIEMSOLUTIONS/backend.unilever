using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Controllers.CalculosAuxliares
{
    public class TurnoActual
    {
        public string TurnoActualSystema()
        {

            // CODIGO PARA GUARDAR EL TURNO AUTIMATICAMENTE EN EL SISTEMA

            //fecha para turno 3
            DateTime fechaT3 = DateTime.Now.AddDays(1);
            string fechaSysetemaT3 = fechaT3.ToShortDateString();
            DateTime fechaActualT3 = Convert.ToDateTime(fechaSysetemaT3);
            // fecha para turno 1,2
            DateTime fechasys = DateTime.Now;
            string fechaSysetema = fechasys.ToShortDateString();
            DateTime fechaActual = Convert.ToDateTime(fechaSysetema);
            // horas de los turno 1
            DateTime horaT1ini = Convert.ToDateTime("06:00:00");
            DateTime horaT1fin = Convert.ToDateTime("14:00:00");
            // horas de los turno 2
            DateTime horaT2ini = Convert.ToDateTime("14:00:00");
            DateTime horaT2fin = Convert.ToDateTime("22:00:00");
            // horas de los turno 3
            DateTime horaT3ini = Convert.ToDateTime("22:00:00");
            DateTime horaT3fin = Convert.ToDateTime("00:00:00");
            //aux
            DateTime horaT3auxini = Convert.ToDateTime("00:00:00");
            DateTime horaT3auxfin = Convert.ToDateTime("06:00:00");


            // conversion final turno 1
            DateTime fechaConvertidaT1inicio = fechaActual.AddHours(horaT1ini.Hour).AddMinutes(horaT1ini.Minute).AddSeconds(horaT1ini.Second);
            DateTime fechaConvertidaT1fin = fechaActual.AddHours(horaT1fin.Hour).AddMinutes(horaT1fin.Minute).AddSeconds(horaT1fin.Second);
            // conversion final turno 2
            DateTime fechaConvertidaT2inicio = fechaActual.AddHours(horaT2ini.Hour).AddMinutes(horaT2ini.Minute).AddSeconds(horaT2ini.Second);
            DateTime fechaConvertidaT2fin = fechaActual.AddHours(horaT2fin.Hour).AddMinutes(horaT2fin.Minute).AddSeconds(horaT2fin.Second);
            // conversion final turno 3
            DateTime fechaConvertidaT3inicio = fechaActual.AddHours(horaT3ini.Hour).AddMinutes(horaT3ini.Minute).AddSeconds(horaT3ini.Second);
            DateTime fechaConvertidaT3fin = fechaActual.AddHours(horaT3fin.Hour).AddMinutes(horaT3fin.Minute).AddSeconds(horaT3fin.Second);
            // aux
            DateTime fechaConvertidaT3auxinicio = fechaActual.AddHours(horaT3auxini.Hour).AddMinutes(horaT3auxini.Minute).AddSeconds(horaT3auxini.Second);
            DateTime fechaConvertidaT3auxfin = fechaActual.AddHours(horaT3auxfin.Hour).AddMinutes(horaT3auxfin.Minute).AddSeconds(horaT3auxfin.Second);




            string turno;

            if (fechasys > fechaConvertidaT1inicio && fechasys < fechaConvertidaT1fin)
            {
                turno = "T1";

            }
            else if (fechasys > fechaConvertidaT2inicio && fechasys < fechaConvertidaT2fin)
            {
                turno = "T2";

            }
            else if (fechasys > fechaConvertidaT3inicio && fechasys < fechaConvertidaT3fin)
            {
                turno = "T3";

            }
            else if (fechasys > fechaConvertidaT3auxinicio && fechasys < fechaConvertidaT3auxfin)
            {
                turno = "T3";

            }
            else
            {
                turno = ("Na");

            }
            return turno;
            //return System.Convert.ToString(fechaConvertida);



        }
    }
}
