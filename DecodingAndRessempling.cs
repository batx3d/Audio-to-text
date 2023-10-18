using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Lame;
using NAudio.FileFormats;
using NAudio.Wave.SampleProviders;

namespace AudioToText
{
    internal class DecodingAndRessempling
    {
        public string ConvertMp3ToWav(string mp3FilePath)
        {
            string NewAFP = "ResampledMp3.wav";
            using (var mp3Reader = new Mp3FileReader(mp3FilePath))
            {
                var monoFormat = new WaveFormat(16000, 1); // Mono format
                var resampler = new MediaFoundationResampler(mp3Reader, monoFormat); 
                byte[] buffer = new byte[resampler.WaveFormat.AverageBytesPerSecond * 10];
                int bytesRead;

                using (var writer = new WaveFileWriter(NewAFP, resampler.WaveFormat))
                {
                    // Read audio from the resampler and write it to the WAV file
                    while ((bytesRead = resampler.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
            return NewAFP;
        }

        public string ResampleWav(string inputWavFilePath)
        {
            string NewAFP = "ResampledWav.wav";
            using (var reader = new WaveFileReader(inputWavFilePath))
            {
                var format = new WaveFormat(16000, 1);

                using (var resampler = new MediaFoundationResampler(reader, format))
                {
                    WaveFileWriter.CreateWaveFile(NewAFP, resampler);
                }
            }
            return NewAFP;
        }

    }
}
