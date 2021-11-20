using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Rayquaza : Pokemon
    {
        public Rayquaza(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Air Slash";
            actionList[1] = "Hyper Beam";
            actionList[2] = "Dragon Ascent";
            actionList[3] = "Dragon Dance";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("rayquaza");
        }

        public override Image SetItemImage()
        {
            return GetPicture.Source("fire");
        }

        public override void getHP()
        {
            hp = 20 + level * 4;
            maxHP = hp;
        }

        public override void setHP(int damage)
        {
            base.setHP(damage);
            special_skills_round_left--;
            if (special_skills_round_left < 0)
            {
                special_skills_round_left = 0;
            }
        }

        //Air Slash
        public override int action1()
        {
            return -(6 + 3 * level / 5) * (1 + special_skills_round_left * 2);
        }

        //Hyper Beam
        public override int action2()
        {
            return -(8 + 4 * level / 5) * (1 + special_skills_round_left * 2);
        }

        //Dragon Ascent
        public override int action3()
        {
            return -(10 + 5 * level / 5) * (1 + special_skills_round_left * 2);
        }

        //Dragon Dance
        public override int action4()
        {
            special_skills_round_left = 2;
            return 0;
        }

        public override string Get_type()
        {
            return "Rayquaza";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
