using ContoCorrente;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    

    private static void Main(string[] args)
    {
        Conto c1 = new Conto("0101", "Dottore", "UniCreditCard", 0);
        Conto c2 = new Conto("0102", "Strada", "UniCreditCard", 0);

        Carta crt1 = new Carta("0101", "abc123", c1);
        Carta crt2 = new Carta("0102", "def456", c2);


        bool sceltaConto = false;
        do
        {
            Console.WriteLine("Scegli su quale dei 2 conti vuoi lavorare (la risposta deve essere UGUALE alle seguenti): Conto1 - Conto2");
            string rispostaConto = Console.ReadLine();


            //PARTE A
            if (rispostaConto == "Conto1")
            {
                bool sblocco = false;
                do
                {
                    Console.WriteLine("Inserisca il pin del conto: ");
                    string pinContoStabilito = "abc123";
                    string pinConto = Console.ReadLine();
                    //Controllo pin conto
                    if (pinConto == pinContoStabilito)
                    {
                        Console.WriteLine("Il conto è stato sbloccato");
                        sblocco = true;
                    }
                    else
                    {
                        Console.WriteLine("Il pin è errato");
                        sblocco = false;
                    }
                } while (sblocco == false);

                bool answer = false;
                do
                {
                    //Conto 1
                    //Scelta dell'azione da eseguire
                    Console.WriteLine("Scriva cosa vuoi fare (la risposta deve essere UGUALE alle seguenti): Prelevare - Depositare - Bonifico - PrelevaCarta - DepositaCarta");
                    string risposta = Console.ReadLine();

                    //Preleva
                    if (risposta == "Prelevare" && c1.Saldo != 0)
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole prelevare: ");
                            double preleva = Convert.ToDouble(Console.ReadLine());
                            if (preleva <= 0 || preleva > c1.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                //bool transazione = false;
                                /*do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);
                                */
                                c1.PrelevaDenaro(preleva);
                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c1.ConosciSaldo()}£");
                    }
                    else
                    if(risposta == "Prelevare" && c1.Saldo == 0)
                    {
                        Console.WriteLine("Non puoi prelevare denaro se non hai soldi nel conto");
                    }

                    else
                    if (risposta == "PrelevaCarta" && c1.Saldo == 0)
                    {
                        Console.WriteLine("Non puoi prelevare denaro se non hai soldi nel conto");
                    }


                    //Deposita
                    else
                    if (risposta == "Depositare")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole depositare: ");
                            double deposita = Convert.ToDouble(Console.ReadLine());
                            if (deposita <= 0)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                /*bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato, la transizione e il conto sono stati bloccati");
                                    }
                                } while (transazione == false);*/
                                c1.DepositaDenaro(deposita);

                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c1.ConosciSaldo()}£");
                    }
                    //Bonifico
                    else if (risposta == "Bonifico")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma del bonifico: ");
                            double bonifico = Convert.ToDouble(Console.ReadLine());
                            if (bonifico <= 0 || bonifico > c1.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma del bonifico");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                /*bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato, la transizione e il conto sono stati bloccati");
                                    }
                                }while (transazione == false);*/
                                c1.Bonifico(bonifico, c2);
                                
                            }
                            Console.WriteLine($"il saldo del primo conto a seguito del bonifico equivale a {c1.ConosciSaldo()}£");
                            Console.WriteLine($"il saldo del secondo conto a seguito del bonificao equivale a {c2.ConosciSaldo()}£");
                        } while (sommaTransitoria == true);
                    }
                    //PARTE B
                    if (risposta == "DepositaCarta")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole depositare: ");
                            double deposita = Convert.ToDouble(Console.ReadLine());
                            if (deposita <= 0)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin della carta: ");
                                    string pinCartaStabilito = "1234";
                                    string pinInserito = Convert.ToString(Console.ReadLine());
                                    //Controllo pin conto
                                    if (pinInserito == pinCartaStabilito)
                                    {
                                        Console.WriteLine("la carta è stata sbloccata");
                                        transazione = true;
                                        crt1.Deposita(deposita, pinInserito);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);
                                
                                

                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c1.ConosciSaldo()}£");
                    }
                    //PARTE B
                    if (risposta == "PrelevaCarta" && c1.Saldo != 0)
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole prelevare: ");
                            double preleva = Convert.ToDouble(Console.ReadLine());
                            if (preleva <= 0 || preleva > c1.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin della carta: ");
                                    string pinCartaStabilito = "1234";
                                    string pinInserito = Convert.ToString(Console.ReadLine());
                                    //Controllo pin conto
                                    if (pinInserito == pinCartaStabilito)
                                    {
                                        Console.WriteLine("la carta è stata sbloccata");
                                        transazione = true;
                                        crt1.Preleva(preleva, pinInserito);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);


                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c1.ConosciSaldo()}£");
                    }
                    

                    bool siono = true;
                    do
                    {
                        Console.WriteLine("Vuole continuare con le operazioni? Si - No");
                        string si_no = Console.ReadLine();

                        if (si_no == "Si")
                        {
                            answer = true;
                            siono = true;
                        }
                        else
                            if (si_no == "No")
                        {
                            answer = false;
                            siono = true;
                        }
                        else
                        {
                            Console.WriteLine("la risposta che ha inserito non va bene");
                            siono = false;
                        }
                    } while (siono == false);

                } while (answer == true);
            }



            else
            {
                bool sblocco = false;
                do
                {
                    Console.WriteLine("Inserisca il pin del conto: ");
                    string pinContoStabilito = "def456";
                    string pinConto = Console.ReadLine();
                    //Controllo pin conto
                    if (pinConto == pinContoStabilito)
                    {
                        Console.WriteLine("Il conto è stato sbloccato");
                        sblocco = true;
                    }
                    else
                    {
                        Console.WriteLine("Il pin è errato");
                        sblocco = false;
                    }
                } while (sblocco == false);

                bool answer = false;
                do
                {
                    //Conto 2
                    //Scelta dell'azione da eseguire
                    Console.WriteLine("Scriva cosa vuole fare (la risposta deve essere UGUALE alle seguenti): Prelevare - Depositare - Bonifico - PrelevaCarta - DepositaCarta");
                    string risposta = Console.ReadLine();

                    //Preleva
                    if (risposta == "Prelevare" && c2.Saldo != 0)
                    {
                        bool sommaTransitoria = true;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole prelevare: ");
                            double preleva = Convert.ToDouble(Console.ReadLine());
                            if (preleva <= 0 || preleva > c2.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = false;
                            }
                            else
                            {
                                //bool transazione = false;
                                /*do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);
                                */
                                c2.PrelevaDenaro(preleva);
                            }
                        } while (sommaTransitoria == false);
                        Console.WriteLine($"il saldo del conto equivale a {c2.ConosciSaldo()}£");
                    }
                    else
                    if (risposta == "Prelevare" && c2.Saldo == 0)
                    {
                        Console.WriteLine("Non puoi prelevare denaro se non hai soldi nel conto");
                    }


                    //Deposita
                    else
                    if (risposta == "Depositare")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole depositare: ");
                            double deposita = Convert.ToDouble(Console.ReadLine());
                            if (deposita <= 0)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                /*bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato, la transizione e il conto sono stati bloccati");
                                    }
                                } while (transazione == false);*/
                                c2.DepositaDenaro(deposita);

                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c2.ConosciSaldo()}£");
                    }

                    else
                    if (risposta == "PrelevaCarta" && c2.Saldo == 0)
                    {
                        Console.WriteLine("Non puoi prelevare denaro se non hai soldi nel conto");
                    }

                    //PARTE B
                    if (risposta == "DepositaCarta")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole depositare: ");
                            double deposita = Convert.ToDouble(Console.ReadLine());
                            if (deposita <= 0)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin della carta: ");
                                    string pinCartaStabilito = "1234";
                                    string pinInserito = Convert.ToString(Console.ReadLine());
                                    //Controllo pin conto
                                    if (pinInserito == pinCartaStabilito)
                                    {
                                        Console.WriteLine("la carta è stata sbloccata");
                                        transazione = true;
                                        crt2.Deposita(deposita, pinInserito);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);



                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c2.ConosciSaldo()}£");
                    }
                    //PARTE B
                    if (risposta == "PrelevaCarta" && c2.Saldo != 0)
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma che vuole prelevare: ");
                            double preleva = Convert.ToDouble(Console.ReadLine());
                            if (preleva <= 0 || preleva > c2.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma da prelevare");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin della carta: ");
                                    string pinCartaStabilito = "1234";
                                    string pinInserito = Convert.ToString(Console.ReadLine());
                                    //Controllo pin conto
                                    if (pinInserito == pinCartaStabilito)
                                    {
                                        Console.WriteLine("la carta è stata sbloccata");
                                        transazione = true;
                                        crt2.Preleva(preleva, pinInserito);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato");
                                    }
                                } while (transazione == false);


                            }
                        } while (sommaTransitoria == true);
                        Console.WriteLine($"il saldo del conto equivale a {c2.ConosciSaldo()}£");
                    }
                    //PARTE A
                    //Bonifico
                    else if (risposta == "Bonifico")
                    {
                        bool sommaTransitoria = false;
                        do
                        {
                            Console.WriteLine("Inserisca la somma del bonifico: ");
                            double bonifico = Convert.ToDouble(Console.ReadLine());
                            if (bonifico <= 0 || bonifico > c2.Saldo)
                            {
                                Console.WriteLine("Non può prelevare questa somma di denaro, reinserisca la somma del bonifico");
                                sommaTransitoria = true;
                            }
                            else
                            {
                                /*bool transazione = false;
                                do
                                {
                                    Console.WriteLine("Inserisca il pin del conto: ");
                                    string pinContoStabilito = "abc123";
                                    string pinConto = Console.ReadLine();
                                    //Controllo pin conto
                                    if (pinConto == pinContoStabilito)
                                    {
                                        Console.WriteLine("Il conto è stato sbloccato");
                                        transazione = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il pin è errato, la transizione e il conto sono stati bloccati");
                                    }
                                }while (transazione == false);*/
                                c2.Bonifico(bonifico, c1);

                            }
                            Console.WriteLine($"il saldo del primo conto a seguito del bonifico equivale a {c1.ConosciSaldo()}£");
                            Console.WriteLine($"il saldo del secondo conto a seguito del bonificao equivale a {c2.ConosciSaldo()}£");
                        } while (sommaTransitoria == true);
                    }

                    bool siono = true;
                    do
                    {
                        Console.WriteLine("Vuole continuare con le operazioni? Si - No");
                        string si_no = Console.ReadLine();

                        if (si_no == "Si")
                        {
                            answer = true;
                            siono = true;
                        }
                        else
                            if (si_no == "No")
                        {
                            answer = false;
                            siono = true;
                        }
                        else
                        {
                            Console.WriteLine("la risposta che ha inserito non va bene");
                            siono = false;
                        }
                    } while (siono == false);

                } while (answer == true);

            }

            bool siono2 = true;
            do
            {
                Console.WriteLine("Vuole tornare al menu delle carte? Si - No (esci)");
                string rispostaMenuConto = Console.ReadLine();
                if (rispostaMenuConto == "Si")
                {
                    sceltaConto = true;
                    siono2 = true;
                }
                else
                    if (rispostaMenuConto == "No")
                {
                    sceltaConto = false;
                    siono2 = true;
                }
                else
                {
                    Console.WriteLine("la risposta che ha inserito non va bene");
                    siono2 = false;
                }
            }while (siono2 == false);
                
        } while (sceltaConto == true);
    }
}