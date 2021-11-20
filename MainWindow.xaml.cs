using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using IERG3080_____Pokemon_Go.Pokemon_Type;

namespace IERG3080_____Pokemon_Go
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ManagePokemon{
        private List<Pokemon> pokemon_list;

        public int coins { get; private set; }
        public string Show_money
        {
            get
            {
                return "X " + coins.ToString();
            }
        }

        private Pokemon mainPokemon;
        public Pokemon MainPokemon 
        {
            get{return mainPokemon;}
        }

        private ManagePokemon() {
			pokemon_list = new List<Pokemon>();
            coins = 0;
            mainPokemon = new Pikachu("Pikachu", 5);
        }

        private static ManagePokemon instance;
        public static ManagePokemon GetInstance()
        {
            if (instance == null)
            {
                instance = new ManagePokemon();
            }
            return instance;
        }

        public void AddPokemon(Pokemon target)
        {
            pokemon_list.Add(target);
        }

        public void RemovePokemon(Pokemon target)
        {
            if (pokemon_list.Contains(target))
            {
                pokemon_list.Remove(target);
            }
        }

        public void ChangeMainPokemon(Pokemon target)
        {
            mainPokemon = target;
        }

        public List<Pokemon> ListAllPokemon()
        {
            return pokemon_list;
        }

        public void GetCoin(int profit)
        {
            coins += profit;
        }

        public bool ReduceCoin(int purchase)
        {
            if (coins - purchase < 0)
            {
                MessageBox.Show("You don't have enough money");
                return false;
            }
            coins -= purchase;
            return true;
        }
    }

    public class map_info
    {
        private double x, y;
        private int map_num;

        private map_info()
        {
            x = 0;
            y = 0;
            map_num = 0;
        }

        private static map_info map_instance;
        public static map_info get_map()
        {
            if (map_instance == null)
            {
                map_instance = new map_info();
            }
            return map_instance;
        }
        public void set_map(double top, double left, int num)
        {
            x = top;
            y = left;
            map_num = num;
        }
        public double get_x()
        {
            return x;
        }
        public double get_y()
        {
            return y;
        }
        public int get_num()
        {
            return map_num;
        }
    }
 }
