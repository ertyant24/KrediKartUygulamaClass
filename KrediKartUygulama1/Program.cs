using System.Diagnostics.SymbolStore;

namespace KrediKartUygulama1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secim = "";

            do
            {
                
                MenuYaz();
                Console.WriteLine("");
                Console.Write("Lütfen Seçim Yapınız : ");
                secim = Console.ReadLine();


                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Bankamatik Kartı Seçildi.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Kredi Kartı Platinium Seçildi.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Kredi Kartı Gold Seçildi.");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Kredi Kartı Silver Seçildi.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Lütfen Klavye'de [1] ile [4] arasında bir seçim yapınız.");
                        break;
                }

            } while (secim != "0");

            if (secim == "0")
            {
                Console.Clear();
                Console.WriteLine("Çıkış Yapılıyor...");
                Console.WriteLine("");
                Console.WriteLine("Herhangi bir tuşa bastığınızda uygulamadan ayrılacaksınız.");
            }

        }


        public static void MenuYaz()
        {
            Console.Clear();

            Console.WriteLine(" MENÜ");
            Console.WriteLine(" ****");
            Console.WriteLine("");
            Console.WriteLine("  1 - Bankamatik");
            Console.WriteLine("  2 - Kredi Kartı(Platinium)");
            Console.WriteLine("  3 - Kredi Kartı(Gold)");
            Console.WriteLine("  4 - Kredi Kartı(Silver)");
            Console.WriteLine("----");
            Console.WriteLine("0 - Çıkış");
            Console.WriteLine("");

        }


        public enum KartTuru
        {
            Visa,
            Master
        }
        public enum HesapTuru
        {
            TL,
            USD,
            EURO,
            AUX
        }

        public interface IHavale
        {
            void HavaleGonder(string iban, decimal tutar);
        }

        public interface IEft
        {
            void EftGonder(string iban, decimal tutar);
        }

        public interface IPuan
        {
            int KazanilanPuan { get; set; }
        }

        public interface ITaksit
        {
            void TaksitYap(decimal tutar, int taksitsayisi);
        }
        public class Kart
        {
            public string BankaAdi { get; set; }
            public string KartAdi { get; set; }
            public KartTuru KartTuru { get; set; }
            public string CvcKodu { get; set; }

            public void ParaCek(decimal tutar)
            {
                Console.WriteLine("Para çekiminiz tamamlanmıştır." + " " + tutar);
            }

            public void ParaYatir(decimal tutar)
            {
                Console.WriteLine("Para yatırma işleminiz tamamlanmıştır." + " " + tutar);
            }

        }

        public class KrediKarti
        {
            public DateTime SonKullanimTarihi { get; set; }

            public bool EkKartMi { get; set; }

            public void BorcOde(decimal tutar)
            {
                Console.WriteLine("Borç Tutarınız : " + tutar);
            }
        }

        public class Bankamatik : Kart, IHavale
        {
            public HesapTuru HesapTuru { get; set; }
            public int Bakiye { get; set; }

            public void HavaleGonder(string iban, decimal tutar)
            {
                Console.WriteLine("Havale gönderim işelminiz tamamlanmıştır. to " + iban + " ---- " + tutar);
            }



            public void LimitTanimla(decimal tutar)
            {
                Console.WriteLine("Limitiniz : " + tutar);
            }

        }

        public class Platinium : KrediKarti, IHavale, IEft, IPuan
        {
            public bool ClubUyeligiVarmi { get; set; }
            public DateTime UyelikBaslangicTarihi { get; set; }
            public DateTime UyelikBitisTarihi { get; set; }
            public int KazanilanPuan { get; set; }


            public void UyeligiYenile()
            {
                Console.WriteLine("Üyelğiniz Yenilenmiştir.");
            }

            public void UyeligiBitir()
            {
                Console.WriteLine("Üyeliğiniz Sonlanmıştır.");
            }

            public void HavaleGonder(string iban, decimal tutar)
            {
                Console.WriteLine("Havale gönderim işelminiz tamamlanmıştır. to " + iban + " ---- " + tutar);
            }

            public void EftGonder(string iban, decimal tutar)
            {
                Console.WriteLine(iban + " nolu iban'a Eft gönderimi yapılmıştır." + " --- " + tutar);
            }
        }

        public class Gold : KrediKarti, IHavale, IPuan, ITaksit
        {
            public bool IndirimOzelligiVarmi { get; set; }
            public bool KampanyaTanimliMi { get; set; }
            public DateTime KampanyaBaslangicTarihi { get; set; }
            public DateTime KampanyaBitisTarihi { get; set; }
            public int KazanilanPuan { get; set; }

            public void KampanyaTanimla()
            {
                Console.WriteLine("Kampanya Tanımlanmıştır.");
            }

            public void KampanyaBitir()
            {
                Console.WriteLine("Kampanya Bitmiştir.");
            }

            public void HavaleGonder(string iban, decimal tutar)
            {
                Console.WriteLine("Havale gönderim işelminiz tamamlanmıştır. to " + iban + " ---- " + tutar);
            }

            public void TaksitYap(decimal tutar, int taksitsayisi)
            {
                Console.WriteLine("Tutar : " + tutar);
                Console.WriteLine("Taksit Sayısı : " + taksitsayisi);
            }
        }

        public class Silver : KrediKarti, ITaksit, IEft
        {
            public bool KisitlamaVarmi { get; set; }
            public DateTime KisitlamaTarihi { get; set; }

            public void EftGonder(string iban, decimal tutar)
            {
                Console.WriteLine(iban + " nolu iban'a Eft gönderimi yapılmıştır." + " --- " + tutar);
            }

            public void TaksitYap(decimal tutar, int taksitsayisi)
            {
                Console.WriteLine("Tutar : " + tutar);
                Console.WriteLine("Taksit Sayısı : " + taksitsayisi);
            }
        }

    }


}