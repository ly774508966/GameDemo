﻿using UnityEngine;
using System.Collections;
using System;
public class XLog : IXLog
{
    private Logger m_logger = null;
    private static IXLog s_logger;
    public static IXLog Log
    {
        get
        {
            return XLog.s_logger;
        }
    }
    static XLog()
    {
        XLog.s_logger = null;
        XLog.s_logger = XLog.GetLog<XLog>();
    }
    public static void Init()
    {
        string newFullPath = SystemConfig.LogPath;
        Logger.Init(newFullPath);
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            Logger.IsInEditor = true;
        }
        else
        {
            Logger.IsInEditor = false;
        }
    }
    public static void Close()
    {
        Logger.Close();
    }
    public static IXLog GetLog<T>()
    {
        return new Logger(typeof(T).ToString());
    }
    public static IXLog GetLog(Type type)
    {
        return new Logger(type.ToString());
    }
    public XLog(Type type)
    {
        this.m_logger = new Logger(type.ToString());
    }
    public void Debug(object message)
    {
        this.m_logger.Debug(message);
    }
    public void Info(object message)
    {
        this.m_logger.Info(message);
    }
    public void Error(object message)
    {
        this.m_logger.Error(message);
    }
    public void Fatal(object message)
    {
        this.m_logger.Fatal(message);
    }
}
