﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCheckService;

namespace DataHandleService
{
    /// <summary>
    /// 数据解析服务
    /// </summary>
    public class DataHandleHelper
    {
        /// <summary>
        /// 心跳包结构体
        /// </summary>
        public struct HeartStruct
        {
            public string Status { get; set; }

            public string Runtime { get; set; }

            public string Temp { get; set; }

            public string Hum { get; set; }

            public string Light { get; set; }

            public string Noise { get; set; }

            public string Relays { get; set; }

            public string VideoIn { get; set; }

            public string VideoOut { get; set; }

            public string Projector { get; set; }

            public string CameraPower { get; set; }
        }

        /// <summary>
        /// 数据校验服务
        /// </summary>
        private DataCheckHelper DataCheck;

        /// <summary>
        /// 构造器
        /// </summary>
        public DataHandleHelper()
        {
            DataCheck = new DataCheckHelper();
        }

        #region 环境数据获取
        /// <summary>
        /// 获取房间温度
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseTemp(string Data)
        {
            string Temp = string.Empty;

            if (DataCheck.CheckData(Data))
            {
                //数据处理
                Temp = Data.Split(' ')[3].Split('=')[1];

                return Temp + " ℃";
            }
            else
            {
                Temp = "ERROR";
                return Temp;
            }
        }

        /// <summary>
        /// 获取房间湿度
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseHum(string Data)
        {
            string Hum = string.Empty;

            if (DataCheck.CheckData(Data))
            {
                //数据处理
                Hum = Data.Split(' ')[4].Split('=')[1];

                return Hum + " %";
            }
            else
            {
                Hum = "ERROR";
                return Hum;
            }
        }

        /// <summary>
        /// 获取房间光照
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseLight(string Data)
        {
            string Light = string.Empty;

            if (DataCheck.CheckData(Data))
            {
                //数据处理
                Light = Data.Split(' ')[5].Split('=')[1];

                return Light + " LUX";
            }
            else
            {
                Light = "ERROR";
                return Light;
            }
        }

        /// <summary>
        /// 获取房间噪音
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseNoise(string Data)
        {
            string Noise = string.Empty;

            if (DataCheck.CheckData(Data))
            {
                //数据处理
                Noise = Data.Split(' ')[6].Split('=')[1];

                return Noise + " DB";
            }
            else
            {
                Noise = "ERROR";
                return Noise;
            }
        }
        #endregion

        #region 设备状态获取
        /// <summary>
        /// 获取心跳包内容
        /// </summary>
        /// <param name="Data"></param>
        /// <returns>心跳包结构体</returns>
        public HeartStruct GetHeartbeat(string Data)
        {
            HeartStruct Heart = new HeartStruct();

            if (DataCheck.CheckData(Data))
            {
                string HeartData = Data.Split(':')[0];

                foreach (string item in HeartData.Split('\t'))
                {
                    switch (item.Split('=')[0])
                    {
                        case "Status":
                            Heart.Status = item.Split('=')[1];
                            break;
                        case "Runtime":
                            Heart.Runtime = item.Split('=')[1];
                            break;
                        case "Temp":
                            Heart.Temp = item.Split('=')[1];
                            break;
                        case "Hum":
                            Heart.Hum = item.Split('=')[1];
                            break;
                        case "Light":
                            Heart.Light = item.Split('=')[1];
                            break;
                        case "Noise":
                            Heart.Noise = item.Split('=')[1];
                            break;
                        case "Relays":
                            Heart.Relays = item.Split('=')[1];
                            break;
                        case "VideoIn":
                            Heart.VideoIn = item.Split('=')[1];
                            break;
                        case "VideoOut":
                            Heart.VideoOut = item.Split('=')[1];
                            break;
                        case "Projector":
                            Heart.Projector = item.Split('=')[1];
                            break;
                        case "CameraPower":
                            Heart.CameraPower = item.Split('=')[1];
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("获取到错误数据");
            }

            return Heart;
        }
        #endregion
    }
}
