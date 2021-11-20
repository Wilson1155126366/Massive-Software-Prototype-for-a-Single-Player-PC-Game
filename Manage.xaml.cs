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
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Page
    {
        Map map_town;
        Center pokemon_center;
        private MediaPlayer bgm1 = new MediaPlayer();
        ManagePokemon storage;

        Dictionary<string, Pokemon> collection = new Dictionary<string, Pokemon>();
        public Manage()
        {
            InitializeComponent();
            storage = ManagePokemon.GetInstance();

            box.Source = (GetPicture.Source("box")).Source;
            pokemon_image.Source = (GetPicture.Source("unknown")).Source;
            money_board.Source = (GetPicture.Source("money")).Source;
            coin_icon.Source = (GetPicture.Source("coin")).Source;

            Init_list();

            string link = GetPicture.Source_mp3("manage");
            bgm1.Open(new Uri(link, UriKind.Relative));
            bgm1.Volume = 0.1;
            bgm1.Play();
        }
        private void Init_list()
        {
            List<string> list1 = new List<string>();
            foreach (Pokemon pokemon in storage.ListAllPokemon())
            {
                string buf = "[Lv: " + pokemon.level + "] [Type: " + pokemon.Get_type() + "] [Name: " + pokemon.name + "]";
                list1.Add(buf);
                collection.Add(buf, pokemon);
            }
            pokemonbox.ItemsSource = list1;

            List<string> list2 = new List<string>();
            list2.Add("[Lv: " + storage.MainPokemon.level + "] [Type: " + storage.MainPokemon.Get_type() + "] [Name: " + storage.MainPokemon.name + "]");
            mybag.ItemsSource = list2;

            Show_money();
        }
        private void Show_money()
        {
            textBlock4.Text = storage.Show_money;
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            map_info info = map_info.get_map();
            if(info.get_num() == 1)
            {
                bgm1.Stop();
                map_town = new Map();
                NavigationService.Navigate(map_town);
            }
            if (info.get_num() == 2)
            {
                bgm1.Stop();
                pokemon_center = new Center();
                NavigationService.Navigate(pokemon_center);
            }
        }
        private void ShowButtonClick(object sender, RoutedEventArgs e)
        {
            string ccode;
            if (pokemonbox.SelectedItem != null)
            {
                ccode = pokemonbox.SelectedItem.ToString();
                foreach (KeyValuePair<string, Pokemon> pair in collection)
                {
                    if (pair.Key == ccode)
                    {
                        printf_info(pair.Value);
                        pokemonbox.SelectedItem = null;
                        break;
                    }
                }
            }
            if (mybag.SelectedItem != null)
            {
                printf_info(storage.MainPokemon);
                mybag.SelectedItem = null;
            }  
        }
        private void SellButtonClick(object sender, RoutedEventArgs e)
        {
            
            string ccode;
            if (pokemonbox.SelectedItem != null)
            {
                ccode = pokemonbox.SelectedItem.ToString();
                foreach (KeyValuePair<string, Pokemon> pair in collection)
                {
                    if (pair.Key == ccode)
                    {
                        MessageBox.Show("[+$100] Pokemon " + pair.Value.name + " leaves you !");

                        storage.RemovePokemon(pair.Value);
                        pokemonbox.SelectedItem = null;
                        storage.GetCoin(100);

                        collection.Clear();
                        Init_list();
                        break;
                    }
                }
            }
            if (mybag.SelectedItem != null)
            {
                MessageBox.Show("Can only sell the Pokemon in Pokemon storage !");
                mybag.SelectedItem = null;
            }
        }
        private void TransButtonClick(object sender, RoutedEventArgs e)
        {
            string ccode;
            if (pokemonbox.SelectedItem != null)
            {
                ccode = pokemonbox.SelectedItem.ToString();
                foreach (KeyValuePair<string, Pokemon> pair in collection)
                {
                    if (pair.Key == ccode)
                    {
                        MessageBox.Show("Pokemon " + storage.MainPokemon.name + " is transferred to Pokemon center storage");

                        storage.RemovePokemon(pair.Value);
                        storage.AddPokemon(storage.MainPokemon);
                        storage.ChangeMainPokemon(pair.Value);

                        MessageBox.Show("Pokemon " + storage.MainPokemon.name + " is in your Pokemon backpack now");

                        pokemonbox.SelectedItem = null;

                        collection.Clear();
                        Init_list();
                        break;
                    }
                }
            }
            if (mybag.SelectedItem != null)
            {
                MessageBox.Show("Can only transfer Pokemon from Pokemon storage to Pokemon backpack !");
                mybag.SelectedItem = null;
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
