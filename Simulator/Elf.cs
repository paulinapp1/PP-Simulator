﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        private int agility = 1;
        private int counter = 0;
        public int Agility
        {
            get { return agility; }
            init
            {
               agility= Validator.Limiter(value, 0, 10);
            }

        }
        public override char Symbol => 'E';

        public void Sing() {
            counter++;
         
            if (counter % 3 == 0)
            {
                if (agility < 10) agility++;

            }

        }

        public Elf() { }
        public Elf(string name, int level=1, int agility=1) : base(name, level)
        {
            Agility = agility;
        }
        public override string Greeting()
        {
            
            return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}";
         
        }
        public override int Power => 8 * Level + 2 * Agility;
        public override string Info
        {
            get { return $"{Name} [{Level}][{Agility}]"; }
        }





    }
}
