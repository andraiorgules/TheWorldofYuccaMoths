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

/*
 * The World of Yucca Moths
 * Andrada Iorgulescu, May 8, 2022
 * Credits
 * - Environment class code from PROG 201 Data Binding class demo
 * - Entity class populated with code from Prog201 Event Handlers in-class demo
 * - Utility class code from Prog201 in-class demo
 * - Code for loading from XML files based on Prog201 Week 9 in-class demo
 * - Code for WeatherEvent class based on Prog201 in-class demo
 */

namespace TheWorldOfYuccaMoths
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Environment Desert = new Environment();
        Player player = new Player();
        Vendor vendor = new Vendor();

        public MainWindow()
        {
            InitializeComponent();
            EnvironmentName.DataContext = Desert;
            SetUpPlayer();
            SetUpVendor();
            //add code to make the output box display multiple sources
            Output.Text = Desert.Status.ToString();
        }

        private void SetUpPlayer()
        {
            player.Name = "Anonymous Player";
            player.Inventory = Player.LoadPlayerInventory();
            PlayerInventory.DataContext = player.Inventory;
            PlayerNameInventory.DataContext = $" {player.Name} 's Inventory ";
        }

        private void SetUpVendor()
        {
            vendor.Name = "Vendor";
            vendor.Inventory = Vendor.LoadVendorInventory();
            VendorInventory.DataContext = vendor.Inventory;
            VendorNameInventory.DataContext = $" {vendor.Name} 's Inventory";
        }


        //Example code from PROG 201 Event Handlers class demo
        private void UpdateEnvironmentInformation()
        {
            // .....
            foreach (Entity e in Desert.Entities)
            {
                //only update player about the entities that aren't the player and vendor
                if (e.Species.ToLower() != "human")
                    UpdatePlayerOnRatios(e);
            }

        }
        {//Example code from PROG 201 Event Handlers class demo
        private void UpdatePlayerOnRatios(Entity entity)
        {
            entity.AmountChanged += entity.Entity_AmountChanged;

            if (entity.Status != "")
            {
                string current = Output.Text;
                Output.Text = $"Day {Desert.CurrentDay}: {entity.Status}\n" + current;
            }
        }

        private void PlantButton_Click(object sender, RoutedEventArgs e)
        {
            player.Plant();
        }

        private void NextInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            //display next item in player's inventory
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            player.Sell(item);
        }

        private void NextStoreItem_Click(object sender, RoutedEventArgs e)
        {
            //display next item in vendor's inventory
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            player.Buy(item);
        }

        private void HarvestButton_Click(object sender, RoutedEventArgs e)
        {
            player.Harvest();
        }

        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            player.Feed();
        }

        //set up indicator in MainWindow.xaml
        //example code from Prog201 enums demo
        private Brush GetWeatherIndicatorBrush()
        {
            if (WeatherEvent.CurrentWeather == WeatherType.Sunny)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else if (WeatherEvent.CurrentWeather == WeatherType.Cloudy)
            {
                return new SolidColorBrush(Colors.Gray);
            }
            else if (WeatherEvent.CurrentWeather == WeatherType.Rainy)
            {
                return new SolidColorBrush(Colors.DarkGray);
            }
            return Normal;
        }
        //Protoype goals:
        //figure out how to harvest something because i said in the first playtest that it's possible


    }
}
