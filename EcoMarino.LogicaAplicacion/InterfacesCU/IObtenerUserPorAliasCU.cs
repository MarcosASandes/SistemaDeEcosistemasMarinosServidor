﻿using EcoMarino.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.InterfacesCU
{
    public interface IObtenerUserPorAliasCU
    {
        public UsuarioDTO getUserPorAlias(string alias);
    }
}
