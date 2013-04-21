﻿using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArqueoDB.DAL
{
    public class DadosTeste : DropCreateDatabaseIfModelChanges<EntidadesArqueoDB>
    {
        protected override void Seed(EntidadesArqueoDB context)
        {
            var titulos = new List<Titulo>
            {
                new Titulo{Nome = "Senhor(a) Engenheiro"},
                new Titulo{Nome = "Senhor(a)"}
            };
            titulos.ForEach(t => context.Titulos.Add(t));
            context.SaveChanges();

            var directorias = new List<Directoria>
            {
                new Directoria{Caminho = "/Images/Organizacoes/"},
                new Directoria{Caminho = "/Images/Utilizadores/"},
                new Directoria{Caminho = "/Images/Locais/"}
            };
            directorias.ForEach(d => context.Directorias.Add(d));
            context.SaveChanges();

            var imagens = new List<Imagem>
            {
                new Imagem{
                    Nome = "um.jpg", 
                    DirectoriaID = 1, 
                    Descricao = "Imagem perfil UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "um60.jpeg", 
                    DirectoriaID = 1, 
                    Descricao = "Imagem capa UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Imagem Museu", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "teatro.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Imagem Teatro UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "jonas.jpg", 
                    DirectoriaID = 2, 
                    Descricao = "Jonas lindo!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                }
            };
            imagens.ForEach(i => context.Imagens.Add(i));
            context.SaveChanges();

            var paises = new List<Pais>
            {
                new Pais{
                    Nome = "Portugal", 
                    Distritos = new List<Distrito>()
                }
            };
            paises.ForEach(p => context.Paises.Add(p));
            context.SaveChanges();

            var distritos = new List<Distrito>
            {
                new Distrito{
                    Nome = "Braga", 
                    PaisID = 1, 
                    Utilizadores = new List<Utilizador>(),
                    Organizacoes = new List<Organizacao>(),
                    Locais = new List<Local>()
                }
            };
            distritos.ForEach(d => context.Distritos.Add(d));
            context.SaveChanges();

            paises[0].Distritos.Add(distritos[0]);
            context.SaveChanges();

            var utilizadores = new List<Utilizador>
            {
                new Utilizador{
                    NomeUtilizador = "Jonas",
                    Nome = "Jonas Pinto",
                    Password = "papatesaluto",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "Admite lá esse cansaço",
                    Email = "jonas@cabidocardeais.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 5,
                    Sexo = 1,
                    TituloID = 2
                }
            };
            utilizadores.ForEach(u => context.Utilizadores.Add(u));
            context.SaveChanges();

            distritos[0].Utilizadores.Add(utilizadores[0]);
            context.SaveChanges();

            var profissionais = new List<Profissional>
            {
                new Profissional{UtilizadorID = 1}
            };
            profissionais.ForEach(p => context.Profissionais.Add(p));
            context.SaveChanges();

            var organizacoes = new List<Organizacao>
            {
                new Organizacao{
                    Nome = "Universidade do Minho",
                    Activa = true, 
                    Apagada = false,
                    Coordenadas = "30-60-20",
                    DataFundacao = System.DateTime.Now,
                    Descricao = "A Universidade do Minho (UM) foi fundada em Braga em 1973 e integrou-se no chamado grupo das Novas Universidades que vieram alterar o panorama do ensino superior em Portugal. Iniciou as suas actividades académicas em 1975/76.",
                    DistritoID = 1,
                    Email = "um@um.pt",
                    ImagemCapaID = 2,
                    ImagemPerfilID = 1,
                    Morada = "Rua Nova Santa Cruz",
                    ResponsavelID = 1,
                    Publica = true,
                    Membros = new List<Profissional>(),
                    Locais = new List<Local>()
                }
            };
            organizacoes.ForEach(o => context.Organizacoes.Add(o));
            context.SaveChanges();

            distritos[0].Organizacoes.Add(organizacoes[0]);
            context.SaveChanges();

            organizacoes[0].Membros.Add(profissionais[0]);
            context.SaveChanges();

            var locais = new List<Local>
            {
                new Local{
                    Nome = "Museu D. Diogo de Sousa",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "30-30-50",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Museu de Arqueologia D. Diogo de Sousa é um organismo público, dependente da Direção Regional de Cultura do Norte definido na sua Lei orgânica como um museu regional de arqueologia.",
                    Publico = true,
                    Imagens = new List<Imagem>()
                },
                new Local{
                    Nome = "Teatro Romano",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "50-90-10",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Teatro romano do Alto da Cividade, em Braga, é o único teatro romano existente no noroeste da Península Ibérica (e o único também que está a ser escavado actualmente em Portugal e Espanha) fica situado junto às Termas romanas de Maximinos, em Braga.",
                    Publico = true,
                    Imagens = new List<Imagem>()
                },
            };
            locais.ForEach(l => context.Locais.Add(l));
            context.SaveChanges();

            distritos[0].Locais.Add(locais[0]);
            distritos[0].Locais.Add(locais[1]);
            context.SaveChanges();

            organizacoes[0].Locais.Add(locais[0]);
            organizacoes[0].Locais.Add(locais[1]);
            context.SaveChanges();

            locais[0].Imagens.Add(imagens[2]);
            locais[1].Imagens.Add(imagens[3]);
            context.SaveChanges();
        }
    }
}