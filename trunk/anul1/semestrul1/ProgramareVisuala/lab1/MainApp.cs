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

    public static int Main (string[] args)
	{
	    MainApp mainApp =  new MainApp(".\\flori.db.xml");
		FloareSet floareSet = mainApp.getFloareDb();
		mainApp.WriteAsXml(Console.Out, floareSet);
		floareSet.Write(Console.Out);
		mainApp.resourceTest();
		FloareDialog floareDialog = new FloareDialog(floareSet);
	    return 0;
	}

	MainApp (string dbName = "")
	{
		if (dbName == "") dbName = this.floareDbName;
		this.floareDbName = dbName;
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