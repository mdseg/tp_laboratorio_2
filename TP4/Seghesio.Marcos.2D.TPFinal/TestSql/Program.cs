using Entidades;
using Entidades.Repositories;
using Entidades.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TestSql
{
    class Program
    {
        static void Main(string[] args)
        {


            string conexion = @"Data Source=.;Initial Catalog=TPFinal;Integrated Security=True";

            InsumoService serviceInsumo = new InsumoService(conexion);


            InsumoAccesorio acc1 = new InsumoAccesorio(ETipoAccesorio.Tornillo, 170);
            InsumoAccesorio acc2 = new InsumoAccesorio(ETipoAccesorio.Yute, 20);

            Tela tela = new Tela(EColor.Bordo, ETipoTela.Alfombra, 28);

            serviceInsumo.AltaInsumo(tela);

            /*
            
                        InsumoAccesorio acc1 = new InsumoAccesorio(ETipoAccesorio.Pegamento, 20);
            InsumoAccesorio acc2 = new InsumoAccesorio(ETipoAccesorio.Yute, 20);

            repoAccesorio.Create(acc1);
            repoAccesorio.Create(acc2);

            InsumoAccesorio buffer = repoAccesorio.GetById(1);

            buffer.Cantidad = 500;

            repoAccesorio.Update(buffer);

            RepositoryTelaSQL repoTela = new RepositoryTelaSQL(conexion);
            Tela tela = new Tela(EColor.Amarillo, ETipoTela.Peluche, 20);
            Tela tela2 = new Tela(EColor.Rosa, ETipoTela.PolarSoft, 10);

            repoTela.Create(tela);
            repoTela.Create(tela2);
            
            Tela bufferTela = repoTela.GetById(9);

            Console.WriteLine(bufferTela.Mostrar());

            bufferTela.Color = EColor.Violeta;

            repoTela.Update(bufferTela);

            List<Tela> telas = repoTela.GetAll();

            foreach(Tela telamos in telas)
            {
                Console.WriteLine(telamos.Mostrar());
            }

            */
            /*
            
            RepositoryMaderaSQL repoMadera = new RepositoryMaderaSQL(conexion);
            List<Madera> maderas = repoMadera.GetAll();
            Madera madera = new Madera(ETipoMadera.Pino, EForma.Tablon, 20);
            madera.EstaLijada = true;
            repoMadera.Create(madera);
            
            Madera madera = repoMadera.GetById(2);

            madera.Cantidad = 30;

            repoMadera.Update(madera);
            */
            /*

            */

        }
    }
}
