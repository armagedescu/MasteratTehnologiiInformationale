using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

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
            FloareSet.SelectMetoda = FloareSet.SelectMetoda.GetValueOrDefault(SelectMetoda.DupaClasa);
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
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Peyota",
							DenumireStiintifica = "Lophophora williamsii",
							ClasaBiologica = "Cactaceae",
							Utilizare = "Culturala",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Macies",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Utilizare = "Medicinala",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Trandafir",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Utilizare = "Decorativa",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Grau comun",
							DenumireStiintifica = "Triticum aestivum",
							ClasaBiologica = "Poaceae",
							Utilizare = "Alimentara",
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

 

    }
}
