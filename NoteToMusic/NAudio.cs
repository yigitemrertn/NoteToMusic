using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Midi;
using WMPLib;




namespace NoteToMusic
{
    public class NAudio
    {
        public bool isPlaying;
        public async Task PlayMIDI(string filePath)
        {
            Form1 frm = new Form1();
            var midiFile = new MidiFile(filePath, false);
            using (var midiOut = new MidiOut(0))
            {
                foreach (var track in midiFile.Events)
                {

                    for (int i = 0; i < track.Count(); i++)
                    {
                            var midiEvent = track[i];
                            int deltaTime = midiEvent.DeltaTime;

                            if (deltaTime > 0)
                                await Task.Delay(deltaTime);

                            midiOut.Send(midiEvent.GetAsShortMessage());

                    }


                }
            }
        }
    }
}
