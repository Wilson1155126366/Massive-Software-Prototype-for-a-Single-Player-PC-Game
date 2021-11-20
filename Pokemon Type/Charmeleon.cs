using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Charmeleon : Pokemon
    {
        public Charmeleon(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Smokescreen";
            actionList[1] = "Dragon Breath";
            actionList[2] = "Flare Blitz";
            actionList[3] = "Work Up";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("charmeleon");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("fire");
        }

        public override void getHP()
        {
            hp = 10 + level * 2;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            base.setHP(damage);
            special_skills_round_left--;
            if (special_skills_round_left <= 0)
            {
                special_skills_round_left = 0;
            } 
        }

        //Smokescreen
        public override int action1()
        {
            return -(2 + 2 * level / 10) * (1 + special_skills_round_left * 2) ;
        }

        //Dragon Breath
        public override int action2()
        {
            return -(3 + 3 * level / 10) * (1 + special_skills_round_left * 2);
        }

        //Flare Blitz
        public override int action3()
        {
            return -(4 + 4 * level / 10) * (1 + special_skills_round_left * 2);
        }

        //Work Up (Triple Attack)
        public override int action4()
        {
            special_skills_round_left = 2;
            return 0;
        }

        public override string Get_type()
        {
            return "Charmeleon";
        }

        public override Pokemon Evolve()
        {
            if (level >= 16)
                return new Charizard(this.name, this.level);
            else
                return null;
        }
    }

    class Charizard : Pokemon
    {
        public Charizard(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Dragon Claw";
            actionList[1] = "Fire Spin";
            actionList[2] = "Will-O-Wisp";
            actionList[3] = "Work Up";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("charizard");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("fire");
        }

        public override void getHP()
        {
            hp = 20 + level * 3;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            base.setHP(damage);
            special_skills_round_left--;
            if (special_skills_round_left <= 0)
            {
                special_skills_round_left = 0;
            }
        }

        //Dragon Claw
        public override int action1()
        {
            return -(2 + 2 * level / 7) * (1 + special_skills_round_left * 2);
        }

        //Fire Spin
        public override int action2()
        {
            return -(3 + 3 * level / 7) * (1 + special_skills_round_left * 2);
        }

        //Will-O-Wisp
        public override int action3()
        {
            return -(4 + 4 * level / 7) * (1 + special_skills_round_left * 2);
        }

        //Work Up (Triple Attack)
        public override int action4()
        {
            special_skills_round_left = 2;
            return 0;
        }

        public override string Get_type()
        {
            return "Charizard";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
