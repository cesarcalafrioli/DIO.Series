/*
IRepositorio.cs
Author = César Calafrioli
Date = 28/05/2021
Last Modified = 29/05/2021

Interface de Repositório
*/
using System.Collections.Generic;

namespace DIO.Series
{
    public interface IRepositorio<T>
    {
         List<T> Lista();

         T RetornaPorId(int id);

         void Insere(T entidade);

         void Exclui(int id);

         void Atualiza(int id, T entidade);

         int ProximoId();
    }
}