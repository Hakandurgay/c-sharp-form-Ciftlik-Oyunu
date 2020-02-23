
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace CiftlikOyun
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            ACiftlik.TxtBaslangıcDegerSifirla();  //txt dosyasındaki değerler sıfırlanıyor
            InitializeComponent();
        }
      

        Tavuk tavuk = new Tavuk();
        Ordek ordek = new Ordek();
        Inek  inek =  new Inek();
        Keci  keci =  new Keci();
       

      public static string[] DepoBilgileri;

      private int genelsayac = 0;



        bool inekYasam = false;
        bool tavukYasam = false;      //hayvanlar öldükten sonra satış yapıldığında ürünlerini sıfırlamak için bool türünden değişkenler oluşturuluyor
        bool keciYasam=false;           
        bool ordekYasam=false;
 
        private void Form1_Load(object sender, EventArgs e)

        {
            FormElemanOzellikAyarla();          
        }



        private void timergecenzaman_Tick(object sender, EventArgs e)
        {
          
            genelsayac++;
         
            gecensurelbl.Text = Convert.ToString(genelsayac); //geçen süreyi ekrana yazdırır  
            //
        
            if (progresstavuk.Value == 0)  //progress bar sıfıra eşitse hayvan ölü demek oluyor ve labelına öldü yazıldıktan sonra
                                          //yem ver butonu pasit oluyor. Hayvanın öldükten sonra satış yapılırsa labelındaki ürün adetinin sıfır olması için bool değişken false oluyor
            {
                tavukcan.Text = "ÖLDÜ";
                tavukyemverbtn.Enabled = false;
                tavukYasam = false;
            }
            else if(progresstavuk.Value!=0)
            {
                progresstavuk.Value = tavuk.EnerjiKontrol();
                tavukyumurtaadt.Text = tavuk.UrunKontrol();
                tavuk.OlumKontrol(progresstavuk.Value);
                tavukYasam = true;
            }
            // 
            //     
            if (progressordek.Value == 0)
            {
                ordekcan.Text = "ÖLDÜ";
                ordekyemverbtn.Enabled = false;
                ordekYasam = false;
            }
            else if (progressordek.Value != 0)
            {
                progressordek.Value = ordek.EnerjiKontrol();
                ordekyumurtadt.Text = ordek.UrunKontrol();
                ordek.OlumKontrol(progresstavuk.Value);
                ordekYasam = true;
            }
            //
            //
            if (progressinek.Value == 0)
            {
                inekcan.Text = "ÖLDÜ";
                inekyemverbtn.Enabled = false;            //hayvan ölüyken yer verme butonları aktif olurken labelında ölü yazıyor
                inekYasam = false;
               

            }
            else if(progressinek.Value!=0)
            {
                progressinek.Value = inek.EnerjiKontrol();     //inekYasam true ise hayvan yaşıyor 
                ineksutuadt.Text = inek.UrunKontrol();
                inek.OlumKontrol(progressinek.Value);
                inekYasam = true;
            }
            //
            //
         
            if (progresskeci.Value == 0)
            {
                kecican.Text = "ÖLDÜ";
                yemverkecibtn.Enabled = false;
                keciYasam = false;
            }
            else if (progresskeci.Value != 0)
            {
                progresskeci.Value = keci.EnerjiKontrol();
                kecisutuadt.Text = keci.UrunKontrol();
                keci.OlumKontrol(progresskeci.Value);
                keciYasam = true;
            }
            //

        }
    
        //yem verme butonları
        private void tavukyemverbtn_Click(object sender, EventArgs e)
        {        
            progresstavuk.Value = 100;
            Tavuk.tavukprogressSayac = 0;
        }
        private void ordekyemverbtn_Click(object sender, EventArgs e)
        {
            progressordek.Value = 100;
            Ordek.ordekprogresssayac = 0;
        }
        private void inekyemverbtn_Click(object sender, EventArgs e)
        {
            progressinek.Value = 100;
            Inek.inekprogresssayac = 0;
        }
        private void yemverkecibtn_Click(object sender, EventArgs e)
        {
            progresskeci.Value = 100;
            Keci.keciprogresssayac = 0;
        }


        //satış yap butonları
        private void tavukyumurtasatbtn_Click(object sender, EventArgs e)
        {
            if(tavukYasam==true)
            {
                tavuk.SatisYap();
                KasaLabelYaz();
            }
            else if(tavukYasam==false)
            {
                tavuk.SatisYap();
                KasaLabelYaz();
                tavukyumurtaadt.Text = "0";
            }
          
        }
        private void ordekyumurtasatbtn_Click(object sender, EventArgs e)
        {
            if(ordekYasam==true)
            {
                ordek.SatisYap();
                KasaLabelYaz();
            }
          else if(ordekYasam==false)
            {
                ordek.SatisYap();
                KasaLabelYaz();
                ordekyumurtadt.Text = "0";
            }
        }
        private void ineksutusatbtn_Click(object sender, EventArgs e)
        {
            if(inekYasam==true)  //eğer hayvan yaşarken satış yapılırsa bu işlemler yapılıyor
            {
                inek.SatisYap();
                KasaLabelYaz();
            }
            else if(inekYasam==false)   //inek yasam false değerini alınca hayvan ölmüş oluyor ve işlemler yapılıyor
            {
                inek.SatisYap();
                KasaLabelYaz();
                ineksutuadt.Text = "0";   
              
            }
         
        }
        private void kecisutusatbtn_Click(object sender, EventArgs e)
        {
            if (keciYasam == true)
            {
                keci.SatisYap();
                KasaLabelYaz();
            }
            else if (keciYasam == false)
            {
                keci.SatisYap();
                KasaLabelYaz();
                kecisutuadt.Text = "0";
            }
          
        }

        private void KasaLabelYaz()
        {
            kasalbl.Text = DepoBilgileri[4];

        }
        private void FormElemanOzellikAyarla()
        {
            this.Text = "Hayvan Çiftliği";

            progressinek.Maximum = 100;
            progresskeci.Maximum = 100;
            progressordek.Maximum = 100;
            progresstavuk.Maximum = 100;


            progressinek.Value = 100;
            progresskeci.Value = 100;
            progressordek.Value = 100;
            progresstavuk.Value = 100;


            timergecenzaman.Interval = 1000;
            timergecenzaman.Enabled = true;
        }
    }
}
