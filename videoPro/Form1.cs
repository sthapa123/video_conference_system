using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Voice;


namespace videoPro
{
    public partial class Form1 : Form
    {
        Thread videoSendingThread;
        String recievedControl;
        bool rcvstart,sndStart;
        bool rcvstop,sndStop;
        //bool rcvend,sndEnd;
        Thread RecievingVideoThread;
        private WaveOutPlayer m_Player;
        private WaveInRecorder m_Recorder;
        private FifoStream m_Fifo = new FifoStream();
        private Socket inputVoiceSocket;
        private byte[] m_PlayBuffer;
        private byte[] m_RecBuffer;
        private Thread AudioSendingThread;
        TcpClient sendcontrolsTCPClient;
        int SendingVideoPort;
        int RecievingVideoPort;
        int SendingControlsPort;
        int RecievingControlsPort;
        int SendingVoicePort;
        int RecievingVoicePort;
        Boolean stopVideo;
        Boolean cameraStarted;

        String Peer2IP;

        public Form1()
        {
            InitializeComponent();
            stopVideo = false;
            cameraStarted = false;

            rcvstart = false;
            sndStart = false;
            rcvstop = false;
            sndStop = false;

            if (Choose_Peer.choosenPeer == 1)
            {
                this.Text = "Peer1";
                SendingVideoPort = 50000;
                RecievingVideoPort = 50001;
                SendingControlsPort = 50002;
                RecievingControlsPort = 50003;
                SendingVoicePort = 50006;
                RecievingVoicePort = 50007;
            }
            else if (Choose_Peer.choosenPeer == 2)
            {
                this.Text = "Peer2";
                SendingVideoPort = 50001;
                RecievingVideoPort = 50000;
                SendingControlsPort = 50003;
                RecievingControlsPort = 50002;
                SendingVoicePort = 50007;
                RecievingVoicePort = 50006;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                ThreadStart rcvcontrolStartThread = new ThreadStart(recieveControls);
                Thread rcvcontThread = new Thread(rcvcontrolStartThread);
                rcvcontThread.Start();

               
               // CheckForIllegalCrossThreadCalls = false;
            }
            catch (Exception E)
            {
                        
                MessageBox.Show(E.Message);
            }
        }



        #region Voice 

