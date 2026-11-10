using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Arena
{
    internal class Carodej : Bojovnik
    {
        /// <summary>
        /// Mana čaroděje
        /// </summary>
        private int _mana;
        private int _maxMana;
        private int _magUtok;
        

        public Carodej(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magUtok) : base(jmeno, zivot, utok, obrana, kostka)
        {
            _mana = mana;
            _maxMana = mana;
            _magUtok = magUtok;
        }
        public override void Utoc(Bojovnik souper)
        {
            if (_mana == _maxMana)
            {
                _mana = 0;
                int uder = _magUtok + _kostka.HodSebou();
                Zprava = $"{_jmeno} sesílá magický útok s úderem za {uder} hp \n Protivník se nemůže bránit";
                souper.BranSe(uder, true);
                
            }
            else
            {
                base.Utoc(souper);
                _mana += 10;

            }
            if (_mana > _maxMana)
            {
                _mana = _maxMana;
            }
        }
        public string VratGrafickyPekneStaty()
        {
            string zivotyOutput = base.VratGrafickyPekneZivoty();

            int celkem = 20;
            double pocet = Math.Round(((double)_mana / _maxMana) * celkem);

            int zbyva = (int)pocet;
            int chybi = celkem - zbyva;

            // \u001b[44m = tmavě modrý podklad,
            // \u001b[104m = světle modrý podklad
            // \u001b[0m   = reset barvy
            string zbyvajiciBloky = new string(' ', zbyva);
            string chybajiciBloky = new string(' ', chybi);
            string manaOutput = $"Mana: \u001b[44m{zbyvajiciBloky}\u001b[104m{chybajiciBloky}\u001b[0m";
            return zivotyOutput + "\n" + manaOutput;
        }

    }
}
