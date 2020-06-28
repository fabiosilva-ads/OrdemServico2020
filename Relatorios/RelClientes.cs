using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdemServico2020.Camadas;

namespace OrdemServico2020.Relatorios
{
    public class RelClientes
    {
        public static void relCliente()
        {
            Camadas.DAL.Clientes bllCliente = new Camadas.DAL.Clientes();
            List<Camadas.MODEL.Clientes> lstClientes = new List<Camadas.MODEL.Clientes>();
            lstClientes = bllCliente.Select();

            string pasta = Funcoes.diretorioPasta();
            string arquivo = pasta + @"\RelClientes_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".html";
            string arquivoPDF = pasta + @"\RelClientes_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".pdf";

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
                sw.WriteLine("<h1>RELATÓRIO DE CLIENTES</h1>");
                sw.WriteLine("<h6> <i>");
                sw.WriteLine("Gerado em " + DateTime.Now.ToString());
                sw.WriteLine("</i></h6>");
                sw.WriteLine("</br>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<table class='table table-striped'>");
                sw.WriteLine("<tr align='center'>");
                sw.WriteLine("<th align='center' width='30px'>");
                sw.WriteLine("ID");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='left' width='150px'>");
                sw.WriteLine("NOME");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='left' width='150px'>");
                sw.WriteLine("ENDERECO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='center' width='150px'>");
                sw.WriteLine("FONE");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;
                foreach (Camadas.MODEL.Clientes cliente in lstClientes.OrderBy(o => o.nome))
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='center' width='30px'>");
                    sw.WriteLine(cliente.idCli);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='150px'>");
                    sw.WriteLine(cliente.nome);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='150px'>");
                    sw.WriteLine(cliente.endereco);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td  align='center' width='150px'>");
                    sw.WriteLine(cliente.fone);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    cont++;
                }

                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h5>");
                sw.WriteLine("Total de Clientes: " + cont.ToString());
                sw.WriteLine("</br>");
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
