using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Squirtle : Pokemon
    {
        public Squirtle(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Rapid Spin";
            actionList[1] = "Aqua Tail";
            actionList[2] = "Water Pulse";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("squirtle");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("shield");
        }

        public override void getHP()
        {
            hp = 15 + level * 3;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
        }

        //Water Gun
        public override int action1()
        {
            return -(2 + 2 * level / 10);
        }

        //Aqua Tail
        public override int action2()
        {
            return -(3 + 3 * level / 10);
        }

        //Hydro Pump
        public override int action3()
        {
            return -(4 + 4 * level / 10);
        }

        //Protect
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Squirtle";
        }

        public override Pokemon Evolve()
        {
            if (level >= 16)
                return new Blastoise(this.name, this.level);
            else
                return null;
        }
    }

    class Blastoise : Pokemon
    {
        public Blastoise(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Water Pulse";
            actionList[1] = "Aqua Tail";
            actionList[2] = "Hydro Pump";
            actionList[3] = "Iron Defense";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("blastoise");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("shield");
        }

        public override void getHP()
        {
            hp = 30 + level * 4;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
        }

        //Water Pulse
        public override int action1()
        {
            return -(2 + 2 * level / 7);
        }

        //Aqua Tail
        public override int action2()
        {
            return -(3 + 3 * level / 7);
        }

        //Hydro Pump
        public override int action3()
        {
            return -(4 + 4 * level / 7);
        }

        //Iron Defense
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Blastoise";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
