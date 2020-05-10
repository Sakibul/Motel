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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Motel
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

        private void btnRoomEdit_Click(object sender, RoutedEventArgs e)
        {
            service.RoomService roomService = new service.RoomService();
            
            Room room = new Room();
            room.RoomId = Byte.Parse(txtRoomRoomId.Text);
            room.Type = txtRoomType.Text;
            room.NoOfBeds = Byte.Parse(txtRoomNoOfBeds.Text);
            room.Availability = (chkRoomAvailability.IsChecked == true);
            room.RatePerDay = Decimal.Parse(txtRoomRatePerDay.Text);

            roomService.EditRoom(room);

            MessageBox.Show("Room has been updated. Please reload Grid.");
        }

        private void btnRoomAdd_Click(object sender, RoutedEventArgs e)
        {
            service.RoomService roomService = new service.RoomService();

            Room room = new Room()
            {
                Type = txtRoomType.Text,
                NoOfBeds = Byte.Parse(txtRoomNoOfBeds.Text),
                Availability = (chkRoomAvailability.IsChecked == true),
                RatePerDay = Decimal.Parse(txtRoomRatePerDay.Text)
            };

            roomService.AddRoom(room);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            service.RoomService roomService = new service.RoomService();
            this.DataContext = roomService.GetAllRooms();
        }

        private void dataGridRoom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = dataGridRoom.SelectedItem;

            txtRoomRoomId.Text = (dataGridRoom.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            txtRoomType.Text = (dataGridRoom.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            txtRoomNoOfBeds.Text = (dataGridRoom.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            //chkRoomAvailability.Text = (dataGridRoom.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            txtRoomRatePerDay.Text = (dataGridRoom.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void btnRoomLoadGrid_Click(object sender, RoutedEventArgs e)
        {
            service.RoomService roomService = new service.RoomService();
            this.DataContext = roomService.GetAllRooms();
        }
    }
}
