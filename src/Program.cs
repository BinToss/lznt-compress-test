using System;
using System.IO;
using System.Management;

namespace comtest
{
  public static class Program
  {
    public static void Main()
    {
      try
      {
        var target = @"D:\New Folder";
        var dirInfo = new DirectoryInfo(target);
        Console.ReadKey();
        if ((dirInfo.Attributes & FileAttributes.Compressed) != FileAttributes.Compressed)
        {
          var objPath = $"Win32_Directory.Name='{target}'";
          using (var dir = new ManagementObject(objPath))
          {
            var outParams = dir.InvokeMethod("Compress", null, null);
            uint ret = (uint)outParams.Properties["ReturnValue"].Value;
            Console.WriteLine(dir["Name"]);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}