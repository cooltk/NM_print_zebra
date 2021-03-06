﻿using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Forms;

namespace NM_Test_print_zebra
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            // Set the printer name. 
            pd.PrinterSettings.PrinterName = "ZDesigner ZT230-200dpi ZPL";            
            for (int i = 0; i< int.Parse(textboxQte.Text); i++) 
            {
                pd.Print();
            };
                
        }

        void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font printFontGrand = new Font("Arial", 40);
            Font printFontPetit = new Font("Arial", 25);
            Font printFontTresPetit = new Font("Arial", 12);
            Font printFont2 = new Font("Merck", 35);
            Font printFontBarcode = new Font("Free 3 of 9 Extended", 30);
            Font[] TableauFont = new Font[30]
            {
                new Font("Free 3 of 9 Extended", 30),
                new Font("Free 3 of 9 Extended", 29),
                new Font("Free 3 of 9 Extended", 28),
                new Font("Free 3 of 9 Extended", 27),
                new Font("Free 3 of 9 Extended", 26),
                new Font("Free 3 of 9 Extended", 25),
                new Font("Free 3 of 9 Extended", 24),
                new Font("Free 3 of 9 Extended", 23),
                new Font("Free 3 of 9 Extended", 22),
                new Font("Free 3 of 9 Extended", 21),
                new Font("Free 3 of 9 Extended", 20),
                new Font("Free 3 of 9 Extended", 19),
                new Font("Free 3 of 9 Extended", 18),
                new Font("Free 3 of 9 Extended", 17),
                new Font("Free 3 of 9 Extended", 16),
                new Font("Free 3 of 9 Extended", 15),
                new Font("Free 3 of 9 Extended", 14),
                new Font("Free 3 of 9 Extended", 13),
                new Font("Free 3 of 9 Extended", 12),
                new Font("Free 3 of 9 Extended", 11),
                new Font("Free 3 of 9 Extended", 10),
                new Font("Free 3 of 9 Extended", 9),
                new Font("Free 3 of 9 Extended", 8),
                new Font("Free 3 of 9 Extended", 7),
                new Font("Free 3 of 9 Extended", 6),
                new Font("Free 3 of 9 Extended", 5),
                new Font("Free 3 of 9 Extended", 4),
                new Font("Free 3 of 9 Extended", 3),
                new Font("Free 3 of 9 Extended", 2),
                new Font("Free 3 of 9 Extended", 1)
            };

            SolidBrush br = new SolidBrush(System.Drawing.Color.Black);
            int i = 0;
            var dimension = TextRenderer.MeasureText("*" + textbox4.Text + "*", printFontBarcode);
            do
            {
                printFontBarcode = TableauFont[i];
                i++;
                dimension = TextRenderer.MeasureText("*" + textbox4.Text + "*", printFontBarcode);
            } while (dimension.Width > 335 && i < 30);


            ev.Graphics.DrawString(DateTime.Now.ToString(), printFontTresPetit, br, 5, 5);
            ev.Graphics.DrawString(textbox1.Text, printFontTresPetit, br, 5, 20);
            ev.Graphics.DrawString("M", printFont2, br, 190, 5);
            ev.Graphics.DrawString(textbox2.Text, printFontPetit, br, 5, 80); //Item
            ev.Graphics.DrawString(textbox4.Text, printFontTresPetit, br, 5, 150); //LPN code-barre
            ev.Graphics.DrawString("*"+textbox4.Text+"*", printFontBarcode, br, 5, 170); //LPN code-barre
            ev.Graphics.DrawString(textbox3.Text, printFontGrand, br, 5, 210); //Locator
        }
    }
}