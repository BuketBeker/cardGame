using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizeÖdevi
{
    class Deste
    {
        public static bool BilgisayarOynasin = false;
        public static string KullaniciKarti, YerdekiKart = "BOS";
        public static int TurSayisi = 0;
        public static int BerabereMi = 0;

        public void Olustur()
        {
            Random random = new Random();
            string[] oyuncukartlari = new string[18] { "S1", "S2", "S3", "S4", "S5", "K1", "K2", "K3", "K4", "K5", "M1", "M2", "M3", "M4", "M5", "RD", "RD", "RD" };
            string[] kullanici = new string[6];
            string[] Oyuncu2Kartlari = new string[6];
            string[] Oyuncu3Kartlari = new string[6];
            int x = 0, y = 0, z = 0, Tur = 1;

            // KARTLARI KARIŞIK HALDE OYUNCULARA ATIYORUZ
            if (x < 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    int sayi = random.Next(0, 18);
                    if (oyuncukartlari[sayi] != "BOS")
                    {
                        kullanici[x] = oyuncukartlari[sayi];
                        oyuncukartlari[sayi] = "BOS";
                        x++;

                    }
                    else
                    {
                        i = i - 1;
                    }
                }
            }
            if (y < 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    int sayi = random.Next(0, 18);
                    if (oyuncukartlari[sayi] != "BOS")
                    {
                        Oyuncu2Kartlari[y] = oyuncukartlari[sayi];
                        oyuncukartlari[sayi] = "BOS";
                        y++;

                    }
                    else
                    {
                        i = i - 1;
                    }
                }
            }

            if (z < 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    int sayi = random.Next(0, 18);
                    if (oyuncukartlari[sayi] != "BOS")
                    {
                        Oyuncu3Kartlari[z] = oyuncukartlari[sayi];
                        oyuncukartlari[sayi] = "BOS";
                        z++;
                    }
                    else
                    {
                        i = i - 1;
                    }
                }

            }
            // KARTLARI GÖRÜNTÜLEMEK İÇİN
            Console.WriteLine("Kullanıcının Kartları :");
            for (int i = 0; i < kullanici.Length; i++)
            {
                Console.WriteLine(kullanici[i]);
            }
            Console.WriteLine("Oyuncu2'nin Kartları :");
            for (int i = 0; i < Oyuncu2Kartlari.Length; i++)
            {
                Console.WriteLine(Oyuncu2Kartlari[i]);
            }
            Console.WriteLine("Oyuncu3'ün Kartları :");
            for (int i = 0; i < Oyuncu3Kartlari.Length; i++)
            {
                Console.WriteLine(Oyuncu3Kartlari[i]);
            }

            bool Kartiste = true;
            Console.WriteLine("***** Oyuna sen başlıyorsun *****");
            Console.WriteLine("LÜTFEN BÜYÜK KARAKTER KULLANINIZ.");
            Console.WriteLine("1.TUR");

            while (Kartiste == true)
            {
                KullaniciKartlari(kullanici); //KULLANICININ KARTLARINI GÖSTERİYORUZ
                Console.Write("\nLütfen Kart Atınız : ");
                KullaniciKarti = Console.ReadLine();
                if ((KullaniciKarti == "PAS" || KullaniciKarti == "RD") && TurSayisi <= 0) //İLK ELDEN PAS VEYA RD KARTI ATAMIYORUZ
                {
                    Console.WriteLine("İlk elden pas veya renk değiştirme kartını kullanamazsın!");
                    BilgisayarOynasin = false;
                }
                else if (KullaniciKarti == "PAS")
                {
                    Console.WriteLine("PAS kullandın : " + YerdekiKart);
                    BilgisayarOynasin = true;
                    BerabereMi++;
                }
                else if (KullaniciKarti == "RD") //RD KARTI İLE İLGİLİ KURALLAR
                {
                    int RD = 0;
                    bool RDVarMi = false;
                    for (int rd = 0; rd < 6; rd++)
                    {
                        if (kullanici[rd] == "RD")
                        {
                            RD = rd;
                            RDVarMi = true;
                        }
                    }
                    if (RDVarMi == true)
                    {
                        while (true)
                        {
                            Console.Write("Lütfen bir renk belirleyiniz : (M/K/S) "); // RD KARTININ RENGİNİN BELİRLENMESİ
                            string YeniRenk = Console.ReadLine();
                            if (YeniRenk == "M")
                            {
                                YerdekiKart = "M" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Atılan son kart : {0} ", YerdekiKart);
                                kullanici[RD] = "BOS";
                                BilgisayarOynasin = true;
                                break;
                            }
                            else if (YeniRenk == "K")
                            {
                                YerdekiKart = "K" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Atılan son kart : {0} ", YerdekiKart);
                                kullanici[RD] = "BOS";
                                BilgisayarOynasin = true;
                                break;
                            }
                            else if (YeniRenk == "S")
                            {
                                YerdekiKart = "S" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("Atılan son kart : {0} ", YerdekiKart);
                                kullanici[RD] = "BOS";
                                BilgisayarOynasin = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı renk girişi yaptınız.");
                                BilgisayarOynasin = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Elinizde RD kartı yok. Atılan son kart : {0} ", YerdekiKart);
                        BilgisayarOynasin = false;
                    }
                }
                else
                {
                    if (TurSayisi > 0)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (kullanici[i] == KullaniciKarti)
                            {
                                if (kullanici[i].Substring(0, 1) == YerdekiKart.Substring(0, 1) || kullanici[i].Substring(1, 1) == YerdekiKart.Substring(1, 1))
                                {
                                    TurSayisi++;

                                    YerdekiKart = KullaniciKarti;
                                    kullanici[i] = "BOS";
                                    BilgisayarOynasin = true;
                                    break;
                                }
                            }
                        }
                        if (BilgisayarOynasin == false)
                        {
                            Console.WriteLine("Bu kart elinizde mevcut değil veya uygun olmayan bir kart attınız. Atılan son kart : {0} ", YerdekiKart);
                            BilgisayarOynasin = false;
                        }

                    }

                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {

                            if (kullanici[i] == KullaniciKarti)
                            {
                                TurSayisi++;

                                YerdekiKart = KullaniciKarti;
                                kullanici[i] = "BOS";
                                BilgisayarOynasin = true;
                                break;
                            }
                        }
                    }
                }

                bool KontrolEt = false;
                KontrolEt = OyunBitti(kullanici); // OYUNUN BİTİP BİTMEDİĞİNİ KONTROL ETMEK İÇİN

                if (KontrolEt == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("OYUN BİTTİ - KAZANAN SEN");
                    KalanKartlar(kullanici, Oyuncu2Kartlari, Oyuncu3Kartlari);
                    break;
                }
                if (BilgisayarOynasin == true)
                {
                    BilgisayarKartAt(Oyuncu2Kartlari, "OYUNCU 2");// BİLGİSAYARIN KART ATMASI İÇİN
                    bool kontrol2 = false;
                    kontrol2 = OyunBitti(Oyuncu2Kartlari);
                    if (kontrol2 == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("OYUN BİTTİ - KAZANAN 2.OYUNCU");
                        KalanKartlar(kullanici, Oyuncu2Kartlari, Oyuncu3Kartlari);
                        break;
                    }
                    BilgisayarKartAt(Oyuncu3Kartlari, "OYUNCU 3");// BİLGİSAYARIN KART ATMASI İÇİN
                    bool kontrol3 = false;
                    kontrol3 = OyunBitti(Oyuncu3Kartlari);
                    if (kontrol3 == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("OYUN BİTTİ - KAZANAN 3.OYUNCU");
                        KalanKartlar(kullanici, Oyuncu2Kartlari, Oyuncu3Kartlari);
                        break;
                    }
                    BilgisayarOynasin = false;
                    Console.WriteLine();
                    Tur++;
                    Console.WriteLine(Tur + ".Tur");
                }

                if(BerabereMi == 5) // BERABERE KALMASI DURUMUNDA
                {
                    Console.WriteLine("Oyun Berabere Kaldı.");

                }

           
            }
            Console.ReadLine();
        }

        public static void BilgisayarKartAt(string[] BilgisayarKartlari, string BilgisayarOyuncu) // BİLGİSAYARIN KART ATMASI 
        {
            bool KartUygunMu = false, RDVarMi = false;
            int RDindex = 0; 
            if (YerdekiKart == "BOS")
            {
                for (int i = 0; i < 6; i++)
                {
                    if (BilgisayarKartlari[i] != "RD")
                    {
                        Console.WriteLine("{0} : {1}", BilgisayarOyuncu, BilgisayarKartlari[i]);
                        YerdekiKart = BilgisayarKartlari[i];
                        BilgisayarKartlari[i] = "BOS";
                        break;
                    }

                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (BilgisayarKartlari[i].Substring(0, 1) == YerdekiKart.Substring(0, 1) || BilgisayarKartlari[i].Substring(1, 1) == YerdekiKart.Substring(1, 1))
                    {
                        KartUygunMu = true;
                        Console.WriteLine("{0} : {1}", BilgisayarOyuncu, BilgisayarKartlari[i]);
                        YerdekiKart = BilgisayarKartlari[i];
                        BilgisayarKartlari[i] = "BOS";
                        break;
                    }
                }
                if (KartUygunMu == false)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (BilgisayarKartlari[i] == "RD")
                        {
                            RDindex = i;
                            RDVarMi = true;
                            break;
                        }
                    }

                    if (RDVarMi == true)
                    {
                        bool RenkliKartYok = false;
                        for (int i = 0; i < 6; i++)
                        {
                            if (BilgisayarKartlari[i].Substring(0, 1) == "K")
                            {
                                YerdekiKart = "K" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı.", BilgisayarOyuncu, YerdekiKart);
                                BilgisayarKartlari[RDindex] = "BOS";
                                RenkliKartYok = true;
                                break;
                            }
                            else if (BilgisayarKartlari[i].Substring(0, 1) == "M")
                            {
                                YerdekiKart = "M" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı.", BilgisayarOyuncu, YerdekiKart);
                                BilgisayarKartlari[RDindex] = "BOS";
                                RenkliKartYok = true;
                                break;
                            }
                            else if (BilgisayarKartlari[i].Substring(0, 1) == "S")
                            {
                                YerdekiKart = "S" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı.", BilgisayarOyuncu, YerdekiKart);
                                BilgisayarKartlari[RDindex] = "BOS";
                                RenkliKartYok = true;
                                break;
                            }
                        }
                        if (RenkliKartYok == false)
                        {
                            Random random = new Random();
                            int Renk = random.Next(0, 3); // ATILACAK RENGİN BELİRLENMESİ
                            if (Renk == 0)
                            {
                                YerdekiKart = "M" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı", BilgisayarOyuncu, YerdekiKart);

                            }
                            else if (Renk == 1)
                            {
                                YerdekiKart = "K" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı", BilgisayarOyuncu, YerdekiKart);
                            }
                            else if (Renk == 2)
                            {
                                YerdekiKart = "S" + YerdekiKart.Substring(1, 1);
                                Console.WriteLine("{0} RD kartını kullanarak yeni kartı {1} yaptı", BilgisayarOyuncu, YerdekiKart);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("{0} PAS verdi : {1}", BilgisayarOyuncu, YerdekiKart);
                        BerabereMi++;
                    }

                }
            }

        }

        public static void KullaniciKartlari(string[] Kart) // KULLANICININ KARTLARINI GÖSTEREN FONKSİYON
        {
            foreach (var item in Kart)
            {
                Console.Write(item + " ");
            }
        }

        public static void KalanKartlar(string[] Kart1, string[] Kart2, string[] Kart3) // KALAN KARTLARI GÖSTEREN FONKSİYON
        {
            Console.WriteLine();
            Console.WriteLine("Kullanıcının Kartları:");
            foreach (var item in Kart1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Oyuncu2'nin Kartları:");
            foreach (var item in Kart2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Oyuncu3'ün Kartları:");
            foreach (var item in Kart3)
            {
                Console.Write(item + " ");
            }
        }

        public static bool OyunBitti(string[] KartDurum)
        {
            bool BittiMi = false;
            int KartSayisi = 0;
            for (int i = 0; i < 6; i++)
            {
                if (KartDurum[i] == "BOS")
                {
                    KartSayisi++;
                }
            }
            if (KartSayisi >= 6)
            {
                BittiMi = true;
            }
            return BittiMi;
        }
    }
}
