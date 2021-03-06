using Entidades.Exceptions;
using Files.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Entidades.Bitacora;

namespace Entidades.Reportes
{
    public delegate void InformeRealizado(int estado);
    public delegate void ErrorInforme(SavePdfException ex);

    public class FabricaReporte
    {
        public event InformeRealizado ActualizacionInforme;
        public event ErrorInforme EnviarErrorInforme;
        private Fabrica fabrica;
        private string path;
        private Logger logger;

        public FabricaReporte(Fabrica fabrica, string path, Logger logger)
        {
            this.fabrica = fabrica;
            this.path = path;
            this.logger = logger;
        }

        /// <summary>
        /// Método encargado de crear en un archivo PDF válido en el directorio proporcionado y extraer la información que obtiene cada atributo
        /// de la clase fábrica.
        /// Incluye conceptos de la clase 19 Archivos
        /// </summary>
        /// <param name="path">ruta que incluye el nombre del archivo pdf a crear</param>
        /// <param name="fabrica"></param>
        public void CrearReporte()
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                Document doc = new Document(PageSize.LETTER, 10, 10, 14, 14);
                PdfWriter PW = PdfWriter.GetInstance(doc, fs);

                List<Insumo> stockInsumos = fabrica.ServicioInsumo.GetAll();


                doc.Open();
                doc.AddAuthor("Marcos Seghesio");
                doc.AddTitle("Reporte");

                Paragraph parrafoTitulo = new Paragraph();
                //Fuente
                Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                doc.Add(new Paragraph($"Reporte de Fábrica del {DateTime.Now}"));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);


