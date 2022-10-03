using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor.Timeline.Actions;
using UnityEngine;

/// <summary>
/// 複数のGunをひとつのインスタンスかのように制御するためのコンポーネント
/// </summary>
public class GunSystem : MonoBehaviour
{

    [Tooltip("砲配列")]
    [SerializeField] List<Gun> _guns;
    [Tooltip("砲の射撃パターン")]
    [SerializeField] FireTimingMode _fireTimingMode;
    
    /// <summary>砲</summary>
    public Gun Gun { get => _guns.FirstOrDefault(); }
    /// <summary>砲弾</summary>
    public Bullet Bullet { get => Gun.Bullet; }
    /// <summary>砲身</summary>
    public Transform Barrel { get => Gun.Barrel; }
    /// <summary>砲口</summary>
    public Transform Muzzle { get => Gun.Muzzle; }
    /// <summary>砲の射撃パターン</summary>
    public FireTimingMode FireTimingMode { get => _fireTimingMode; set => _fireTimingMode = value; }



    /// <summary>砲弾の実体化から発射関数の呼び出しまでを行う</summary>
    /// <returns>発砲した砲弾群 失敗していたらnull</returns>
    public Bullet[] Fire()
    {
        if(_fireTimingMode == FireTimingMode.Coinstantaneous)
        {
            Bullet[] bullets = new Bullet[_guns.Count];
            for(int i = 0; i < _guns.Count; i++)
            {
                bullets[i] = _guns[i].Fire();
            }
            return bullets;
        }
        return null;
    }

    /// <summary>砲弾の切り替えを行う</summary>
    /// <param name="f"></param>
    public bool Change(float f)
    {
        return Gun.Change(f);
    }

    /// <summary>砲弾の選択を行う</summary>
    /// <param name="n"></param>
    public bool Choice(int n)
    {
        return Gun.Choice(n);
    }
}

public enum FireTimingMode
{
    /// <summary>同時</summary>
    Coinstantaneous,
    /// <summary>連続</summary>
    Concatenation,
}