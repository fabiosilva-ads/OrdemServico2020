using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdemServico2020.Camadas;

namespace OrdemServico2020.Relatorios
{
    public class RelOrdens
    {
        public static void relOrdem()
        {
            Camadas.BLL.Ordens bllOrdem = new Camadas.BLL.Ordens();
            List<Camadas.MODEL.Ordens> lstOrdens = new List<Camadas.MODEL.Ordens>();
            lstOrdens = bllOrdem.Select();

            string pasta = Funcoes.diretorioPasta();
            string arquivo = pasta + @"\RelOrdens_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".html";
            string arquivoPDF = pasta + @"\RelOrdens_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".pdf";

            StreamWriter sw = new StreamWriter(arquivo);
            using (sw)
            {
                sw.WriteLine("<html>");

                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' " +
                            "content='text/html; charset=utf-8'/>");
                sw.WriteLine("<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>");
                sw.WriteLine("</head>");

                sw.WriteLine("<body>");
                sw.WriteLine("<h1>RELATÓRIO DE ORDEM DE SERVIÇO</h1>");
                sw.WriteLine("<h6> <i>");
                sw.WriteLine("Gerado em " + DateTime.Now.ToString());
                sw.WriteLine("</i></h6>");
                sw.WriteLine("</br>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<table class='table table-striped'>");
                sw.WriteLine("<tr align='right'>");
                sw.WriteLine("<th align='center' width='50px'>");
                sw.WriteLine("ORDEM Nº");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='center' width='100px'>");
                sw.WriteLine("CLIENTE");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='center' width='100px'>");
                sw.WriteLine("EQUIPAMENTO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='center' width='100px'>");
                sw.WriteLine("DEFEITO");
                sw.WriteLine("</th>");               
                sw.WriteLine("<th  align='center' width='100px'>");
                sw.WriteLine("VALOR");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='center' width='50px'>");
                sw.WriteLine("SITUAÇÃO");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;
                float soma = 0;
                foreach (Camadas.MODEL.Ordens ordem in lstOrdens.OrderBy(o => o.idOrd))
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='center' width='50px'>");
                    sw.WriteLine(ordem.idOrd);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='center' width='100px'>");
                    sw.WriteLine(ordem.nomeCli);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='center' width='100px'>");
                    sw.WriteLine(ordem.equipamento);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='center' width='100px'>");
                    sw.WriteLine(ordem.defeito);
                    sw.WriteLine("</td>");                    
                    sw.WriteLine("<td  align='right' width='100px'>");
                    sw.WriteLine(string.Format("{0:C2}", ordem.valor));
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='center' width='50px'>");
                    sw.WriteLine(ordem.situacao);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    soma = soma + ordem.valor;
                    cont++;
                }

                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h5>");
                sw.WriteLine("Total de Registros: " + cont.ToString());
                sw.WriteLine("</br>");
                sw.WriteLine("Valor Total dos Registros: " + string.Format("{0:C2}", soma));
                sw.WriteLine("</h5>");
                sw.WriteLine("</body>");

                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arquivo);

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            htmlToPdf.CustomWkHtmlArgs = "--dpi 300";
            htmlToPdf.GeneratePdfFromFile(arquivo, null, arquivoPDF);
        }
    }
}
