
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.MusicTheory;
using System.Windows.Forms;

namespace NoteToMusic
{
    public class ToMIDI
    {
        public static void Convert(string xmlPath, string midiOutputPath)
        {
            try
            { 
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                var midiFile = new MidiFile();
                var trackChunk = new TrackChunk();
                midiFile.Chunks.Add(trackChunk);

                var tempoMap = midiFile.GetTempoMap();
                var noteEvents = new List<Melanchall.DryWetMidi.Interaction.Note>();
          

                int ticksPerQuarterNote = 180; 
                long currentTime = 0; 
                int previousNoteEndTime = 0;

                   XmlNodeList noteNodes = xmlDoc.SelectNodes("//note");

                    foreach (XmlNode noteNode in noteNodes)
                    {
                        XmlNode pitchNode = noteNode.SelectSingleNode("pitch");
                        XmlNode durationNode = noteNode.SelectSingleNode("duration");

                        if (pitchNode != null && durationNode != null)
                        {
                            string step = pitchNode.SelectSingleNode("step").InnerText; 
                            int octave = int.Parse(pitchNode.SelectSingleNode("octave").InnerText);
                            int duration = int.Parse(durationNode.InnerText);

                            NoteName noteEnum;
                            if (Enum.TryParse(step, out noteEnum))
                            {
                                var midiNote = new Melanchall.DryWetMidi.Interaction.Note(noteEnum, octave);
                                noteEvents.Add(midiNote);

                                int noteStartTime = (int)currentTime;
                                int noteDuration = duration * ticksPerQuarterNote;

                                trackChunk.Events.Add(new NoteOnEvent((SevenBitNumber)midiNote.NoteNumber, (SevenBitNumber)100) { DeltaTime = noteStartTime - previousNoteEndTime });
                                trackChunk.Events.Add(new NoteOffEvent((SevenBitNumber)midiNote.NoteNumber, (SevenBitNumber)100) { DeltaTime = noteDuration });

                                previousNoteEndTime = noteStartTime + noteDuration;
                            }
                            currentTime += duration * ticksPerQuarterNote;
                        }
                    }
               

                midiFile.Write(midiOutputPath, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}   
