namespace Gft
{
    internal class Prato
    {
        public string Periodo { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public bool Multiplo { get; set; }

        public Prato(string periodo,int tipo,string descricao,bool multiplo)
        {
            Periodo = periodo;
            Tipo = tipo;
            Descricao = descricao;
            Multiplo = multiplo;
        }

        
    }
}