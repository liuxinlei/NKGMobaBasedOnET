//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年1月19日 10:56:54
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace ETModel
{
    /// <summary>
    /// 用于初始化行为树的结点,去执行那些只会执行一次的初始化操作
    /// 注意，里面的所有action只能是Action()，不能是Func这种
    /// 并且默认只能是加给自己的Buff
    /// </summary>
    [Title("用于初始化行为树", TitleAlignment = TitleAlignments.Centered)]
    public class NP_InitTreeAction: NP_ClassForStoreAction
    {
        [LabelText("初始化行为节点集合")]
        public List<NP_ClassForStoreAction> NpClassForStoreActions = new List<NP_ClassForStoreAction>();

        public override Action GetActionToBeDone()
        {
            foreach (var npClassForStoreAction in NpClassForStoreActions)
            {
                npClassForStoreAction.Unitid = this.Unitid;
                npClassForStoreAction.BelongtoRuntimeTree = this.BelongtoRuntimeTree;
            }

            this.Action = this.DoInit;
            return this.Action;
        }

        public void DoInit()
        {
            //Log.Info("准备执行初始化的行为操作");
            foreach (var classForStoreAction in NpClassForStoreActions)
            {
                classForStoreAction.GetActionToBeDone().Invoke();
            }

            this.BelongtoRuntimeTree.GetBlackboard().Set("HasInitTree", true);
        }
    }
}