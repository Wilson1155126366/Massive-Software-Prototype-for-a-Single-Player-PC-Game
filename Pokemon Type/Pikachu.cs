using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    public class Pikachu : Pokemon
    { 
        public Pikachu(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Lightning Rod";
            actionList[1] = "Rising Voltage";
            actionList[2] = "Thunder Shock";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("pikachu");
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
            //Pikachu have a shield in special_skills
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
        }

        //Lightning Rod
        public override int action1()
        {
            return - (2 + 2 * level / 7);
        }

        //Rising Voltage
        public override int action2()
        {
            return - (3 + 3 * level / 7);
        }

        //Thunder Shock
        public override int action3()
        {
            return - (4 + 4 * level / 7);
        }

        //Protect
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Pikachu";
        }

        public override Pokemon Evolve()
        {
            if (level >= 16)
                return new raichu(this.name, this.level);
            else
                return null;
        }

    }
    public class raichu : Pokemon
    {
        public raichu(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Thunder Punch";
            actionList[1] = "Discharge";
            actionList[2] = "Thunderbolt";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("raichu");
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
            //Pikachu have a shield in special_skills
            if (Special_skills == false)
            {
                base.setHP(damage);
            }
            special_skills_round_left--;
            if (special_skills_round_left < 0) special_skills_round_left = 0;
        }

        //Lightning Rod
        public override int action1()
        {
            return - (4 + 2 * level / 5);
        }

        //Rising Voltage
        public override int action2()
        {
            return - (6 + 3 * level / 5);
        }

        //Thunder Shock
        public override int action3()
        {
            return - (8 + 4 * level / 5);
        }

        //Protect
        public override int action4()
        {
            special_skills_round_left = 1;
            return 0;
        }

        public override string Get_type()
        {
            return "Raichu";
        }

        public override Pokemon Evolve()
        {
            return null;
        }
    }
}
