using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vosk;

namespace AudioToText
{
    public class ConvertAudiotoText
    {
        
        public void Translate(string audioPath) 
        {
            
            string modelPath = "Model"; // Path to the downloaded model folder
            string audioFilePath = audioPath; // Path to the audio file

            if (Directory.Exists(modelPath) && File.Exists(audioFilePath))
            {
                using (var model = new Model(modelPath))
                using (var recognizer = new VoskRecognizer(model, 16000.0f))
                {
                    string fileExtension = Path.GetExtension(audioFilePath);
                    string NewAFP = "";
                    if (fileExtension == ".wav")
                    {
                        DecodingAndRessempling ResamplerWav = new DecodingAndRessempling();
                        NewAFP = ResamplerWav.ResampleWav(audioFilePath);
                    }

                    if (fileExtension == ".mp3")
                    {
                        DecodingAndRessempling ResamplerMP3 = new DecodingAndRessempling();
                        NewAFP = ResamplerMP3.ConvertMp3ToWav(audioFilePath);
                    }
                    using (var audioStream = new FileStream(NewAFP, FileMode.Open))
                    {
                        byte[] audioData = new byte[audioStream.Length];
                        audioStream.Read(audioData, 0, (int)audioStream.Length);

                        recognizer.AcceptWaveform(audioData, audioData.Length);
                        var result = recognizer.Result();
                
                            //сохранение в файл
                        File.WriteAllText("result.txt", result);
                        MessageBox.Show("Расшифровка закончена!", "Расшифровка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            File.Delete(NewAFP);

                            Console.WriteLine("Промежуточный файл удален успешно.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при удалении промежуточного файла: " + ex.Message);
                        } 

                    }
                }
            }
            else
            {
                Console.WriteLine("Model path or audio file not found.");
                MessageBox.Show("Ошибка!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveText(string savePath)
        {
            var save = File.ReadAllText("result.txt");

            MessageBox.Show("Файл сохранен!" , "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            File.WriteAllText(savePath, save);
            File.WriteAllText("result.txt", "");

            
        }

    }

    
}
