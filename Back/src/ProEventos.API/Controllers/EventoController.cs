﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Lote = "1ª",
                ImageURL = "Foto1.png"
            },
            new Evento() {
                EventoId = 2,
                Tema = "Angular",
                Local = "São Paulo",
                QtdPessoas = 300,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                Lote = "2ª",
                ImageURL = "Foto2.png"
            }
        };

        public EventoController(ILogger<EventoController> logger)
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(Evento => Evento.EventoId == id);
        }


    }
}

