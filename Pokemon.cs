using IERG3080_____Pokemon_Go.Pokemon_Type;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IERG3080_____Pokemon_Go
{
    public abstract class Pokemon
    {
        public string name;
        protected int hp;
        public int level {get; protected set; }
        public string[] actionList { get; protected set; }
        //actionList = new string[4];
        protected int maxHP = 10000;

        protected int special_skills_round_left = -1;

        public bool Special_skills{ 
            get { 
                if (special_skills_round_left > 0) 
                    return true;
                return false;
            } 
        }

        public int HP { get { return hp; } }

        protected Pokemon(string name, int level)
        {
            actionList = new string[4];
            this.name = name;
            if (level > 100)
            {
                this.level = 100;
            }
            else
            {
                this.level = level;
            }
            hp = 10;
        }

        public delegate void CalculateHP(int level);
        public delegate int Skills();
        public void PowerUp()
        {
            level++;
        }

        public virtual void setHP(int change)
        {
            hp += change;
            if (hp < 0)
            {
                hp = 0;
            }else if(hp > maxHP)
            {
                hp = maxHP;
            }
        }

        public abstract string Get_type();
        public abstract Pokemon Evolve();

        public static Pokemon RandomPokemon()
        {
            Random rnd = new Random();
            int rnd_level = rnd.Next(1, 16);
            Pokemon generated_pokemon = null;

            string RandomName()
            {
                string[] name = { "Oliver", "Harry", "George", "Noah", "Jack", "Jacob", "Leo", "Oscar", "Charlie", "Muhammad", "Olivia", "Amelia", "Ava", "Henry", "Oscar", "Theo", "Teddy", "Peter", "Alan", "Lucas" };
                Random rnd = new Random();
                return name[rnd.Next(0, name.Length)];
            }

            switch (rnd.Next(0, 6))
            {
                case 0:
                    generated_pokemon = new Eevee(RandomName(), rnd_level);
                    break;
                case 1:
                    generated_pokemon = new Charmeleon(RandomName(), rnd_level);
                    break;
                case 2:
                    generated_pokemon = new Squirtle(RandomName(), rnd_level);
                    break;
                case 3:
                    generated_pokemon = new Bulbasaur(RandomName(), rnd_level);
                    break;
                case 4:
                    generated_pokemon = new Munchlax(RandomName(), rnd_level);
                    break;
                default:
                    generated_pokemon = new Pikachu(RandomName(), rnd_level);
                    break;
            }
            if (rnd.Next(1, 5) == 1)
            {
                generated_pokemon.level = 16 + rnd.Next(0, 5);
                if (generated_pokemon.Evolve() != null)
                {
                    return generated_pokemon.Evolve();
                }
            }
            return generated_pokemon;
        }

        public static Pokemon Boss(int level)
        {
            return new Rayquaza("Rayquaza", level);
        }

        public abstract Image SetImage();
        public abstract Image SetItemImage();

        public virtual void getHP()
        {
            special_skills_round_left = -1;
            hp = 10 + level * 2;
            maxHP = hp;
        }

        public abstract int action1();
        public abstract int action2();
        public abstract int action3();
        public abstract int action4();
    }
}
