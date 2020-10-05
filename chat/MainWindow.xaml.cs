using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Newtonsoft.Json;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static string username;
        public static string targetName;
        public static string chatUrl = "https://chat-ucla.herokuapp.com/chats";
        public static string dmUrl = "https://chat-ucla.herokuapp.com/direct_message?sender=";

        static List<Blocked> blockedUsers = new List<Blocked>();

        static List<Messages> chatMessages = new List<Messages>();
        static List<Messages> dmMessages = new List<Messages>();

        public MainWindow()
        {
            InitializeComponent();
            HideAll();
            grid_sign_in.Visibility = Visibility.Visible;
            try
            {
                using (var reader = new StreamReader(@"blocked.csv"))
                {
                    string line = reader.ReadToEnd();
                    blockedUsers = JsonConvert.DeserializeObject<List<Blocked>>(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            GetAsyncChat();
        }

        public static async void GetAsyncChat ()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(chatUrl);
                string json_data = await response.Content.ReadAsStringAsync();
                chatMessages = JsonConvert.DeserializeObject<List<Messages>>(json_data);
            }
            var matchedBlocks = blockedUsers.Where(b => b.Username == username).
                Select(b => b.BlockedName).ToList();
            foreach (string blockedUser in matchedBlocks)
            {
                foreach (var message in chatMessages.Where(m => m.Fields.Username == blockedUser))
                {
                    message.Fields.Message = "***blocked***";
                }
            }
        }

        public static async void GetAsyncDM ()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(dmUrl + username + "&receiver=" + targetName);
                string json_data = await response.Content.ReadAsStringAsync();
                dmMessages = JsonConvert.DeserializeObject<List<Messages>>(json_data);
            }
        }

        private async void PostAsAsyncChat()
        {
            var message = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("username", username),
               new KeyValuePair<string, string>("message", txt_chat.Text)
            });

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(chatUrl, message);
                string json_data = await response.Content.ReadAsStringAsync();
            }

            txt_chat.Text = string.Empty;
        }

        private async void PostAsAsyncDM()
        {
            var message = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("sender", username),
               new KeyValuePair<string, string>("receiver", targetName),
               new KeyValuePair<string, string>("message", txt_direct_message.Text)
            });

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(
                    dmUrl + username + "&receiver=" + targetName, message);
                string json_data = await response.Content.ReadAsStringAsync();
            }

            txt_direct_message.Text = string.Empty;
        }

        private void HideAll()
        {
            grid_sign_in.Visibility = Visibility.Hidden;
            grid_block.Visibility = Visibility.Hidden;
            grid_chat.Visibility = Visibility.Hidden;
            grid_direct_message1.Visibility = Visibility.Hidden;
            grid_direct_message2.Visibility = Visibility.Hidden;
            grid_search.Visibility = Visibility.Hidden;
        }

        private void btn_sign_in_Click(object sender, RoutedEventArgs e)
        {
            if (txt_sign_in.Text != null)
            {
                username = txt_sign_in.Text;
                btn_menu_chat_Click(sender, e);
            }
        }
        private void txt_sign_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_sign_in_Click(sender, e);
            }
        }

        private void btn_chat_Click(object sender, RoutedEventArgs e)
        {
            PostAsAsyncChat();
            btn_menu_chat_Click(sender, e);
        }

        private void txt_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_chat_Click(sender, e);
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            lb_search.ItemsSource = chatMessages.Where(m => m.Fields.Message.ToLower().
                Contains(txt_search.Text.ToLower())).
                Select(m => m.Fields.Username + ": " + m.Fields.Message).ToList();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_search_Click(sender, e);
            }
        }

        private void btn_menu_search_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            grid_search.Visibility = Visibility.Visible;
            GetAsyncChat();
            lb_search.ItemsSource = chatMessages.
                Select(m => m.Fields.Username + ": " + m.Fields.Message).ToList();
        }

        private void btn_menu_chat_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            grid_chat.Visibility = Visibility.Visible;
            GetAsyncChat();
            lb_chat.ItemsSource = chatMessages.
                Select(m => m.Fields.Username + ": " + m.Fields.Message).ToList();
        }

        private void btn_menu_direct_message_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            grid_direct_message1.Visibility = Visibility.Visible;
        }

        private void btn_menu_block_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            grid_block.Visibility = Visibility.Visible;
            lb_block.ItemsSource = blockedUsers.Where(b => b.Username == username).
                Select(b => b.BlockedName).ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var blocked = blockedUsers;
            string serializedJson = JsonConvert.SerializeObject(blocked);
            var csv = new StringBuilder();
            csv.AppendLine(serializedJson);
            File.WriteAllText(@"blocked.csv", csv.ToString());
        }

        private void btn_block_Click(object sender, RoutedEventArgs e)
        {
            blockedUsers.Add(new Blocked(username, txt_block.Text));
            txt_block.Text = string.Empty;
            lb_block.ItemsSource = blockedUsers.Where(b => b.Username == username).
                Select(b => b.BlockedName).ToList();
        }

        private void txt_block_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_block_Click(sender, e);
            }
        }

        private void btn_remove_block_Click(object sender, RoutedEventArgs e)
        {
            if (lb_block.SelectedItem != null)
            {
                blockedUsers.RemoveAll(b => b.Username == username & 
                    b.BlockedName == lb_block.SelectedItem.ToString());
            }
            lb_block.ItemsSource = blockedUsers.Where(b => b.Username == username).
                Select(b => b.BlockedName).ToList();
        }

        private void btn_dm_user_Click(object sender, RoutedEventArgs e)
        {
            if (txt_dm_user != null)
            {
                targetName = txt_dm_user.Text;
                HideAll();
                grid_direct_message2.Visibility = Visibility.Visible;
                GetAsyncDM();
                if (blockedUsers.Where(b => b.Username == username).
                    Select(b => b.BlockedName).ToList().Contains(targetName))
                {
                    lb_direct_message.ItemsSource = dmMessages.
                        Select(d => d.Fields.Sender + ": ***blocked***").ToList();
                } else
                {
                    lb_direct_message.ItemsSource = dmMessages.
                        Select(d => d.Fields.Sender + ": " + d.Fields.Message).ToList();
                }
            }
        }

        private void txt_dm_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_dm_user_Click(sender, e);
            }
        }

        private void btn_direct_message_Click(object sender, RoutedEventArgs e)
        {
            PostAsAsyncDM();
            btn_dm_user_Click(sender, e);
        }

        private void txt_direct_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_direct_message_Click(sender, e);
            }
        }
    }

    internal class Messages
    {
        public string Model { get; set; }
        public int Pk { get; set; }
        public FieldChat Fields { get; set; }
    }

    internal class FieldChat
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string Username { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Created_at { get; set; }
    }

    internal class Blocked
    {
        public string Username { get; set; }
        public string BlockedName { get; set; }

        public Blocked(string username, string blockedName)
        {
            Username = username;
            BlockedName = blockedName;
        }
    }
}