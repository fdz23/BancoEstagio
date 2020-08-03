using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Banco.Vetor
{
    class ListaGenerica<T> : IEnumerable<T>
    {
        private List<T> _lista;

        public ListaGenerica()
        {
            _lista = new List<T>();
        }

        public int Tamanho()
        {
            return _lista.Count;
        }

        public bool EhVazia()
        {
            return Tamanho() == 0;
        }

        public void Adicione(T item)
        {
            _lista.Add(item);
        }

        public T ElementoNaPosicao(int posicao)
        {
            return _lista[posicao];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_lista).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
