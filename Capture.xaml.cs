using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace IERG3080_____Pokemon_Go
{

    public partial class Capture : Page
    {
        Capture_Game game;
        private Pokemon target;
        private MediaPlayer bgm1 = new MediaPlayer();

        public Capture(Pokemon target)
        {
            InitializeComponent();

            string link = GetPicture.Source_mp3("catch_pokemon");
            bgm1.Open(new Uri(link, UriKind.Relative));
            bgm1.Volume = 0.1;
            bgm1.Play();

            this.target = target;
            game = new Capture_Game(target, progress_game, countdown, target_pokemon, pokemon_nametag);
        }

        private void Capture_button_Click(object sender, RoutedEventArgs e)
        {
            game.captureStop = true;

            bool start()
            {
                if (game.finished == true)
                {
                    game.finished = false;
                    return true;
                }
                return false;
            }

            void end()
            {
                if (game.isSuccess == true)
                {
                    ManagePokemon storage = ManagePokemon.GetInstance();
                    //target = target.Evolve();
                    storage.AddPokemon(target);
                    MessageBox.Show("[Lv: " + target.level + "] [Type: " + target.Get_type() + "] [Name: " + target.name + "]");
                }
                bgm1.Stop();
                map_info info = map_info.get_map();
                if(info.get_num() == 1)
                    NavigationService.Navigate(new Map());
                else if (info.get_num() == 4)
                    NavigationService.Navigate(new Wild());
            }
            
            CustomTimer t2 = new CustomTimer(1, start, end);
        }
    }

    public class Capture_Game
    {
        private ProgressBar progress_game;
        private Label countdown;
        private Image target_pokemon;
        private Pokemon target;
        private Label pokemon_nametag;

        private int counter;
        private int num_of_chance;

        public bool finished = false;
        public bool captureStop = false;
        public bool isSuccess = false;

        public Capture_Game(Pokemon target, ProgressBar progress_game, Label countdown, Image target_pokemon, Label pokemon_nametag)
        {
            this.progress_game = progress_game;
            this.countdown = countdown;
            this.target_pokemon = target_pokemon;
            this.target = target;
            this.pokemon_nametag = pokemon_nametag;

            //Set the number of chance before the pokemon is escaped
            Random rnd = new Random();
            num_of_chance = rnd.Next(1, 4);

            Reset();
        }

        private void Reset()
        {
            //Reset the value of progress bar
            counter = 0;

            //Reset the middle countdown timer
            countdown.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FFFFFF"));
            countdown.Content = "";

            //Reset the pokemon name tag
            pokemon_nametag.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CCFFFFFF"));
            pokemon_nametag.Content = target.name + " (Lv. " + target.level + ")";

            //Reset the progress bar
            progress_game.Value = 0;
            progress_game.Foreground = Brushes.Red;

            //Start the Progress Bar
            InitProgressBar();

            //Reset the pokemon image
            target_pokemon.Source = target.SetImage().Source;
        }

        private void InitProgressBar()
        {
            bool start()
            {
                if(captureStop == true)
                {
                    captureStop = false;
                    return true;
                }
                counter++;
                UpdateProgressBar();
                return false;
            }

            void end()
            {
                if (finished == false)
                {
                    CountDownAnimation();
                }
            }
            CustomTimer t = new CustomTimer(1, start, end);
        }

        private void UpdateProgressBar()
        {
            int cycle_time = 50;
            //Set the length of the progress bar
            int result = counter % cycle_time * 2;
            if (result <= cycle_time)
            {
                progress_game.Value = (double)result / cycle_time * 100;
            }
            else
            {
                progress_game.Value = (double)(cycle_time - (result - cycle_time)) / cycle_time * 100;
            }

            //Set the colour of the progress bar
            switch ((int) (progress_game.Value / 10))
            {
                case 0:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0000"));
                    break;
                case 1:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3300"));
                    break;
                case 2:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff6600"));
                    break;
                case 3:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff9900"));
                    break;
                case 4:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCC00"));
                    break;
                case 5:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFF00"));
                    break;
                case 6:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccff00"));
                    break;
                case 7:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#99ff00"));
                    break;
                case 8:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#66ff00"));
                    break;
                case 9:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FF00"));
                    break;
                default:
                    progress_game.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FF00"));
                    break;
            }
        }

        private void CountDownAnimation()
        {
            int i = 3;
            int result = CheckCaptureSuccess();
            void init()
            {
                countdown.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CCFFFFFF"));
                countdown.Content = 3;

                pokemon_nametag.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FFFFFF"));
                pokemon_nametag.Content = "";


                target_pokemon.Source = Pokeball_Image().Source;
                target_pokemon.Height /= 2;
                target_pokemon.Width /= 2;
            }

            bool start()
            {
                i--;
                countdown.Content = i;

                if (result != 1 && i<=2)
                {
                    Random rnd = new Random();
                    if (rnd.Next(0, 2) == 0)
                    {
                        return true;
                    }
                }

                if (i <= 0)
                {
                    countdown.Content = 1;
                    return true;
                }
                
                return false;
            }

            void end()
            {
                if(finished == false)
                {
                    countdown.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00FFFFFF"));
                    countdown.Content = "";
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Gotcha !\n The new pokemon has been added into your pokemon center !");
                            finished = true;
                            isSuccess = true;
                            break;
                        case 2:
                            target_pokemon.Source = Open_Pokeball_Image().Source;
                            MessageBox.Show("The Pokemon Escaped!");
                            void end()
                            {
                                finished = true;
                            }
                            CustomTimer t = new CustomTimer(750, end);
                            break;
                        case 3:
                            Reset();
                            target_pokemon.Height *= 2;
                            target_pokemon.Width *= 2;
                            MessageBox.Show("Try again!");
                            break;
                    }
                }
            }
            CustomTimer t = new CustomTimer(750, init, start, end);
        }

        private int CheckCaptureSuccess()
        {
            Random rnd = new Random();
            int temp = rnd.Next(0, 100);
            //The probability from left to right (each elements mean 10%), e.g. red means only 1% can catch the pokemon
            int[] probability_success = {1, 5, 10, 15, 20, 30, 35, 40, 60, 80, 100};

            // 1: gotcha; 2: Escaped; 3: Try again
            if (temp >= (100 - probability_success[(int)(progress_game.Value / 10)]))
            {
                return 1;
            }
            else
            {
                num_of_chance--;
                if (num_of_chance <= 0 && finished != true)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }

        private static Image Pokeball_Image()
        {
            return GetPicture.Source("pokeball");
        }

        private static Image Open_Pokeball_Image()
        {
            return GetPicture.Source("open_pokeball");
        }
    }
}