using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace Server
{
    class ServerThread : BaseThread
    {
        
        private TcpClient client;
        public TcpClient Client() { return client; }

        public ServerThread(TcpClient client)
        {
            this.client = client;
        }

        public override void RunThread()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            log("Podlaczono nowego klienta");
            NetworkStream ntStream = client.GetStream();
            byte[] bytesFrom = new byte[10025];
            ntStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
            string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
            log(" >> Data from client - " + dataFromClient);
            StreamWriter out_ = new StreamWriter(client.GetStream());
            //BufferedStream in_ = new BufferedStream();

            try
            {

                //string out = new string()
            }
            catch (Exception ex)
            {
                log(ex.ToString());
                throw;
            }

            log("klient rozlaczony");
            Program.watki.Remove(this);

        }

        public void log(String _string)
        {
            Console.WriteLine(_string);
        }
    }
}
