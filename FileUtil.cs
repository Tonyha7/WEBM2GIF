using ImageMagick;

namespace WEBM2GIF
{
    public class FileUtil
    {
        public static void FindAndConvent(String inpath, String? outd =null, bool delo=false)
        {
            DirectoryInfo ind = new DirectoryInfo(inpath);
            if (outd == null)
            {
                outd = ind.FullName;
            }
            FileInfo[] fis = ind.GetFiles();
            for (int i = 0; i < fis.Length; i++)
            {
                if (fis[i].Name.ToLower().EndsWith(".webm"))
                {
                    Console.WriteLine("Found File:" + fis[i].FullName + " Let's Go.");

                    using var animatedWebP = new MagickImageCollection(fis[i].FullName);
                    animatedWebP.Write(outd+fis[i].Name + ".gif", MagickFormat.Gif);

                    if (delo)
                    {
                        File.Delete(fis[i].FullName);
                        Console.WriteLine("Deleted:" + fis[i].FullName);
                    }
                }
                
            }
            DirectoryInfo[] dis = ind.GetDirectories();
            for (int j = 0; j < dis.Length; j++)
            {
                FindAndConvent(dis[j].FullName,outd,delo);
            }
        }
    }
}
