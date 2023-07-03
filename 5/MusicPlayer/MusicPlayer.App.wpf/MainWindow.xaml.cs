using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicPlayer.BLL;
using MusicPlayer.DI;
using MusicPlayer.Settings;

namespace MusicPlayer.App.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region DI - Внедрение зависимости
        private static Configuration _configuration;
        private IPlayer player;

        public static ISong CreateSong(string title, string artist, string file)
        {          
            var song = _configuration.Container.GetInstance<ISong>();
            song.Title = title;
            song.Artist = artist;
            song.FileName = file;

            var player = _configuration.Container.GetInstance<IPlayer>();
            player.AddSong(song);
            return song;
        }

        private static IPlayer CreatePlayer(string name)
        {
            var player = _configuration.Container.GetInstance<IPlayer>();

            return player;
        }

        public static IEnumerable<ISong> GetAllSongs()
        {
            var player = _configuration.Container.GetInstance<IPlayer>();
            var songs = player.GetAllSongs();
            return songs;
        }
        #endregion


        public MainWindow()
        {
            _configuration = new Configuration();
            InitializeComponent();
            ListBox_Songs.ItemsSource = GetAllSongs();
            ListBox_Songs.DisplayMemberPath = "Title";           
        }

        private void Btn_Play_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Songs.SelectedItem == null)
            {
                ListBox_Songs.SelectedIndex = 0;
            }
            var player = _configuration.Container.GetInstance<IPlayer>();
            player.Play();
            Label_Status.Content = "Играет:";
        }

        private void Btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Songs.SelectedItem != null)
            {
                var player = _configuration.Container.GetInstance<IPlayer>();
                player.Pause();
                Label_Status.Content = "Остановлена:";
            }
        }

        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Songs.SelectedItem != null)
            {
                var player = _configuration.Container.GetInstance<IPlayer>();
                player.Next();
                Label_CurrentSong.Content = $"Песня: {player.CurrentSong.Title} Исполнитель: {player.CurrentSong.Artist}";
                if (ListBox_Songs.SelectedIndex == ListBox_Songs.Items.Count - 1)
                {
                    ListBox_Songs.SelectedIndex = 0;
                }
                else
                {
                    ListBox_Songs.SelectedIndex++;
                }
            }
        }

        private void Btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Songs.SelectedItem != null)
            {
                var player = _configuration.Container.GetInstance<IPlayer>();
                player.Previous();
                Label_CurrentSong.Content = $"Песня: {player.CurrentSong.Title} Исполнитель: {player.CurrentSong.Artist}";
                if (ListBox_Songs.SelectedIndex == 0)
                {
                    ListBox_Songs.SelectedIndex = ListBox_Songs.Items.Count - 1;
                }
                else
                {
                    ListBox_Songs.SelectedIndex--;
                }
            }
        }

        private void Btn_AddSong_Click(object sender, RoutedEventArgs e)
        {
            Window_AddSong window_AddSong = new Window_AddSong();
            window_AddSong.Owner = this;
            window_AddSong.ShowDialog();
        }

        private void Btn_RemoveSong_Click(object sender, RoutedEventArgs e)
        {
            if(ListBox_Songs.SelectedItem != null)
            {
                var player = _configuration.Container.GetInstance<IPlayer>();
                player.Pause();
                player.RemoveSong((ISong)ListBox_Songs.SelectedItem);
                ListBox_Songs.ItemsSource = GetAllSongs();
                Label_CurrentSong.Content = "";
                Label_CurrentSongArtist.Content = "";
                Label_Status.Content = "Выберите песню";
            }
        }

        public void RefreshSongsView()
        {
            ListBox_Songs.ItemsSource = GetAllSongs();
        }

        private void ListBox_Songs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var player = _configuration.Container.GetInstance<IPlayer>();
            if(ListBox_Songs.SelectedItem == null)
            {
                if (ListBox_Songs.Items.Count == 0)
                {
                    Label_Status.Content = "Добавьте и выберите песню";
                    Label_CurrentSong.Content = "";
                }
                else
                {
                    Label_Status.Content = "Играет:";
                    player.Next();
                }
            }
            else
            {
                player.CurrentSong = (ISong)ListBox_Songs.SelectedItem;
                player.Open();
                player.Play();
                Label_Status.Content = "Играет:";
                Label_CurrentSong.Content = $"Песня: {player.CurrentSong.Title}";
                Label_CurrentSongArtist.Content = $"Исполнитель: {player.CurrentSong.Artist}";
                ListBox_Songs.SelectedItem = player.CurrentSong;
            }
        }
    }
}
