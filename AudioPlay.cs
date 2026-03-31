using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

// Plase note: The code originally used from my lecturer to play the audio file unfortunately could not work,
// I have modified it to fit the needs of my project.
// so I had to make some changes to get it working(spent hours trying to get it to work).

namespace ChatBot
{
    internal class AudioPlay
    {
        // Small helper class to play audio files using the OS default handler.
        // provides a single static method to open an audio file so it plays on the user's machine.
        public static void PlayAudio(string audioFilePath)
        {
            // Attempt to play the specified audio file. This method performs basic validation before delegating
            // playback to the OS. It intentionally does not block for playback completion and does not manage audio streams.
            try
            {
                // Validate the path: ensure it's not null/empty and the file actually exists on disk.
                // tell the user if the file is missing.
                if (string.IsNullOrWhiteSpace(audioFilePath) || !File.Exists(audioFilePath))
                {
                    Console.WriteLine("Error! Audio file not found.");
                    return;
                }

                var psi = new ProcessStartInfo
                {
                    FileName = audioFilePath,
                    UseShellExecute = true,
                };

                // Use the OS shell to open the file with the default media player.
                // this launches whatever program the user has associated with the audio file.
                Process.Start(psi);
            }
            catch (Exception)
            {
                // Generic fallback for any error during playback initiation.
                // notify the user something went wrong.
                Console.WriteLine("Error! Could not play audio file");
            }
        }
    }
}