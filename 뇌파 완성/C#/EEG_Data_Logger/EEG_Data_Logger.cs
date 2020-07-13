using System;
using System.Collections.Generic;
using Emotiv;
using System.IO;
using System.Threading;
using System.Reflection;


namespace EEG_Data_Logger
{
    class EEG_Logger
    {
        EmoEngine engine;   // Access to the EDK is via the EmoEngine 
        int userID = -1;    // userID is used to uniquely identify a user's headset
                            //string filename = "EEG_Data_Logger.csv"; // output filename        //전체 data 기록 안함

        Data_Set ds;
        //private List<double[]> rawData;
        public int rawDataIdx;

        //시작 txt읽어오기
        StreamReader srtReader;

        //p300값 저장 폴더
        DirectoryInfo f;
        StreamWriter wr;

        //긍부정 값 저장 폴더
        DirectoryInfo f2;
        StreamWriter wr2;


        //eeg rawdata 가져오기
        Dictionary<int, List<double>> rawDict;
        public int wsize = 0; //windowsize=3s


        EEG_Logger()
        {
            // create the engine
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);

            // connect to Emoengine.            
            engine.Connect();

            // create a header for our output file
            //WriteHeader();

            rawDataIdx = 0;
            ds = new Data_Set();

            //p300값 txt파일로
            string makeFolder_path = @"C:\\Users\\sohyeon\\Desktop\\";
            string folderName = makeFolder_path + "p300";
            f = new DirectoryInfo(folderName);
            f.Create();

            //긍부정값 txt파일로
            string folderName2 = makeFolder_path + "ne_po";
            f2 = new DirectoryInfo(folderName2);
            f2.Create();

            //eeg raw data저장
            rawDict = new Dictionary<int, List<double>>();
            for (int i = 0; i < 14; i++)
            {
                rawDict[i] = new List<double>();
            }
        }

        void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("User Added Event has occured");

