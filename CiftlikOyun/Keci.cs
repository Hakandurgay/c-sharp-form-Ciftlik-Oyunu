using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiftlikOyun
{
    class Keci:ACiftlik
    {
        public static int keciprogresssayac { get; set; }
        public static int kecilabelsayac { get; set; }

        public override int EnerjiKontrol()
        {
            keciprogresssayac++;
            int progresskeci = 0;

            progresskeci = 100 - (6 * keciprogresssayac);

            if (progresskeci < 4)
            {
                return progresskeci = 0;
            }


            return progresskeci;
        }


        public override string UrunKontrol()
        {
            kecilabelsayac++;

            int kecisutadet = kecilabelsayac / 8;


            DosyaOku();
            Form.DepoBilgileri[3] = Convert.ToString(kecisutadet);
            DosyaYaz();
            return kecisutadet.ToString();
        }
        public override void OlumKontrol(int keciprogress)
        {
            if (keciprogress == 4)
            {
              

                SoundPlayer Kecises = new SoundPlayer();
                string Kecisesi = Application.StartupPath + "\\keci.wav";
                Kecises.SoundLocation = Kecisesi;
                Kecises.Play();

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

            int kecisutsatis = 0;

            DosyaOku();
            kecisutsatis = (Convert.ToInt16(Form.DepoBilgileri[3]) * 8) + Convert.ToInt16(Form.DepoBilgileri[4]);
            Form.DepoBilgileri[4] = kecisutsatis.ToString();
            DosyaYaz();
            kecilabelsayac = 0;

        }


    }
}
