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
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Page
    {
        Capture capture;
        GymBattle gymBattle;
        Center pokemoncenter;
        Manage manage;
        Market market;
        Shop shop;
        Wild wild;
        tower town_bot;

        int speed = 5; // declaring an integer called speed with value of 5
        bool goUp; // this is the go up boolean
        bool goDown; // this is the go down boolean
        bool goLeft; // this is the go left boolean
        bool goRight; // this is the go right boolean
        bool goEnter;

        private MediaPlayer bgm1 = new MediaPlayer();
        private TimeSpan interval = new TimeSpan(0, 1, 44);
        bool flag = true;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public Map()
        {
            InitializeComponent();

            player.Source = (GetPicture.Source("player_front")).Source;
            Town_map.Source = (GetPicture.Source("town")).Source;
            enter.Source = (GetPicture.Source("Enter")).Source;
            tutor.Source = (GetPicture.Source("tutor")).Source;

            string link = GetPicture.Source_mp3("town");
            bgm1.Open(new Uri(link, UriKind.Relative));
            bgm1.Volume = 0.05;
            bgm1.Play();

            Create_list();

            map_info info = map_info.get_map();
            if (info.get_num() == 1)
            {
                Canvas.SetTop(player, info.get_x());
                Canvas.SetLeft(player, info.get_y());
            }
            else
            {
                tutor.Visibility = Visibility.Visible;
                ManagePokemon storage = ManagePokemon.GetInstance();
                storage.GetCoin(1000);
            }

            timer();
        }

        public List<FrameworkElement> block_list = new List<FrameworkElement>();
        private void Create_list()
        {
            block_list.Add(house1);
            block_list.Add(house2);
            block_list.Add(house3);
            block_list.Add(house4);
            block_list.Add(board);
            block_list.Add(tree1);
            block_list.Add(tree2);
            block_list.Add(tree3);
            block_list.Add(tree4);
            block_list.Add(tree5);
            block_list.Add(tree6);
            block_list.Add(tree7);
            block_list.Add(tree8);
            block_list.Add(tree9);
            block_list.Add(tree10);
        }

        private void timer()
        {
            dispatcherTimer.Tick += Timer_Tick; // linking the timer event
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20); // running the timer every 20 milliseconds
            dispatcherTimer.Start(); // starting the timer
        }

        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            bgm1.Stop();

            map_info info = map_info.get_map();
            info.set_map(Canvas.GetTop(player), Canvas.GetLeft(player), 1);

            capture = new Capture(Pokemon.RandomPokemon());
            NavigationService.Navigate(capture);
        }
        private void Battle_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            bgm1.Stop();

            map_info info = map_info.get_map();
            info.set_map(Canvas.GetTop(player), Canvas.GetLeft(player), 1);

            Pokemon player2 = Pokemon.RandomPokemon();
            ManagePokemon player_pokemon = ManagePokemon.GetInstance();

            gymBattle = new GymBattle(player_pokemon.MainPokemon, player2);
            NavigationService.Navigate(gymBattle);
        }
        private void Box_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            bgm1.Stop();

            map_info info = map_info.get_map();
            info.set_map(Canvas.GetTop(player), Canvas.GetLeft(player), 1);

            manage = new Manage();
            NavigationService.Navigate(manage);
        }
        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            bgm1.Stop();

            map_info info = map_info.get_map();
            info.set_map(Canvas.GetTop(player), Canvas.GetLeft(player), 1);

            shop = new Shop();
            NavigationService.Navigate(shop);
        }
        private void Money_Click(object sender, RoutedEventArgs e)
        {
            ManagePokemon storage = ManagePokemon.GetInstance();
            storage.GetCoin(9999);
            MessageBox.Show("+ $9999 !");
        }
        private void Testing_Click(object sender, RoutedEventArgs e)
        {
            Capture_Button.Visibility = Visibility.Visible;
            Battle_Button.Visibility = Visibility.Visible;
            Box_Button.Visibility = Visibility.Visible;
            Shop_Button.Visibility = Visibility.Visible;
            Money_Button.Visibility = Visibility.Visible;

            Testing_Button.Visibility = Visibility.Hidden;
            MessageBox.Show("[Warning] You cant play all my content with the testing tool, it is just for convenient access to some functions !");
        }
        private void Tutor_Click(object sender, RoutedEventArgs e)
        {
            textBlock1.Visibility = Visibility.Visible;
            textBlock2.Visibility = Visibility.Visible;
            textBlock3.Visibility = Visibility.Visible;
            textBlock4.Visibility = Visibility.Visible;
            textBlock5.Visibility = Visibility.Visible;

            tutor1.Source = (GetPicture.Source("arrow")).Source;
            tutor2.Source = (GetPicture.Source("arrow")).Source;
            tutor3.Source = (GetPicture.Source("arrow")).Source;
            tutor4.Source = (GetPicture.Source("arrow")).Source;
            tutor5.Source = (GetPicture.Source("arrow")).Source;

            tutor1.Visibility = Visibility.Visible;
            tutor2.Visibility = Visibility.Visible;
            tutor3.Visibility = Visibility.Visible;
            tutor4.Visibility = Visibility.Visible;
            tutor5.Visibility = Visibility.Visible;

            MessageBox.Show("Welcome! This is a Gameboy RPG Pokemon game, different from Pokemon Go, you can run around in the custom map. You can control the character with arrow key, and interact with things with enter key when you close to them ! And here is the map information as exploring a RPG game with a map is quite time-wasting !");
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = true; // down key is pressed go down will be true
                player.Source = (GetPicture.Source("player_front")).Source;
                if(tutor.Visibility == Visibility.Visible)
                    tutor.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.Up)
            {
                goUp = true; // up key is pressed go up will be true
                player.Source = (GetPicture.Source("player_back")).Source;
                if (tutor.Visibility == Visibility.Visible)
                    tutor.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.Left)
            {
                goLeft = true; // left key is pressed go left will be true
                player.Source = (GetPicture.Source("player_left")).Source;
                if (tutor.Visibility == Visibility.Visible)
                    tutor.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.Right)
            {
                goRight = true; // right key is pressed go right will be true
                player.Source = (GetPicture.Source("player_right")).Source;
                if (tutor.Visibility == Visibility.Visible)
                    tutor.Visibility = Visibility.Hidden;
            }

            if(e.Key == Key.Enter)
            {
                goEnter = true;
            }
        }
        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = false; // down is released go down will be false
            }
            else if (e.Key == Key.Up)
            {
                goUp = false; // up key is released go up will be false
            }
            else if (e.Key == Key.Left)
            {
                goLeft = false; // left key is released go left will be false
            }
            else if (e.Key == Key.Right)
            {
                goRight = false; // right key is released go right will be false
            }

            if (e.Key == Key.Enter)
            {
                goEnter = false;
            }
        }

        private FrameworkElement intersect;
        private void Timer_Tick(object sender, EventArgs e)
        {
            bool top = true;
            bool bot = true;
            bool left = true;
            bool right = true;

            foreach(FrameworkElement block in block_list)
            {
                if (check_intersect(block))
                {
                    if(top == true)
                        top = bot_collision(intersect);
                    if (bot == true)
                        bot = top_collision(intersect);
                    if (left == true)
                        left = right_collision(intersect);
                    if (right == true)
                        right = left_collision(intersect);
                }
            }

            if(check_intersect(house1) || check_intersect(house3) || check_intersect(board) || check_intersect(door2) || check_intersect(door4) || check_intersect(Towild) || check_intersect(Totower))
            {
                if (enter.Visibility == Visibility.Hidden)
                {
                    enter.Visibility = Visibility.Visible;
                }

                Canvas.SetTop(enter, Canvas.GetTop(player) - 80);
                Canvas.SetLeft(enter, Canvas.GetLeft(player) - 30);

                if (goEnter == true && check_intersect(house1))
                {
                    MessageBox.Show("Not open yet !");
                    goEnter = false;
                }
                else if (goEnter == true && check_intersect(door2))
                {
                    MessageBox.Show("Here is the Pokemon Center");
                    goEnter = false;
                    flag = false;

                    pokemoncenter = new Center();
                    NavigationService.Navigate(pokemoncenter);
                }
                else if (goEnter == true && check_intersect(house3))
                {
                    MessageBox.Show("Not open yet !");
                    goEnter = false;
                }
                else if (goEnter == true && check_intersect(door4))
                {
                    MessageBox.Show("Here is the Pokemon Market");
                    goEnter = false;
                    flag = false;

                    market = new Market();
                    NavigationService.Navigate(market);
                }
                else if (goEnter == true && check_intersect(board))
                {
                    MessageBox.Show("Welcome to Verdanturf Town, here is IERG3800 village, [Left] [To battle tower] You can battle with other pokemon there, [Up] [To pokemon wild] You can catch pokemon there");
                    goEnter = false;
                }
                else if (goEnter == true && check_intersect(Towild))
                {
                    MessageBox.Show("To pokemon wild");
                    goEnter = false;
                    flag = false;

                    wild = new Wild();
                    NavigationService.Navigate(wild);
                }
                else if (goEnter == true && check_intersect(Totower))
                {
                    MessageBox.Show("To combat tower");
                    goEnter = false;
                    flag = false;

                    town_bot = new tower();
                    NavigationService.Navigate(town_bot);
                }
            }
            else
            {
                if (enter.Visibility == Visibility.Visible)
                    enter.Visibility = Visibility.Hidden;
            }

            if (goUp && Canvas.GetTop(player) > 0 && top)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - speed);
                // if go up is true and player is within the boundary from the top 
                // then we can use the set top to move the rec1 towards top of the screen
            }
            else if (goDown && Canvas.GetTop(player) + (player.Height * 2) < 600 && bot)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + speed);
                // if go down is true and player is within the boundary from the bottom of the screen
                // then we can set top of rec1 to move down
            }
            else if (goLeft && Canvas.GetLeft(player) > 0 + block1.Width && left)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
                // if go left is true and player is inside the boundary from the left
                // then we can set left of the player to move towards left of the screen
            }
            else if (goRight && Canvas.GetLeft(player) + player.Width < Canvas.GetLeft(block2) && right)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
                // if go right is true and player is inside the boundary from the right
                // then we can set left of the player to move towards right of the screen
            }

            if (flag == false)
            {
                dispatcherTimer.Tick -= Timer_Tick;
                dispatcherTimer.Stop();
                bgm1.Stop();
            }
            if (bgm1.Position > interval)
            {
                bgm1.Position = TimeSpan.Zero;
                bgm1.Play();
            }
        }
        private bool top_collision(FrameworkElement obj)
        {
            if (Canvas.GetTop(player) + player.Height > Canvas.GetTop(obj) && Canvas.GetTop(player) < Canvas.GetTop(obj))
                return false;
            return true;
        }
        private bool bot_collision(FrameworkElement obj)
        {
            if (Canvas.GetTop(player) < Canvas.GetTop(obj) + obj.Height && Canvas.GetTop(player) + player.Height > Canvas.GetTop(obj) + obj.Height)
                return false;
            return true;
        }
        private bool left_collision(FrameworkElement obj)
        {
            if (Canvas.GetLeft(player) + player.Width > Canvas.GetLeft(obj) && Canvas.GetLeft(player) < Canvas.GetLeft(obj))
                return false;
            return true;
        }
        private bool right_collision(FrameworkElement obj)
        {
            if (Canvas.GetLeft(player) < Canvas.GetLeft(obj) + obj.Width && Canvas.GetLeft(player) + player.Width > Canvas.GetLeft(obj) + obj.Width)
                return false;
            return true;
        }

        private bool check_intersect(FrameworkElement obj)
        {
            Rect player_hitbox = BoundsRelativeTo(player, Town);
            Rect block = BoundsRelativeTo(obj, Town);
            if (player_hitbox.IntersectsWith(block))
            {
                intersect = obj;
                return true;
            } 
            else return false;
        }
        public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        {
            return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        }
    }
}
