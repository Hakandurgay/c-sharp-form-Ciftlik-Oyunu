

using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiftlikOyun
{
     class Inek:ACiftlik
    {

        public static int inekprogresssayac { get; set; }
        public static int ineklabelsayac { get; set; }
        int progressinek = 0;

        public override int EnerjiKontrol()
        {

            inekprogresssayac++;

            progressinek = 100 - (8 * inekprogresssayac);

           if(progressinek<4)
            {
                return progressinek = 0;
            }

            return progressinek;
        }

        public override string UrunKontrol()
        {
            ineklabelsayac++;

        

            int inekSutAdet = ineklabelsayac / 8;
            
          

            DosyaOku();
            Form.DepoBilgileri[2] = Convert.ToString(inekSutAdet);
            DosyaYaz();
            return inekSutAdet.ToString();

        }
        public override void OlumKontrol(int inekprogress)
        {
            if (inekprogress == 4)
            {
                Form inekform1 = new Form();

           
                SoundPlayer Inekses = new SoundPlayer();
                string Ineksesi = Application.StartupPath + "\\inek.wav";
                Inekses.SoundLocation = Ineksesi;
                Inekses.Play();


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

            int ineksutsatis = 0;

            DosyaOku();
            ineksutsatis = (Convert.ToInt16(Form.DepoBilgileri[2]) * 5) + Convert.ToInt16(Form.DepoBilgileri[4]);
            Form.DepoBilgileri[4] = ineksutsatis.ToString();
            DosyaYaz();
           ineklabelsayac = 0;

        }

    }
}
