using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.ComponentModel;
using System.Diagnostics;

namespace Lab
{
   
   

    public partial class MainWindow : Window
    {
        static BackgroundWorker bkworker = new BackgroundWorker();
        public static string textOriginal;
        public static string textCriptat;
        public List<string> textReasamblat = new List<string>();
        public List<string> lista = new List<string>();
        public static int numar;

        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void BtnThread_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();


            textOriginal = Text_Initial.Text;
            numar = textOriginal.Length / Environment.ProcessorCount;
            lista.Capacity = Environment.ProcessorCount;
            for (int i = 0; i < textOriginal.Length; i+=numar)
            {
                if ((i + numar) < textOriginal.Length)
                {
                    lista.Add(textOriginal.Substring(i, numar));
                }
                else
                    lista.Add(textOriginal.Substring(i));
            }
            
            for(int k = 0; k<lista.Count; k++)
            {
                int temp = k;
                new Thread(() => { textReasamblat[temp] = CriptareDecriptare.Criptare(lista[temp]); }).Start();
                
            }
            stopWatch.Start();
            for(int i = 0; i<textReasamblat.Count; i++)
                Criptat.Text += textReasamblat[i];
            stopWatch.Stop();
            Durata.Text = String.Format("{00:00} ms", stopWatch.ElapsedMilliseconds);
        }

        private void BtnExec_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();

            textOriginal = Text_Initial.Text;
            stopWatch.Start();
            textCriptat = CriptareDecriptare.Criptare(textOriginal);
            stopWatch.Stop();
            Durata.Text = String.Format("{00:00} ms", stopWatch.ElapsedMilliseconds);
            Criptat.Text = textCriptat;
        }


    }
}
