using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArqueoDB.Models;

namespace ArqueoDB.DAL
{
    public class Util
    {
        public static void registarActividadeLocal (Local local, out Dictionary<int, int> documentosMes, out Dictionary<int, int> publicacoesMes, out Dictionary<int, int> imagensMes, out Dictionary<int, int> comentariosMes) {

            documentosMes = new Dictionary<int, int>();
            publicacoesMes = new Dictionary<int, int>();
            comentariosMes = new Dictionary<int, int>();
            imagensMes = new Dictionary<int, int>();

            iniciarDicionarioActividade(documentosMes);
            iniciarDicionarioActividade(publicacoesMes);
            iniciarDicionarioActividade(comentariosMes);
            iniciarDicionarioActividade(imagensMes);

            foreach (Documento doc in local.Documentos) {double diffDias = (System.DateTime.Now - doc.DataPublicacao).TotalDays ;actualizaDicionarioActividade(documentosMes, diffDias);}
            foreach (Publicacao pub in local.Publicacoes) { double diffDias = (System.DateTime.Now - pub.DataPublicacao).TotalDays; actualizaDicionarioActividade(publicacoesMes, diffDias); }
            foreach (Comentario com in local.Comentarios) { double diffDias = (System.DateTime.Now - com.DataPublicacao).TotalDays; actualizaDicionarioActividade(comentariosMes, diffDias); }
            foreach (Imagem img in local.Imagens) { double diffDias = (System.DateTime.Now - img.DataPublicacao).TotalDays; actualizaDicionarioActividade(imagensMes, diffDias); }
        }

        public static void registarActividadeArtefacto(Artefacto art, out Dictionary<int, int> imagensMes, out Dictionary<int, int> comentariosMes)
        {
            comentariosMes = new Dictionary<int, int>();
            imagensMes = new Dictionary<int, int>();

            iniciarDicionarioActividade(comentariosMes);
            iniciarDicionarioActividade(imagensMes);

            foreach (Comentario com in art.Comentarios) { double diffDias = (System.DateTime.Now - com.DataPublicacao).TotalDays; actualizaDicionarioActividade(comentariosMes, diffDias); }
            foreach (Imagem img in art.Imagens) { double diffDias = (System.DateTime.Now - img.DataPublicacao).TotalDays; actualizaDicionarioActividade(imagensMes, diffDias); }
        }

        private static void iniciarDicionarioActividade(Dictionary<int, int> dic)
        {
            dic.Add(0, 0);
            dic.Add(1, 0);
            dic.Add(2, 0);
            dic.Add(3, 0);
            dic.Add(4, 0);
            dic.Add(5, 0);
        }

        private static void actualizaDicionarioActividade(Dictionary<int, int> dic, double diffDias)
        {
            int valor;
            if (diffDias < 30)
            {
                dic.TryGetValue(0, out valor);
                dic.Remove(0);
                dic.Add(0, valor + 1);
            }
            else if (diffDias < 60)
            {
                dic.TryGetValue(1, out valor);
                dic.Remove(1);
                dic.Add(1, valor + 1);
            }
            else if (diffDias < 90)
            {
                dic.TryGetValue(2, out valor);
                dic.Remove(2);
                dic.Add(2, valor + 1);
            }
            else if (diffDias < 120)
            {
                dic.TryGetValue(3, out valor);
                dic.Remove(3);
                dic.Add(3, valor + 1);
            }
            else if (diffDias < 150)
            {
                dic.TryGetValue(4, out valor);
                dic.Remove(4);
                dic.Add(4, valor + 1);
            }
            else if (diffDias < 180)
            {
                dic.TryGetValue(5, out valor);
                dic.Remove(5);
                dic.Add(5, valor + 1);
            }
        }

        public static string determinarLabel(int i)
        {
            switch (i)
            {
                case 0: return "mes actual";
                case 1: return "a 2 meses";
                case 2: return "a 3 meses";
                case 3: return "a 4 meses";
                case 4: return "a 5 meses";
                case 5: return "a 6 meses";
                default: return "";
            }
        }

        public static int getValor(Dictionary<int, int> dic, int chave)
        {
            int res;
            dic.TryGetValue(chave, out res);
            return res;
        }
    }
}