        private void Recieve_Voice()
        {
            try
            {

                byte[] br;
                inputVoiceSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                inputVoiceSocket.Bind(new IPEndPoint(IPAddress.Any, RecievingVoicePort));
                while (true)
                {
                    br = new byte[16384];//First, 16384 = 16 * 1024 or 16KB. If you read stat, you will see that the call would be returning the preferred block size for filesystem IO
                    inputVoiceSocket.Receive(br);
                    m_Fifo.Write(br, 0, br.Length);
                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void Send_Voice(IntPtr data, int size)
        {
            try
            {

                //for Recorder
                if (m_RecBuffer == null || m_RecBuffer.Length < size)
                    m_RecBuffer = new byte[size];
                System.Runtime.InteropServices.Marshal.Copy(data, m_RecBuffer, 0, size);
                //Microphone ==> data ==> m_RecBuffer ==> m_Fifo
                inputVoiceSocket.SendTo(m_RecBuffer, new IPEndPoint(IPAddress.Parse(Peer2IP), SendingVoicePort));
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void Start()
        {
            Stop();
            try
            {
                WaveFormat fmt = new WaveFormat(44100, 16, 2);
                m_Player = new WaveOutPlayer(-1, fmt, 16384, 3, new BufferFillEventHandler(Filler));
                //The first parameter is the ID of the wave device that you want to use.The value -1 represents the default system device, but if your system has more than one sound card, then you can pass any number from 0 to the number of installed sound cards minus one to select a particular device.
                //The second parameter is the format of the audio samples.                                                                                     
                //The third and forth parameters are the size of the internal wave buffers and the number of buffers to allocate. You should set these to reasonable values. Smaller buffers will give you less latency(short period of delay ), but the audio may stutter if your computer is not fast enough.
                //The fifth and last parameter is a delegate that will be called periodically as internal audio buffers finish playing, so that you can feed them with new sound data.
                m_Recorder = new WaveInRecorder(-1, fmt, 16384, 3, new BufferDoneEventHandler(Send_Voice));
            }
            catch
            {
                Stop();
                throw;
            }
        }

        private void Stop()
        {
            try
            {

                if (m_Player != null)
                    try
                    {
                        m_Player.Dispose();
                    }
                    finally
                    {
                        m_Player = null;
                    }
                if (m_Recorder != null)
                    try
                    {
                        m_Recorder.Dispose();
                    }
                    finally
                    {
                        m_Recorder = null;
                    }
                m_Fifo.Flush(); // clear all pending data
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void Filler(IntPtr data, int size)
        {
            try
            {

                if (m_PlayBuffer == null || m_PlayBuffer.Length < size)
                    m_PlayBuffer = new byte[size];
                if (m_Fifo.Length >= size)
                    m_Fifo.Read(m_PlayBuffer, 0, size);
                else
                    for (int i = 0; i < m_PlayBuffer.Length; i++)
                        m_PlayBuffer[i] = 0;
                System.Runtime.InteropServices.Marshal.Copy(m_PlayBuffer, 0, data, size);
                // m_Fifo ==> m_PlayBuffer==> data ==> Speakers
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        #endregion




        private delegate void _getIP();

        private void getIP()
        {
            Peer2IP = textBoxPeer2IP.Text.ToString();
        }
      
        private void recieveControls() //act as TCP Client 
        {

            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new _getIP(getIP));
                }

                TcpListener listenControl = new TcpListener(IPAddress.Any, RecievingControlsPort);
                while (true)
                {
                    listenControl.Start();
                    Socket contSocket = listenControl.AcceptSocket();
                    NetworkStream controlNS = new NetworkStream(contSocket);
                    StreamReader controlSR = new StreamReader(controlNS);

                    ParseControl(controlSR.ReadLine());
                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
          }

        private void ParseControl(String controltext)
        {
            try
            {


                if (controltext == "start" && rcvstop == false)
                {
                    rcvstart = true;
                    rcvstop = false;
                     
                    videoSendingThread = new Thread(new ThreadStart(Send_Video));
                    videoSendingThread.Start();
                    
                    //if (sndStart == true)
                    //{
                    //    AudioSendingThread = new Thread(new ThreadStart(Start));
                    //    videoSendingThread.Start();
                    //}
                }
                else if (controltext == "start" && rcvstop == true)
                {
                    rcvstart = true;
                    rcvstop = false;
                  
                    //if (rcvstart == true && sndStart == true)
                    //{
                    //    AudioSendingThread.Start();
                    //}
                }
                else if (controltext == "stop")
                {
                    rcvstart = false;
                    rcvstop = true;
                    //videoSendingThread.Sleep(100); 
                    stopVideo = true;
                
                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void Send_Video() //act as UDP server
        {
            try
            {
                

                if (rcvstart == true && rcvstop == false)
                {
                   
                    MemoryStream ms = new MemoryStream();// Store it in Binary Array as Stream
                    pictureBoxPeer1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Socket sendToPeer2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    IPEndPoint sending_end_point = new IPEndPoint(IPAddress.Parse(Peer2IP), SendingVideoPort);
                    byte[] arrImage = ms.GetBuffer();
                    sendToPeer2.SendTo(arrImage,sending_end_point);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
      
        private void Send_Control(Object sendControl)
        {
            try
            {
                String controlToSend=(String) sendControl;
                sendcontrolsTCPClient = new TcpClient(Peer2IP, SendingControlsPort);
                
                NetworkStream ns = sendcontrolsTCPClient.GetStream();
                
                StreamWriter csw = new StreamWriter(ns);
                csw.WriteLine(controlToSend);
                csw.Flush();
                sendcontrolsTCPClient.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Receive_video() //act as UDP Client
        {
            try
            {

                UdpClient UdpClint = new UdpClient(RecievingVideoPort);
                IPEndPoint Adress = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    Byte[] arrImage = UdpClint.Receive(ref Adress);
                    MemoryStream ms = new MemoryStream(arrImage);
                    Image rcvdImage = Image.FromStream(ms);
                    pictureBoxPeer2.Image = rcvdImage;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
      
        private void SendingControlThread(String parameter)
        {
            try
            {

                ParameterizedThreadStart startSendingControls = new ParameterizedThreadStart(Send_Control);
                Thread sth = new Thread(startSendingControls);
                sth.Start(parameter);
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void WebCamCapture_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            try
            {
                cameraStarted = true;
                this.pictureBoxPeer1.Image = e.WebCamImage;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void Capturing_Tick(object sender, EventArgs e)
        {
            try
            {

                if (rcvstart == true && rcvstop == false)
                {
                    Send_Video();
                }
            }
            catch (Exception E)
            {
                
                MessageBox.Show(E.Message);
            }
        }
      
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                this.WebCamCapture.TimeToCapture_milliseconds = 5;
                this.WebCamCapture.Start(0);
                this.WebCamCapture.FrameNumber = 12;
                Capturing.Enabled = true;
                
            }
            catch (Exception E)
            {
                
                MessageBox.Show(E.Message);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cameraStarted == true)
                {
                    if (sndStart == false && sndStop == true)
                    {
                        sndStart = true;
                        sndStop = false;
                        SendingControlThread("start");
                    }
                    else if (sndStart == false && sndStop == false)
                    {
                        sndStart = true;
                        SendingControlThread("start");

                        ThreadStart startRecievingVideo = new ThreadStart(Receive_video);
                        RecievingVideoThread = new Thread(startRecievingVideo);
                        RecievingVideoThread.Start();
                    }

                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (sndStart == true && sndStop == false)
                {
                    sndStop = true;
                    sndStart = false;
                    SendingControlThread("stop");
                }

            }
            catch (Exception E)
            {
                
                MessageBox.Show(E.Message);
            }
            
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            try
            {
                
                SendingControlThread("stop");

                Environment.Exit(0);
            }
            catch (Exception E)
            {
                
                MessageBox.Show(E.Message);
            }
        }
    }
}