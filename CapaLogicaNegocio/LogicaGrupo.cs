﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;

namespace CapaLogicaNegocio
{
  public  class LogicaGrupo
    {
        public static List<EntidadGrupo> ListGrupo()
        {
            return DatosGrupo.ListGrupo();
        }
    }
}
