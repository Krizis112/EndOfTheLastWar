using System.Collections.Generic;
using System.Linq;

public class Bioms 
{
	public static Dictionary<string, Biom> bioms = new Dictionary<string, Biom>();
	public static Biom error, forest;

	public static void load() 
	{
		error = new Biom("error");
		forest = new Biom("forest") 
		{
			speedMultiplier = 2,
		}.colors("caffff", "c8ffff", "cbffff").add();
	}

	public static Biom getBiomWithColor(string color) 
	{
		return bioms.Values.FirstOrDefault(biom => biom.colorsArray.Contains(color));
	}
}
