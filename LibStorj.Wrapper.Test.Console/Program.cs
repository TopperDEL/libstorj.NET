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
            IStorj storj = new Storj();
            storj.ImportKeys(new Contracts.Models.Keys("USER","PASSWORD","MNEMONIC"),"PASSPHRASE");
            var keyExist = storj.KeysExist;
            
            var buckets = await storj.GetBucketsAsync();
            var files = await storj.ListFilesAsync(buckets[4]);
            var v1 = (new VersionInfo()).GetCurlVersion();
            var v2 = (new VersionInfo()).GetLibuvCVersion();
            var v3 = (new VersionInfo()).GetJsonCVersion();
            var v4 = (new VersionInfo()).GetNettleVersion();

            //var deleted = await storj.DeleteFileAsync(files[0]);
            storj.SetDownloadDirectory(@"C:\Users\Tim Parth\Desktop\storjdown\");

            //storj.UploadFile(buckets[4].Id, "Uploadfile.txt", @"C:\Users\Tim Parth\Desktop\storjdown\Uploadfile.txt");
            //var info = await storj.GetInfoAsync();
            //for(int i = 0; i<10000;i++)
            //{

            //}
            //var file = await storj.UploadFile(buckets[4].Id, "Uploadfile.txt", @"C:\Users\Tim Parth\Desktop\storjdown\Uploadfile.txt");
            //string path = await storj.DownloadFile(files.First(), @"C:\Users\Tim Parth\Desktop\storjdown\download.txt");
            var job = storj.DownloadFile(files.First(), @"C:\Users\Tim Parth\Desktop\storjdown\download.txt");
            while(!job.IsFinished)
            {
                System.Console.Clear();
                System.Console.WriteLine("Status: " + job.CurrentProgress.DoneBytes + "/" + job.CurrentProgress.TotalBytes + " - " + job.CurrentProgress.Progress + "%");
                //var info = await storj.GetInfoAsync();

            }
            //for (int i = 0; i < 10; i++)
            {
                var info = await storj.GetInfoAsync();
            }


            return;

            //System.Console.WriteLine("Starte Test...");
            //bool result = await storj.TestAsync();
            //System.Console.WriteLine("TestResult: " + result);

            //System.Console.WriteLine("GetInfo...");
            //var info = await storj.GetInfoAsync();
            //System.Console.WriteLine("GetInfoResult: " + info.Title + " - " + info.Description + " - " + info.Version + " - " + info.Host);

            //System.Threading.Thread.Sleep(10000);
        }
        static void OnDownloadProgress(ProgressStatusDownload progress)
        {
            System.Console.WriteLine("DownloadProgress: " + progress.Progress);
        }
    }
}
