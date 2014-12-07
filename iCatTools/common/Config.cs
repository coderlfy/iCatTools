﻿/****************************************
###创建人：lify
###创建时间：2012-02-26
###公司：山西博华科技有限公司
###最后修改时间：2012-02-26
###最后修改人：lify
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace iCatTools.common
{
    class Config
    {
        /// <summary>
        /// 获取config键值
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string Get(string keyName, string defaultValue)
        {
            #region
            string value = "";
            if (System.Configuration.ConfigurationManager.AppSettings[keyName] == null)
            {
                Save(keyName, defaultValue);
                value = defaultValue.ToString();
            }
            else
                value = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return value;
            #endregion
        }
        /// <summary>
        /// 保存App.config
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="value">目标值</param>
        public static string Save(string keyName, string value)
        {
            #region
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (System.Configuration.ConfigurationManager.AppSettings[keyName] != null)
                configuration.AppSettings.Settings[keyName].Value = value;
            else
                configuration.AppSettings.Settings.Add(keyName, value);
            configuration.Save();
            return value;
            #endregion
        }
        /// <summary>
        /// 更新App.config文件
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static string Update(string keyName, string value)
        {
            #region
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[keyName].Value = value;
            configuration.Save();
            return value;
            #endregion
        }
    }
}