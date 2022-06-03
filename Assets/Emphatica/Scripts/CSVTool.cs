using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVTool
{
    private string path = Path.Combine(Application.dataPath, "../") + "/Reports";
    private string fileName;

    public CSVTool(string fileName, string header) 
    {
        if (!Directory.Exists(path)) 
        {
            Directory.CreateDirectory(path);
        }

        this.fileName = path + "/" + fileName + ".csv";

        TextWriter tw = new StreamWriter(this.fileName, false);
        tw.WriteLine(header);
        tw.Close();
    }
    
    public void WriteLine(string line) 
    {
        TextWriter tw = new StreamWriter(this.fileName, true);
        tw.Write(line);
        tw.Close();
    }

    public void WriteNewLine(string line)
    {
        TextWriter tw = new StreamWriter(this.fileName, true);
        tw.WriteLine(line);
        tw.Close();
    }

}
