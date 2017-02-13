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
using System.Diagnostics;



namespace PDFGenerator
{

    public partial class Form1 : Form
    {
        Deck deck;
        private readonly float dpi600Width_A4 = 4961;
        private readonly float dpi600Height_A4 = 7016;
        private readonly float dpi300Width_A4 = 2480;
        private readonly float dpi300Height_A4 = 3508;

        private readonly float dpi600PPMM_A4 = 4961.00f / 210.00f;
        private readonly float dpi300PPMM_A4 = 2480.00f / 210.00f;
        private readonly float dpi600Width_Letter = 5100;
        private readonly float dpi600Height_Letter = 6600;
        private readonly float dpi300Width_Letter = 2550;
        private readonly float dpi300Height_Letter = 3300;

        private readonly float dpi600PPMM_Letter = 5100.00f / 215.90f;
        private readonly float dpi300PPMM_Letter = 2550.00f / 279.40f;

        private readonly float mmToInch = 25.4f;
        private readonly float mmWidth_A4 = 210;
        private readonly float mmHeight_A4 = 297;
        private readonly float mmWidth_Letter = 215.90f;
        private readonly float mmHeight_Letter = 279.40f;
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
                List<string> extensions = determineFileExtensions();
                string[] fronts = parseTextBox(frontText);
                string[] rears = parseTextBox(rearText);
                string[] mutual = parseTextBox(MutualTB);


                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file).ToLower();
                    if (extensions.Any(u => fileName.Contains(u)) == true)

