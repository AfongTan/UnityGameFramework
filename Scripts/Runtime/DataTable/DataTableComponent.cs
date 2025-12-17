//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// Modified: DataTable Component - Luban Version
//------------------------------------------------------------

using System.IO;
using Luban;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 数据表组件（Luban 版本）
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Data Table")]
    public sealed class DataTableComponent : GameFrameworkComponent
    {
        /// <summary>
        /// 获取所有配置表
        /// </summary>
        public cfg.Tables Tables { get; private set; }

        /// <summary>
        /// 是否已初始化
        /// </summary>
        public bool IsInitialized => Tables != null;

        /// <summary>
        /// 游戏框架组件初始化
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        /// <summary>
        /// 初始化 Luban 配置表
        /// </summary>
        public void Initialize()
        {
            if (IsInitialized)
            {
                Log.Warning("Luban data tables already initialized.");
                return;
            }

            Tables = new cfg.Tables(LoadByteBuf);
            Log.Info("Luban data tables initialized successfully.");
        }

        /// <summary>
        /// 加载二进制配置文件
        /// </summary>
        private ByteBuf LoadByteBuf(string file)
        {
            string path = $"{Application.dataPath}/UnityGameFramework/GenerateDatas/bytes/{file}.bytes";
            return new ByteBuf(File.ReadAllBytes(path));
        }
    }
}
