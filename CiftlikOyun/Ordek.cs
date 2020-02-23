using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiftlikOyun
{
    class Ordek : ACiftlik
    {
       
        public static int ordeklabelsayac { get; set; }
        public static int ordekprogresssayac { get; set; }
      

        public override int EnerjiKontrol()
        {
            ordekprogresssayac++;
            int progressordek = 0;
            progressordek = 100 - (3 *ordekprogresssayac );
            if (progressordek < 1)
            {
                return progressordek = 0;
            }

            return progressordek;

        }

        public override string UrunKontrol()
        {
            ordeklabelsayac++;
            int ordekYumurtaAdet = ordeklabelsayac / 5;
            DosyaOku();
            Form.DepoBilgileri[1] = Convert.ToString(ordekYumurtaAdet);
            DosyaYaz();
            return ordekYumurtaAdet.ToString();
        }


        public override void OlumKontrol(int ordekprogress)
        {
            if (ordekprogress == 1)
            {
              
                SoundPlayer ordekses = new SoundPlayer();
                string ordeksesi = Application.StartupPath + "\\ordek.wav";
                ordekses.SoundLocation = ordeksesi;
                ordekses.Play();
             

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
            int ordekyumurtasatis = 0;
            DosyaOku();
            ordekyumurtasatis = (Convert.ToInt16(Form.DepoBilgileri[1]) * 3) + Convert.ToInt16(Form.DepoBilgileri[4]);
            Form.DepoBilgileri[4] = ordekyumurtasatis.ToString();
            DosyaYaz();
            ordeklabelsayac = 0;
        }


    }
}
