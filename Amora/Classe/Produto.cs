using System;
using System.Collections.Generic;

namespace Amora
{
	public class Produto
	{
		public Produto()
		{
		}

		public string Codigo;
		public string Nome;
		public string Categoria;
		public Decimal Valor;
		public Decimal Desconto;
		public string Descricao;
		public List<string> Imagem;
	}
}
