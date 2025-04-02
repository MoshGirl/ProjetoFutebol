﻿using ProjetoFutebol.Dominio.DTOs;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFutebol.Aplicacao.Servicos.EntidadesService
{
    public class PaisService : IPaisService
    {
        public PaisService()
        {

        }

        public List<Pais> ConverterAreasParaPaises(AreasDTO areasDto)
        {
            if (areasDto == null || areasDto.areas == null)
                return new List<Pais>();

            return areasDto.areas
                .Where(a => !string.IsNullOrEmpty(a.name) && !string.IsNullOrEmpty(a.countryCode))
                .Select(a => new Pais
                {
                    PaisID = a.id,
                    NomePais = a.name,
                    CodigoPais = a.countryCode
                }).ToList();
        }
    }
}
