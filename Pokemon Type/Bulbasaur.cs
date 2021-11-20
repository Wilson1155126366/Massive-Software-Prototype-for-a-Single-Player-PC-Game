using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Bulbasaur : Pokemon
    {
        public Bulbasaur(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }
        private void setSkillsName()
        {
            actionList[0] = "Tackle";
            actionList[1] = "Vine Whip";
            actionList[2] = "Razor Leaf";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("bulbasaur");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("shield");
        }

        public override void getHP()
        {
            hp = 10 + level * 2;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            //shield special_skills
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
        }

        //Tackle
        public override int action1()
        {
            return -(2 + 2 * level / 7);
        }

        //Vine Whip
        public override int action2()
        {
            return -(3 + 3 * level / 7);
        }

        //Razor Leaf
        public override int action3()
        {
            return -(4 + 4 * level / 7);
        }

        //Protect
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Bulbasaur";
        }

        public override Pokemon Evolve()
        {
            if (level >= 16)
                return new Venusaur(this.name, this.level);
            else
                return null;
        }
    }
    class Venusaur : Pokemon
    {
        public Venusaur(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Seed Bomb";
            actionList[1] = "Take Down";
            actionList[2] = "Solar Beam";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("venusaur");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("shield");
        }

        public override void getHP()
        {
            hp = 20 + level * 3;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            //shield special_skills
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
            if (special_skills_round_left < 0) special_skills_round_left = 0;
        }

        //Seed Bomb
        public override int action1()
        {
            return -(4 + 2 * level / 5);
        }

        //Take Down
        public override int action2()
        {
            return -(6 + 3 * level / 5);
        }

        //Solar Beam
        public override int action3()
        {
            return -(8 + 4 * level / 5);
        }

        //Protect
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Venusaur";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
