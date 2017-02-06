using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace PDFGenerator
{

    public partial class Form1 : Form
    {
        Deck deck;
        private readonly int dpi600Width = 4961;
        private readonly int dpi600Height = 7016;
        private readonly int dpi300Width = 2480;
        private readonly int dpi300Height = 3508;
        private readonly int mmWidth = 210;
        private readonly int mmHeight = 297;
        private readonly float dpi600PPMM = 4961.00f / 210.00f;
        private readonly float dpi300PPMM = 2480.00f / 210.00f;
        private readonly float pokerWidthMM = 63;
        private readonly float pokerHeightMM = 88;

        public Form1()
        {
            InitializeComponent();
            deck = new Deck();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderText.Clear();
                frontImageList.Images.Clear();
                frontListView.Clear();
                rearImageList.Images.Clear();
                rearListView.Clear();

                string[] files = Directory.GetFiles(fbd.SelectedPath);
                folderText.Text = fbd.SelectedPath.ToString();
                frontListView.Groups.Add(new ListViewGroup("Used"));
                int i = 0;
                int j = 0;
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file).ToLower();
                    if (fileName.Contains(".png") || fileName.Contains(".jpeg") || fileName.Contains(".jpg") || fileName.Contains(".gif"))

                        try
                        {
                            frontListView.HideSelection = false;
                            rearListView.HideSelection = false;

                            System.Drawing.Image imageToList = System.Drawing.Image.FromFile(file);
                            if (fileName.Contains(determineDefault(frontText)))
                            {
                                frontImageList.Images.Add(imageToList);
                                frontListView.Items.Add(Path.GetFileName(file), i);
                                i++;
                            }
                            else if (fileName.Contains(determineDefault(rearText)))
                            {
                                rearImageList.Images.Add(imageToList);
                                rearListView.Items.Add(Path.GetFileName(file), j);
                                j++;
                            }


                        }
                        catch (Exception ex)
                        {


                        }
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (determineSelected(frontListView) == true && determineSelected(rearListView) == true)
            {
                Card card = new Card();
                card.frontImage = System.Drawing.Image.FromFile(folderText.Text + "\\" + frontListView.SelectedItems[0].Text);
                card.frontFP = frontListView.SelectedItems[0].Text;
                card.rearImage = System.Drawing.Image.FromFile(folderText.Text + "\\" + rearListView.SelectedItems[0].Text);
                card.rearFP = rearListView.SelectedItems[0].Text;
                card.quantity = determineQuantity(quantityText);
                deck.Cards.Add(card);
                frontListBox.Items.Add(card.frontFP);
                rearListBox.Items.Add(card.rearFP);
                quantityListBox.Items.Add(card.quantity);
            }
            else
            {

                //add error messages
            }

            if (changeFront.Checked)
            {
                frontListView.SelectedItems[0].Group = frontListView.Groups[0];

            }

        }


        public bool isNumeric(string text)
        {

            int quantity;
            return int.TryParse(text, out quantity);
        }

        public string determineDefault(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                switch (textBox.Name)
                {
                    case "frontText":
                        return "front";
                    case "rearText":
                        return "back";
                    case "quantityText":
                        return "1";
                    case "bleedText":
                        return "0";
                    default:
                        return "default";

                }

            }
            else
            {
                return textBox.Text;
            }

        }

        public bool determineSelected(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        public int determineQuantity(TextBox textbox)
        {
            if (isNumeric(quantityText.Text) == true)
            {

                return Convert.ToInt32(quantityText.Text);
            }
            else
            {

                return Convert.ToInt32(determineDefault(quantityText));
            }


        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            deck = new Deck();
            frontListBox.Items.Clear();
            rearListBox.Items.Clear();
            quantityListBox.Items.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (verifyCardSelection() == true)
            {
                deck.Cards.RemoveAt(frontListBox.SelectedIndex);
                var index = frontListBox.SelectedIndex;

                frontListBox.Items.RemoveAt(frontListBox.SelectedIndex);
                rearListBox.Items.RemoveAt(rearListBox.SelectedIndex);
                quantityListBox.Items.RemoveAt(quantityListBox.SelectedIndex);




            }
        }

        private void frontListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCardListBox(frontListBox);
        }

        private void rearListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCardListBox(rearListBox);
        }

        private void quantityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCardListBox(quantityListBox);
        }

        private void changeCardListBox(ListBox listBox)
        {
            if (listBox.SelectedIndex != -1)
            {


                if (frontListBox.SelectedIndex != listBox.SelectedIndex)
                {
                    frontListBox.SetSelected(listBox.SelectedIndex, true);
                }
                if (rearListBox.SelectedIndex != listBox.SelectedIndex)
                {
                    rearListBox.SetSelected(listBox.SelectedIndex, true);
                }

                if (quantityListBox.SelectedIndex != listBox.SelectedIndex)
                {
                    quantityListBox.SetSelected(listBox.SelectedIndex, true);
                }
            }
        }

        private void updateQuantityButton_Click(object sender, EventArgs e)
        {
            if (verifyCardSelection() == true)
            {
                frontListBox.Items.Insert(frontListBox.SelectedIndex, deck.Cards[frontListBox.SelectedIndex].frontFP);
                rearListBox.Items.Insert(rearListBox.SelectedIndex, deck.Cards[rearListBox.SelectedIndex].rearFP);
                quantityListBox.Items.Insert(quantityListBox.SelectedIndex, updateQuantityText.Text);
                deck.Cards[quantityListBox.SelectedIndex - 1].quantity = Convert.ToInt16(updateQuantityText.Text);


                frontListBox.Items.RemoveAt(frontListBox.SelectedIndex);
                rearListBox.Items.RemoveAt(rearListBox.SelectedIndex);
                quantityListBox.Items.RemoveAt(quantityListBox.SelectedIndex);


            }
        }

        private bool verifyCardSelection()
        {
            if (frontListBox.SelectedIndex == rearListBox.SelectedIndex && rearListBox.SelectedIndex == quantityListBox.SelectedIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void generate_Click(object sender, EventArgs e)
        {
            //check if 0 cards in deck

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(dpi600Width, dpi600Height);
            Document pdf = new Document(rect);
            //pdf.SetPageSize(rect);
            pdf.AddCreator("ICWT Dev");
            var output = File.Create("deck.pdf");
            PdfWriter.GetInstance(pdf, output);
            pdf.Open();
            int pages = calculatePages();
            float[,] cords = calculateCords(pdf);
            var cord = 0;
            foreach(var card in deck.Cards)
            {
                for (var q = 0; q < card.quantity; q++)
                {
                    if (cord == 9)
                    {
                        pdf.NewPage();
                        cord = 0;
                    }
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(folderText.Text + "\\" + card.frontFP);
                    image.ScaleAbsolute(pokerWidthMM * dpi600PPMM, pokerHeightMM * dpi600PPMM);
                    image.SetAbsolutePosition(cords[cord, 0], cords[cord, 1]);
                    pdf.Add(image);
                    cord++;

                }

            }
            pdf.NewPage();
            cord = 0;
            foreach (var card in deck.Cards)
            {
                for (var q = 0; q < card.quantity; q++)
                {
                    if (cord == 9)
                    {
                        pdf.NewPage();
                        cord = 0;
                    }
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(folderText.Text + "\\" + card.rearFP);
                    image.ScaleAbsolute(pokerWidthMM * dpi600PPMM, pokerHeightMM * dpi600PPMM);
                    image.SetAbsolutePosition(cords[cord, 0], cords[cord, 1]);
                    pdf.Add(image);
                    cord++;

                }

            }
            pdf.Close();
            reorderPDF();
            //for (var x = 0; x < pages * 2; x++)
            //{
            //    pdf.NewPage();
            //    for (var y = 0; y < 9; y++)
            //    {

            //        if (x % 2 == 1)
            //        {
            //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(folderText.Text + "\\" + deck.Cards[0].frontFP);
            //            image.ScaleAbsolute(pokerWidthMM * dpi600PPMM, pokerHeightMM * dpi600PPMM);
            //            image.SetAbsolutePosition(cords[y, 0], cords[y, 1]);
            //            pdf.Add(image);
            //        }
            //        else
            //        {
            //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(folderText.Text + "\\" + deck.Cards[0].rearFP);
            //            image.ScaleAbsolute(pokerWidthMM * dpi600PPMM, pokerHeightMM * dpi600PPMM);
            //            image.SetAbsolutePosition(cords[y, 0], cords[y, 1]);
            //            pdf.Add(image);

            //        }

            //    }


            //}
          

        }

        private void reorderPDF()
        {
            var inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "deck.pdf");
            var output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");

            PdfReader reader = new PdfReader(inputFile);

            using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (Document pdf = new Document(reader.GetPageSizeWithRotation(1)))
                {
                    
                    PdfCopy copy = new PdfCopy(pdf, fs);
                    pdf.Open();
                    copy.SetLinearPageMode();
                    int[] newOrder = new int[reader.NumberOfPages];
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        copy.AddPage(copy.GetImportedPage(reader, i));
                    }
                    int counter = 0;
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        
                        if(i%2 == 0)
                        {
                            newOrder[i-1] = (reader.NumberOfPages/2)+newOrder[i-2];

                        }
                        else
                        {
                            newOrder[i-1] = i - counter;
                            counter++;
                        }

                        

                    }
                    //Reorder pages
                    copy.ReorderPages(newOrder);
                    pdf.Close();
                }
            }

        }

       

        private float[,] calculateCords(Document pdf)
        {
            float[,] cords = new float[9, 2];
            float bleed = determineBleed();
            float x = (pdf.PageSize.Width / 2) - ((pokerWidthMM * dpi600PPMM) / 2) - (pokerWidthMM * dpi600PPMM) - bleed;
            float y = (pdf.PageSize.Height / 2) - ((pokerHeightMM * dpi600PPMM) / 2) - (pokerHeightMM * dpi600PPMM) - bleed;
            int z = 0;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {

                    cords[z, 0] = x + j * (pokerWidthMM * dpi600PPMM + bleed);
                    cords[z, 1] = y + i * (pokerHeightMM * dpi600PPMM + bleed);
                    z++;
                }

            }


            return cords;
        }

        private float determineBleed()
        {
            float bleed = float.Parse(determineDefault(bleedText));
            if (DPI300RB.Checked == true)
            {

                return bleed * dpi300PPMM;
            }
            else if (DPI600RB.Checked == true)
            {

                return bleed * dpi600PPMM;
            }
            else
            {

                return bleed;
            }

        }

        private int calculatePages()
        {
            double pages = Convert.ToDouble(deck.getDeckQuantity()) / 9.0;
            return (int)Math.Ceiling(pages);
        }

    }
}