                if (fabrica.ServicioProducto.GetAllProductosLineaProduccion().Count > 0)
                {

                    doc.Add(new Paragraph("Informe linea de Producción"));
                    doc.Add(Chunk.NEWLINE);
                    PdfPTable tblLineaProduccion = crearTablaProductos(fabrica.ServicioProducto.GetAllProductosLineaProduccion(), standarFont, true);
                    doc.Add(tblLineaProduccion);
                }
                else
                {
                    doc.Add(new Paragraph("Informe linea de Producción: no productos en Linea de Producción"));
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                if (fabrica.ServicioProducto.GetAllByEstado(EEstado.Completo).Count > 0)
                {
                    doc.Add(new Paragraph("Informe stock de Productos terminados"));
                    doc.Add(Chunk.NEWLINE);
                    PdfPTable tblLineaProduccion = crearTablaProductos(fabrica.ServicioProducto.GetAllByEstado(EEstado.Completo), standarFont, false);
                    doc.Add(tblLineaProduccion);
                }
                else
                {
                    doc.Add(new Paragraph("Informe stock de Productos terminados: no productos en inventario"));
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                if (Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Madera) > 0)
                {
                    parrafoTitulo = new Paragraph("Informe maderas");
                    parrafoTitulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(parrafoTitulo);
                    doc.Add(Chunk.NEWLINE);
                    PdfPTable tblMadera = crearTablaInsumos(stockInsumos, ETipoInforme.Madera, standarFont);
                    doc.Add(tblMadera);
                }
                else
                {
                    doc.Add(new Paragraph("Informe maderas: no hay maderas cargadas"));
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                if (Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Tela) > 0)
                {
                    parrafoTitulo = new Paragraph("Informe Telas");
                    parrafoTitulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(parrafoTitulo);
                    doc.Add(Chunk.NEWLINE);
                    PdfPTable tblTela = crearTablaInsumos(stockInsumos, ETipoInforme.Tela, standarFont);
                    doc.Add(tblTela);
                }
                else
                {
                    doc.Add(new Paragraph("Informe Telas: no hay telas cargadas"));
                }
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph("Otros Insumos"));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Paragraph($"Cantidad de Yute disponible: {Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Yute)}"));
                doc.Add(new Paragraph($"Cantidad de Tornillos disponibles: {Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Tornillo)}"));
                doc.Add(new Paragraph($"Cantidad de Barniz disponibles: {Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Barniz)}"));
                doc.Add(new Paragraph($"Cantidad de Pegamento disponibles: {Insumo.CountInsumoType(stockInsumos, ETipoInsumo.Pegamento)}"));

                doc.Close();
                PW.Close();
            }
            catch(IOException e)
            {
                throw new SavePdfException("Error al crear el reporte");
            }

            




        }
        /// <summary>
        /// Método encargado de crear una tabla para un listado de productos, ya sea si es una tabla para la linea de produccion o para el stock de productos terminados
        /// </summary>
        /// <param name="listaProductos"></param>
        /// <param name="standarFont">Fuente estándar</param>
        /// <param name="esLineaProduccion">si es true es una tabla para la linea de producción, si es false es una tabla para stock de productos terminados</param>
        /// <returns></returns>
        private PdfPTable crearTablaProductos(List<Producto> listaProductos, Font standarFont, bool esLineaProduccion)
        {
            PdfPTable tblEjemplo;
            if(esLineaProduccion)
            {
                tblEjemplo = new PdfPTable(8);
            }
            else
            {
                tblEjemplo = new PdfPTable(7);
            }
            tblEjemplo.WidthPercentage = 100;

            //Configurando el titulo de las columnas

            PdfPCell clTipoProducto = new PdfPCell(new Phrase("Tipo de producto", standarFont));
            clTipoProducto.BorderWidth = 0;
            clTipoProducto.BorderWidth = 0.75f;

            PdfPCell clModelo = new PdfPCell(new Phrase("Modelo", standarFont));
            clModelo.BorderWidth = 0;
            clModelo.BorderWidth = 0.75f;

            PdfPCell clMaderaPrincipal = new PdfPCell(new Phrase("Madera Principal", standarFont));
            clMaderaPrincipal.BorderWidth = 0;
            clMaderaPrincipal.BorderWidth = 0.75f;

            PdfPCell clMaderaSecundaria = new PdfPCell(new Phrase("Madera Secundaria", standarFont));
            clMaderaSecundaria.BorderWidth = 0;
            clMaderaSecundaria.BorderWidth = 0.75f;

            PdfPCell clMaterialTela = new PdfPCell(new Phrase("Material Tela", standarFont));
            clMaterialTela.BorderWidth = 0;
            clMaterialTela.BorderWidth = 0.75f;

            PdfPCell clColorTela = new PdfPCell(new Phrase("Color Tela", standarFont));
            clColorTela.BorderWidth = 0;
            clColorTela.BorderWidth = 0.75f;

            PdfPCell clDetalles = new PdfPCell(new Phrase("Detalles", standarFont));
            clDetalles.BorderWidth = 0;
            clDetalles.BorderWidth = 0.75f;

            PdfPCell clEstado = new PdfPCell(new Phrase("Estado", standarFont));
            clEstado.BorderWidth = 0;
            clEstado.BorderWidth = 0.75f;

            tblEjemplo.AddCell(clTipoProducto);
            tblEjemplo.AddCell(clModelo);
            tblEjemplo.AddCell(clMaderaPrincipal);
            tblEjemplo.AddCell(clMaderaSecundaria);
            tblEjemplo.AddCell(clMaterialTela);
            tblEjemplo.AddCell(clColorTela);
            tblEjemplo.AddCell(clDetalles);
            if(esLineaProduccion)
            {
                tblEjemplo.AddCell(clEstado);
            }


            foreach (Producto p in listaProductos)
            {
                if (p is Torre)
                {
                    clTipoProducto = new PdfPCell(new Phrase("Torre", standarFont));
                    clTipoProducto.BorderWidth = 0;
                    clModelo = new PdfPCell(new Phrase(((Torre)p).Modelo.ToString(), standarFont));
                    clModelo.BorderWidth = 0;
                    clMaderaSecundaria = new PdfPCell(new Phrase(((Torre)p).MaderaColumna.TipoMadera.ToString(), standarFont));
                    clMaderaSecundaria.BorderWidth = 0;
                    if (((Torre)p).MetrosYute > 0)
                    {
                        clDetalles = new PdfPCell(new Phrase($"Metros de Yute: {((Torre)p).MetrosYute}", standarFont));
                    }
                    else
                    {
                        clDetalles = new PdfPCell(new Phrase($"Sin adicionales", standarFont));
                    }
                    clDetalles.BorderWidth = 0;
                }
                else
                {
                    clTipoProducto = new PdfPCell(new Phrase("Estante", standarFont));
                    clTipoProducto.BorderWidth = 0;
                    clModelo = new PdfPCell(new Phrase("Único", standarFont));
                    clModelo.BorderWidth = 0;
                    clMaderaSecundaria = new PdfPCell(new Phrase("No aplica", standarFont));
                    clMaderaSecundaria.BorderWidth = 0;
                    clDetalles = new PdfPCell(new Phrase($"Cantidad: {((Estante)p).CantidadEstantes}", standarFont));
                    clDetalles.BorderWidth = 0;

                }


                clMaderaPrincipal = new PdfPCell(new Phrase(p.MaderaPrincipal.TipoMadera.ToString(), standarFont));
                clMaderaPrincipal.BorderWidth = 0;

                clMaterialTela = new PdfPCell(new Phrase(p.TelaProducto.TipoTela.ToString(), standarFont));
                clMaterialTela.BorderWidth = 0;

                clColorTela = new PdfPCell(new Phrase(p.TelaProducto.Color.ToString(), standarFont));
                clColorTela.BorderWidth = 0;

                clEstado = new PdfPCell(new Phrase(p.EstadoProducto.ToString(), standarFont));
                clEstado.BorderWidth = 0;


                tblEjemplo.AddCell(clTipoProducto);
                tblEjemplo.AddCell(clModelo);
                tblEjemplo.AddCell(clMaderaPrincipal);
                tblEjemplo.AddCell(clMaderaSecundaria);
                tblEjemplo.AddCell(clMaterialTela);
                tblEjemplo.AddCell(clColorTela);
                tblEjemplo.AddCell(clDetalles);
                if(esLineaProduccion)
                {
                    tblEjemplo.AddCell(clEstado);
                }

            }

            return tblEjemplo;
        }
        /// <summary>
        /// Crea una tabla para el stock de Insumos dando al posibilidad a elegir si es para Telas o Maderas
        /// </summary>
        /// <param name="listaInsumos">Listado de Insumos</param>
        /// <param name="tipoInforme">Tipo de informe a elegir entre Tela o Madera</param>
        /// <param name="standarFont">Fuente estándar</param>
        /// <returns></returns>
        private PdfPTable crearTablaInsumos(List<Insumo> listaInsumos, ETipoInforme tipoInforme, Font standarFont)
        {
            PdfPTable tblInsumo = new PdfPTable(4);

            string campo2;

            if(tipoInforme == ETipoInforme.Madera)
            {
                campo2 = "Forma";
            }
            else
            {
                campo2 = "Color";
            }
            PdfPCell clCampoUno = new PdfPCell(new Phrase("Tipo", standarFont));
            clCampoUno.BorderWidth = 0;
            clCampoUno.BorderWidth = 0.75f;

            PdfPCell clCampoDos = new PdfPCell(new Phrase(campo2, standarFont));
            clCampoDos.BorderWidth = 0;
            clCampoDos.BorderWidth = 0.75f;

            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", standarFont));
            clCantidad.BorderWidth = 0;
            clCantidad.BorderWidth = 0.75f;

            PdfPCell clFechaIngreso = new PdfPCell(new Phrase("Fecha de Ingreso", standarFont));
            clFechaIngreso.BorderWidth = 0;
            clFechaIngreso.BorderWidth = 0.75f;

            tblInsumo.AddCell(clCampoUno);
            tblInsumo.AddCell(clCampoDos);
            tblInsumo.AddCell(clCantidad);
            tblInsumo.AddCell(clFechaIngreso);

            foreach (Insumo insumo in listaInsumos)
            {
                if(tipoInforme == ETipoInforme.Madera && insumo is Madera)
                {
                    Madera madera = (Madera)insumo;

                    clCampoUno = new PdfPCell(new Phrase(madera.TipoMadera.ToString(), standarFont));
                    clCampoUno.BorderWidth = 0;
                    clCampoDos = new PdfPCell(new Phrase(madera.Forma.ToString(), standarFont));
                    clCampoDos.BorderWidth = 0;
                    clCantidad = new PdfPCell(new Phrase(madera.Cantidad.ToString(), standarFont));
                    clCantidad.BorderWidth = 0;
                    clFechaIngreso = new PdfPCell(new Phrase(madera.FechaIngreso.Date.ToString("MM/dd/yyyy"), standarFont));
                    clFechaIngreso.BorderWidth = 0;

                    tblInsumo.AddCell(clCampoUno);
                    tblInsumo.AddCell(clCampoDos);
                    tblInsumo.AddCell(clCantidad);
                    tblInsumo.AddCell(clFechaIngreso);
                }
                else if(tipoInforme == ETipoInforme.Tela && insumo is Tela)
                {
                    Tela tela = (Tela)insumo;

                    clCampoUno = new PdfPCell(new Phrase(tela.TipoTela.ToString(), standarFont));
                    clCampoUno.BorderWidth = 0;
                    clCampoDos = new PdfPCell(new Phrase(tela.Color.ToString(), standarFont));
                    clCampoDos.BorderWidth = 0;
                    clCantidad = new PdfPCell(new Phrase(tela.Cantidad.ToString(), standarFont));
                    clCantidad.BorderWidth = 0;
                    clFechaIngreso = new PdfPCell(new Phrase(tela.FechaIngreso.Date.ToString("MM/dd/yyyy"), standarFont));
                    clFechaIngreso.BorderWidth = 0;

                    tblInsumo.AddCell(clCampoUno);
                    tblInsumo.AddCell(clCampoDos);
                    tblInsumo.AddCell(clCantidad);
                    tblInsumo.AddCell(clFechaIngreso);
                }

            }
            return tblInsumo;
        }
        /// <summary>
        /// Metodo ejecutado en un hilo secundario que gestiona la generación del informe y se comunica paralelamente con el formulario
        /// </summary>
        public void GenerarReporte()
        {
            SavePdfException ex;
            this.ActualizacionInforme.Invoke(33);
            Thread.Sleep(3000);
            try
            {
                this.CrearReporte();
                this.ActualizacionInforme.Invoke(66);
                Thread.Sleep(3000);
                this.ActualizacionInforme.Invoke(100);
                Process.Start(path);
                this.ActualizacionInforme.Invoke(120);
            }
            catch(Exception e)
            {
                ex = new SavePdfException(e.Message);
                this.ActualizacionInforme.Invoke(120);
                this.EnviarErrorInforme(ex);
            }


        }


    }

    public enum ETipoInforme
    {
        Madera,
        Tela
    }
}

