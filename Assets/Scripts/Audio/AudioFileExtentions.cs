using UnityEngine;

public enum AudioFile
{
    /* BGM */
    Title_bgm,
    Field_bgm1,
    Field_bgm2,
    Field_bgm3,
    Field_bgm4,
    GameClear_bgm,
    GameOver_bgm,
    Battle_bgm,
    Boss_bgm1,
    Boss_bgm2,
    Boss_bgm3,
    Boss_bgm4,
    /* BGM */

    GAME_START,
    GAME_PAUSE,
    BUTTON_CLICK,
    ACTION_SELECT,
    ACTION_CANCEL,
    DROW,

    ENEMY_ATTACK_SWORD,
    ENEMY_ATTACK_WAND,
    ENEMY_ATTACK_COIN,
    ENEMY_ATTACK_CUP,
    ENEMY_ATTACK_DOWN,
    ENEMY_ATTACK_UP,
    ENEMY_ATTACK_INVERSION,

    WORLD_1,
    FOOL_1,
    FORTUNE_1,
    SILVER,
    COPPER,

    COUNT_DOWN,
    COUNT_UP,
    REVERCE,

    CARD_PUT,
    CARD_CLICK,
    CARD_GET,

    PROPHECY_GREAT_SUCCES,
    PROPHECY_SUCCES,
    DISASTER,

    BATTLE_SCENE_FADE_IN,
    PROPHECY_SCENE_FADE_IN,
    DARK_PROPHECY_SCENE_FADE_IN,
    TARADE_CARD_SCENE_FADE_IN,
    ALCHEMY_SCENE_FADE_IN,

    STAGE_DESIDE,
    STAGE_SELECT_ARROW,

    BONUS,
    BONUS2,
    Boss_Defeat,
}

