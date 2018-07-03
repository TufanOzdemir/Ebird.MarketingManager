using MarketingManager.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarketingManager.Container
{
    public class ProgramController
    {
        public static List<Packeage> PackeageList;
        public static Color EbirdColor;

        public ProgramController()
        {
            EbirdColor = Color.FromHex("#00A0E3");

            PackeageList = new List<Packeage>();
            PackeageList.Add(new Packeage() { ID = 1, Money = 150, Title = "Haftalık 1 Saatlik Ders" });
            PackeageList.Add(new Packeage() { ID = 2, Money = 120, Title = "Dergi Desteği" });
            PackeageList.Add(new Packeage() { ID = 3, Money = 85, Title = "Kitap Desteği" });
            PackeageList.Add(new Packeage() { ID = 4, Money = 110, Title = "Video Desteği" });
            PackeageList.Add(new Packeage() { ID = 5, Money = 45, Title = "Proje Yönetim Sistemi Desteği" });
            PackeageList.Add(new Packeage() { ID = 6, Money = 80, Title = "Yarışma ve Etüt Desteği" });
            //PackeageList.Add(new Packeage() { ID = 7, Money = 30, Title = "Sertifikalı Eğitmen Geliştirme Desteği" });
        }
    }
}
