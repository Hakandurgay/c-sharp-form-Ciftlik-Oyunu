using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace CiftlikOyun
{
    class Tavuk:ACiftlik
    {
        public static int tavuklabelSayac { get; set; }
        public static int tavukprogressSayac { get; set; }

        public override int EnerjiKontrol()
        {
            tavukprogressSayac++;
            int progresstavuk = 0;
           
            progresstavuk=100- (2 * tavukprogressSayac);
            if (progresstavuk < 2)
            {
                return progresstavuk = 0;
            }

           

            return progresstavuk;
        }

        public override string UrunKontrol()
        {
           
            tavuklabelSayac++;
            
            int tavukYumurtaAdet =tavuklabelSayac/ 3;
            //int olduğu için sadece üçe bölünen tam sayıları değerlerini atıcak

            DosyaOku();    
            Form.DepoBilgileri[0] = Convert.ToString(tavukYumurtaAdet);
            DosyaYaz();
            return tavukYumurtaAdet.ToString();
        }

        public override void OlumKontrol(int tavukProgress)
        {
            if(tavukProgress==2)
            {

                SoundPlayer tavukses = new SoundPlayer();
                string tavuksesi = Application.StartupPath + "\\tavuk.wav";
                tavukses.SoundLocation = tavuksesi;
                tavukses.Play();
                
                
            }
        }

        public override void DosyaOku()
        {
            Form.DepoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
           
        }
        public override void DosyaYaz()
        {

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", Form.DepoBilgileri);

        }

        public override void SatisYap()
        {

            //önce dosya açılıp içindekiler okunuyor ve sıfırıncı satırdaki tavukyumurtası sayısı alınıp 
            //yumurta fiyatıyla çarpılıyor ve kasadaki eski meblağ ile toplanıp değişkene atılıyor
            //atılan değişken yeni kasa değeri olduğu için dizinin 4. indexine atılıp tekrar kasa değeri olarak yazılıyor
            //ardından tavuklabelsayac sıfırlanıyor
          
            int tavukyumurtasatis = 0;
        
            DosyaOku();
            tavukyumurtasatis = (Convert.ToInt16(Form.DepoBilgileri[0]) * 1) + Convert.ToInt16(Form.DepoBilgileri[4]);
           Form.DepoBilgileri[4] = tavukyumurtasatis.ToString();
            DosyaYaz();
            tavuklabelSayac = 0;
        
        }
    }
}
