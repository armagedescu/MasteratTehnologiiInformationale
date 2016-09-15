using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace USM.ProgramareVisuala.Lab1
{
partial class MainApp
{
	static string defaultFloareDbName = ".\\flori.db.xml";
    string floareDbName = defaultFloareDbName;
	XmlSerializer serializer = new XmlSerializer(typeof(FloareSet));


	FloareSet getFloareDb () { return getFloareDb (floareDbName); }
	FloareSet getFloareDb (string dbName)
	{
	    if (!File.Exists (dbName)) createDefaultFloareDb(dbName);
		return loadFloareDb(dbName);
	}

	FloareSet loadFloareDb () {return loadFloareDb (floareDbName); }
	FloareSet loadFloareDb (string dbName)
	{
		StreamReader streamer = new StreamReader(dbName);
		FloareSet floareSet = (FloareSet)serializer.Deserialize(streamer);
		streamer.Close();
		return floareSet;
	}

	void createDefaultFloareDb (String dbName)
	{
		FloareSet floareSet = getDefaultFloareSet();
		saveFloareDb (floareSet, dbName);
	}

	public void saveFloareDb (FloareSet floareSet) { saveFloareDb (floareSet, floareDbName); }
	public void saveFloareDb (FloareSet floareSet, String dbName)
	{
		TextWriter writer = new StreamWriter(dbName);
		
		serializer.Serialize(writer, floareSet);
		writer.Close();
	}

	FloareSet getDefaultFloareSet()
	{
		return new FloareSet
		{
			Flori = new Floare[]
					{
						new Floare
						{
							Denumire = "Regina Noptii",
							DenumireStiintifica = "Selenicereus grandifloris",
							ClasaBiologica = "Cactaceae",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Peyota",
							DenumireStiintifica = "Lophophora williamsii",
							ClasaBiologica = "Cactaceae",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Macies",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Trandafir",
							DenumireStiintifica = "Rosa canina",
							ClasaBiologica = "Rosaceae",
							Longevitate = Longevitate.Perena
						},
						new Floare
						{
							Denumire = "Grau comun",
							DenumireStiintifica = "Triticum aestivum",
							ClasaBiologica = "Poaceae",
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
	
	void resourceTest()
	{
		Assembly _assembly = Assembly.GetExecutingAssembly();
        StreamReader _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("textressample.txt"));
		Console.WriteLine("read from resource: " + _textStreamReader.ReadToEnd());
	}

}

//Stream  _imageStream = _assembly.GetManifestResourceStream("textsample.txt");
//pictureBox1.Image = new Bitmap(_imageStream);	
//Console.WriteLine(_textStreamReader.ReadLine());
//var fileStream = new FileStream(@"c:\file.txt", FileMode.Open, FileAccess.Read);
//using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
//{
//    text = streamReader.ReadToEnd();
//}


}