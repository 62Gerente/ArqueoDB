namespace ArqueoDB.Migrations
{
    using ArqueoDB.Models;
    using ArqueoDB.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArqueoDB.DAL.EntidadesArqueoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

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
                new Directoria{Caminho = "/Images/Locais/"},
                new Directoria{Caminho = "/Images/Artefactos/"},
                new Directoria{Caminho = "/Images/Plantas/"},
                new Directoria{Caminho = "/Documentos/"}
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
                    Descricao = "Imagem Entrada Museu D. Diogo", 
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
                },
                new Imagem{
                    Nome = "barney.png", 
                    DirectoriaID = 2, 
                    Descricao = "Barney Stinson!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "robin.jpg", 
                    DirectoriaID = 2, 
                    Descricao = "A robin!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "estelafuneraria.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Estela", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo1.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Terra�o Museu D. Diogo", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo2.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Interior Museu D. Diogo", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo3.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Museu D. Diogo de Sousa", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo4.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Artefactos Museu D. Diogo", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo5.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Placa da entrada do Museu D. Diogo de Sousa em Braga", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo6.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Imagem do Jardim do Museu D. Diogo", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "ruinas_troia.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta das ru�nas de troia", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "ruinas_troia_2.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta das ru�nas de troia", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "ruinas_paricatuba.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta das ru�nas de paricatuba", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "vila_romana.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta da vila romana da Quinta de F�rnea", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
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
                    Descricao = "... o Cabido tem por importante fun��o a de zelar por uma correcta interpreta��o deste Tratado, por forma a que a Praxe seja sempre respeitada, e as suas no��es compreendidas e cumpridas. Em todos os casos duvidosos quanto � correcta aplica��o da justi�a, em qualquer falta cometida pelo Papa, ou em qualquer outra falta de suma import�ncia, ser� ao Cabido que competir� ajuizar e dar senten�a ou conselho...",
                    Email = "jonas@cabidocardeais.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 5,
                    Sexo = 1,
                    TituloID = 2,
                    UtilizadoresSeguidos = new List<Utilizador>(),
                    Seguidores = new List<Utilizador>(),
                    Comentarios = new List<Comentario>(),
                    Publicacoes = new List<Publicacao>()
                },
                new Utilizador{
                    NomeUtilizador = "Barney",
                    Nome = "Barney Stinson",
                    Password = "playbook",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "F�cil",
                    Email = "barney@hymym.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 6,
                    Sexo = 1,
                    TituloID = 2,
                    UtilizadoresSeguidos = new List<Utilizador>(),
                    Seguidores = new List<Utilizador>(),
                    Comentarios = new List<Comentario>(),
                    Publicacoes = new List<Publicacao>()
                },
                new Utilizador{
                    NomeUtilizador = "Robin",
                    Nome = "Robin Scherbatsky",
                    Password = "single",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "buthum",
                    Email = "robin@hymym.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 7,
                    Sexo = 2,
                    TituloID = 2,
                    UtilizadoresSeguidos = new List<Utilizador>(),
                    Seguidores = new List<Utilizador>(),
                    Comentarios = new List<Comentario>(),
                    Publicacoes = new List<Publicacao>()
                }
            };
            utilizadores.ForEach(u => context.Utilizadores.Add(u));
            context.SaveChanges();

            distritos[0].Utilizadores.Add(utilizadores[0]);
            context.SaveChanges();

            var profissionais = new List<Profissional>
            {
                new Profissional{
                    UtilizadorID = 1,
                    Organizacoes = new List<Organizacao>()
                },
                new Profissional{
                    UtilizadorID = 2,
                    Organizacoes = new List<Organizacao>()
                },
                new Profissional{
                    UtilizadorID = 3,
                    Organizacoes = new List<Organizacao>()
                }
            };
            profissionais.ForEach(p => context.Profissionais.Add(p));
            context.SaveChanges();

            var organizacoes = new List<Organizacao>
            {
                new Organizacao{
                    Nome = "Universidade do Minho",
                    Activa = true, 
                    Apagada = false,
                    Coordenadas = "41.558985,-8.397591",
                    DataFundacao = System.DateTime.Now,
                    Descricao = "A Universidade do Minho (UM) foi fundada em Braga em 1973 e integrou-se no chamado grupo das Novas Universidades que vieram alterar o panorama do ensino superior em Portugal. Iniciou as suas actividades acad�micas em 1975/76. A universidade � governada por uma reitoria, composta por um reitor e um conselho geral, e cinco unidades internas que agrupam por �reas de interven��o as v�rias entidades internas. Apesar de ser uma Universidade recente, desde o inicio, foi incutida � universidade toda a tradi��o acad�mica milenar, de origem religiosa, da cidade de Braga, desde os trajes acad�micos, as festividades do enterro da Gata e o primeiro de Dezembro, e as bibliotecas da cidade.",
                    DistritoID = 1,
                    Email = "um@um.pt",
                    ImagemCapaID = 2,
                    ImagemPerfilID = 1,
                    Morada = "Rua Nova Santa Cruz",
                    ResponsavelID = 1,
                    Publica = true,
                    Membros = new List<Profissional>(),
                    Locais = new List<Local>(),
                    Documentos = new List<Documento>(),
                    Publicacoes = new List<Publicacao>()
                }
            };
            organizacoes.ForEach(o => context.Organizacoes.Add(o));
            context.SaveChanges();

            distritos[0].Organizacoes.Add(organizacoes[0]);
            context.SaveChanges();

            organizacoes[0].Membros.Add(profissionais[0]);
            organizacoes[0].Membros.Add(profissionais[1]);
            organizacoes[0].Membros.Add(profissionais[2]);
            context.SaveChanges();

            profissionais[0].Organizacoes.Add(organizacoes[0]);
            profissionais[1].Organizacoes.Add(organizacoes[0]);
            profissionais[2].Organizacoes.Add(organizacoes[0]);
            context.SaveChanges();

            var locais = new List<Local>
            {
                new Local{
                    Nome = "Museu D. Diogo de Sousa",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "41.546283, -8.427632",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Museu de Arqueologia D. Diogo de Sousa � um organismo p�blico, dependente da Dire��o Regional de Cultura do Norte definido na sua Lei org�nica como um museu regional de arqueologia. O Museu foi criado em 1918, como museu de arqueologia e arte geral, como o objectivo de obstar � dispers�o do patrim�nio local at� ent�o na posse de particulares e outras institui��es. Em 1980, com a sua revitaliza��o a miss�o do Museu foi redefinida como um organismo cient�fico-cultural no �mbito disciplinar de arqueologia, passando a exercer as suas actividades b�sicas nos dom�nios do apoio � investiga��o, da museologia, da divulga��o cultural, do apoio ao ensino e � defesa e preserva��o do patrim�nio arqueol�gico regional.",
                    Publico = true,
                    Imagens = new List<Imagem>(),
                    Artefactos = new List<Artefacto>(),
                    Documentos = new List<Documento>(),
                    Seguidores = new List<Utilizador>(),
                    Comentarios = new List<Comentario>(),
                    Publicacoes = new List<Publicacao>(),
                    Plantas = new List<Planta>()
                },
                new Local{
                    Nome = "Teatro Romano",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "41.546711, -8.430314",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Teatro romano do Alto da Cividade, em Braga, � o �nico teatro romano existente no noroeste da Pen�nsula Ib�rica (e o �nico tamb�m que est� a ser escavado actualmente em Portugal e Espanha) fica situado junto �s Termas romanas de Maximinos, em Braga. A sua descoberta acidental em 1999, quando se procedia a escava��es nas termas, levou � descoberta de estruturas que revelaram a exist�ncia de um teatro, cujo estado de conserva��o acabou por exceder todas as expectativas. A �rea que foi poss�vel escavar at� ao momento, com cerca de 80 metros de di�metro e o n�mero elevado de elementos arquitect�nicos e decorativos encontrados, permitiram identificar as diferentes partes org�nicas do teatro. Entre os investigadores � considerada uma descoberta extraordin�ria, que coloca a cidade de Braga ao mais alto n�vel europeu em termos de arquitectura romana.",
                    Publico = true,
                    Imagens = new List<Imagem>(),
                    Artefactos = new List<Artefacto>(),
                    Documentos = new List<Documento>(),
                    Seguidores = new List<Utilizador>(),
                    Comentarios = new List<Comentario>(),
                    Publicacoes = new List<Publicacao>(),
                    Plantas = new List<Planta>()
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
            locais[0].Imagens.Add(imagens[8]);
            locais[0].Imagens.Add(imagens[9]);
            locais[0].Imagens.Add(imagens[10]);
            locais[0].Imagens.Add(imagens[11]);
            locais[0].Imagens.Add(imagens[12]);
            locais[0].Imagens.Add(imagens[13]);
            locais[1].Imagens.Add(imagens[3]);
            context.SaveChanges();

            imagens[7].AutorID = 1;
            imagens[8].AutorID = 1;
            imagens[9].AutorID = 1;
            imagens[10].AutorID = 1;
            imagens[11].AutorID = 1;
            imagens[12].AutorID = 1;
            imagens[13].AutorID = 1;
            context.SaveChanges();

            var artefactos = new List<Artefacto>
            {
                new Artefacto{
                    Nome = "Estela Funer�ria III D.C.",
                    Apagado = false,
                    Cordenadas = "20-20-22",
                    DataDescoberta = System.DateTime.Now,
                    Descricao = "Estela de granito, truncada na parte superior e inferior e incompleta no lado esquerdo. A parte superior denota tra�os de uma decora��o feita de uma ros�cea circundada por um cord�o entran�ado.",
                    Imagens = new List<Imagem>(),
                    LocalID = 1,
                    OrganizacaoID = 1,
                    Publico = true,
                    ResponsavelID = 1
                }
            };
            artefactos.ForEach(a => context.Artefactos.Add(a));
            context.SaveChanges();

            locais[0].Artefactos.Add(artefactos[0]);
            context.SaveChanges();

            artefactos[0].Imagens.Add(imagens[7]);
            context.SaveChanges();

            var documentos = new List<Documento>
            {
                new Documento{
                    Titulo = "The Playbook",                
                    NomeFicheiro = "playbook.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 2,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Peace and love!",                    
                    Publico = true,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "A obra do mestre Andr�",                
                    NomeFicheiro = "mestre_andre.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 3,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Fant�stico!",                    
                    Publico = false,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "Harry Poter",                
                    NomeFicheiro = "documento.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 3,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "A vers�o de hp da robin",                    
                    Publico = true,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "Jonas, Quando for grande quero ser como tu!",                
                    NomeFicheiro = "documento.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 1,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "N�o h� palavras",                    
                    Publico = false,        
                    Apagado = false
                }
            };

            documentos.ForEach(d => context.Documentos.Add(d));
            context.SaveChanges();

            organizacoes[0].Documentos.Add(documentos[0]);
            organizacoes[0].Documentos.Add(documentos[1]);
            context.SaveChanges();

            documentos.ForEach(d => locais[0].Documentos.Add(d));
            context.SaveChanges();

            var comentarios = new List<Comentario>()
            {
                new Comentario{
                    Texto="Excelentes fotografias do Museu D. Diogo, Obrigado",
                    AutorID = 3,
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now
                },
                new Comentario{
                    Texto="Obrigado pelas fotografias",
                    AutorID = 2,
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now
                },
                new Comentario{
                    Texto="Para quando as novas fotografias dos artefactos do museu?",
                    AutorID = 3,
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now
                },
                new Comentario{
                    Texto="Jonas te saluto!",
                    AutorID = 2,
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now
                },
            };
            //comentarios.ForEach(c => utilizadores[0].Comentarios.Add(c));
            //context.SaveChanges();

            var publicacoes = new List<Publicacao>()
            {
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now.AddHours(-2),
                    Publico = true,
                    Titulo = "Bracara Augusta",
                    Descricao = "As interven��es arqueol�gicas realizadas em Braga, desde meados da d�cada de setenta, proporcionam um melhor conhecimento da organiza��o da cidade romana de Bracara Augusta. Alguns desses vest�gios da ocupa��o romana foram integrados na malha urbana actual sendo visit�veis."
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now.AddDays(-10),
                    Publico = true,
                    Titulo = "Mosaico in Situ",
                    Descricao = "Durante as escava��es arqueol�gicas, que precederam a constru��o do edif�cio do Museu, foram encontrados vest�gios de uma habita��o do s�culo I, com a particularidade de ter um mosaico. Dada a elevada acidez do solo em Braga, este tipo de achado raramente se preserva, pelo que se procedeu � sua integra��o nas instala��es do Museu, no espa�o-cripta do bloco de servi�os. O mosaico � constitu�do por motivos geom�tricos bicromos (branco e preto). Um dos pain�is musivos � constitu�do por um tabuleiro, em que as casas apresentam cruzeta ao centro, em oposi��o de cores e o outro � decorado com quadr�cula de linhas de ampulhetas, com tesselas de granito e de calc�rio. Est�o em curso trabalhos de restauro."
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now,
                    Publico = true,
                    Titulo = "A primeira publica��o",
                    Descricao = "� com agrado que vimos anunciar a cria��o da organiza��o da Universidade do Minho na plataforma ArqueoDB. Juntem-se a n�s!"
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now.AddMinutes(-15),
                    Publico = true,
                    Titulo = "O Museu",
                    Descricao = "De passagem, venha ver o novo futuro que demos ao passado."
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now,
                    Publico = true,
                    Titulo = "Servi�o Educativo",
                    Descricao = "O Servi�o Educativo do Museu D. Diogo de Sousa criou um conjunto de Fichas Informativas que podem ser utilizadas pelo p�blico geral e pelo p�blico escolar, em particular, na prepara��o, durante a realiza��o ou ap�s a sua visita ao Museu, como complemento da mesma."

                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now,
                    Publico = true,
                    Titulo = "Actividade do Museu (1980-2006)",
                    Descricao = "A planifica��o da actividade do Museu, entre 1980-2006 foi naturalmente condicionada pela inexist�ncia de espa�os expositivos abertos ao p�blico, pelo facto do seu quadro de pessoal se ter vindo progressivamente a concentrar e a especializar no sector t�cnico-laboratorial e ainda, por enquadrar um projecto de arqueologia urbana."

                }
            };
            publicacoes.ForEach(c => utilizadores[0].Publicacoes.Add(c));
            context.SaveChanges();

            publicacoes.ForEach(c => organizacoes[0].Publicacoes.Add(c));
            locais[0].Publicacoes.Add(publicacoes[3]);
            locais[0].Publicacoes.Add(publicacoes[4]);
            locais[0].Publicacoes.Add(publicacoes[5]);
            context.SaveChanges();

            //var plantas = new List<Planta>() {
                
            //    new Planta{
            //        Nome = "Ru�nas de troia",        
            //        //LocalID = 0,
            //        //Local = locais[0],
            //        ImagemID = 14,  
            //        //Imagem = imagens[0],
            //        OrganizacaoID = 0,  
            //        //Organizacao = organizacoes[0],
            //        ResponsavelID = 0, 
            //        //Responsavel = profissionais[0],
            //        DataPublicacao = System.DateTime.Now,
            //        Descricao = "Planta das ru�nas de troia",        
            //        Publico = true,        
            //        Apagado = false
            //    }
            //    //new Planta{
            //    //    Nome = "Segunda planta das Ru�nas de troia",        
            //    //    LocalID = 0, 
            //    //    ImagemID = 15,        
            //    //    OrganizacaoID = 0,        
            //    //    ResponsavelID = 0, 
            //    //    DataPublicacao = System.DateTime.Now,
            //    //    Descricao = "Planta das ru�nas de troia",        
            //    //    Publico = true,        
            //    //    Apagado = false
            //    //},
            //    //new Planta{
            //    //    Nome = "Ru�nas de Paricatuba",        
            //    //    LocalID = 0, 
            //    //    ImagemID = 16,        
            //    //    OrganizacaoID = 0,        
            //    //    ResponsavelID = 0, 
            //    //    DataPublicacao = System.DateTime.Now,
            //    //    Descricao = "Planta das ru�nas de Paricatuba",        
            //    //    Publico = true,        
            //    //    Apagado = false
            //    //},
            //    //new Planta{
            //    //    Nome = "Vila Romana",        
            //    //    LocalID = 0, 
            //    //    ImagemID = 17,        
            //    //    OrganizacaoID = 0,        
            //    //    ResponsavelID = 0, 
            //    //    DataPublicacao = System.DateTime.Now,
            //    //    Descricao = "Vila Romana de Quinta de F�rnea",        
            //    //    Publico = true,        
            //    //    Apagado = false
            //    //}
            //};

            //plantas.ForEach(p => context.Plantas.Add(p));
            //plantas.ForEach(p => locais[0].Plantas.Add(p));
            //context.Plantas
            //context.SaveChanges();
        }

    }
}

