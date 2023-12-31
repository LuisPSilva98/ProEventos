﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
       private readonly DataContext _context;

        public EventosController(DataContext context)
        {
           _context = context;
        }


        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(Evento => Evento.EventoId == id);
        }

        [HttpPut("{id}")]
        public void UpdateById(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(Evento => Evento.EventoId == id);
            if(evento is not null){
                _context.Eventos.Update(evento);
            }
        }

    }
}

