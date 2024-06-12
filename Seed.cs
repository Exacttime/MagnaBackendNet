﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagnaBackendNet.domain.models;

namespace MagnaBackendNet
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.UsuarioMangas.Any())
            {
                var UsuarioMangas = new List<UsuarioManga>()
                {
                    new UsuarioManga()
                    {
                        Manga = new Manga()
                        {
                            Title = "Pikachu",
                            Chapter = 1,
                            Description = "teste",
                            ImageUrl = "Random",
                        },
                        Usuario = new Usuario()
                        {
                            username = "erc",
                            password = "teste",
                            email = "teste@hotmail.com",
                        }
                    },
                    new UsuarioManga()
                         {
                        Manga = new Manga()
                        {
                            Title = "loco",
                            Chapter = 1,
                            Description = "loco",
                            ImageUrl = "Random",
                        },
                        Usuario = new Usuario()
                        {
                            username = "loco",
                            password = "loco",
                            email = "teste@hotmail.com",
                        }
                    }
                };
                dataContext.UsuarioMangas.AddRange(UsuarioMangas);
                dataContext.SaveChanges();
            }
        }
    }
}
