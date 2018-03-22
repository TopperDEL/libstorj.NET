using LibStorj.Wrapper.Contracts.Interfaces;
using LibStorj.Wrapper.x64;
using Nito.AsyncEx;

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

            //Get the versions of the dependencies to see if they work
            var v1 = (new VersionInfo()).GetCurlVersion();
            var v2 = (new VersionInfo()).GetLibuvCVersion();
            var v3 = (new VersionInfo()).GetJsonCVersion();
            var v4 = (new VersionInfo()).GetNettleVersion();

            IStorj storj = new Storj();
            //Set your keys and Mnemonics here or provide a keyfile via the overloads.
            storj.ImportKeys(new Contracts.Models.Keys("USER","PASSWORD","MNEMONIC"),"PASSPHRASE");
            
            var buckets = await storj.GetBucketsAsync(); //Load all buckets - if that works your credentials did work
           
            //Now do whatever you like - storj is working for you! :)
        }
    }
}
