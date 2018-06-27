using MarketingManager.Components;
using MarketingManager.Container;
using MarketingManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MarketingManager.Pages
{
    public class ProcessPage : ContentPage
    {
        List<PackeageViewModel> SelectedList;
        Frame GridFrame;
        Label fiyatLbl;
        Entry entry;

        public ProcessPage()
        {
            SelectedList = new List<PackeageViewModel>();
            ToolbarItems.Add(new ToolbarItem() { Text = "Fiyatları Düzenle", Priority = 2, Command = new Command(EditPageNavigate) });
            GridFrame = new Frame();
            entry = new Entry() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Placeholder = "Öğrenci Sayısı Giriniz", Keyboard = Keyboard.Numeric, TextColor = ProgramController.EbirdColor };
            fiyatLbl = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Text = "0 TL", TextColor = ProgramController.EbirdColor };
            ComponentLoad();
        }

        private void ComponentLoad()
        {
            ScrollView sl = new ScrollView();
            StackLayout stackLayout = new StackLayout();
            sl.Content = stackLayout;

            stackLayout.Children.Add(Header());
            stackLayout.Children.Add(FormLoad());
            stackLayout.Children.Add(GridFrame);
            GridLoad();
            Content = sl;
        }

        private View Header()
        {
            Frame frame = new Frame();
            StackLayout stackLayout = new StackLayout() { Padding = 0, Spacing = 0 };
            frame.Content = stackLayout;

            stackLayout.Children.Add(new Image() { Source = "Assets/ebird small logo.png", Margin = 10, WidthRequest = 400, HeightRequest = 250 });
            //stackLayout.Children.Add(new Label() { Text = "ESOF Paket Özelleştirme Aracı", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 45, FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 0, 0, 10), TextColor = ProgramController.EbirdColor });

            return frame;
        }

        private View FormLoad()
        {
            Frame frame = new Frame() { BorderColor = ProgramController.EbirdColor, HorizontalOptions = LayoutOptions.Center };
            StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            StackLayout mainStack = new StackLayout();
            frame.Content = mainStack;

            stackLayout.Children.Add(entry);
            stackLayout.Children.Add(new Button() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BackgroundColor = ProgramController.EbirdColor, Text = "Hesapla", TextColor = Color.White, Command = new Command(Calculate) });

            mainStack.Children.Add(stackLayout);
            mainStack.Children.Add(fiyatLbl);
            return frame;
        }

        private void GridLoad()
        {
            DynamicGrid dynamicGrid = new DynamicGrid(2) { Margin = 5 };
            dynamicGrid.AddView(PageLeft());
            dynamicGrid.AddView(PageRight());

            GridFrame.Content = dynamicGrid;
        }

        private View PageRight()
        {
            Frame frame = new Frame() { BorderColor = ProgramController.EbirdColor };
            StackLayout gridRightStackLayout = new StackLayout();

            frame.Content = gridRightStackLayout;
            gridRightStackLayout.Children.Add(new Label() { Text = "Eklenen Özellikler", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 30, FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 0, 0, 10), TextColor = ProgramController.EbirdColor });
            foreach (var item in SelectedList)
            {
                StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.Center };
                stackLayout.Children.Add(new Button() { VerticalOptions = LayoutOptions.Center, BackgroundColor = ProgramController.EbirdColor, Text = "-", TextColor = Color.White, FontAttributes = FontAttributes.Bold, CornerRadius = 20, WidthRequest = 40, HeightRequest = 40, Command = new Command(DecreaseButtonClick), CommandParameter = item });
                stackLayout.Children.Add(new Label() { VerticalOptions = LayoutOptions.Center, Text = item.Model.Title });
                stackLayout.Children.Add(new Label() { VerticalOptions = LayoutOptions.Center, Text = $"{item.Quantity} adet" });
                gridRightStackLayout.Children.Add(stackLayout);
            }
            return frame;
        }

        private View PageLeft()
        {
            Frame frame = new Frame() { BorderColor = ProgramController.EbirdColor };
            StackLayout gridLeftStackLayout = new StackLayout();

            frame.Content = gridLeftStackLayout;
            gridLeftStackLayout.Children.Add(new Label() { Text = "Eklenebilecek Özellikler", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 30, FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 0, 0, 10), TextColor = ProgramController.EbirdColor });
            foreach (var item in ProgramController.PackeageList)
            {
                StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.Center };
                stackLayout.Children.Add(new Button() { VerticalOptions = LayoutOptions.Center, BackgroundColor = ProgramController.EbirdColor, Text = "+", TextColor = Color.White, FontAttributes = FontAttributes.Bold, CornerRadius = 20, WidthRequest = 40, HeightRequest = 40, Command = new Command(AddButtonClick), CommandParameter = item });
                stackLayout.Children.Add(new Label() { VerticalOptions = LayoutOptions.Center, Text = item.Title });
                gridLeftStackLayout.Children.Add(stackLayout);
            }
            return frame;
        }

        private void AddButtonClick(object obj)
        {
            Packeage packeage = (Packeage)obj;
            if (SelectedList.Any(i => i.Model == packeage))
            {
                SelectedList.First(i => i.Model.ID == packeage.ID).Quantity++;
            }
            else
            {
                SelectedList.Add(new PackeageViewModel() { Model = packeage, Quantity = 1 });
            }
            GridLoad();
        }

        private void DecreaseButtonClick(object sender)
        {
            PackeageViewModel packeage = (PackeageViewModel)sender;
            if (packeage.Quantity == 1)
            {
                SelectedList.Remove(packeage);
            }
            else
            {
                packeage.Quantity--;
            }
            GridLoad();
        }

        private void Calculate(object obj)
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                fiyatLbl.Text = "Bu alan boş geçilemez. Lütfen öğrenci sayısı giriniz!";
                return;
            }
            try
            {
                int deger = Int32.Parse(entry.Text);
                float value = SelectedList.Sum(i => i.Model.Money * i.Quantity);
                fiyatLbl.Text = $"{Discont(deger, value)} TL";
            }
            catch
            {
                fiyatLbl.Text = "Hatalı giriş yaptınız. Lütfen sadece sayı giriniz!";
                entry.Text = "";
            }
        }

        private float Discont(int student, float money)
        {
            float result = student * money;
            float discont = 0;
            if (student > 150)
            {
                discont = 30f / 100f * result;
            }
            else if (student > 100)
            {
                discont = 20f / 100f * result;
            }
            else if (student > 50)
            {
                discont = 10f / 100f * result;
            }
            result -= discont;
            return result;
        }

        private void EditPageNavigate(object obj)
        {
            Navigation.PushAsync(new EditPage());
        }
    }
}