static class AudioFileExtentions
{
    public static AudioClip ToAudioClip(this AudioFile audioFile)
    {
        string fileName;

        switch (audioFile)
        {
            case AudioFile.Title_bgm:
                fileName = "Title_bgm";
                break;
            case AudioFile.Field_bgm1:
                fileName = "Field_bgm1";
                break;
            case AudioFile.Field_bgm2:
                fileName = "Field_bgm2";
                break;
            case AudioFile.Field_bgm3:
                fileName = "Field_bgm3";
                break;
            case AudioFile.Field_bgm4:
                fileName = "Field_bgm4";
                break;
            case AudioFile.GameClear_bgm:
                fileName = "GameClear_bgm";
                break;
            case AudioFile.GameOver_bgm:
                fileName = "GameOver_bgm";
                break;
            case AudioFile.Battle_bgm:
                fileName = "Battle_bgm";
                break;
            case AudioFile.Boss_bgm1:
                fileName = "Boss_bgm1";
                break;
            case AudioFile.Boss_bgm2:
                fileName = "Boss_bgm2";
                break;
            case AudioFile.Boss_bgm3:
                fileName = "Boss_bgm3";
                break;
            case AudioFile.Boss_bgm4:
                fileName = "Boss_bgm4";
                break;
            case AudioFile.GAME_START:
                fileName = "Game_Start";
                break;
            case AudioFile.GAME_PAUSE:
                fileName = "Game_Pause";
                break;
            case AudioFile.BUTTON_CLICK:
                fileName = "Button_Click";
                break;
            case AudioFile.ACTION_SELECT:
                fileName = "Action_Select";
                break;
            case AudioFile.ACTION_CANCEL:
                fileName = "Action_Cancel";
                break;
            case AudioFile.DROW:
                fileName = "Drow";
                break;
            case AudioFile.ENEMY_ATTACK_SWORD:
                fileName = "Enemy_Attack_Sword";
                break;
            case AudioFile.ENEMY_ATTACK_WAND:
                fileName = "Enemy_Attack_Wand";
                break;
            case AudioFile.ENEMY_ATTACK_COIN:
                fileName = "Enemy_Attack_Coin";
                break;
            case AudioFile.ENEMY_ATTACK_CUP:
                fileName = "Enemy_Attack_Cup";
                break;
            case AudioFile.ENEMY_ATTACK_DOWN:
                fileName = "Enemy_Attack_Down";
                break;
            case AudioFile.ENEMY_ATTACK_UP:
                fileName = "Enemy_Attack_Up";
                break;
            case AudioFile.ENEMY_ATTACK_INVERSION:
                fileName = "Enemy_Attack_Inversion";
                break;
            case AudioFile.WORLD_1:
                fileName = "World_1";
                break;
            case AudioFile.FOOL_1:
                fileName = "Fool_1";
                break;
            case AudioFile.FORTUNE_1:
                fileName = "Fortune_1";
                break;
            case AudioFile.SILVER:
                fileName = "Silver";
                break;
            case AudioFile.COPPER:
                fileName = "Copper";
                break;
            case AudioFile.COUNT_DOWN:
                fileName = "Count_Down";
                break;
            case AudioFile.COUNT_UP:
                fileName = "Count_Up";
                break;
            case AudioFile.REVERCE:
                fileName = "Reverce";
                break;
            case AudioFile.CARD_PUT:
                fileName = "Card_Put";
                break;
            case AudioFile.CARD_CLICK:
                fileName = "Card_Click";
                break;
            case AudioFile.CARD_GET:
                fileName = "Card_Get";
                break;
            case AudioFile.PROPHECY_GREAT_SUCCES:
                fileName = "Prophecy_Great_Success";
                break;
            case AudioFile.PROPHECY_SUCCES:
                fileName = "Prophecy_Success";
                break;
            case AudioFile.DISASTER:
                fileName = "Disaster";
                break;
            case AudioFile.BATTLE_SCENE_FADE_IN:
                fileName = "Battle_Scene_Fade_In";
                break;
            case AudioFile.PROPHECY_SCENE_FADE_IN:
                fileName = "Prophecy_Scene_Fade_In";
                break;
            case AudioFile.DARK_PROPHECY_SCENE_FADE_IN:
                fileName = "Dark_Prophecy_Scene_Fade_In";
                break;
            case AudioFile.TARADE_CARD_SCENE_FADE_IN:
                fileName = "Trade_Card_Scene_Fade_In";
                break;
            case AudioFile.ALCHEMY_SCENE_FADE_IN:
                fileName = "Alchemy_Scene_Fade_In";
                break;
            case AudioFile.STAGE_DESIDE:
                fileName = "Stage_Deside";
                break;
            case AudioFile.STAGE_SELECT_ARROW:
                fileName = "Stage_Select_Arrow";
                break;
            case AudioFile.BONUS:
                fileName = "Bonus";
                break;
            case AudioFile.BONUS2:
                fileName = "Bonus2";
                break;
            case AudioFile.Boss_Defeat:
                fileName = "Boss_Defeat";
                break;
            default:
                fileName = null;
                break;
        }

        return AudioClipLoader.Load("Sound/" + fileName);
    }