                        try
                        {
                            frontListView.HideSelection = false;
                            rearListView.HideSelection = false;

                            System.Drawing.Image imageToList = System.Drawing.Image.FromFile(file);
                            if (mutual.Any(u => fileName.Contains(u)) == true)
                            {
                                if (fronts.Any(u => fileName.Contains(u)) == true)
                                {
                                    frontImageList.Images.Add(imageToList);
                                    frontListView.Items.Add(Path.GetFileName(file), i);
                                    i++;
                                }
                                else if (rears.Any(u => fileName.Contains(u)) == true)
                                {
                                    rearImageList.Images.Add(imageToList);
                                    rearListView.Items.Add(Path.GetFileName(file), j);
                                    j++;
                                }
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

        public string determineTBDefault(TextBox textBox)
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
                    case "DestinationTB":
                        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    case "DestinationFileNameTB":
                        return "OrderedDeck_" + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
                    case "CustomExtensionTB":
                        return "";
                    case "MutualTB":
                        return "";
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

                return Convert.ToInt32(determineTBDefault(quantityText));
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
            determineDPI();
            determineCardSize();
            determinePageSize();


            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(deck.widthPaperPixel, deck.heightPaperPixel);
            Document pdf = new Document(rect);
            //pdf.SetPageSize(rect);
            pdf.AddCreator("ICWT Dev");
            string unorderedPDF = "UnorderedDeck.pdf";

            var output = File.Create(unorderedPDF);
            PdfWriter.GetInstance(pdf, output);
            pdf.Open();
            int pages = calculatePages();
            float[,] cords = calculateCords(pdf);
            var cord = 0;
            foreach (var card in deck.Cards)
            {
                for (var q = 0; q < card.quantity; q++)
                {
                    if (cord == 9)
                    {
                        pdf.NewPage();
                        cord = 0;
                    }
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(folderText.Text + "\\" + card.frontFP);
                    image.ScaleAbsolute(deck.widthCardPixel, deck.heightCardPixel);
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
                    image.ScaleAbsolute(deck.widthCardPixel, deck.heightCardPixel);
                    image.SetAbsolutePosition(cords[cord, 0], cords[cord, 1]);
                    pdf.Add(image);
                    cord++;

                }

            }
            pdf.Close();
            reorderPDF(unorderedPDF);



        }




        private void reorderPDF(string unorderedPDF)
        {
            PdfReader reader = new PdfReader(unorderedPDF);
            var output = determineOutputFile();

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

                        if (i % 2 == 0)
                        {
                            newOrder[i - 1] = (reader.NumberOfPages / 2) + newOrder[i - 2];

                        }
                        else
                        {
                            newOrder[i - 1] = i - counter;
                            counter++;
                        }
                    }
                    //Reorder pages
                    copy.ReorderPages(newOrder);
                    pdf.Close();
                    fs.Close();
                    reader.Close();
                }
            }
            if (LaunchCB.Checked)
            {
                Process.Start(output);
            }

        }





        private float[,] calculateCords(Document pdf)
        {
            float[,] cords = new float[9, 2];
            float bleedPixel = determineBleedPixel();
            float x = (pdf.PageSize.Width / 2) - ((deck.widthCardPixel) / 2) - (deck.widthCardPixel) - bleedPixel;
            float y = (pdf.PageSize.Height / 2) - ((deck.heightCardPixel) / 2) - (deck.heightCardPixel) - bleedPixel;
            int z = 0;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {

                    cords[z, 0] = x + j * (deck.widthCardPixel + bleedPixel);
                    cords[z, 1] = y + i * (deck.heightCardPixel + bleedPixel);
                    z++;
                }

            }


            return cords;
        }
        private void determineDPI()
        {
            if (DPI300RB.Checked)
            {
                deck.dpi = 300;

            }
            else if (DPI600RB.Checked)
            {
                deck.dpi = 600;

            }
            else
            {
                deck.dpi = 300;
            }
        }
        private void determinePageSize()
        {
            if (LetterRB.Checked)
            {
                deck.heightPaperPixel = calculatePixelFromMMRounded(mmHeight_Letter);
                deck.widthPaperPixel = calculatePixelFromMMRounded(mmWidth_Letter);

            }
            else if (A4RB.Checked)
            {
                deck.heightPaperPixel = calculatePixelFromMMRounded(mmHeight_A4);
                deck.widthPaperPixel = calculatePixelFromMMRounded(mmWidth_A4);

            }
            else
            {
                deck.heightPaperPixel = calculatePixelFromMMRounded(mmHeight_Letter);
                deck.widthPaperPixel = calculatePixelFromMMRounded(mmWidth_Letter);

            }
        }




        private void determineCardSize()
        {
            //default will be poker sizes, but allowing for potentially more sizes. 
            if (PokerRB.Checked)
            {
                deck.widthCardPixel = calculatePixelFromMMRounded(pokerWidthMM);
                deck.heightCardPixel = calculatePixelFromMMRounded(pokerHeightMM);
            }
            else
            {
                deck.widthCardPixel = calculatePixelFromMMRounded(pokerWidthMM);
                deck.heightCardPixel = calculatePixelFromMMRounded(pokerHeightMM);

            }
        }

        private float determineBleedPixel()
        {
            if (ZeroMMRB.Checked)
            {
                return calculatePixelFromMM(0);

            }
            else if (OneMMRB.Checked)
            {
                return calculatePixelFromMM(1);

            }
            else if (ThreeMMRB.Checked)
            {
                return calculatePixelFromMM(3);

            }
            else if (FiveMMRB.Checked)
            {

                return calculatePixelFromMM(5);
            }
            else if (CustonBleedRB.Checked)
            {
                return calculatePixelFromMM(float.Parse(determineTBDefault(bleedText)));

            }
            else
            {
                return calculatePixelFromMM(0);

            }



        }

        private string determineOutputFile()
        {
            return Path.Combine(determineTBDefault(DestinationTB), determineTBDefault(DestinationFileNameTB)); ;
        }

        private List<string> determineFileExtensions()
        {
            List<string> extension = new List<string>();
            if (PNGCB.Checked)
            {
                extension.Add(".png");

            }
            if (JPEGCB.Checked)
            {
                extension.Add(".jpeg");
                extension.Add(".jpg");

            }
            if (GIFCB.Checked)
            {
                extension.Add(".gif");

            }
            if (TIFFCB.Checked)
            {
                extension.Add(".tiff");

            }
            if (CustomExtensionCB.Checked)
            {
                extension.AddRange(parseTextBox(CustomExtensionTB));
                
            }
            return extension;
        }

        private string[] parseTextBox(TextBox textBox)
        {
            string[] singleText = new string[]{ determineTBDefault(textBox)};
            if (singleText[0] != "" && textBox.Text.Length > 3)
            {
                return textBox.Text.Split(';');
            }
            return singleText;
        }

        private int calculatePages()
        {
            double pages = Convert.ToDouble(deck.getDeckQuantity()) / 9.0;
            return (int)Math.Ceiling(pages);
        }

        private int calculatePixelFromMMRounded(float lengthMM)
        {
            return (int)Math.Round(((lengthMM / mmToInch) * deck.dpi));
        }
        private float calculatePixelFromMM(float lengthMM)
        {
            return ((lengthMM / mmToInch) * deck.dpi);
        }




        private void DPI600RB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DestinationTB.Clear();
                folderText.Text = fbd.SelectedPath.ToString();
            }



        }

        private void bleedText_TextChanged(object sender, EventArgs e)
        {

        }

        private void OneMMRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FileExtesionLabel_Click(object sender, EventArgs e)
        {

        }



    }
}
