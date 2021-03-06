//------------------------------------------------------------------------------
// <auto-generated>
// 社交功能 相关接口
// UI 显示和操作 调用唯一入口
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace AssemblyCSharp
{
		public class MFPSocialManager
		{


		//是否 打开360 登录， 联网，获取参数为ture 才打开
		public Boolean isOpen360SDK = false;

		private static MFPSocialManager _instance;
		public static MFPSocialManager Instance
		{
			get
			{
				if(_instance==null){
					_instance = new MFPSocialManager();
				}
				return _instance;
			}
		}


		/**
		 * 登录： 登录360 
		 */ 
		public void login()
		{
				
		}

		/**
		 * 得到某一个关卡  好友的名称
		 * 从 360 好友排行榜里面，获得某个级别的好友名字
		 */ 
		public String getFriendNameByLevel(String level)
		{

			return "friend" + level;
				
		}

		/**
		 * 得到某一个关卡好友列表，按照分数排好顺序的 ： name  score sn
		 * 1、先从360 获取游戏好友id 列表；
		 * 2、得到这些id 的关卡分数信息
		 * 3、按照关卡分数信息排序返回给 调用者使用
		 */ 
		public Array getFriendsByLevel(String level)
		{
			return null;
		}

		/**
		 * 从后台返回朋友 关卡信息；
		 */ 
		public Array getFriendsByBackend(String friendIds)
		{
			return null;
				
		}

		/**
		 * 更新 玩家 级别信息 ，调用360 接口
		 * 方便获取好友级别排行榜
		 */ 
		public void updateLevelData()
		{
				
		}

		/**
		 * 保存数据： 用户退出游戏时调用，把前端数据同步到后台
		 */ 
		public void saveData()
		{
		
		}


		}
}

