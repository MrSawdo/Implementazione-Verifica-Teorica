using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente
{
    internal class Conto
    {
        private string numero_conto;
        private string cliente;
        private string banca;
        private double saldo;

        public Conto(string numero_conto, string cliente, string banca, double saldo)
        {
            this.numero_conto = numero_conto;
            this.cliente = cliente;
            this.banca = banca;
            this.saldo = saldo;
        }

        public string Num_conto
        {
            get { return numero_conto; }
        }
        public string Cliente
        {
            get { return cliente; }
        }

        public string Banca
        {
            get { return banca; }
        }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public double DepositaDenaro(double value)
        {
            if (value <= 0)
                return -1;
            return saldo += value;
        }

        public double PrelevaDenaro(double value)
        {
            if (value <= 0 || value > saldo)
                return -1;
            return saldo -= value;
        }

        public double ConosciSaldo() 
        {
            return saldo;
        }

        public void Bonifico(double value, Conto c2)
        {
            if (value <= 0 || value > saldo)
                return;
            saldo -= value;
            c2.saldo += value;
        }
    }
}
