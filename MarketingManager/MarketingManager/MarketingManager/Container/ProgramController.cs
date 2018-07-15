using Data;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
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
            PackeageList.Add(new Packeage() { ID = 1, Money = 200, Title = "Haftalık 1 Saatlik Ders" });
            PackeageList.Add(new Packeage() { ID = 2, Money = 75, Title = "Dergi Desteği" });
            PackeageList.Add(new Packeage() { ID = 3, Money = 40, Title = "Kitap Desteği" });
            PackeageList.Add(new Packeage() { ID = 4, Money = 155, Title = "Video Desteği" });
            PackeageList.Add(new Packeage() { ID = 5, Money = 45, Title = "Proje Yönetim Sistemi Desteği" });
            PackeageList.Add(new Packeage() { ID = 6, Money = 400, Title = "Yarışma ve Etüt Desteği" });
        }
    }
}
