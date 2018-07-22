using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gft
{
    public class Menu
    {
        readonly List<Prato> pratos = new List<Prato>();
        public Menu()
        {
            pratos.Add(new Prato("manhã", 1, "ovos", false));
            pratos.Add(new Prato("manhã", 2, "torrada", false));
            pratos.Add(new Prato("manhã", 3, "café", true));
            pratos.Add(new Prato("noite", 1, "carne", false));
            pratos.Add(new Prato("noite", 2, "batata", true));
            pratos.Add(new Prato("noite", 3, "vinho", false));
            pratos.Add(new Prato("noite", 4, "bolo", false));
        }

        public string Generate(string periodo, int[] tipos)
        {

            List<PratoRetorno> retorno = new List<PratoRetorno>();
            foreach (int tipo in tipos.OrderBy(t => t))
            {
                var prato = pratos.Where(p => p.Periodo == periodo && p.Tipo == tipo).FirstOrDefault();

                if (prato == null)
                    retorno.Add(new PratoRetorno { Ordem = 0, Descricao = "erro" });
                else
                {
                    if (prato.Multiplo && retorno.Any(p => p.Ordem == prato.Tipo))
                    {
                        retorno.Find(p => p.Ordem == prato.Tipo).Quantidade++;
                    }
                    else
                    {
                        retorno.Add(new PratoRetorno { Ordem = prato.Tipo, Descricao = prato.Descricao, Quantidade = 1 });
                    }
                }
            }

            return GenerateRetorno(retorno);
        }

        private string GenerateRetorno(List<PratoRetorno> listaretorno)
        {
            StringBuilder retorno = new StringBuilder();
            foreach (PratoRetorno prato in listaretorno.Where(p=> p.Ordem > 0).OrderBy(p=> p.Ordem))
            {
                if (prato.Quantidade > 1)
                    retorno.AppendFormat("{0} (x{1}), ", prato.Descricao, prato.Quantidade);
                else
                    retorno.AppendFormat("{0}, ", prato.Descricao);
            }

            foreach (PratoRetorno prato in listaretorno.Where(p => p.Ordem == 0))
                retorno.AppendFormat("{0}, ", prato.Descricao);

            return retorno.ToString().Remove(retorno.Length - 2);
        }
    }
}
