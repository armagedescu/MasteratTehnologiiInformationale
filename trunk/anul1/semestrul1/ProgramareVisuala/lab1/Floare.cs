namespace USM.ProgramareVisuala.Lab1
{

using System;
using System.IO;
public class Floare
{
   public string Denumire{get;set;}
   public string DenumireStiintifica{get;set;}
   public Longevitate? Longevitate{get; set;}
   public double? LungimeMedie;
   public double? LungimeMaxima;

	/////////   output   ///////////
   public void Write(TextWriter writer, string indent)
   {
        string indent1 = indent + "   ";
       	writer.WriteLine(indent + "{");
		writer.WriteLine(String.Format("{0}Denumire:'{1}'", indent1, Denumire));
		writer.WriteLine(String.Format("{0}DenumireStiintifica:'{1}'", indent1, DenumireStiintifica));
		writer.WriteLine(String.Format("{0}Longevitate:'{1}'", indent1, Longevitate));
       	writer.WriteLine(indent + "}");
   }
}

public class FloareSet
{
    public Floare[] Flori {get; set;}
	
	/////////   output   ///////////
    public void Write(TextWriter writer, string indent = "")
	{
	    string indent1 = indent + "   ";
		string indent2 = indent1 + "   ";
	    writer.WriteLine(indent + "FloareSet:");
	    writer.WriteLine(indent + "{");
	    writer.WriteLine(indent1 + "FloareSet:");
	    writer.WriteLine(indent1 + "[");
		foreach (Floare floare in Flori) floare.Write(writer, indent2);
	    writer.WriteLine(indent1 + "]");
	    writer.WriteLine(indent + "}");
	}
}

public enum Longevitate
{
   Anuala, Bianuala, Perena
}

}