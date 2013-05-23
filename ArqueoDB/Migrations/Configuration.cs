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
                    Descricao = "Terraço Museu D. Diogo", 
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
                    Descricao = "Planta das ruínas de troia", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "ruinas_troia_2.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta das ruínas de troia", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "ruinas_paricatuba.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta das ruínas de paricatuba", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "vila_romana.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Planta da vila romana da Quinta de Fórnea", 
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
                    Descricao = "... o Cabido tem por importante função a de zelar por uma correcta interpretação deste Tratado, por forma a que a Praxe seja sempre respeitada, e as suas noções compreendidas e cumpridas. Em todos os casos duvidosos quanto à correcta aplicação da justiça, em qualquer falta cometida pelo Papa, ou em qualquer outra falta de suma importância, será ao Cabido que competirá ajuizar e dar sentença ou conselho...",
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
                    Descricao = "Fácil",
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
                    Descricao = "A Universidade do Minho (UM) foi fundada em Braga em 1973 e integrou-se no chamado grupo das Novas Universidades que vieram alterar o panorama do ensino superior em Portugal. Iniciou as suas actividades académicas em 1975/76. A universidade é governada por uma reitoria, composta por um reitor e um conselho geral, e cinco unidades internas que agrupam por áreas de intervenção as várias entidades internas. Apesar de ser uma Universidade recente, desde o inicio, foi incutida à universidade toda a tradição académica milenar, de origem religiosa, da cidade de Braga, desde os trajes académicos, as festividades do enterro da Gata e o primeiro de Dezembro, e as bibliotecas da cidade.",
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
                    Descricao = "O Museu de Arqueologia D. Diogo de Sousa é um organismo público, dependente da Direção Regional de Cultura do Norte definido na sua Lei orgânica como um museu regional de arqueologia. O Museu foi criado em 1918, como museu de arqueologia e arte geral, como o objectivo de obstar à dispersão do património local até então na posse de particulares e outras instituições. Em 1980, com a sua revitalização a missão do Museu foi redefinida como um organismo científico-cultural no âmbito disciplinar de arqueologia, passando a exercer as suas actividades básicas nos domínios do apoio à investigação, da museologia, da divulgação cultural, do apoio ao ensino e à defesa e preservação do património arqueológico regional.",
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
                    Descricao = "O Teatro romano do Alto da Cividade, em Braga, é o único teatro romano existente no noroeste da Península Ibérica (e o único também que está a ser escavado actualmente em Portugal e Espanha) fica situado junto às Termas romanas de Maximinos, em Braga. A sua descoberta acidental em 1999, quando se procedia a escavações nas termas, levou à descoberta de estruturas que revelaram a existência de um teatro, cujo estado de conservação acabou por exceder todas as expectativas. A área que foi possível escavar até ao momento, com cerca de 80 metros de diâmetro e o número elevado de elementos arquitectónicos e decorativos encontrados, permitiram identificar as diferentes partes orgânicas do teatro. Entre os investigadores é considerada uma descoberta extraordinária, que coloca a cidade de Braga ao mais alto nível europeu em termos de arquitectura romana.",
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
                    Nome = "Estela Funerária III D.C.",
                    Apagado = false,
                    Cordenadas = "20-20-22",
                    DataDescoberta = System.DateTime.Now,
                    Descricao = "Estela de granito, truncada na parte superior e inferior e incompleta no lado esquerdo. A parte superior denota traços de uma decoração feita de uma rosácea circundada por um cordão entrançado.",
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
                    Titulo = "A obra do mestre André",                
                    NomeFicheiro = "mestre_andre.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 3,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Fantástico!",                    
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
                    Descricao = "A versão de hp da robin",                    
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
                    Descricao = "Não há palavras",                    
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
                    Descricao = "As intervenções arqueológicas realizadas em Braga, desde meados da década de setenta, proporcionam um melhor conhecimento da organização da cidade romana de Bracara Augusta. Alguns desses vestígios da ocupação romana foram integrados na malha urbana actual sendo visitáveis."
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now.AddDays(-10),
                    Publico = true,
                    Titulo = "Mosaico in Situ",
                    Descricao = "Durante as escavações arqueológicas, que precederam a construção do edifício do Museu, foram encontrados vestígios de uma habitação do século I, com a particularidade de ter um mosaico. Dada a elevada acidez do solo em Braga, este tipo de achado raramente se preserva, pelo que se procedeu à sua integração nas instalações do Museu, no espaço-cripta do bloco de serviços. O mosaico é constituído por motivos geométricos bicromos (branco e preto). Um dos painéis musivos é constituído por um tabuleiro, em que as casas apresentam cruzeta ao centro, em oposição de cores e o outro é decorado com quadrícula de linhas de ampulhetas, com tesselas de granito e de calcário. Estão em curso trabalhos de restauro."
                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now,
                    Publico = true,
                    Titulo = "A primeira publicação",
                    Descricao = "É com agrado que vimos anunciar a criação da organização da Universidade do Minho na plataforma ArqueoDB. Juntem-se a nós!"
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
                    Titulo = "Serviço Educativo",
                    Descricao = "O Serviço Educativo do Museu D. Diogo de Sousa criou um conjunto de Fichas Informativas que podem ser utilizadas pelo público geral e pelo público escolar, em particular, na preparação, durante a realização ou após a sua visita ao Museu, como complemento da mesma."

                },
                new Publicacao{
                    Apagado = false,
                    DataPublicacao = System.DateTime.Now,
                    Publico = true,
                    Titulo = "Actividade do Museu (1980-2006)",
                    Descricao = "A planificação da actividade do Museu, entre 1980-2006 foi naturalmente condicionada pela inexistência de espaços expositivos abertos ao público, pelo facto do seu quadro de pessoal se ter vindo progressivamente a concentrar e a especializar no sector técnico-laboratorial e ainda, por enquadrar um projecto de arqueologia urbana."

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
            //        Nome = "Ruínas de troia",        
            //        //LocalID = 0,
            //        //Local = locais[0],
            //        ImagemID = 14,  
            //        //Imagem = imagens[0],
            //        OrganizacaoID = 0,  
            //        //Organizacao = organizacoes[0],
            //        ResponsavelID = 0, 
            //        //Responsavel = profissionais[0],
            //        DataPublicacao = System.DateTime.Now,
            //        Descricao = "Planta das ruínas de troia",        
            //        Publico = true,        
            //        Apagado = false
            //    }
            //    //new Planta{
            //    //    Nome = "Segunda planta das Ruínas de troia",        
            //    //    LocalID = 0, 
            //    //    ImagemID = 15,        
            //    //    OrganizacaoID = 0,        
            //    //    ResponsavelID = 0, 
            //    //    DataPublicacao = System.DateTime.Now,
            //    //    Descricao = "Planta das ruínas de troia",        
            //    //    Publico = true,        
            //    //    Apagado = false
            //    //},
            //    //new Planta{
            //    //    Nome = "Ruínas de Paricatuba",        
            //    //    LocalID = 0, 
            //    //    ImagemID = 16,        
            //    //    OrganizacaoID = 0,        
            //    //    ResponsavelID = 0, 
            //    //    DataPublicacao = System.DateTime.Now,
            //    //    Descricao = "Planta das ruínas de Paricatuba",        
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
            //    //    Descricao = "Vila Romana de Quinta de Fórnea",        
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

