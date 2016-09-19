using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace USM.ProgramareVisuala.Lab1
{
public partial class MainApp
{
	[STAThread]
    public static int Main (string[] args)
	{
		string floareDbPath = ".\\flori.db.xml";
		if (args.Length > 0) floareDbPath = args[0];
        FloareModel floareModel = new FloareModel(floareDbPath);
        floareModel.getFloareDb();
		FloareDialog floareDialog = new FloareDialog(floareModel);
		floareDialog.ShowDialog();
        floareModel.saveFloareDb();
	    return 0;
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