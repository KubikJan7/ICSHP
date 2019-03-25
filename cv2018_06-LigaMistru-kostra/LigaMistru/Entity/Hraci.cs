using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    public class Hraci
    {
        // TODO: zaměnit pole za SpojovySeznam
        private Hrac[] hraci;
        private int pocetHracu;

        public event PocetZmenenEventHandler PocetZmenen;

        public Hraci()
        {
            hraci = new Hrac[2];
            pocetHracu = 0;
        }

        public int Pocet
        {
            get => pocetHracu;
        }

        public Hrac this[int index]
        {
            get => hraci[index];
        }

        public void Vymaz(int index)
        {
            // TODO: zpracovat index < 0 || index >= pocetHracu
            for (int i = index; i < pocetHracu - 1; i++)
            {
                hraci[i] = hraci[i + 1];
            }

            pocetHracu--;

            OnPocetZmenen(pocetHracu + 1);
        }

        public void Pridej(Hrac hrac)
        {
            // TODO: hrac == null?
            if (pocetHracu == hraci.Length)
                ZvetsiPole();

            hraci[pocetHracu] = hrac;
            pocetHracu++;

            OnPocetZmenen(pocetHracu - 1);
        }

        private void ZvetsiPole()
        {
            Hrac[] novePole = new Hrac[hraci.Length * 2];
            Array.Copy(hraci, novePole, hraci.Length);

            hraci = novePole;
        }

        public void NajdiNejlepsiKluby(out FotbalovyKlub[] kluby, out int golPocet) 
        {
            // TODO: refactoring - toto je moc dlouhé a hnusné!
            int maximalniPocetGolu = 0;
            int[] poctyGoluDleKlubu = new int[FotbalovyKlubInfo.Pocet];
            for (int i = 0; i < pocetHracu; i++)
            {
                int indexKlubuVPoli = (int)hraci[i].Klub;

                poctyGoluDleKlubu[indexKlubuVPoli] += hraci[i].GolPocet;
                maximalniPocetGolu = Math.Max(maximalniPocetGolu, poctyGoluDleKlubu[indexKlubuVPoli]);
            }

            int pocetKlubuSMaximem = 0;
            for (int i = 0; i < poctyGoluDleKlubu.Length; i++)
            {
                if (poctyGoluDleKlubu[i] == maximalniPocetGolu)
                    pocetKlubuSMaximem++;
            }

            kluby = new FotbalovyKlub[pocetKlubuSMaximem];
            golPocet = maximalniPocetGolu;

            for (int i = 0, j = 0; i < poctyGoluDleKlubu.Length; i++)
            {
                if (poctyGoluDleKlubu[i] == maximalniPocetGolu)
                {
                    kluby[j] = (FotbalovyKlub)i;
                    j++;
                }
            }
        }

        private void OnPocetZmenen(int puvodniPocetHracu)
        {
            PocetZmenen?.Invoke(this, new PocetZmenenEventArgs()
            {
                PuvodniPocet = puvodniPocetHracu
            });
        }
    }
}
