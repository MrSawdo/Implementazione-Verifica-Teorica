using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContoCorrente
{
    internal class Carta
    {
            private string numero_seriale;
            private static string pin = "1234";
            private Conto conto;
            public Carta(string numero_seriale, string pin, Conto conto)
            {
                this.numero_seriale = numero_seriale;
                this.conto = conto;
            }
            public string Numero_seriale
            {
                get { return numero_seriale; }
            }
            public string Pin
            {
                get { return pin; }
            }
            public Conto Conto
            {
                get { return conto; }
                set { conto = value; }
            }
            public double Deposita(double value, string pinInserito)
            {
                if (pin == pinInserito)
                    return conto.DepositaDenaro(value);
                else
                    return -1;
            }
            public double Preleva(double value, string pinInserito)
            {
                if (pin == pinInserito)
                    return conto.PrelevaDenaro(value);
                else
                    return -1;
            }
            public double Conosci(string pinInserito)
            {
                if (pin == pinInserito)
                    return conto.ConosciSaldo();
                else
                    return -1;
            }
        }
}
