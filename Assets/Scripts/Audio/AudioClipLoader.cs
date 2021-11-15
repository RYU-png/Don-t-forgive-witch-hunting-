using System;
using System.Collections.Generic;
using UnityEngine;

public static class AudioClipLoader
{
    private static readonly Dictionary<string, AudioClip> Cache = new Dictionary<string, AudioClip>();

    public static AudioClip Load(string path)
    {
        if (!Cache.ContainsKey(path))
        {
            Cache[path] = Resources.Load(path, typeof(AudioClip)) as AudioClip;
        }

        return Cache[path];
    }

    public static bool UnLoad(string path)
    {
        if (Cache.ContainsKey(path))
        {
            Resources.UnloadAsset(Cache[path]);
            Cache.Remove(path);
        }

        return true;
    }

    public static void PreLoadAll()
    {
        foreach (AudioFile af in Enum.GetValues(typeof(AudioFile)))
        {
            af.ToAudioClip();
        }
    }

    public static void Clear()
    {
        Cache.Clear();
    }
}