    public static bool RemoveAudioClip(this AudioFile audioFile)
    {
        string fileName;

        switch (audioFile)
        {
            case AudioFile.Title_bgm:
                fileName = "Title_bgm";
                break;
            case AudioFile.Field_bgm1:
                fileName = "Field_bgm1";
                break;
            case AudioFile.Field_bgm2:
                fileName = "Field_bgm2";
                break;
            case AudioFile.Field_bgm3:
                fileName = "Field_bgm3";
                break;
            case AudioFile.Field_bgm4:
                fileName = "Field_bgm4";
                break;
            case AudioFile.GameClear_bgm:
                fileName = "GameClear_bgm";
                break;
            case AudioFile.GameOver_bgm:
                fileName = "GameOver_bgm";
                break;
            case AudioFile.Battle_bgm:
                fileName = "Battle_bgm";
                break;
            case AudioFile.Boss_bgm1:
                fileName = "Boss_bgm1";
                break;
            case AudioFile.Boss_bgm2:
                fileName = "Boss_bgm2";
                break;
            case AudioFile.Boss_bgm3:
                fileName = "Boss_bgm3";
                break;
            case AudioFile.Boss_bgm4:
                fileName = "Boss_bgm4";
                break;
            case AudioFile.GAME_START:
                fileName = "Game_Start";
                break;
            case AudioFile.GAME_PAUSE:
                fileName = "Game_Pause";
                break;
            case AudioFile.BUTTON_CLICK:
                fileName = "Button_Click";
                break;
            case AudioFile.ACTION_SELECT:
                fileName = "Action_Select";
                break;
            case AudioFile.ACTION_CANCEL:
                fileName = "Action_Cancel";
                break;
            case AudioFile.DROW:
                fileName = "Drow";
                break;
            case AudioFile.ENEMY_ATTACK_SWORD:
                fileName = "Enemy_Attack_Sword";
                break;
            case AudioFile.ENEMY_ATTACK_WAND:
                fileName = "Enemy_Attack_Wand";
                break;
            case AudioFile.ENEMY_ATTACK_COIN:
                fileName = "Enemy_Attack_Coin";
                break;
            case AudioFile.ENEMY_ATTACK_CUP:
                fileName = "Enemy_Attack_Cup";
                break;
            case AudioFile.ENEMY_ATTACK_DOWN:
                fileName = "Enemy_Attack_Down";
                break;
            case AudioFile.ENEMY_ATTACK_UP:
                fileName = "Enemy_Attack_Up";
                break;
            case AudioFile.ENEMY_ATTACK_INVERSION:
                fileName = "Enemy_Attack_Inversion";
                break;
            case AudioFile.WORLD_1:
                fileName = "World_1";
                break;
            case AudioFile.FOOL_1:
                fileName = "Fool_1";
                break;
            case AudioFile.FORTUNE_1:
                fileName = "Fortune_1";
                break;
            case AudioFile.SILVER:
                fileName = "Silver";
                break;
            case AudioFile.COPPER:
                fileName = "Copper";
                break;
            case AudioFile.COUNT_DOWN:
                fileName = "Count_Down";
                break;
            case AudioFile.COUNT_UP:
                fileName = "Count_Up";
                break;
            case AudioFile.REVERCE:
                fileName = "Reverce";
                break;
            case AudioFile.CARD_PUT:
                fileName = "Card_Put";
                break;
            case AudioFile.CARD_CLICK:
                fileName = "Card_Click";
                break;
            case AudioFile.CARD_GET:
                fileName = "Card_Set";
                break;
            case AudioFile.PROPHECY_GREAT_SUCCES:
                fileName = "Prophecy_Great_Success";
                break;
            case AudioFile.PROPHECY_SUCCES:
                fileName = "Prophecy_Great_Success";
                break;
            case AudioFile.DISASTER:
                fileName = "Disaster";
                break;
            case AudioFile.BATTLE_SCENE_FADE_IN:
                fileName = "Battle_Scene_Fade_In";
                break;
            case AudioFile.PROPHECY_SCENE_FADE_IN:
                fileName = "Prophecy_Scene_Fade_In";
                break;
            case AudioFile.DARK_PROPHECY_SCENE_FADE_IN:
                fileName = "Dark_Scene_Fade_In";
                break;
            case AudioFile.TARADE_CARD_SCENE_FADE_IN:
                fileName = "Trade_Card_Scene_Fade_In";
                break;
            case AudioFile.ALCHEMY_SCENE_FADE_IN:
                fileName = "Alchemy_Scene_Fade_In";
                break;
            case AudioFile.STAGE_DESIDE:
                fileName = "Stage_Deside";
                break;
            case AudioFile.STAGE_SELECT_ARROW:
                fileName = "Stage_Select_Arrow";
                break;
            case AudioFile.BONUS:
                fileName = "Bonus";
                break;
            case AudioFile.BONUS2:
                fileName = "Bonus2";
                break;
            case AudioFile.Boss_Defeat:
                fileName = "Boss_Defeat";
                break;
            default:
                fileName = null;
                break;
        }

        return AudioClipLoader.UnLoad("Sound/" + fileName);
    }
}