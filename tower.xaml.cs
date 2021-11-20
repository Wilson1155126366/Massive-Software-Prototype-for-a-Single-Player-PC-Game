﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace IERG3080_____Pokemon_Go
{
    /// <summary>
    /// Interaction logic for tower.xaml
    /// </summary>
    public partial class tower : Page
    {
        Map map_town;
        GymBattle battle;
        Top tower_top;

        int speed = 5; // declaring an integer called speed with value of 5
        bool goUp; // this is the go up boolean
        bool goDown; // this is the go down boolean
        bool goLeft; // this is the go left boolean
        bool goRight; // this is the go right boolean
        bool goEnter;

        private MediaPlayer bgm1 = new MediaPlayer();
        private TimeSpan interval = new TimeSpan(0, 4, 8);
        bool flag = true;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public tower()
        {
            InitializeComponent();

            player.Source = (GetPicture.Source("player_back")).Source;
            center_map.Source = (GetPicture.Source("tower_bot")).Source;
            enter.Source = (GetPicture.Source("Enter")).Source;

            string link = GetPicture.Source_mp3("cave");
            bgm1.Open(new Uri(link, UriKind.Relative));
            bgm1.Volume = 0.1;
            bgm1.Play();

            map_info info = map_info.get_map();
            if (info.get_num() == 5)
            {
                Canvas.SetTop(player, info.get_x());
                Canvas.SetLeft(player, info.get_y());
            }

            Create_list();

            timer();
        }
        public List<FrameworkElement> block_list = new List<FrameworkElement>();
        private void Create_list()
        {
            block_list.Add(block3);
        }
        private void timer()
        {
            dispatcherTimer = new DispatcherTimer(); // adding the timer to the form
            dispatcherTimer.Tick += Timer_Tick; // linking the timer event
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20); // running the timer every 20 milliseconds
            dispatcherTimer.Start(); // starting the timer
        }

        private void Tutor_Click(object sender, RoutedEventArgs e)
        {
            rect1.Source = (GetPicture.Source("red")).Source;
            rect1.Visibility = Visibility.Visible;

            MessageBox.Show("You can running around in the cave, then some evil pokemon will have chance to notice you, you would not get into battle if you dont move, then you will need to fight with them if you want to move forward, and you can earn money from winning the battle, you can go into the boss room at the end of the road (the red rectangular area). The method to let you get into battle is same as the Gameboy or 3DS version.");
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = true; // down key is pressed go down will be true
                player.Source = (GetPicture.Source("player_front")).Source;
            }
            else if (e.Key == Key.Up)
            {
                goUp = true; // up key is pressed go up will be true
                player.Source = (GetPicture.Source("player_back")).Source;
            }
            else if (e.Key == Key.Left)
            {
                goLeft = true; // left key is pressed go left will be true
                player.Source = (GetPicture.Source("player_left")).Source;
            }
            else if (e.Key == Key.Right)
            {
                goRight = true; // right key is pressed go right will be true
                player.Source = (GetPicture.Source("player_right")).Source;
            }

            if (e.Key == Key.Enter)
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
        private int count = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            bool top = true;
            bool bot = true;
            bool left = true;
            bool right = true;

            foreach (FrameworkElement block in block_list)
            {
                if (check_intersect(block))
                {
                    if (top == true)
                        top = bot_collision(intersect);
                    if (bot == true)
                        bot = top_collision(intersect);
                    if (left == true)
                        left = right_collision(intersect);
                    if (right == true)
                        right = left_collision(intersect);
                }
            }

            if (check_intersect(exit) || check_intersect(exit2))
            {
                if (enter.Visibility == Visibility.Hidden)
                {
                    enter.Visibility = Visibility.Visible;
                }

                Canvas.SetTop(enter, Canvas.GetTop(player) - 80);
                Canvas.SetLeft(enter, Canvas.GetLeft(player) - 30);

                if (goEnter == true && check_intersect(exit))
                {
                    goEnter = false;
                    flag = false;

                    map_info info = map_info.get_map();
                    info.set_map(300, 210, 1);

                    map_town = new Map();
                    NavigationService.Navigate(map_town);
                }
                else if (goEnter == true && check_intersect(exit2))
                {
                    goEnter = false;
                    flag = false;

                    MessageBox.Show("You go to the top of the tower");

                    tower_top = new Top();
                    NavigationService.Navigate(tower_top);
                }
            }
            else
            {
                if (enter.Visibility == Visibility.Visible)
                    enter.Visibility = Visibility.Hidden;
            }

            if (check_intersect(bushes1) || check_intersect(bushes2))
            {
                if ((check_intersect(bushes1) || check_intersect(bushes2)) && (goUp || goDown || goLeft || goRight))
                {
                    count++;
                    if (count > 100)
                    {
                        goUp = false;
                        goDown = false;
                        goLeft = false;
                        goRight = false;
                        count = 0;

                        MessageBox.Show("You meet an evil Pokemon which is uncatchable, fight !");
                        flag = false;

                        map_info info = map_info.get_map();
                        info.set_map(Canvas.GetTop(player), Canvas.GetLeft(player), 5);

                        Pokemon player2 = Pokemon.RandomPokemon();
                        ManagePokemon player_pokemon = ManagePokemon.GetInstance();

                        battle = new GymBattle(player_pokemon.MainPokemon, player2);
                        NavigationService.Navigate(battle);
                    }
                }
            }

            if (goUp && Canvas.GetTop(player) > 50 && top)
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
            Rect player_hitbox = BoundsRelativeTo(player, Tower_map);
            Rect block = BoundsRelativeTo(obj, Tower_map);
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
