// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using ImageMagick;
using System;
using WEBM2GIF;

String helpmsg = "this is help";
String? webmpath = null;
String? outpath = null;
bool isNeeddel = false;

switch (args.Count())
{
    case 1:
        webmpath= args[0];
        break;
    case 2:
        webmpath = args[0];
        if (args[1] == "-d")
        {
            isNeeddel = true;
        }
        else
        {
            outpath = args[1];
        }
        break;
    case 3:
        webmpath = args[0];
        outpath = args[1];
        if (args[2] == "-d")
        {
            isNeeddel= true;
        }
        break;
    default:
        Console.WriteLine(helpmsg);
        Environment.Exit(1);
        break;
}

String info = "WEBM PATH: " + webmpath + Environment.NewLine;
if (outpath != null)
{
    info+="GIF out PATH: " + outpath + Environment.NewLine;
}
if (isNeeddel)
{
    info += "Will Delete Original WEBM Files."+ Environment.NewLine;
}

Console.WriteLine(info);

FileUtil.FindAndConvent(webmpath,outpath,isNeeddel);