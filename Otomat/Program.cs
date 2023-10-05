using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urunler = new string[3] {"Kola", "Bisküvi", "Çikolata"};
            int[] fiyatlar = new int[3] {7,3,2};
            string username = "admin";
            string password = "admin";
            string username1 = "member";
            string password1 = "member";
            int yatirilantutar = 0;
            int totaltutar = 0;
            string kullaniciadi = "";
            string sifre = "";
            ILKGIRIS:
            Console.WriteLine("****** OTOMAT ******\n \n");
            Console.WriteLine("Admin girişi için 1'i, üye girişi için 2'yi tuşlayınız");
            string girissecim = Console.ReadLine();
            if (girissecim =="1")
            {
                ADMINGIRISI:
                Console.Clear();
                Console.WriteLine("Kullanıcı adınızı giriniz");
                kullaniciadi = Console.ReadLine();
                Console.WriteLine("Şifrenizi giriniz");
                sifre = Console.ReadLine();
                if (kullaniciadi == username && sifre == password)
                {
                    Console.Clear();
                    ADMINISLEMLERI:
                    Console.WriteLine("Yapmak istediğiniz işlemi seçiniz: \n 1-Ürün değiştir \n 2-Fiyat değiştir");
                    string adminislemsecim = Console.ReadLine();
                    if (adminislemsecim == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Ürün/fiyat listesi aşağıdaki gibidir. Lütfen değiştirmek istediğiniz ürünü seçiniz\n");
                        for (int i = 0; i < urunler.Length; i++)
                        {
                            Console.WriteLine("{0}-{1} ({2}TL)", (i + 1), urunler[i], fiyatlar[i]);
                        }
                        int degisecekurun = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yerine koyulacak ürünü giriniz: ");
                        string koyulacakurun = Console.ReadLine();
                        urunler[degisecekurun-1] = koyulacakurun;
                        Console.Clear();
                        Console.WriteLine("Değişim başarılı");
                        goto ILKGIRIS;


                    } //URUN DEGISTIRME
                    else if (adminislemsecim == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Ürün/fiyat listesi aşağıdaki gibidir. Lütfen değiştirmek istediğiniz fiyatı seçiniz\n");
                        for (int i = 0; i < fiyatlar.Length; i++)
                        {
                            Console.WriteLine("{0}-{1} ({2}TL)", (i + 1), urunler[i], fiyatlar[i]);
                        }
                        int degisecekfiyat = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yerine koyulacak fiyatı giriniz: ");
                        int koyulacakfiyat = Convert.ToInt32(Console.ReadLine());
                        fiyatlar[degisecekfiyat - 1] = koyulacakfiyat;
                        Console.Clear();
                        Console.WriteLine("Değişim başarılı");
                        goto ILKGIRIS;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen verilen seçenekler harici başka bir değer girmeyiniz");
                        goto ADMINISLEMLERI;
                    }
                }
                else
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı");
                    goto ADMINGIRISI;
                }

            }//ADMIN GIRISI KISMI - YAPILACAK HENUZ YAPILMADI
            else if(girissecim =="2") 
            {
                
                Console.Clear();
                UYELOGIN:
                Console.WriteLine("Kullanıcı adınızı giriniz");
                kullaniciadi = Console.ReadLine();
                Console.WriteLine("Şifrenizi giriniz");
                sifre = Console.ReadLine();
                if (kullaniciadi == username1 && sifre == password1)
                {

                    Console.Clear();
                    UYEGIRISIBASARILIISE:
                    Console.WriteLine("Yatırılacak tutarı giriniz:");
                    try
                    {
                        yatirilantutar = Convert.ToInt32(Console.ReadLine());
                        totaltutar =totaltutar+yatirilantutar;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen numerik bir değer giriniz");
                        goto UYEGIRISIBASARILIISE;
                        
                    }
                    Console.Clear();

                    Console.WriteLine("Satın almak istediğiniz ürünü seçiniz");
                    for (int i = 0; i < urunler.Length; i++)
                    {
                        Console.WriteLine("{0}-{1} ({2}TL)", (i + 1), urunler[i], fiyatlar[i]);
                    }
                    int urunsecimi = Convert.ToInt32(Console.ReadLine());
                    if (fiyatlar[urunsecimi-1]>totaltutar)
                    {
                        Console.Clear();
                        YETERSIZBAKIYE:
                        Console.WriteLine("Bakiyeniz yetersiz.\n 1-Bakiye ekle \n 2-Para iadesi");
                        string yetersizbakiyesecim = Console.ReadLine();
                        if (yetersizbakiyesecim == "1")
                        {
                            Console.Clear();
                            goto UYEGIRISIBASARILIISE;
                        }
                        else if(yetersizbakiyesecim =="2")
                        {
                            Console.Clear();
                            Console.WriteLine("İade edilen tutar: {0}", totaltutar);
                            Console.WriteLine("Çıkış yapmak için herhangi bir tuşa basınız");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen numerik bir değer giriniz");
                            goto YETERSIZBAKIYE;
                        }

                    }//BAKIYE YETERSIZ ISE
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Alınan ürün: {0}", urunler[urunsecimi - 1]);
                        Console.WriteLine("Para üstü: {0}", totaltutar - fiyatlar[urunsecimi - 1]);
                    }//SATIS BASARILI
                    

                } // GIRIS  BASARILI ISE

                else
                {
                    Console.Clear();
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı");
                    goto UYELOGIN;
                }// GIRIS BASARILI DEGILSE

            } // UYE GIRISI KISMI
            else
            {
                Console.Clear();
                Console.WriteLine("Lütfen 1 ve 2 harici başka bir değer girmeyiniz");
                goto ILKGIRIS;
            }// 1 VE 2 HARICI DEGER GIRILIRSE KISMI



        }
    }
}
