using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Munchlax : Pokemon
    {
        public Munchlax(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Lick";
            actionList[1] = "Bite";
            actionList[2] = "Belly Drum";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("munchlax");
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

        //Lick
        public override int action1()
        {
            return -(2 + 2 * level / 10);
        }

        //Bite
        public override int action2()
        {
            return -(3 + 3 * level / 10);
        }

        //Belly Drum
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
            return "Munchlax";
        }

        public override Pokemon Evolve()
        {
            if (level >= 16)
                return new Snorlax(this.name, this.level);
            else
                return null;
        }
    }

    class Snorlax : Pokemon
    {
        public Snorlax(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Crunch";
            actionList[1] = "Heavy Slam";
            actionList[2] = "Giga Impact";
            actionList[3] = "Defense Curl";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("snorlax");
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

        //Crunch
        public override int action1()
        {
            return -(2 + 2 * level / 7);
        }

        //Heavy Slam
        public override int action2()
        {
            return -(3 + 3 * level / 7);
        }

        //Giga Impact
        public override int action3()
        {
            return -(4 + 4 * level / 7);
        }

        //Defense Curl
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Snorlax";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
