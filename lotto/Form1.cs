using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Oletetaan, ett‰ kaikki lottorivin checkboxit ovat groupBox1 sis‰ll‰
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox checkBox)
                {
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;
                }
            }

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox = sender as CheckBox;

            // Lasketaan, kuinka monta checkboxia on valittu
            int valittujenMaara = groupBox1.Controls.OfType<CheckBox>().Count(cb => cb.Checked);

            if (valittujenMaara > 7)
            {
                // Jos yritet‰‰n valita enemm‰n kuin 7, estet‰‰n valinta ja informoidaan k‰ytt‰j‰‰
                clickedCheckBox.Checked = false;
                MessageBox.Show("Voit valita enint‰‰n 7 numeroa per lottorivi.", "Liian monta valintaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPelaa_Click(object sender, EventArgs e)
        {

            int j, rahat, pelit;
            string apumuuttuja = "";
            j = 0;
            rahat = int.Parse(textBox2.Text);
            pelit = int.Parse(textBox3.Text);

            foreach (Control control in groupBox1.Controls)
            {

                if (control is CheckBox checkBox)
                {
                    // tee jotain lˆytyneelle checkboxille
                    if (checkBox.Checked)
                    {
                        j++;
                        if (j < 8)
                        {

                            apumuuttuja += checkBox.Text + " ";

                            if (j == 7)
                            {
                                textBox1.Text += apumuuttuja;
                                textBox1.Text += Environment.NewLine;


                                if (rahat < 2)
                                {
                                    MessageBox.Show("Tarvitset v‰hint‰‰n 2 euroa pelata lottoa.");
                                    return;
                                }


                                if (rahat >= 2)
                                {
                                    rahat = (rahat - 2);
                                    textBox2.Text = rahat.ToString();
                                    pelit += 2;
                                    textBox3.Text = pelit.ToString();
                                }
                            }

                        }

                    }


                }
            }

        }

        private void btnNollaa_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
