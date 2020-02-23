/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2018-2019 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: B171210041
**				ÖĞRENCİ ADI............: HAKAN DURGAY
**				ÖĞRENCİ NUMARASI.......: PROJE
**                         DERSİN ALINDIĞI GRUP...: 1-D
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiftlikOyun
{
   abstract  class ACiftlik
    {
      
        public abstract int EnerjiKontrol();
        public abstract string UrunKontrol();
        public abstract void OlumKontrol(int progressDeger);
        public abstract void DosyaOku();
        public abstract void DosyaYaz();
        public abstract void SatisYap();

        public static void TxtBaslangıcDegerSifirla()  //bu fonksiyon kurucuya gönderilerek başlangıçta dosya değerleri sıfır olarak atanıyor
        {
            Form.DepoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            Form.DepoBilgileri[0] = "0";
            Form.DepoBilgileri[1] = "0";
            Form.DepoBilgileri[2] = "0";
            Form.DepoBilgileri[3] = "0";
            Form.DepoBilgileri[4] = "0";
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", Form.DepoBilgileri);
        }
        
       
    }
}
