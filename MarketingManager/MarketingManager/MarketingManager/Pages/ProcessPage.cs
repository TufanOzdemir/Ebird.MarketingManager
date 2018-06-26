using MarketingManager.Container;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarketingManager.Pages
{
    public class ProcessPage : ContentPage
    {
        public ProcessPage()
        {
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            Frame frame = new Frame() { BorderColor = ProgramController.EbirdColor, Margin = new Thickness(10, 10, 800, 500) };
            StackLayout mainStackLayout = new StackLayout();

            frame.Content = mainStackLayout;

            foreach (var item in ProgramController.PackeageList)
            {
                StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.Center };
                stackLayout.Children.Add(new Button() { VerticalOptions = LayoutOptions.Center, BackgroundColor = ProgramController.EbirdColor, Text = "+", TextColor = Color.White, FontAttributes = FontAttributes.Bold, CornerRadius = 20, WidthRequest = 40, HeightRequest = 40, Command = new Command(AddButtonClick), CommandParameter = item.ID });
                stackLayout.Children.Add(new Label() { VerticalOptions = LayoutOptions.Center, Text = item.Title });
                mainStackLayout.Children.Add(stackLayout);
            }
            Content = frame;
        }

        private void AddButtonClick(object sender)
        {
            int btn = (int)sender;
        }
    }
}
