using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IERG3080_____Pokemon_Go
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        Map map_town;
        Market market;
        private MediaPlayer bgm1 = new MediaPlayer();
        ManagePokemon storage;

        public Shop()
        {
            InitializeComponent();
            storage = ManagePokemon.GetInstance();

            box.Source = (GetPicture.Source("box")).Source;
            money_board.Source = (GetPicture.Source("money")).Source;
            coin_icon.Source = (GetPicture.Source("coin")).Source;

            Init_list();

            string link = GetPicture.Source_mp3("upgrade");
            bgm1.Open(new Uri(link, UriKind.Relative));
            bgm1.Volume = 0.1;
            bgm1.Play();
        }

        private void Init_list()
        {
            printf_info(storage.MainPokemon);
            Show_money();
        }
        private void Show_money()
        {
            textBlock4.Text = storage.Show_money;
        }
        private void Levelup_Click(object sender, RoutedEventArgs e)
        {
            if (storage.MainPokemon.level < 100)
            {
                if (storage.ReduceCoin(100))
                {
                    storage.MainPokemon.PowerUp();
                    storage.MainPokemon.getHP();

                    //MessageBox.Show("[-$100] Upgrade successfully");

                    printf_info(storage.MainPokemon);
                    Show_money();
                }
            }
            else
                MessageBox.Show("This Pokemon cannot upgrade anymore !");
        }

        Random rnd = new Random();
        private void Evolve_Click(object sender, RoutedEventArgs e)
        {
            int result = rnd.Next(0, 2);

            if(storage.MainPokemon.Evolve() == null)
            {
                if (storage.MainPokemon.level < 16)
                {
                    MessageBox.Show("This Pokemon need level 16 to evolve");
                }
                else
                {
                    MessageBox.Show("This Pokemon cannot evolve anymore !");
                }
            }
            else if(result == 0)
            {
                if(storage.ReduceCoin(500))
                {
                    storage.ChangeMainPokemon(storage.MainPokemon.Evolve());
                    MessageBox.Show("[-$500] Evolve successfully");

                    printf_info(storage.MainPokemon);
                    Show_money();
                }
            }
            else if(result == 1)
            {
                if (storage.ReduceCoin(500))
                {
                    MessageBox.Show("[-$500] Evolve failed! You are so unluck! There is 50% chance to evolve failed !");
                    Show_money();
                }
            }
        }
        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            if(textbox.Text == "")
            {
                MessageBox.Show("Pokemon name cannot be blank");
            }else if (textbox.Text == storage.MainPokemon.name)
            {
                MessageBox.Show("Don't waste money to change the same name");
            }
            else
            {
                if (storage.ReduceCoin(50))
                {
                    if (textbox.Text.Length > 15)
                    {
                        storage.MainPokemon.name = textbox.Text.Substring(0, 15);
                    }
                    else
                    {
                        storage.MainPokemon.name = textbox.Text;
                    }
                    MessageBox.Show("[-$50] Your Pokemon renamed to " + storage.MainPokemon.name);

                    printf_info(storage.MainPokemon);
                    Show_money();
                    textbox.Text = "";
                }
            } 
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            map_info info = map_info.get_map();
            if (info.get_num() == 1)
            {
                bgm1.Stop();
                map_town = new Map();
                NavigationService.Navigate(map_town);
            }
            if (info.get_num() == 3)
            {
                bgm1.Stop();
                market = new Market();
                NavigationService.Navigate(market);
            }
        }

        public void printf_info(Pokemon buf)
        {
            pokemon_image.Source = (buf.SetImage()).Source;
            textBlock3.Text =
                            "[Lv: " + buf.level + "] [Type: " + buf.Get_type() + "]\n" +
                            "[Name: " + buf.name + "]\n" +
                            "[HP: " + buf.HP + "]\n" +
                            "[Skill 1] " + "[" + buf.actionList[0] + "]\n" +
                            "[Skill 2] " + "[" + buf.actionList[1] + "]\n" +
                            "[Skill 3] " + "[" + buf.actionList[2] + "]\n" +
                            "[Skill 4] " + "[" + buf.actionList[3] + "]\n";
        }
    }
}
