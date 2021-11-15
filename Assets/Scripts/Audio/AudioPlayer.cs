using UnityEngine;

public class AudioPlayer
{
    public const int DefaultSeChannelCount = 10;
    public const float DEFAULT_VOLUME_BGM = 0.3f;
    public const float DEFAULT_VOLUME_SE = 0.3f;
    public const float DEFAULT_PITCH_BGM = 1.0f;
    public const float DEFAULT_PITCH_SE = 1.0f;

    private static AudioPlayer _mInstance;

    public static AudioPlayer Instance => _mInstance ?? (_mInstance = new AudioPlayer(DefaultSeChannelCount));

    private int _bgmFileIdx;
    private readonly AudioSource _bgmChannel;

    private readonly int _seChannelCount;
    private readonly AudioSource[] _seChannels;

    private int _seChannelIndex;

    private float volume_BGM;
    private float volume_SE;

    private float pitch_BGM;
    private float pitch_SE;

    private AudioPlayer(int seChannelCount)
    {
        var rootObject = new GameObject("AudioPlayer");
        Object.DontDestroyOnLoad(rootObject);

        _bgmChannel = rootObject.AddComponent<AudioSource>();
        _seChannelCount = seChannelCount;

        _seChannels = new AudioSource[seChannelCount];

        for (int i = 0; i < seChannelCount; i++)
        {
            _seChannels[i] = rootObject.AddComponent<AudioSource>();
        }

        _bgmFileIdx = -1;
        _seChannelIndex = 0;
        volume_BGM = DEFAULT_VOLUME_BGM;
        volume_SE = DEFAULT_VOLUME_SE;
        pitch_BGM = DEFAULT_PITCH_BGM;
        pitch_SE = DEFAULT_PITCH_SE;
    }

    //
    // ↓↓↓↓↓実際に他のクラスで使用する関数群↓↓↓↓↓
    //

    // BGMの再生.
    public static bool PlayBgm(AudioFile audioFile)
    {
        return Instance.DoPlayBgm(audioFile);
    }

    // BGMの一時停止.
    public static void PauseBgm(bool flag)
    {
        Instance.DoPauseBgm(flag);
    }

    // BGMの停止.
    public static void StopBgm()
    {
        Instance.DoStopBgm();
    }

    // BGMの音量設定
    public static void SetVolume_BGM(float value)
    {
        Instance.DoSetVolume_BGM(value);
    }

    // BGMの音量取得
    public static float GetVolume_BGM()
    {
        return Instance.volume_BGM;
    }

    // BGMのピッチ取得
    public static float GetPitch_BGM()
    {
        return Instance.pitch_BGM;
    }

    //
    // ↑↑↑↑↑実際に他のクラスで使用する関数群↑↑↑↑↑
    //

    //BGMの再生.
    public bool DoPlayBgm(AudioFile audioFile)
    {
        if ((int)audioFile != _bgmFileIdx)
        {
            _bgmChannel.Stop();
            _bgmFileIdx = (int)audioFile;

            var clip = audioFile.ToAudioClip();
            if (clip == null) return false;

            _bgmChannel.clip = clip;
            _bgmChannel.loop = true;
            _bgmChannel.volume = volume_BGM;
            _bgmChannel.pitch = pitch_BGM;

            _bgmChannel.Play();
        }
        return true;
    }

    // BGMの一時停止.
    public void DoPauseBgm(bool flag)
    {
        if (flag)
        {
            _bgmChannel.Pause();
        }
        else
        {
            _bgmChannel.Play();
        }
    }

    // BGMの停止.
    public void DoStopBgm()
    {
        _bgmChannel.Stop();
        _bgmFileIdx = -1;
    }

    // BGMの音量設定
    public void DoSetVolume_BGM(float value)
    {
        volume_BGM = value;
        _bgmChannel.volume = volume_BGM;
    }

    // BGMのピッチ設定
    public void DoSetPitch_BGM(float value)
    {
        pitch_BGM = value;
        _bgmChannel.pitch = pitch_BGM;
    }

    //
    // ↓↓↓↓↓実際に他のクラスで使用する関数群↓↓↓↓↓
    //

    // SE再生.
    public static AudioSource PlaySe(AudioFile audioFile)
    {
        return Instance.DoPlaySe(audioFile);
    }

    // SEの音量設定
    public static void SetVolume_SE(float value)
    {
        Instance.DoSetVolume_SE(value);
    }

    // SEの音量設定
    public static void SetPitch_SE(float value)
    {
        Instance.DoSetPitch_SE(value);
    }

    // SEの音量取得
    public static float GetVolume_SE()
    {
        return Instance.volume_SE;
    }

    // SEの音量取得
    public static float GetPitch_SE()
    {
        return Instance.pitch_SE;
    }

    // SE全ての停止
    public static bool StopAllSe()
    {
        return Instance.DoStopAllSe();
    }

    //
    // ↑↑↑↑↑実際に他のクラスで使用する関数群↑↑↑↑↑
    //

    // SE再生.
    public AudioSource DoPlaySe(AudioFile audioFile)
    {
        var seChannel = _seChannels[_seChannelIndex];
        seChannel.Stop();

        var clip = audioFile.ToAudioClip();
        if (clip == null) return null;

        if (++_seChannelIndex >= _seChannelCount)
        {
            _seChannelIndex = 0;
        }

        seChannel.clip = clip;
        seChannel.volume = volume_SE;
        seChannel.pitch = pitch_SE;

        seChannel.Play();

        return seChannel;
    }

    // SE全ての停止
    public bool DoStopAllSe()
    {
        for (int i = 0; i < _seChannels.Length; i++)
        {
            _seChannels[i].Stop();
        }
        return true;
    }

    // SEの音量設定
    public void DoSetVolume_SE(float value)
    {
        volume_SE = value;

        for (int i = 0; i < DefaultSeChannelCount; i++)
        {
            var seChannel = _seChannels[i];

            seChannel.volume = volume_SE;
        }
    }

    // SEのピッチ設定
    public void DoSetPitch_SE(float value)
    {
        pitch_SE = value;
    }
}