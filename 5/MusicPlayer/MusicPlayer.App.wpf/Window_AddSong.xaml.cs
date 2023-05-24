using MusicPlayer.BLL;
using MusicPlayer.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayer.App.wpf
{
    /// <summary>
    /// Логика взаимодействия для Window_AddSong.xaml
    /// </summary>
    public partial class Window_AddSong : Window
    {
        public Window_AddSong()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var title = TextBox_Title.Text;
            var artist = TextBox_Artist.Text;
            if (title.Length == 0 || artist.Length == 0)
            {
                MessageBox.Show("Поля Название и Исполнитель не могут быть пустыми!"); return;
            }
            MainWindow.CreateSong(title, artist);
            var own = (MainWindow)this.Owner;
            own.RefreshSongsView();
            this.DialogResult = true;
        }
    }
}
