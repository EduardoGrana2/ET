using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Tecnico.Clases
{
    internal interface Ifunciones
    {
        bool Alta();
        bool Baja();
        bool Actualizar();
        DataTable ConsultaDCF();
        DataTable ConsultaPorSku(string id);

    }
}
