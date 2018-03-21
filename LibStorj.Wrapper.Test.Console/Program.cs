using LibStorj.Wrapper.Contracts.Interfaces;
using LibStorj.Wrapper.Contracts.Models;
using LibStorj.Wrapper.x64;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Test.Console.x64
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            IStorjUtils utils = new StorjUtils();

            //First test - if this fails, the system could not load the DLLs correctly.
            var timestamp = utils.GetTimestamp();

            IStorj storj = new Storj();
            //Set your keys and Mnemonics here or provide a keyfile vie the overloads.
            storj.ImportKeys(new Contracts.Models.Keys("USER","PASSWORD","MNEMONIC"),"PASSPHRASE");
            var keyExist = storj.KeysExist; //This is not really working - it always returns "true"
            
            var buckets = await storj.GetBucketsAsync(); //Load all buckets - if that works your credentials did work
            var files = await storj.ListFilesAsync(buckets[0]); //Load the files of the first bucket

            //Get the versions of the dependencies to see if they work
            var v1 = (new VersionInfo()).GetCurlVersion();
            var v2 = (new VersionInfo()).GetLibuvCVersion();
            var v3 = (new VersionInfo()).GetJsonCVersion();
            var v4 = (new VersionInfo()).GetNettleVersion();

            storj.UploadFile(buckets[0].Id, "Uploadfile.txt", @"YOURPATH\YOURFILE.txt"); //Test-upload a file - provide a path to a small file here

            //At this point, the upload does not work.
            //After the next line the upload works but blocks GetInfoAsync. If the file is uploaded, the GetInfo is executed and returns
            var info = await storj.GetInfoAsync();

            //The same with download
            var job = storj.DownloadFile(files.Item2.First(), @"YOURPATH\YOURFILE.txt");
            while(!job.IsFinished)
            {
                System.Console.Clear();
                System.Console.WriteLine("Status: " + job.CurrentProgress.DoneBytes + "/" + job.CurrentProgress.TotalBytes + " - " + job.CurrentProgress.Progress + "%");
                //The same like above
                var infoDownload = await storj.GetInfoAsync();
            }
        }
        static void OnDownloadProgress(ProgressStatusDownload progress)
        {
            System.Console.WriteLine("DownloadProgress: " + progress.Progress);
        }
    }
}
