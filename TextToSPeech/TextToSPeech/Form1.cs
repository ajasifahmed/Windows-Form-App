using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace TextToSPeech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Speaking.....";
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Volume = trackBar1.Value;
            ss.Speak(textBox1.Text);
            button1.Text ="Speak";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "Listining.....";
            SpeechRecognitionEngine sp = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sp.LoadGrammar(gr);
            try
            {
                sp.SetInputToDefaultAudioDevice();
                RecognitionResult re = sp.Recognize();
                textBox1.Text = re.Text;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sp.UnloadAllGrammars(); 
            }
            button2.Text = "Text to speech";
        }
        
    }
}
