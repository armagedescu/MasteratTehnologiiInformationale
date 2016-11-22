using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace USM.ProgramareVisuala.Lab1
{
    public class FloareModel
    {
        public FloareModel(string dbName)
	    {
	    	this.floareDbName = dbName;
	    }
        string floareDbName;
        string xmlName = "flori.db.xml";
        string buildXmlPath(string path) { return path + "\\" + xmlName; }
        string buildImgPath(string imgName) { return floareDbName + "\\" + imgName; }
        string getDb() { return floareDbName; }
        string getXmlName() { return buildXmlPath(floareDbName); }

        XmlSerializer serializer = new XmlSerializer(typeof(FloareSet));
        public FloareSet FloareSet {get; set;}
        public Floare[] Flori
        {
            get { return FloareSet.Flori; }
            set { FloareSet.Flori = value; }
        }
        public SelectMetoda SelectMetoda
        {
            get { return FloareSet.SelectMetoda.GetValueOrDefault(SelectMetoda.DupaClasa); }
            set { FloareSet.SelectMetoda = value; }
        }

        public void getFloareDb()
        {
            if (!File.Exists(getXmlName()) ) createDefaultFloareDb( );
            FloareSet = loadFloareDb();
        }

        FloareSet loadFloareDb()
        {
            StreamReader streamer = new StreamReader(getXmlName());
            FloareSet floareSet = (FloareSet)serializer.Deserialize(streamer);
            streamer.Close();
            return floareSet;
        }

        public void createDefaultFloareDb()
        {
            FloareSet = getDefaultFloareSet();
            saveFloareDb();
        }

        public void saveFloareDb()
        {
            saveFloareDbTo(getDb());
        }
        public void checkFolder(string path)
        {
            if (Directory.Exists(path)) return;
            DirectoryInfo directory = Directory.CreateDirectory(path);
        }
        public void saveFloareDbTo(string path)
        {
            checkFolder(path);
            foreach (Floare floare in Flori)
            {
                Imagine imagine = floare.Imagine;
                if (imagine == null) continue;
                if (string.IsNullOrWhiteSpace(imagine.NumeImagine) && string.IsNullOrWhiteSpace(imagine.SystemPath))
                    floare.Imagine = null;
                else if (!string.IsNullOrWhiteSpace(imagine.SystemPath))
                {
                    if (!string.IsNullOrWhiteSpace(imagine.NumeImagine))
                        File.Delete(buildImgPath(imagine.NumeImagine));
                    string extension = Path.GetExtension(imagine.SystemPath);
                    imagine.NumeImagine = Guid.NewGuid().ToString() + extension;
                    File.Copy(imagine.SystemPath, buildImgPath(imagine.NumeImagine));
                }
                else if (floare.Sters && floare.Imagine != null && !string.IsNullOrWhiteSpace(imagine.NumeImagine))
                {
                    File.Delete(buildImgPath(floare.Imagine.NumeImagine));
                }
            }
            Floare[] flori = Flori.Where(f => !f.Sters).ToArray();
            Flori = flori;


            //TODO: review this code
            //FloareSet.SelectMetoda = FloareSet.SelectMetoda.GetValueOrDefault(SelectMetoda.DupaClasa);
            TextWriter writer = new StreamWriter(buildXmlPath(path));
            serializer.Serialize(writer, FloareSet);
            writer.Close();
        }
        FloareSet getDefaultFloareSet()
        {
            return new FloareSet
            {
                SelectMetoda = SelectMetoda.DupaClasa,
                Flori = new Floare[]
					{
						new Floare
						{
							Denumire = "Regina Noptii",
							DenumireStiintifica = "Selenicereus grandifloris",
							ClasaBiologica = "Cactaceae",
							Utilizare = "Decorativa",
							Longevitate = Longevitate.Perena,
                            Tulpina = Tulpina.Taratoare
						},
						new Floare
						{
							Denumire = "Peyota",
							DenumireStiintifica = "Lophophora williamsii",
							ClasaBiologica = "Cactaceae",
							Utilizare = "Culturala",
							Longevitate = Longevitate.Perena,
                            Tulpina = Tulpina.Erecta
						},
						new Floare
						{
							Denumire = "Macies",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Utilizare = "Medicinala",
							Longevitate = Longevitate.Perena,
                            Tulpina = Tulpina.Erecta
						},
						new Floare
						{
							Denumire = "Trandafir",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Utilizare = "Decorativa",
                            Tulpina = Tulpina.Erecta,
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Grau comun",
							DenumireStiintifica = "Triticum aestivum",
							ClasaBiologica = "Poaceae",
							Utilizare = "Alimentara",
                            Tulpina = Tulpina.Erecta,
							Longevitate = Longevitate.Perena
						}
					}
            };
        }
        void WriteAsXml(TextWriter writer, FloareSet floareSet)
        {
            serializer.Serialize(writer, floareSet);
            writer.WriteLine();
            writer.Close();
        }



        public Image GetImage(Floare floare)
        {
            if (floare == null) return null;
            if (floare.Imagine == null) return null;
            return GetImage(floare.Imagine);
        }
        public Image GetImage(Imagine imagine)
        {
            if (string.IsNullOrWhiteSpace(imagine.NumeImagine) && string.IsNullOrWhiteSpace(imagine.SystemPath))
                return null;
            string imgPath = buildImgPath(imagine.NumeImagine);
            if (string.IsNullOrWhiteSpace(imagine.NumeImagine))
                imgPath = imagine.SystemPath;


            Image img = null;
            using (var fs = new System.IO.FileStream(imgPath, System.IO.FileMode.Open))
            {
                var bmp = new Bitmap(fs);
                img = (Bitmap)bmp.Clone(); //because need to free resources
            }

            return new Bitmap(img);
        }
    }
}
