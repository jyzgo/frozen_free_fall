﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1008

// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;

	

	/**
	 *  android 支付信息管理类
	 * 如果玩家联网，可以通过后台配置，来读取移动支付的类型
	 * 
	 * 
	 */ 
		public class MFPBillingAndroid
		{
	/*
			// Platform definitions
			static public string DIANXIN_ZIYOU = "DianXin_ZiYou";
			static public string DIANXIN_WAIFANG = "DianXin_WaiFang";
	
			static public string LIANTONG_ZIYOU = "LianTong_ZiYou";
	
			static public string YIDONG_MM_SHENHE = "YiDong_MM_ShenHe";
			static public string YIDONG_MM_ZIQIANMING = "YiDong_MM_ZiQianMing";
			static public string YIDONG_MDO = "YiDong_MDO";
			static public string YIDONG_JIDI = "YiDong_JiDi";
	*/	

		/**mobile mm */
		public const int MOBILE_MM = 1;
		
		/**mobile mdo */
		public const int MOBILE_MDO = 2;
		
		/**mobile game */
		public const int MOBILE_GAME = 3;
	
		static	public int defaultMobileWay = MOBILE_MM;

		
	
		// The reflected class of java api of CMBilling.jar
	#if UNITY_ANDROID && !UNITY_EDITOR
		private  AndroidJavaClass klass = new AndroidJavaClass("com.mfp.android.PayManager");	
	#endif
		// The instance of billing script.
		private static MFPBillingAndroid _instance;
		public static MFPBillingAndroid Instance
		{
			get
			{
				if(_instance==null)
				{
					_instance = new MFPBillingAndroid();
					_instance.setDefaultMobileWay();
				}
				return _instance;
			}
		}
	
		private void setDefaultMobileWay()
		{
			defaultMobileWay = MOBILE_MM;
#if YIDONG_MDO
			defaultMobileWay = MOBILE_MDO;
#elif YIDONG_JIDI
			defaultMobileWay = MOBILE_GAME;
#endif
		}


		/**
		 * 初始化 android 支付
		 * 具体根据运营商来决定初始化哪个支付的sdk ，在java 代码中处理；
		 * 非 移动的手机，参数设置成0;
		 * 移动的手机，根据后台参数来决定用哪个sdk；
		 * mobile way: 移动mm（1），mdo（2），游戏基地（3），其他（0）；
		 */ 
		public void init()
		{
			
			Debug.Log(" wenming MFPBillingAndroid init start,mobile way"+getMobileWay());

		#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					Debug.Log(" wenming MFPBillingAndroid 44444444444444444444");
					int mobileway = MOBILE_MM;
				   if(MFPDeviceAndroid.Instance.getProvider() == MFPDeviceAndroid.PROVIDER_MOBILE){
						mobileway = getMobileWay();
						klass.CallStatic("init", curActivity,mobileway.ToString());
					}else{
						mobileway = 0;

						klass.CallStatic("init", curActivity,mobileway.ToString());
					}

					Debug.Log(" wenming MFPBillingAndroid init end provider:"+MFPDeviceAndroid.Instance.getProvider().ToString()+",mobile way:"+mobileway);
				}
			}
		#endif
		}

		/**
		 * 获取移动支付的方式
		 * 移动MM：1
		 * MDO：2
		 * 游戏基地：3
		 */
		public int getMobileWay()
		{
#if YIDONG_JIDI
			return MOBILE_GAME;
#endif
		
			//如果没有联网，默认使用移动mm，否则请求后台，返回移动支付的类型
			int networkState = MFPDeviceAndroid.Instance.getNetWorkState();
			int notConnected = MFPDeviceAndroid.NETWORK_STATE_NOT_CONNECTED;
			int mobileway =	PlayerPrefs.GetInt("mm_type",defaultMobileWay);
			if (networkState == notConnected)
			{			
				return defaultMobileWay;
			} 
			else 
			{
				// 请求后台，返回 是哪种支付方式；
				if (mobileway == MOBILE_MM)
				{
					return MOBILE_MM;
				}
				else if (mobileway == MOBILE_MDO)
				{
					return MOBILE_MDO;
				}
				else
				{
					return MOBILE_GAME;
				}
			}
		
			return MOBILE_MM;	
		}

		/**
		 * 初始化结束
		 */ 
		public void initDone()
		{
				
		}

		/**
		 * 支付接口
		 * 具体根据运营商来决定初始化哪个支付的sdk ，在java 代码中处理；
	 * 1  2元  20钻
	 * 2  6元  65钻
	 * 3  10元 110钻
	 * 4  15元  170钻
		 */ 
		public void pay(string num)
		{
			Debug.Log(" wenming MFPBillingAndroid pay start");
		#if UNITY_ANDROID && !UNITY_EDITOR

		    klass.CallStatic( "pay",num, "IAPService", "onBillingResult");

		#endif
			Debug.Log(" wenming MFPBillingAndroid pay end num:"+num);
		}

	/**
     * Start SDK's exit UI.
     */
	public void ExitWithUI()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
			using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					if(getMobileWay() == MOBILE_GAME){// 移动游戏基地
						//klass.CallStatic("exit", curActivity);
					}
			}
		}
		#endif
	}

}



