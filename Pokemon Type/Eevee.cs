using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IERG3080_____Pokemon_Go.Pokemon_Type
{
    class Eevee : Pokemon
    {
        public Eevee(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Bite";
            actionList[1] = "Sand Attack";
            actionList[2] = "Take Down";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("eevee");
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

        //Bite
        public override int action1()
        {
            return -(2 + 2 * level / 7);
        }

        //Sand Attack
        public override int action2()
        {
            return -(3 + 3 * level / 7);
        }

        //Take Down
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

        public override Pokemon Evolve()
        {
            Random rnd = new Random();
            if (level >= 16)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        return new Fire_Eevee(this.name, this.level);
                    case 1:
                        return new Water_Eevee(this.name, this.level);
                    case 2:
                        return new leaf_Eevee(this.name, this.level);
                }
                return null;
            }
            else
                return null;
        }

        public override string Get_type()
        {
            return "Eevee";
        }
    }

    class Fire_Eevee : Pokemon
    {
        public Fire_Eevee(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Strong Bite";
            actionList[1] = "Ember";
            actionList[2] = "Flare Blitz";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("fire_eevee");
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
        }

        //Strong Bite
        public override int action1()
        {
            return -(4 + 2 * level / 5);
        }

        //Ember
        public override int action2()
        {
            return -(6 + 3 * level / 5);
        }

        //Flare Blitz
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

        public override Pokemon Evolve()
        {
            return null;
        }

        public override string Get_type()
        {
            return "Fire Eevee";
        }
    }

    class Water_Eevee : Pokemon
    {
        public Water_Eevee(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Strong Bite";
            actionList[1] = "Water Gun";
            actionList[2] = "Water Pulse";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("water_eevee");
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
        }

        //Strong Bite
        public override int action1()
        {
            return -(4 + 2 * level / 5);
        }

        //Water Gun
        public override int action2()
        {
            return -(6 + 3 * level / 5);
        }

        //Water Pulse
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

        public override Pokemon Evolve()
        {
            return null;
        }
        public override string Get_type()
        {
            return "Water Eevee";
        }
    }

    class leaf_Eevee : Pokemon
    {
        public leaf_Eevee(string name, int level) : base(name, level)
        {
            getHP();
            setSkillsName();
        }

        private void setSkillsName()
        {
            actionList[0] = "Strong Bite";
            actionList[1] = "Razor Leaf";
            actionList[2] = "Leaf Blade";
            actionList[3] = "Protect";
        }

        public override Image SetImage()
        {
            return GetPicture.Source("leafeon_eevee");
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
        }

        //Strong Bite
        public override int action1()
        {
            return -(4 + 2 * level / 5);
        }

        //Razor Leaf
        public override int action2()
        {
            return -(6 + 3 * level / 5);
        }

        //Leaf Blade
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

        public override Pokemon Evolve()
        {
            return null;
        }
        public override string Get_type()
        {
            return "Leafeon Eevee";
        }
    }
}
