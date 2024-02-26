using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZemberekDotNet.Morphology;
using ZemberekDotNet.Morphology.Analysis;
using ZemberekDotNet.Normalization;
using ZemberekDotNet.Tokenization;
using ZemberekDotNet.Core.Turkish;
using ZemberekDotNet.Morphology.Lexicon;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegExVeMorfolojikAnaliz
{
    public partial class Form1 : Form
    {
        private TurkishMorphology morphology;
        private TurkishSpellChecker spellChecker;

        public Form1()
        {
            InitializeComponent();
            morphology = TurkishMorphology.CreateWithDefaults();
            spellChecker = new TurkishSpellChecker(morphology);
        }

        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyalar?|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDosyaAdi.Text = openFileDialog.FileName;
                lblDosyaAdi.Text = Path.GetFileName(openFileDialog.FileName);
            }
        }

        private void btnRegexArama_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaAdi.Text))
            {
                MessageBox.Show("Ilk asama olarak Dosya Seçimi yapmalisiniz. Lütfen bir dosya seçiniz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string regexKomutu = txtAranacakRegex.Text;
            if (string.IsNullOrWhiteSpace(regexKomutu))
            {
                MessageBox.Show("Lütfen RegEx komutunuzu giriniz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string dosyaOkunma = File.ReadAllText(txtDosyaAdi.Text);
                MatchCollection matches = Regex.Matches(dosyaOkunma, regexKomutu);
                List<string> sonuclar = new List<string>();
                foreach (Match match in matches)
                {
                    sonuclar.Add(match.Value);
                }
                regexAramaSonucuForm sonuclarForm = new regexAramaSonucuForm(sonuclar);
                sonuclarForm.Show();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Dosya okuma islemlerinde bir hata bulunmakta: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TurkishSpellChecker GetSpellChecker()
        {
            return spellChecker;
        }
        private void btnMorfolojikAnaliz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaAdi.Text))
            {
                MessageBox.Show("İlk asama olarak Dosya Seçimi yapmalisiniz. Lütfen bir dosya seçiniz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string dosyaOkuma = File.ReadAllText(txtDosyaAdi.Text);
                string noktalamaIsaretsizMetin = noktalamaİsaretleriniTemizle(dosyaOkuma);
                string duzeltilmisMetin = hataliYazilariDuzelt(noktalamaIsaretsizMetin, GetSpellChecker());

                richTxtMorfolojikAnalizGetir.Text = duzeltilmisMetin;

                List<string> kelimeler = duzeltilmisMetin.Split(' ').ToList();

                HashSet<string> morfolojiÖncesiEssizKelime = new HashSet<string>(kelimeler);
                int morfolojiÖncesiEssizKelimeSayisi = morfolojiÖncesiEssizKelime.Count;

                Dictionary<string, string> morfolojikAnaliz = new Dictionary<string, string>();

                foreach (string kelime in morfolojiÖncesiEssizKelime)
                {
                    string kok = kokBulma(kelime); 
                    string morfolojikAnalizBulma = morfolojikAnalizBul(kelime);
                    morfolojikAnaliz.Add(kelime, $"{kok +morfolojikAnalizBulma}");
                }

                int morfolojiSonrasiEssizKelimeSayisi = morfolojikAnaliz.Count;

                morfolojikAnalizSonucuForm morfolojikAnalizGoster = new morfolojikAnalizSonucuForm(morfolojikAnaliz);
                morfolojikAnalizGoster.Show();
                MessageBox.Show($"Kök alma işlemi öncesi eşsiz kelime sayisi : {morfolojiÖncesiEssizKelimeSayisi}\nKök alma işlemi sonrası eşsiz kelime sayisi: {morfolojiSonrasiEssizKelimeSayisi}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Dosya okuma hatasi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string hataliYazilariDuzelt(string metin, TurkishSpellChecker spellChecker)
        {
            string[] kelimeler = metin.Split(' ');
            List<string> duzeltilmisKelimeler = new List<string>();

            foreach (string kelime in kelimeler)
            {
                if (!spellChecker.Check(kelime))
                {
                    List<string> duzeltilmisKelimelerListesi = spellChecker.SuggestForWord(kelime);
                    duzeltilmisKelimeler.AddRange(duzeltilmisKelimelerListesi);
                }
                else
                {
                    duzeltilmisKelimeler.Add(kelime);
                }
            }

            string duzeltilmisMetin = string.Join(" ", duzeltilmisKelimeler.ToArray());
            return duzeltilmisMetin;
        }

        private string noktalamaİsaretleriniTemizle(string metin)
        {
            string[] noktalamaIsaretleri = { ".", ",", ";", ":", "!", "?", "'", "\"", "(", ")", "[", "]", "{", "}", "<", ">", "*", "-" };

            foreach (string isaret in noktalamaIsaretleri)
            {
                metin = metin.Replace(isaret, "");
            }

            return metin;
        }
        private string kokBulma(string kelime)
        {
            SingleAnalysis? analysis = morphology.Analyze(kelime).FirstOrDefault();
            string kokBulma = analysis.GetStem();
            return kokBulma;

        }
        private string morfolojikAnalizBul(string kelime)
        {
            SingleAnalysis? analysis = morphology.Analyze(kelime).FirstOrDefault();
            string morfolojikAnaliz = analysis?.ToString() ?? string.Empty;

            return morfolojikAnaliz;
        }
    }
}