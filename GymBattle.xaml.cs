using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace IERG3080_____Pokemon_Go
{
    public partial class GymBattle
    {
        Battle game;
        private int player1_init_hp;
        private int player2_init_hp;
        private Pokemon player1;
        private Pokemon player2;
        private MediaPlayer bgm1 = new MediaPlayer();

        public GymBattle(Pokemon player1, Pokemon player2)
        {
            InitializeComponent();

            this.player1 = player1;
            this.player2 = player2;
            player1.getHP();
            player2.getHP();
            InitLabel();
            InitProgressBar();
            UpdatePlayerItem();

            Button[] buttons = new Button[4];
            for (int i = 0; i < 4; i++)
            {
                buttons[i] = actions.Children[i] as Button;
            }

            attackboard.Text = "";

            game = new Battle(player1, player2, buttons, attackboard);

            player1_pokemon.Source = player1.SetImage().Source;
            player2_pokemon.Source = player2.SetImage().Source;
            player1_name.Content = player1.name.ToString() + " (Lv. " + player1.level + ")";
            player2_name.Content = player2.name.ToString() + " (Lv. " + player2.level + ")";

            CheckGameFinish();

            map_info info = map_info.get_map();
            string link;
            if (info.get_num() == 7)
            {
                link = GetPicture.Source_mp3("boss");
                bgm1.Open(new Uri(link, UriKind.Relative));
                bgm1.Volume = 0.1;
            }
            else
            {
                link = GetPicture.Source_mp3("fight");
                bgm1.Open(new Uri(link, UriKind.Relative));
                bgm1.Volume = 0.05;
            }

            bgm1.Play();
        }

        private void CheckGameFinish() 
        {
            bool Procedure()
            {
                UpdateLabel();
                UpdateProgressBar();
                UpdatePlayerItem();

                if (game.finished == true)
                {
                    game.finished = false;
                    return true;
                }

                return false;
            }

            void End()
            {
                if (game.isWin)
                {
                    ManagePokemon storage = ManagePokemon.GetInstance();
                    storage.GetCoin(100);
                    MessageBox.Show("[+$100] You win !");
                    storage.MainPokemon.getHP();
                }
                else
                {
                    ManagePokemon storage = ManagePokemon.GetInstance();
                    MessageBox.Show("You lose!");
                    storage.MainPokemon.getHP();
                }  
                bgm1.Stop();
                map_info info = map_info.get_map();
                if (info.get_num() == 1)
                    NavigationService.Navigate(new Map());
                else if (info.get_num() == 5)
                    NavigationService.Navigate(new tower());
                else if (info.get_num() == 6)
                    NavigationService.Navigate(new Top());
                
                if (info.get_num() == 7 && game.isWin == true)
                {
                    Pokemon target = Pokemon.Boss(1);
                    ManagePokemon storage = ManagePokemon.GetInstance();
                    storage.AddPokemon(target);

                    MessageBox.Show("You beat the boss, you got Legendary Pokemon [Lv: " + target.level + "] [Type: " + target.Get_type() + "] [Name: " + target.name + "], it is transferred to your pokemon storage");
                    NavigationService.Navigate(new Top());
                }
                else if (info.get_num() == 7 && game.isWin == false)
                {
                    MessageBox.Show("Come back later when you become stronger !");
                    NavigationService.Navigate(new Top());
                }
            }
            CustomTimer t = new CustomTimer(1, Procedure, End);
        }

        private void InitLabel()
        {
            player1_init_hp = player1.HP;
            player2_init_hp = player2.HP;

            UpdateLabel();
        }

        private void InitProgressBar()
        {
            player1_bar.Value = 100;
            player2_bar.Value = 100;
            player1_bar.Foreground = Brushes.LimeGreen;
            player2_bar.Foreground = Brushes.LimeGreen;
        }

        private void UpdateLabel()
        {
            player1_hp.Content = "HP: " + player1.HP.ToString() + " / " + player1_init_hp.ToString();
            player2_hp.Content = "HP: " + player2.HP.ToString() + " / " + player2_init_hp.ToString();
        }

        private void UpdateProgressBar()
        {
            player1_bar.Value = (double)player1.HP / (double)player1_init_hp * 100;
            if (player1_bar.Value <= 30)
            {
                player1_bar.Foreground = Brushes.Red;
            }
            else
            {
                player1_bar.Foreground = Brushes.LimeGreen;
            }

            player2_bar.Value = (double)player2.HP / (double)player2_init_hp * 100;
            if (player2_bar.Value <= 30)
            {
                player2_bar.Foreground = Brushes.Red;
            }
            else
            {
                player2_bar.Foreground = Brushes.LimeGreen;
            }
        }

        private void UpdatePlayerItem()
        {
            if (player1.Special_skills == true)
            {
                player1_item1.Source = player1.SetItemImage().Source;
            }
            else
            {
                player1_item1.Source = null;
            }

            if (player2.Special_skills == true)
            {
                player2_item1.Source = player2.SetItemImage().Source;
            }
            else
            {
                player2_item1.Source = null;
            }
        }
    }

    public class Battle
    {
        public bool finished = false;

        private Pokemon player1;
        private Pokemon player2;
        private Pokemon currentPlayer;
        private readonly Button[] buttons;
        private TextBlock attackboard;
        private int textcounter = 0;
        public bool isWin = false;

        public Battle(Pokemon player1, Pokemon player2, Button[] buttons, TextBlock attackboard)
        {
            this.player1 = player1;
            this.player2 = player2;
            currentPlayer = player1;

            this.attackboard = attackboard;
            this.buttons = buttons;

            for (int i = 0; i < 4; i++)
            {
                buttons[i].Click += new RoutedEventHandler(Attack);
            }

            textcounter = 0;

            for (int i = 0; i < 4; i++)
            {
                buttons[i].Tag = i;
                buttons[i].Content = player1.actionList[i];
            }
        }

        private void UpdateAttackBoard(string message, int option)
        {
            if (option == 0)
            {
                textcounter++;
                var lines = (from item in attackboard.Text.Split('\n') select item.Trim());
                if (textcounter > 10)
                {
                    lines = lines.Skip(1);
                }
                attackboard.Text = string.Join(Environment.NewLine, lines.ToArray());

                string message1 = "Round " + ((textcounter + 1) / 2) + ": " + currentPlayer.name + " used " + message;
                attackboard.Text += message1;
            }
            else if (option == 1)
            {
                string message1 = "";
                Pokemon opponent = currentPlayer == player1 ? player2 : player1;
                if (message == "0" && opponent.Special_skills == false)
                {
                    message1 = ("(" + opponent.name + " Successfully Avoided the attack.)\n").ToString();
                }
                else if(message != "0")
                {
                    message1 = " (HP ";
                    message1 += "-" + Math.Abs(Int32.Parse(message)).ToString() + ")\n";
                }
                else
                {
                    message1 = "\n";
                }

                attackboard.Text += message1;
            }
            
        }

        private void Attack(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (currentPlayer == player1)
            {
                AttackMode((int)button.Tag);
            }
        }

        private void AttackMode(int attackmode)
        {
            if (CheckWin() == 0)
            {
                Pokemon.Skills Skill = null;
                switch (attackmode)
                {
                    case 0:
                        Skill = currentPlayer.action1;
                        break;
                    case 1:
                        Skill = currentPlayer.action2;
                        break;
                    case 2:
                        Skill = currentPlayer.action3;
                        break;
                    case 3:
                        Skill = currentPlayer.action4;
                        break;
                    default:
                        break;
                }
                int damage = Skill();

                UpdateAttackBoard(currentPlayer.actionList[attackmode].ToString(), 0);
                SwitchPlayer(damage);
            }
        }

        private void ComputerMove()
        {
            void End()
            {
                Random rnd = new Random();
                int temp = rnd.Next(0, 4);
                AttackMode(temp);
            }
            CustomTimer t = new CustomTimer(750, End);
        }

        private void SwitchPlayer(int damage)
        {
            if(currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }

            if (currentPlayer == player2)
            {
                ComputerMove();
            }

            currentPlayer.setHP(damage);
            UpdateAttackBoard((damage).ToString(), 1);

            if (finished == false)
            {
                switch (CheckWin())
                {
                    case 0:
                        return;
                    case 1:
                        MessageBox.Show(currentPlayer.name + " Wins!");
                        break;
                    case 2:
                        MessageBox.Show(player2.name + " Wins!");
                        break;
                    case 3:
                        MessageBox.Show(player1.name + " Wins!");
                        break;
                }
                finished = true;
            }
        }

        private int CheckWin()
        {
            if (player1.HP <= 0 && player2.HP <= 0)
            {
                return 1;
            }
            else if (player1.HP <= 0)
            {  
                return 2;
            }
            else if (player2.HP <= 0)
            {
                isWin = true;
                return 3;
            }
            return 0;
        }
    }
}
