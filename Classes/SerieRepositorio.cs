/*
SerieRepositorio.cs
Author = César Calafrioli
Date = 28/05/2021
Last Modified = 29/05/2021

Repositório contendo a CRUD de series
*/
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public int qtdSeries()
        {
            return listaSerie.Count;    
        }

        public bool serieExcluida(int id){

            return listaSerie[id].retornaExcluido();

        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

    }
}