            // record the user 
            userID = (int)e.userId;

            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // ask for up to 1 second of buffered data
            engine.DataSetBufferSizeInSec(1);

        }

        void Run()
        {
            #region Config

            // Handle any waiting events
            engine.ProcessEvents();

            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
                return;

            Dictionary<EdkDll.IEE_DataChannel_t, double[]> data = engine.GetData((uint)userID);

            if (data == null)
            {
                return;
            }
            #endregion

            int _bufferSize = data[EdkDll.IEE_DataChannel_t.IED_TIMESTAMP].Length;
            //Console.WriteLine("Writing " + _bufferSize.ToString() + " sample of data ");

            //시작 txt파일 읽어오기
            srtReader = new StreamReader("C:\\Users\\sohyeon\\Desktop\\start.txt");
            string sLine = "";
            sLine = srtReader.ReadLine();
            srtReader.Close();

            if (sLine == "s")
            {
                // Write the data to a file
                //TextWriter file = new StreamWriter(filename, true);

                int chIdx = 0;
                //double[] arr;
                for (int i = 0; i < _bufferSize; i++)
                {
                    //arr = new double[26];
                    // now write the data
                    foreach (EdkDll.IEE_DataChannel_t channel in data.Keys)
                    {
                        //file.Write(data[channel][i] + ",");
                        Console.WriteLine(rawDataIdx + "," + data[channel][i] + ",");
                        ds.AddData(chIdx, rawDataIdx, data[channel][i]);
                        //rawDict[chIdx].Add(data[channel][i]);
                        chIdx++;
                    }
                    chIdx = 0;
                    //file.WriteLine("");
                    rawDataIdx++;
                    //wsize++;
                    if (rawDataIdx >= 128)
                    {
                        break;
                    }
                    //  if (wsize >= 128 * 3)
                    //  {
                    //      break;
                    //  }
                }
                //file.Close();
            }
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("EEG Data Reader Example");

            double p300st = 0.11485094; //p300 기준
            double npst1 = 0.436268;   //np 기준(긍)
            double npst2 = 0.434627; //np기중 (부)
            double p300res = 0; //p300 퍼센트 결과
            double npres = 0;  //np 퍼센트 결과
            double end; //전체 퍼센트




            string source = DateTime.Now.ToString("dd  HH-mm-ss");
            string ch = "AF3, F7, F3, FC5, T7, P7, O1, O2, P8,T8, FC6, F4, F8, AF4";
            string leftch = "AF3, F7, F3, FC5, T7, P7, O1";
            string rightch = "O2, P8, T8, FC6, F4, F8, AF4";

            //p300 변화량 파일 만들기
            string pfilename =  "p300 " + source + ".csv";
            TextWriter p300file = new StreamWriter(pfilename, false);
            p300file.WriteLine(ch);


            //긍부정 파일만들기
            //string Lefilename = "Left " + source + ".csv";
            //TextWriter Lefile = new StreamWriter(Lefilename, false);
            //Lefile.WriteLine(leftch);
            //
            //
            //string Rifilename = " Right " + source + ".csv";
            //TextWriter Rifile = new StreamWriter(Rifilename, false);
            //Rifile.WriteLine(rightch);


            //p300 확인 로우 데이터
            string p300rawname = " rawP300 " + source + ".csv";
            TextWriter p300raw = new StreamWriter(p300rawname, false);
            p300raw.WriteLine(ch);

            //알파 확인
            string alpha = " alpha " + source + ".csv";
            TextWriter alphaa = new StreamWriter(alpha, false);
            alphaa.WriteLine(ch);

            //베타 확인
            string beta = " beta " + source + ".csv";
            TextWriter betaa = new StreamWriter(beta, false);
            betaa.WriteLine(ch);

            string fftle = " fftleft " + source + ".csv";
            TextWriter fftleft = new StreamWriter(fftle, false);


            string fftri = " fftright " + source + ".csv";
            TextWriter fftright = new StreamWriter(fftri, false);



            EEG_Logger p = new EEG_Logger();
            EEG_Data_Analysis ana = new EEG_Data_Analysis();

            double[,] rawEEGdata;
            double[,] pp300 = new double[14, 60];
            int cnt_pp = 0;
            double[] sum_pp = new double[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] avg_pp = new double[14];
            double[,] diff_p = new double[14, 30];
            double[] sum_diff = new double[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] p300 = new double[14];

            double[] ch_eeg; //3초 동안의 rawData
            double[,] left_ratio = new double[28, 7]; //좌반구 활성화
            double[,] right_ratio = new double[28, 7]; //우반구 활성화
            int fftTime = 0; //활성화도 30초

            int npnum = 0; //긍부정도 텍스트파일
            double sumRatio = 0;
            double avgRatio;

            double maxP300 = -100;
            int maxP300time=0;

            double maxNp = -100;
            int maxNptime = 0;

            FFT fft = new FFT();


            while (true)
            {
                if (Console.KeyAvailable)
                    break;

                p.Run();

                //p300 분석
                if (p.rawDataIdx == 128)
                {
                    rawEEGdata = new double[14, 128];
                    for (int i = 0; i < 14; i++)
                    {
                        for (int j = 0; j < 128; j++)
                        {
                            rawEEGdata[i, j] = p.ds.series[i + 3, j];

                            if (cnt_pp > 29)
                                p.rawDict[i].Add(rawEEGdata[i, j]);
                        }
                    }

                    //p300 rawdata 엑셀로 뽑기
                    for (int i = 0; i < 128; i++)
                    {
                        for (int j = 0; j < 14; j++)
                            p300raw.Write(rawEEGdata[j, i] + ",");
                        p300raw.WriteLine("");
                    }

                    if (cnt_pp > 29) //광고 시작후 eeg 사이즈
                        p.wsize++;
                    double[] arr = new double[128];

                    for (int i = 0; i < 14; i++)
                    {
                        for (int j = 0; j < 128; j++)
                        {
                            arr[j] = rawEEGdata[i, j];
                        }
                        pp300[i, cnt_pp] = ana.GetP300(arr);
                    }

                    if (cnt_pp == 29) //중립뇌파 각 채널별 평균
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            for (int j = 0; j < 30; j++)
                            {
                                sum_pp[i] += pp300[i, j];
                            }
                            avg_pp[i] = sum_pp[i] / 30;
                        }
                    }
                    else if (cnt_pp > 29) //광고 뇌파
                    {
                        int num;
                        for (int i = 0; i < 14; i++)
                        {
                            //변화량 diff_p배열
                            diff_p[i, cnt_pp - 30] = ((avg_pp[i] - pp300[i, cnt_pp]) / avg_pp[i]) * 100;
                            sum_diff[i] += diff_p[i, cnt_pp - 30];
                            p300file.Write(diff_p[i, cnt_pp - 30] + ",");
                            num = cnt_pp - 30;

                            // p300 Graph
                            if (i == 3)//특정 채널만 txt파일로 1초에 하나씩 생성
                            {
                                p.wr = new StreamWriter(@"C:\Users\sohyeon\Desktop\p300\" + num + ".txt");
                                p.wr.WriteLine(diff_p[i, cnt_pp - 30]);
                                p.wr.Close();

                                //p300이 최고인 지점
                                if (diff_p[i, cnt_pp - 30] > maxP300)
                                {
                                    maxP300 = diff_p[i, cnt_pp - 30];
                                    maxP300time = cnt_pp - 30;
                                }                                   
                                if (diff_p[i, cnt_pp - 30] >= p300st)
                                {
                                    p300res += 4;                                   
                                }
                            }
                        }
                        p300file.WriteLine("");
                    }
                    if (cnt_pp == 59)//광고 종료
                    {
                        p300file.WriteLine("");

                        for (int i = 0; i < 14; i++)
                        {
                            p300[i] = sum_diff[i] / 30;
                            p300file.Write(p300[i] + ",");
                        }
                        p300file.Close();

                        

                    }
                    cnt_pp++;
                    p.rawDataIdx = 0;
                }

                //긍부정 분석
                if (p.wsize == 5)
                {
                    ch_eeg = new double[128 * 4];
                    for (int i = 0; i < 14; i++)
                    {
                        double asum = 0, bsum = 0;
                        double a, b; //여기에 알파, 베타
                        Array.Copy(p.rawDict[i].ToArray(), 0, ch_eeg, 0, 128 * 3);
                        p.rawDict[i].RemoveRange(0, 128); //1초 data삭제

                        var fftArray = fft.Excute(ch_eeg); //fft를 한 값을 받는 배열이 필요
                       // Console.WriteLine(fftArray.Length);


                        var df = fft.GetDF(5);


                        //fftArray 배열에서 알파, 베타 뽑->비율값
                        for (int j = Convert.ToInt32(8 / df); j < Convert.ToInt32(12 / df); j++)
                        {
                            asum += fftArray[j];
                        }
                        for (int j = Convert.ToInt32(21 / df); j < Convert.ToInt32(30 / df); j++)
                        {
                            bsum += fftArray[j];
                        }

                        a = asum / (Convert.ToInt32(12 / df) - Convert.ToInt32(8 / df));
                        b = bsum / (Convert.ToInt32(30 / df) - Convert.ToInt32(21 / df));

                        alphaa.Write(a + ",");
                        betaa.Write(b + ",");
                        double fftRatio = b / a;

                        //fftraw data 값 받기
                        for (int j = 0; j < 512; j++)
                        {
                            if (i >= 0 && i < 7)
                            {
                                fftleft.Write(fftArray[j] + ",");
                            }
                            if (i >= 7 && i < 14)
                            {
                                fftright.Write(fftArray[j] + ",");
                            }
                        }

                        fftleft.WriteLine("");
                        fftright.WriteLine("");

                        if(i==1 || i == 4 || i == 9)
                        {
                            sumRatio += fftRatio;
                        }

                        //if (i >= 0 && i < 7)
                        //{
                        //    left_ratio[fftTime, i] = fftRatio;
                        //}
                        //else if (i >= 7 && i < 14)
                        //{
                        //    right_ratio[fftTime, i - 7] = fftRatio;
                        //}


                    }
                    avgRatio = sumRatio / 3;
                    sumRatio = 0;
                    p.wr2 = new StreamWriter(@"C:\Users\sohyeon\Desktop\ne_po\" + npnum + ".txt");
                    p.wr2.WriteLine(avgRatio);
                    p.wr2.Close();                   

                    if (avgRatio > maxNp)
                    {
                        maxNp = avgRatio;
                        maxNptime = npnum;
                    }
                    npnum++;

                    if (avgRatio >= npst1)
                        npres += 3.8;
                    else if (avgRatio < npst1 && avgRatio > 2)
                        npres += 2;
                    else
                    {
                        npres += 1;
                    }
                      
                    alphaa.WriteLine("");
                    betaa.WriteLine("");

                   // for (int i = 0; i < 7; i++)
                   // {
                   //     Lefile.Write(left_ratio[fftTime, i] + ",");
                   //     Rifile.Write(right_ratio[fftTime, i] + ",");
                   //
                   //     if (i == 2)    //긍부정 텍스트 파일
                   //     {
                   //         p.wr2 = new StreamWriter(@"C:\Users\user\Desktop\ne_po\" + npnum + ".txt");
                   //         p.wr2.WriteLine(left_ratio[fftTime, i]);
                   //         p.wr2.Close();
                   //         npnum++;
                   //     }
                   // }
                   // Lefile.WriteLine("");
                   // Rifile.WriteLine("");

                    fftTime++;
                    if (cnt_pp == 60)
                    {
                       // Lefile.Close();
                      //  Rifile.Close();
                        fftleft.Close();
                        fftright.Close();

                        p.wr = new StreamWriter(@"C:\Users\sohyeon\Desktop\p300\p300res.txt");
                        p.wr.WriteLine(p300res);
                        p.wr.Close();

                        //최대 p300 시간 저장
                        p.wr = new StreamWriter(@"C:\Users\sohyeon\Desktop\p300\maxP300time.txt");
                        p.wr.WriteLine(maxP300time+"~"+(maxP300time+1));
                        p.wr.Close();

                        p.wr2 = new StreamWriter(@"C:\Users\sohyeon\Desktop\ne_po\npres.txt");
                        p.wr2.WriteLine(npres);
                        p.wr2.Close();

                        //최대 긍부정 시간 저장
                        p.wr2 = new StreamWriter(@"C:\Users\sohyeon\Desktop\ne_po\maxNptime.txt");
                        p.wr2.WriteLine(maxNptime + "~" + (maxNptime + 3));
                        p.wr2.Close();

                        p.wr2 = new StreamWriter(@"C:\Users\sohyeon\Desktop\ne_po\end.txt");
           
                        p.wr2.WriteLine((p300res*2+npres*3)/5 );
                        p.wr2.Close();


                        break;
                    }
                    p.wsize = 4;
                }

                Thread.Sleep(10);
            }

            StreamWriter srtWriter = new StreamWriter("C:\\Users\\sohyeon\\Desktop\\start.txt");
            srtWriter.Write("");
            srtWriter.Close();
        }
    }
}